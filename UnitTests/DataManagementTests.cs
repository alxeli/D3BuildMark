using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessObjects;

namespace UnitTests
{
    [TestClass]
    public class DataManagementTests
    {
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
