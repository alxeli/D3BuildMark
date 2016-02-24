using System;
using System.IO;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using ZTn.BNet.D3;
using ZTn.BNet.D3.Artisans;
using ZTn.BNet.D3.Calculator;
using ZTn.BNet.D3.Calculator.Gems;
using ZTn.BNet.D3.Calculator.Helpers;
using ZTn.BNet.D3.Careers;
using ZTn.BNet.D3.DataProviders;
using ZTn.BNet.D3.Helpers;
//using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.HeroFollowers;
using ZTn.BNet.D3.Items;
using ZTn.BNet.D3.Progresses;
using ZTn.BNet.D3.Skills;
using ZTn.Bnet.Portable;
using ZTn.Bnet.Portable.Windows;

namespace DataManagement
{
    public class ApiManager
    {
        private static ApiManager _instance = null;
        private static object _lock = new object();
        private object _api_sync = new object();

        //my api key for the battle.net api
        private const string API_KEY = "gsy79dc8h2qjpy82k23kb5htysmyrw6w";

        private ApiManager()
        {
            RegisterPcl.Register();
            
            //D3Api.DataProvider = new CacheableDataProvider(new HttpRequestDataProvider());
            D3Api.DataProvider = new HttpRequestDataProvider();
            D3Api.ApiKey = API_KEY;
        }

