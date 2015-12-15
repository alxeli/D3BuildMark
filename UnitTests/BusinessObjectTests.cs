using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessObjects;

namespace UnitTests
{
    [TestClass]
    public class BusinessObjectTests
    {
        [TestMethod]
        public void TestUserDefaultConstructor()
        {
            User user = new User();

            string expected_name = null;
            Profile expected_profile = new Profile();

            Assert.AreEqual(expected_name, user.Name);
            Assert.IsInstanceOfType(expected_profile, typeof(Profile));
        }

        [TestMethod]
        public void TestUserOverloadedConstructor()
        {
            User user = new User("test_user");

            string expected_name = "test_user";
            Profile expected_profile = new Profile();

            Assert.AreEqual(expected_name, user.Name);
            Assert.IsInstanceOfType(expected_profile, typeof(Profile));
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
