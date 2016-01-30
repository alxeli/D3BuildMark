using System;
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

        //
        public bool RetrieveProfile(ref Profile profile)
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
                        profile.Heroes.Add(new Hero(hs.Name, hs.HeroClass.ToString()));
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

        public bool RetrieveHeroBuild(User user, Hero hero, ref BuildSnapshot snapshot)
        {
            try
            {
                //ZTn.BNet.BattleNet.BattleTag tag = new ZTn.BNet.BattleNet.BattleTag()
                Career career = null;

                lock (_api_sync)
                {
                    //API Career retrieval
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
                            t_hero = ZTn.BNet.D3.Heroes.Hero.CreateFromHeroId(new ZTn.BNet.BattleNet.BattleTag(user.Profile.BattleTag), t_sum.Id);
                        }
                    }

                    //add all item information
                    snapshot.Items["Head"] = new BusinessObjects.Item(t_hero.Items.Head.Name, ZTn.BNet.D3.Items.Item.CreateFromTooltipParams(t_hero.Items.Head.TooltipParams).Attributes);
                    snapshot.Items["Neck"] = new BusinessObjects.Item(t_hero.Items.Neck.Name, ZTn.BNet.D3.Items.Item.CreateFromTooltipParams(t_hero.Items.Neck.TooltipParams).Attributes);
                    snapshot.Items["Shoulders"] = new BusinessObjects.Item(t_hero.Items.Shoulders.Name, ZTn.BNet.D3.Items.Item.CreateFromTooltipParams(t_hero.Items.Shoulders.TooltipParams).Attributes);
                    snapshot.Items["Gloves"] = new BusinessObjects.Item(t_hero.Items.Hands.Name, ZTn.BNet.D3.Items.Item.CreateFromTooltipParams(t_hero.Items.Hands.TooltipParams).Attributes);
                    snapshot.Items["Chest"] = new BusinessObjects.Item(t_hero.Items.Torso.Name, ZTn.BNet.D3.Items.Item.CreateFromTooltipParams(t_hero.Items.Torso.TooltipParams).Attributes);
                    snapshot.Items["Bracers"] = new BusinessObjects.Item(t_hero.Items.Bracers.Name, ZTn.BNet.D3.Items.Item.CreateFromTooltipParams(t_hero.Items.Bracers.TooltipParams).Attributes);
                    snapshot.Items["Belt"] = new BusinessObjects.Item(t_hero.Items.Waist.Name, ZTn.BNet.D3.Items.Item.CreateFromTooltipParams(t_hero.Items.Waist.TooltipParams).Attributes);
                    snapshot.Items["LeftRing"] = new BusinessObjects.Item(t_hero.Items.LeftFinger.Name, ZTn.BNet.D3.Items.Item.CreateFromTooltipParams(t_hero.Items.LeftFinger.TooltipParams).Attributes);
                    snapshot.Items["RightRing"] = new BusinessObjects.Item(t_hero.Items.RightFinger.Name, ZTn.BNet.D3.Items.Item.CreateFromTooltipParams(t_hero.Items.RightFinger.TooltipParams).Attributes);
                    snapshot.Items["Pants"] = new BusinessObjects.Item(t_hero.Items.Legs.Name, ZTn.BNet.D3.Items.Item.CreateFromTooltipParams(t_hero.Items.Legs.TooltipParams).Attributes);
                    snapshot.Items["Boots"] = new BusinessObjects.Item(t_hero.Items.Feet.Name, ZTn.BNet.D3.Items.Item.CreateFromTooltipParams(t_hero.Items.Feet.TooltipParams).Attributes);
                    snapshot.Items["LeftHand"] = new BusinessObjects.Item(t_hero.Items.MainHand.Name, ZTn.BNet.D3.Items.Item.CreateFromTooltipParams(t_hero.Items.MainHand.TooltipParams).Attributes);
                    if (t_hero.Items.OffHand != null)
                        snapshot.Items["RightHand"] = new BusinessObjects.Item(t_hero.Items.OffHand.Name, ZTn.BNet.D3.Items.Item.CreateFromTooltipParams(t_hero.Items.OffHand.TooltipParams).Attributes);
                    else
                        snapshot.Items["RightHand"] = new BusinessObjects.Item("empty");
                    //Add all active skills
                    snapshot.Skills[0] = new BusinessObjects.Skill(t_hero.Skills.Active[0].Skill.Name + ": " + t_hero.Skills.Active[0].Rune.Name, t_hero.Skills.Active[0].Rune.Description);
                    snapshot.Skills[1] = new BusinessObjects.Skill(t_hero.Skills.Active[1].Skill.Name + ": " + t_hero.Skills.Active[1].Rune.Name, t_hero.Skills.Active[1].Rune.Description);
                    snapshot.Skills[2] = new BusinessObjects.Skill(t_hero.Skills.Active[2].Skill.Name + ": " + t_hero.Skills.Active[2].Rune.Name, t_hero.Skills.Active[2].Rune.Description);
                    snapshot.Skills[3] = new BusinessObjects.Skill(t_hero.Skills.Active[3].Skill.Name + ": " + t_hero.Skills.Active[3].Rune.Name, t_hero.Skills.Active[3].Rune.Description);
                    snapshot.Skills[4] = new BusinessObjects.Skill(t_hero.Skills.Active[4].Skill.Name + ": " + t_hero.Skills.Active[4].Rune.Name, t_hero.Skills.Active[4].Rune.Description);
                    snapshot.Skills[5] = new BusinessObjects.Skill(t_hero.Skills.Active[5].Skill.Name + ": " + t_hero.Skills.Active[5].Rune.Name, t_hero.Skills.Active[5].Rune.Description);

                    //Add all passive skills
                    snapshot.Skills[6] = new BusinessObjects.Skill(t_hero.Skills.Passive[0].Skill.Name, t_hero.Skills.Passive[0].Skill.Description);
                    snapshot.Skills[7] = new BusinessObjects.Skill(t_hero.Skills.Passive[1].Skill.Name, t_hero.Skills.Passive[1].Skill.Description);
                    snapshot.Skills[8] = new BusinessObjects.Skill(t_hero.Skills.Passive[2].Skill.Name, t_hero.Skills.Passive[2].Skill.Description);
                    snapshot.Skills[9] = new BusinessObjects.Skill(t_hero.Skills.Passive[3].Skill.Name, t_hero.Skills.Passive[3].Skill.Description);
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
    }
}
