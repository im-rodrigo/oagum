using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using oagum0._01.Models;
using System.Data.Entity;
using System.Data.EntityModel;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int sum = 1 + 1;
            Assert.AreEqual(2, sum);
        }

        [TestMethod]
        public void MembershipEntitiesTest()
        {
            using (MembershipEntities1 memberDatabase = new MembershipEntities1())
            {
                
               User newuser = memberDatabase.Users.FirstOrDefault();
                
               Assert.AreNotEqual(null, newuser);
            }
        }

    }
}
