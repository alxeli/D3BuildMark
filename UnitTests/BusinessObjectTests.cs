using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessObjects;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class BusinessObjectTests
    {
        //User
        [TestMethod]
        public void TestUserDefaultConstructor()
        {
            User user = new User();

            string expected_name = null;

            Assert.AreEqual(expected_name, user.Name);
            Assert.IsNotNull(user.Profile);
        }
        [TestMethod]
        public void TestUserOverloadedConstructor()
        {
            User user = new User("test_user");

            string expected_name = "test_user";

            Assert.AreEqual(expected_name, user.Name);
            Assert.IsNotNull(user.Profile);
        }

        //Profile
        [TestMethod]
        public void TestProfileDefaultConstructor()
        {
            Profile profile = new Profile();

            string expected_battletag = null;

            Assert.AreEqual(expected_battletag, profile.BattleTag);
            Assert.IsNotNull(profile.Heroes);
        }
        [TestMethod]
        public void TestProfileOverloadedConstructor()
        {
            Profile profile = new Profile("butchiebags#1483");

            string expected_battletag = "butchiebags#1483";

            Assert.AreEqual(expected_battletag, profile.BattleTag);
            Assert.IsNotNull(profile.Heroes);
        }

        //Hero
        [TestMethod]
        public void TestHeroDefaultConstructor()
        {
            Hero hero = new Hero();

            string expected_name = null;
            string expected_class = null;

            Assert.AreEqual(expected_name, hero.Name);
            Assert.AreEqual(expected_class, hero.Class);
            Assert.IsNotNull(hero.BuildSnapshots);
        }
        [TestMethod]
        public void TestHeroOverloadedConstructor()
        {
            Hero hero = new Hero("Jondar", "Templar");

            string expected_name = "Jondar";
            string expected_class = "Templar";

            Assert.AreEqual(expected_name, hero.Name);
            Assert.AreEqual(expected_class, hero.Class);
            Assert.IsNotNull(hero.BuildSnapshots);
        }

        [TestMethod]
        public void TestApiManagerRetrieveProfileThatExists()
        {
            ApiManager manager = new ApiManager();
            Profile profile;
            
            Assert.AreEqual(true, manager.RetrieveProfile(out profile));
        }
        [TestMethod]
        public void TestApiManagerRetrieveProfileThatDoesNotExist()
        {
            ApiManager manager = new ApiManager();
            Profile profile;

            Assert.AreEqual(true, manager.RetrieveProfile(out profile));
        }
    }
}
