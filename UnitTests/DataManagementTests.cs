﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataManagement;
using BusinessObjects;

namespace UnitTests
{
    [TestClass]
    public class DataManagementTests
    {
        [TestMethod]
        public void TestApiManagerRetrieveProfileThatExists()
        {
            ApiManager manager =  ApiManager.GetInstance();
            AC_Profile profile = new AC_Profile();
            profile.BattleTag = "butchiebags#1483";

            Assert.IsTrue(manager.RetrieveProfile(ref profile));
            Assert.IsNotNull(profile.BattleTag);
            Assert.IsTrue(profile.Heroes.Count > 0);
        }
        [TestMethod]
        public void TestApiManagerRetrieveProfileThatDoesNotExist()
        {
            ApiManager manager = ApiManager.GetInstance();
            AC_Profile profile = new AC_Profile();
            profile.BattleTag = "invalid";

            Assert.IsFalse(manager.RetrieveProfile(ref profile));
            Assert.IsNotNull(profile.BattleTag);
            Assert.IsTrue(profile.Heroes.Count == 0);
        }
    }
}
