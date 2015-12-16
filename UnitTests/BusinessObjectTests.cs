using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessObjects;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class BusinessObjectTests
    {
        //Item
        [TestMethod]
        public void TestItemDefaultConstructor()
        {
            string expected_name = null;
            Item item = new Item();
            
            Assert.AreEqual(expected_name, item.Name);
            Assert.IsNotNull(item.Attributes);
        }
        [TestMethod]
        public void TestItemOverloadedConstructor()
        {
            string expected_name = "Shenlongs Relentless Assault";
            List<string> expected_attributes = new List<string>();
            expected_attributes.Add("+1556-1931 Damage");
            expected_attributes.Add("+867 Dexterity");
            expected_attributes.Add("+954 Vitality");
            expected_attributes.Add("+21825 Life per Hit");
            expected_attributes.Add("+15 Maximum Spirit(Monk Only)");
            expected_attributes.Add("2.2% Chance to Freeze on Hit");
            expected_attributes.Add("Critical Hit Damage Increaded by 130.0%");
            
            Item item = new Item("Shenlongs Relentless Assault", expected_attributes);


            Assert.AreEqual(expected_name, item.Name);
            Assert.AreEqual(expected_attributes, item.Attributes);
        }

        //Skill
        public void TestSkillDefaultConstructor()
        {
            string expected_name = null;
            string expected_description = null;

            Skill skill = new Skill();

            Assert.AreEqual(expected_name, skill.Name);
            Assert.AreEqual(expected_description, skill.Description);
        }
        [TestMethod]
        public void TestSkillOverloadedConstructor()
        {
            string expected_name = "Epiphany - Desert Shroud";
            string expected_description = "Infuse yourself with sand, reducing damage taken by 50%";

            Skill skill = new Skill(expected_name, expected_description);

            Assert.AreEqual(expected_name, skill.Name);
            Assert.AreEqual(expected_description, skill.Description);
        }

        //BuildSnapshot

        //BuildMark

        //Hero
        [TestMethod]
        public void TestHeroDefaultConstructor()
        {
            string expected_name = null;
            string expected_class = null;

            Hero hero = new Hero();
            
            Assert.AreEqual(expected_name, hero.Name);
            Assert.AreEqual(expected_class, hero.Class);
            Assert.IsNotNull(hero.BuildSnapshots);
        }
        [TestMethod]
        public void TestHeroOverloadedConstructor()
        {
            string expected_name = "Jondar";
            string expected_class = "Templar";

            Hero hero = new Hero("Jondar", "Templar");
            
            Assert.AreEqual(expected_name, hero.Name);
            Assert.AreEqual(expected_class, hero.Class);
            Assert.IsNotNull(hero.BuildSnapshots);
        }

        //Profile
        [TestMethod]
        public void TestProfileDefaultConstructor()
        {
            string expected_battletag = null;

            Profile profile = new Profile();

            Assert.AreEqual(expected_battletag, profile.BattleTag);
            Assert.IsNotNull(profile.Heroes);
        }
        [TestMethod]
        public void TestProfileOverloadedConstructor()
        {
            string expected_battletag = "butchiebags#1483";

            Profile profile = new Profile("butchiebags#1483");

            Assert.AreEqual(expected_battletag, profile.BattleTag);
            Assert.IsNotNull(profile.Heroes);
        }

        //User
        [TestMethod]
        public void TestUserDefaultConstructor()
        {
            string expected_name = null;

            User user = new User();

            Assert.AreEqual(expected_name, user.Name);
            Assert.IsNotNull(user.Profile);
        }
        [TestMethod]
        public void TestUserOverloadedConstructor()
        {
            string expected_name = "test_user";

            User user = new User("test_user");

            Assert.AreEqual(expected_name, user.Name);
            Assert.IsNotNull(user.Profile);
        }
    }
}
