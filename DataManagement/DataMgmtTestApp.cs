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
        //stay consistent with these consts in default.aspx.cs
        const string BATTLETAG = "butchiebags#1483";
        const string GUID = "7ABF093B-19C6-42EC-94CE-5E1907F3B3AF";

        static void Main(string[] args)
        {
            //API
            //TestDisplayRetrieveProfile();
            //TestRetrieveHeroBuild();


            //PERSISTENT CREATE
            //TestCreateUserProfile();
            //TestCreateHero();
            //TestStoreHeroBuild();

            //PERSISTENT READ
            //

            Console.Write("Done");
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

        static void TestCreateUserProfile()
        {
            DBManager db_manager = new DBManager();

            User user = new User("butchiebags");
            user.GUID = new Guid(GUID);

            Console.WriteLine("Test CreateUserProfile " + db_manager.CreateUser(user));
        }
        static void TestCreateHero()
        {
            DBManager db_manager = new DBManager();

            User user = new User(new Guid(GUID), "butchiebags");
            user.Profile.Heroes.Add(new Hero("Timmons", "Monk"));

            Console.WriteLine("Test CreateHero " + db_manager.CreateHero(user, user.Profile.Heroes[0]));
        }
        static void TestStoreHeroBuild()
        {
            ApiManager api_manager = ApiManager.GetInstance();
            DBManager db_manager = new DBManager();
            User user = new User(new Guid(GUID), "butchiebags");
            user.Profile = new Profile(BATTLETAG);
            Hero hero = new Hero("Timmons", "Monk");
            BuildSnapshot snapshot = new BuildSnapshot("Wave of Fire");

            Console.WriteLine("Test API RetrieveHeroBuild " + api_manager.RetrieveHeroBuild(user, hero, ref snapshot));
            Console.WriteLine("Test DB CreateBuildSnapshot " + db_manager.CreateBuildSnapshot(user, hero, snapshot));
        }
    }
}