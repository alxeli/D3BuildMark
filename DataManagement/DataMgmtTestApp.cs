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
        //const string USERNAME = "hannah92";
        //const string BATTLETAG = "Hannah92#1641";
        //const string HERONAME = "Riftbanga";
        //const string BUILDNAME = "Heal Monk S3";
        //const string GUID = "82994855-28B2-433A-A6AA-E94CE48BCA89";
        const string USERNAME = "butchiebags";
        const string BATTLETAG = "butchiebags#1483";
        const string HERONAME = "Timmons";
        const string BUILDNAME = "Wave of Fire";
        const string GUID = "82994855-28B2-433A-A6AA-E94CE48BCA89";

        static void Main(string[] args)
        {
            //API
            //TestDisplayRetrieveProfile();
            //TestRetrieveHeroBuild();


            //PERSISTENT CREATE
            //TestCreateUser();
            //TestCreateProfile();
            //TestCreateHero();
            //TestStoreHeroBuild();
            //TestItemTwoStringCtor();

            //PERSISTENT READ
            //

            Console.Write("Done");
            Console.Read();
        }
        static void TestItemTwoStringCtor()
        {
            AC_Item item = new AC_Item("test", "Primary:\n+851 Dexterity\n+126 Resistance to All Elements\nRegenerates 9834 Life per Second\n\nSecondary:\n+34 % Extra Gold from Monsters\n Increase the effect of any gem socketed into this item by 95 %. \n\nPassive: ");
        }

        static void TestDisplayRetrieveProfile()
        {
            ApiManager api_manager = ApiManager.GetInstance();
            AC_Profile test_profile = new AC_Profile(BATTLETAG);

            api_manager.RetrieveProfile(ref test_profile);

            Console.WriteLine(test_profile.BattleTag + "\n");
            foreach (AC_Hero h in test_profile.Heroes)
            {
                Console.WriteLine("{0}, {1}", h.Class, h.Name);
            }
        }
        static void TestRetrieveHeroBuild()
        {
            ApiManager api_manager = ApiManager.GetInstance();
            AC_User user = new AC_User(new Guid(GUID), USERNAME);
            user.Profile = new AC_Profile(BATTLETAG);
            AC_Hero hero = new AC_Hero(HERONAME, "Monk");
            AC_BuildSnapshot snapshot = new AC_BuildSnapshot();

            api_manager.RetrieveHeroBuild(user, hero, ref snapshot);

            Console.Read();
        }

        static void TestCreateUser()
        {
            DBManager db_manager = new DBManager();

            AC_User user = new AC_User(USERNAME);
            user.GUID = new Guid(GUID);

            Console.WriteLine("Test CreateUserProfile " + db_manager.CreateUser(user));
        }
        static void TestCreateProfile()
        {
            DBManager db_manager = new DBManager();

            AC_User user = new AC_User(USERNAME, BATTLETAG);
            user.GUID = new Guid(GUID);

            Console.WriteLine("Test CreateUserProfile " + db_manager.CreateProfile(user));
        }
        static void TestCreateHero()
        {
            DBManager db_manager = new DBManager();

            AC_User user = new AC_User(new Guid(GUID), USERNAME);
            user.Profile.Heroes.Add(new AC_Hero(HERONAME, "Monk"));

            Console.WriteLine("Test CreateHero " + db_manager.CreateHero(user, user.Profile.Heroes[0]));
        }
        static void TestStoreHeroBuild()
        {
            ApiManager api_manager = ApiManager.GetInstance();
            DBManager db_manager = new DBManager();
            AC_User user = new AC_User(new Guid(GUID), USERNAME);
            user.Profile = new AC_Profile(BATTLETAG);
            AC_Hero hero = new AC_Hero(HERONAME, "Monk");
            AC_BuildSnapshot snapshot = new AC_BuildSnapshot(BUILDNAME);

            Console.WriteLine("Test API RetrieveHeroBuild " + api_manager.RetrieveHeroBuild(user, hero, ref snapshot));
            Console.WriteLine("Test DB CreateBuildSnapshot " + db_manager.CreateBuildSnapshot(user, hero, snapshot));
        }
    }
}