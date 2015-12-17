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
    public static class ApiManager
    {
        //my api key for the battle.net api
        private const string API_KEY = "gsy79dc8h2qjpy82k23kb5htysmyrw6w";

        static ApiManager()
        {
            RegisterPcl.Register();
            D3Api.DataProvider = new CacheableDataProvider(new HttpRequestDataProvider());
            D3Api.ApiKey = API_KEY;
        }

        public static bool RetrieveProfile(ref Profile profile)
        {
            try
            {
                //API Career retrieval
                Career career = Career.CreateFromBattleTag(new ZTn.BNet.BattleNet.BattleTag(profile.BattleTag));

                //clear existing profile heroes to eliminate duplicates
                profile.Heroes.Clear();

                foreach (ZTn.BNet.D3.Heroes.HeroSummary hs in career.Heroes)
                {
                    profile.Heroes.Add(new Hero(hs.Name, hs.HeroClass.ToString()));
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
