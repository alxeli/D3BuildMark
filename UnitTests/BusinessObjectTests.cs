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
        [TestMethod]
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
        [TestMethod]
        public void TestBuildSnapshotDefaultConstructor()
        {
            string expected_name = null;
            Dictionary<string, Item> expected_items = new Dictionary<string, Item>();
            expected_items.Add("Head", null);
            expected_items.Add("Neck", null);
            expected_items.Add("Shoulders", null);
            expected_items.Add("Gloves", null);
            expected_items.Add("Chest", null);
            expected_items.Add("Bracers", null);
            expected_items.Add("Belt", null);
            expected_items.Add("LeftRing", null);
            expected_items.Add("RightRing", null);
            expected_items.Add("Pants", null);
            expected_items.Add("Boots", null);
            expected_items.Add("LeftHand", null);
            expected_items.Add("RightHand", null);
            Skill[] expected_skills = new Skill[10];

            BuildSnapshot buildsnapshot = new BuildSnapshot();

            Assert.AreEqual(expected_name, buildsnapshot.Name);
            Assert.IsNotNull(buildsnapshot.BuildMark);
            Assert.IsNull(buildsnapshot.Items["Head"]);
            Assert.IsNull(buildsnapshot.Items["Neck"]);
            Assert.IsNull(buildsnapshot.Items["Shoulders"]);
            Assert.IsNull(buildsnapshot.Items["Gloves"]);
            Assert.IsNull(buildsnapshot.Items["Chest"]);
            Assert.IsNull(buildsnapshot.Items["Bracers"]);
            Assert.IsNull(buildsnapshot.Items["Belt"]);
            Assert.IsNull(buildsnapshot.Items["LeftRing"]);
            Assert.IsNull(buildsnapshot.Items["RightRing"]);
            Assert.IsNull(buildsnapshot.Items["Pants"]);
            Assert.IsNull(buildsnapshot.Items["Boots"]);
            Assert.IsNull(buildsnapshot.Items["LeftHand"]);
            Assert.IsNull(buildsnapshot.Items["RightHand"]);
            foreach (Skill skill in buildsnapshot.Skills)
            {
                Assert.IsNotNull(skill);
            }
        }
        [TestMethod]
        public void TestBuildSnapshotOverloadedConstructor()
        {
            string expected_name = "Holy EP Speed Ulianas";
            Dictionary<string, Item> expected_items = new Dictionary<string, Item>();
            expected_items.Add("Head", null);
            expected_items.Add("Neck", null);
            expected_items.Add("Shoulders", null);
            expected_items.Add("Gloves", null);
            expected_items.Add("Chest", null);
            expected_items.Add("Bracers", null);
            expected_items.Add("Belt", null);
            expected_items.Add("LeftRing", null);
            expected_items.Add("RightRing", null);
            expected_items.Add("Pants", null);
            expected_items.Add("Boots", null);
            expected_items.Add("LeftHand", null);
            expected_items.Add("RightHand", null);
            Skill[] expected_skills = new Skill[10];

            BuildSnapshot buildsnapshot = new BuildSnapshot(expected_name);

            Assert.AreEqual(expected_name, buildsnapshot.Name);
            Assert.IsNotNull(buildsnapshot.BuildMark);
            Assert.IsNull(buildsnapshot.Items["Head"]);
            Assert.IsNull(buildsnapshot.Items["Neck"]);
            Assert.IsNull(buildsnapshot.Items["Shoulders"]);
            Assert.IsNull(buildsnapshot.Items["Gloves"]);
            Assert.IsNull(buildsnapshot.Items["Chest"]);
            Assert.IsNull(buildsnapshot.Items["Bracers"]);
            Assert.IsNull(buildsnapshot.Items["Belt"]);
            Assert.IsNull(buildsnapshot.Items["LeftRing"]);
            Assert.IsNull(buildsnapshot.Items["RightRing"]);
            Assert.IsNull(buildsnapshot.Items["Pants"]);
            Assert.IsNull(buildsnapshot.Items["Boots"]);
            Assert.IsNull(buildsnapshot.Items["LeftHand"]);
            Assert.IsNull(buildsnapshot.Items["RightHand"]);
            foreach (Skill skill in buildsnapshot.Skills)
            {
                Assert.IsNotNull(skill);
            }
        }

        //BuildMark
        [TestMethod]
        public void TestBuildMarkDefaultConstructor()
        {
            string expected_score = null;
            string expected_damage = null;
            string expected_toughness = null;
            string expected_recovery = null;
            bool expected_is_calculated = false;
            DateTime expected_date_last_calculated = new DateTime(2015, 12, 14, 15, 49, 15, DateTimeKind.Local);

            BuildMark buildmark = new BuildMark();

            Assert.AreEqual(expected_score, buildmark.Score);
            Assert.AreEqual(expected_damage, buildmark.Damage);
            Assert.AreEqual(expected_toughness, buildmark.Toughness);
            Assert.AreEqual(expected_recovery, buildmark.Recovery);
            Assert.AreEqual(expected_is_calculated, buildmark.isCalculated);
            Assert.AreEqual(expected_date_last_calculated, buildmark.DateLastCalculated);
        }
        [TestMethod]
        public void TestBuildMarkOverloadedConstructor()
        {
            string expected_score = null;
            string expected_damage = "1,200,000";
            string expected_toughness = "65,000,000";
            string expected_recovery = "2,500,000";
            bool expected_is_calculated = false;
            DateTime expected_date_last_calculated = new DateTime(2015, 12, 14, 15, 49, 15, DateTimeKind.Local);

            BuildMark buildmark = new BuildMark(expected_damage, expected_toughness, expected_recovery);

            Assert.AreEqual(expected_score, buildmark.Score);
            Assert.AreEqual(expected_damage, buildmark.Damage);
            Assert.AreEqual(expected_toughness, buildmark.Toughness);
            Assert.AreEqual(expected_recovery, buildmark.Recovery);
            Assert.AreEqual(expected_is_calculated, buildmark.isCalculated);
            Assert.AreEqual(expected_date_last_calculated, buildmark.DateLastCalculated);
        }

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
