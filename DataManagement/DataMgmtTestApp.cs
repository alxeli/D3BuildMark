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
        const string GUID = "4647775C-3D5D-4391-AF90-B2314460F86E";

        static void Main(string[] args)
        {
            //TestDisplayRetrieveProfile();
            //TestCreateUserProfile();
            //TestCreateHero();
            //TestRetrieveHeroBuild();
            TestStoreHeroBuild();
            Console.Read();
        }
        static void TestCreateUserProfile()
        {
            DBManager db_manager = new DBManager();

            User user = new User("butchiebags");
            user.GUID = new Guid(GUID);

            if (db_manager.CreateUser(user))
            {
                Console.WriteLine("TestCreateUserProfile Succeeded");
            }
            else
            {
                Console.WriteLine("TestCreateUserProfile Failed");
            }
        }
        static void TestCreateHero()
        {
            DBManager db_manager = new DBManager();

            User user = new User(new Guid(GUID), "butchiebags");
            user.Profile.Heroes.Add(new Hero("Timmons", "Monk"));

            if (db_manager.CreateHero(user, user.Profile.Heroes[0]))
            {
                Console.WriteLine("TestCreateHero Succeeded");
            }
            else
            {
                Console.WriteLine("TestCreateHero Failed");
            }
        }
        static void TestRetrieveHeroBuild()
        {
            ApiManager api_manager = ApiManager.GetInstance();
            User user = new User(new Guid(GUID), "butchiebags");
            user.Profile = new Profile(BATTLETAG);
            Hero hero = new Hero("Timmons", "Monk");
            BuildSnapshot snapshot = new BuildSnapshot();

            api_manager.RetrieveHeroBuild(user, hero, ref snapshot);

            Console.Read();
        }
        static void TestStoreHeroBuild()
        {
            ApiManager api_manager = ApiManager.GetInstance();
            DBManager db_manager = new DBManager();
            User user = new User(new Guid(GUID), "butchiebags");
            user.Profile = new Profile(BATTLETAG);
            Hero hero = new Hero("Timmons", "Monk");
            BuildSnapshot snapshot = new BuildSnapshot("Wave of Fire");

            api_manager.RetrieveHeroBuild(user, hero, ref snapshot);
            db_manager.CreateBuildSnapshot(user, hero, snapshot);

            Console.Read();
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