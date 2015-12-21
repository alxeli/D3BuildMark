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
            //TestCreateUserProfile();

            Console.Read();
        }
        static void TestCreateUserProfile()
        {
            DBManager db_manager = new DBManager();

            if(db_manager.CreateUser("butchiebags", "1234567", "butchiebags@gmail.com", "butchiebags#1483"))
            {
                Console.WriteLine("TestCreateUserProfile Succeeded");
            }
            else
            {
                Console.WriteLine("TestCreateUserProfile Failed");
            }
        }
        static void TestDisplayRetrieveProfile()
        {
            ApiManager api_manager = ApiManager.GetInstance();
            Profile test_profile = new Profile(BATTLETAG);

            api_manager.RetrieveProfile(ref test_profile);
            
            Console.WriteLine(test_profile.BattleTag + "\n");
            foreach (Hero h in test_profile.Heroes)
            {
                Console.WriteLine("{0}, {1}", h.Class, h.Name);
            }
        }
    }
}