        public static ApiManager GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new ApiManager();
                    }
                }
            }
            return _instance;
        }
        
        public bool BattletagExists(string battletag)
        {
            if(battletag == null || battletag.Length < 5)
            {
                return false;
            }

            try
            {
                if (Career.CreateFromBattleTag(new ZTn.BNet.BattleNet.BattleTag(battletag)) == null)
                {
                    return false;
                }
            }
            catch(ArgumentException)
            {
                return false;
            }

            return true;
        }
        public bool RetrieveProfile(ref AC_Profile profile)
        {
            try
            {
                Career career = null;

                lock (_api_sync)
                {
                    //API Career retrieval
                    career = Career.CreateFromBattleTag(new ZTn.BNet.BattleNet.BattleTag(profile.BattleTag));
                }

                //clear existing profile heroes to eliminate duplicates
                profile.Heroes.Clear();

                if (career != null)
                {
                    foreach (ZTn.BNet.D3.Heroes.HeroSummary hs in career.Heroes)
                    {
                        profile.Heroes.Add(new AC_Hero(hs.Name, hs.HeroClass.ToString()));
                    }
                }
            }
            catch (FileNotInCacheException)
            {
                return false;
            }
            catch (BNetResponseFailedException)
            {
                return false;
            }
            catch (BNetFailureObjectReturnedException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            return true;
        }

        public bool RetrieveAllHeroes(AC_Profile profile, ref List<AC_Hero> heroes)
        {
            if(profile == null || profile.BattleTag == null)
            {
                return false;
            }

            try
            {
                Career career = null;

                lock (_api_sync)
                {
                    career = Career.CreateFromBattleTag(new ZTn.BNet.BattleNet.BattleTag(profile.BattleTag));
                }

                if(career != null)
                {
                    foreach (ZTn.BNet.D3.Heroes.HeroSummary t_sum in career.Heroes)
                    {
                        heroes.Add(new AC_Hero(t_sum.Name, t_sum.HeroClass.ToString()));
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (FileNotInCacheException e)
            {
                throw e;
            }
            catch (BNetResponseFailedException e)
            {
                throw e;
            }
            catch (BNetFailureObjectReturnedException e)
            {
                throw e;
            }
            catch (ArgumentException e)
            {
                throw e;
            }
            
            return true;
        }

        public bool RetrieveHeroBuild(AC_User user, AC_Hero hero, ref AC_BuildSnapshot snapshot)
        {
            try
            {
                Career career = null;

                lock (_api_sync)
                {
                    career = Career.CreateFromBattleTag(new ZTn.BNet.BattleNet.BattleTag(user.Profile.BattleTag));
                }
                
                if (career != null)
                {
                    ZTn.BNet.D3.Heroes.Hero t_hero = null;

                    //Retrieve the full Hero via API
                    foreach (ZTn.BNet.D3.Heroes.HeroSummary t_sum in career.Heroes)
                    {
                        if(t_sum.Name == hero.Name)
                        {
                            lock (_api_sync)
                            {
                                t_hero = ZTn.BNet.D3.Heroes.Hero.CreateFromHeroId(new ZTn.BNet.BattleNet.BattleTag(user.Profile.BattleTag), t_sum.Id);
                            }
                        }
                    }

                    snapshot.BuildMark = new AC_BuildMark(t_hero.Stats, t_hero.HeroClass.ToString());

                    //set battletag in snapshot
                    snapshot.Battletag = career.BattleTag.ToString();

                    //add all item information
                    snapshot.Items["Head"] = RetrieveItem(t_hero.Items.Head);
                    snapshot.Items["Neck"] = RetrieveItem(t_hero.Items.Neck);
                    snapshot.Items["Shoulders"] = RetrieveItem(t_hero.Items.Shoulders);
                    snapshot.Items["Gloves"] = RetrieveItem(t_hero.Items.Hands);
                    snapshot.Items["Chest"] = RetrieveItem(t_hero.Items.Torso);
                    snapshot.Items["Bracers"] = RetrieveItem(t_hero.Items.Bracers);
                    snapshot.Items["Belt"] = RetrieveItem(t_hero.Items.Waist);
                    snapshot.Items["LeftRing"] = RetrieveItem(t_hero.Items.LeftFinger);
                    snapshot.Items["RightRing"] = RetrieveItem(t_hero.Items.RightFinger);
                    snapshot.Items["Pants"] = RetrieveItem(t_hero.Items.Legs);
                    snapshot.Items["Boots"] = RetrieveItem(t_hero.Items.Feet);
                    snapshot.Items["LeftHand"] = RetrieveItem(t_hero.Items.MainHand);
                    snapshot.Items["RightHand"] = RetrieveItem(t_hero.Items.OffHand);

                    snapshot.Skills = RetrieveSkills(t_hero.Skills);

                    ////Add all active skills
                    //snapshot.Skills[0] = new AC_Skill(t_hero.Skills.Active[0].Skill.Name + ": " + t_hero.Skills.Active[0].Rune.Name, t_hero.Skills.Active[0].Rune.Description);
                    //snapshot.Skills[1] = new AC_Skill(t_hero.Skills.Active[1].Skill.Name + ": " + t_hero.Skills.Active[1].Rune.Name, t_hero.Skills.Active[1].Rune.Description);
                    //snapshot.Skills[2] = new AC_Skill(t_hero.Skills.Active[2].Skill.Name + ": " + t_hero.Skills.Active[2].Rune.Name, t_hero.Skills.Active[2].Rune.Description);
                    //snapshot.Skills[3] = new AC_Skill(t_hero.Skills.Active[3].Skill.Name + ": " + t_hero.Skills.Active[3].Rune.Name, t_hero.Skills.Active[3].Rune.Description);
                    //snapshot.Skills[4] = new AC_Skill(t_hero.Skills.Active[4].Skill.Name + ": " + t_hero.Skills.Active[4].Rune.Name, t_hero.Skills.Active[4].Rune.Description);
                    //snapshot.Skills[5] = new AC_Skill(t_hero.Skills.Active[5].Skill.Name + ": " + t_hero.Skills.Active[5].Rune.Name, t_hero.Skills.Active[5].Rune.Description);

                    ////Add all passive skills
                    //snapshot.Skills[6] = new AC_Skill(t_hero.Skills.Passive[0].Skill.Name, t_hero.Skills.Passive[0].Skill.Description);
                    //snapshot.Skills[7] = new AC_Skill(t_hero.Skills.Passive[1].Skill.Name, t_hero.Skills.Passive[1].Skill.Description);
                    //snapshot.Skills[8] = new AC_Skill(t_hero.Skills.Passive[2].Skill.Name, t_hero.Skills.Passive[2].Skill.Description);
                    //snapshot.Skills[9] = new AC_Skill(t_hero.Skills.Passive[3].Skill.Name, t_hero.Skills.Passive[3].Skill.Description);
                }
            }
            catch (FileNotInCacheException e)
            {
                throw e;
            }
            catch (BNetResponseFailedException e)
            {
                throw e;
            }
            catch (BNetFailureObjectReturnedException e)
            {
                throw e;
            }
            catch (ArgumentException e)
            {
                throw e;
            }

            return true;
        }
        private AC_Item RetrieveItem(ZTn.BNet.D3.Items.ItemSummary item)
        {
            AC_Item t_item = null;

            if(item != null)
            {
                lock (_api_sync)
                {
                    t_item = new AC_Item(item.Name, ZTn.BNet.D3.Items.Item.CreateFromTooltipParams(item.TooltipParams).Attributes);
                    t_item.Image = D3Api.GetItemIcon(item.Icon, "large").Bytes;

                    //if(!File.Exists("~/Images/" + item.Name))
                    //{
                        
                    //}
                }
            }
            else
            {
                t_item = new AC_Item("Empty");
            }

            return t_item;
        }
        private AC_Skill[] RetrieveSkills(ZTn.BNet.D3.Heroes.HeroSkills hero_skills)
        {
            AC_Skill[] t_skills = new AC_Skill[10];

            for (int i = 0; i < 10; i++)
            {
                if(i < 6)
                {
                    if (hero_skills.Active[i].Skill != null && hero_skills.Active[i].Rune != null)
                    {
                        t_skills[i] = new AC_Skill(hero_skills.Active[i].Skill.Name + ": " + hero_skills.Active[i].Rune.Name, hero_skills.Active[i].Rune.Description);
                    }
                    else
                    {
                        t_skills[i] = new AC_Skill("Empty", "Empty");
                    }
                }
                else if (i < 10)
                {
                    if (hero_skills.Passive[i - 6].Skill != null && hero_skills.Passive[i - 6].Skill.Description != null)
                    {
                        t_skills[i] = new AC_Skill(hero_skills.Passive[i - 6].Skill.Name, hero_skills.Passive[i - 6].Skill.Description);
                    }
                    else
                    {
                        t_skills[i] = new AC_Skill("Empty", "Empty");
                    }
                }
            }

            return t_skills;
        }
    }
}
