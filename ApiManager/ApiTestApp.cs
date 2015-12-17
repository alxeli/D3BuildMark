using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataManagement
{
    class ApiTestApp
    {
        const string BATTLETAG = "butchiebags#1483";

        static void Main(string[] args)
        {
            TestDisplayRetrieveProfile();

            Console.Read();
        }
        static void TestDisplayRetrieveProfile()
        {
            //ApiManager manager = new ApiManager();
            Profile test_profile = new Profile(BATTLETAG);

            ApiManager.RetrieveProfile(ref test_profile);
            
            Console.WriteLine(test_profile.BattleTag + "\n");
            foreach (Hero h in test_profile.Heroes)
            {
                Console.WriteLine("{0}, {1}", h.Class, h.Name);
            }
        }
    }
}