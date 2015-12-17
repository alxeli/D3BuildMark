using System;
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
            //ApiManager manager = new ApiManager();
            Profile profile = new Profile();
            profile.BattleTag = "butchiebags#1483";

            Assert.IsTrue(ApiManager.RetrieveProfile(ref profile));
            Assert.IsNotNull(profile.BattleTag);
            Assert.IsTrue(profile.Heroes.Count > 0);
        }
        [TestMethod]
        public void TestApiManagerRetrieveProfileThatDoesNotExist()
        {
            //ApiManager manager = new ApiManager();
            Profile profile = new Profile();
            profile.BattleTag = "invalid";

            Assert.IsFalse(ApiManager.RetrieveProfile(ref profile));
            Assert.IsNotNull(profile.BattleTag);
            Assert.IsTrue(profile.Heroes.Count == 0);
        }
    }
}
