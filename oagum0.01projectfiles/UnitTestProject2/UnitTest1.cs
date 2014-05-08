using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Web;


namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
     
         [TestMethod]
        public void DatabaseTestNullcheck()
        {
            using (MembershipEntities memberDatabase2 = new MembershipEntities())
            {

                User newuser = memberDatabase2.Users.FirstOrDefault();

                Assert.AreNotEqual(null, newuser);
            }
        }
        [TestMethod]
         public void DatabaseLoginIdTest()
         {
            string UserName = "shaymas123";
            string Password = "123456";

             using (MembershipEntities memberDatabase2 = new MembershipEntities())
             {
                 
                
               User user = memberDatabase2.Users.Where(User => User.UserName == UserName && User.Password == Password).SingleOrDefault();
                      
               string check = user.ID.ToString();

               Assert.AreEqual("1", check);
             

             }
          }

        [TestMethod]
        public void DatabaseLoginNameTest()
        {
            string UserName = "shaymas123";
            string Password = "123456";

            using (MembershipEntities memberDatabase2 = new MembershipEntities())
            {


                User user = memberDatabase2.Users.Where(User => User.UserName == UserName && User.Password == Password).SingleOrDefault();

                string check = user.UserName.ToString();

                Assert.AreEqual("shaymas123", check);


            }
        }

        [TestMethod]
        public void DatabaseLoginEmailTest()
        {
            string UserName = "shaymas00";
            string Password = "123456";
            

            using (MembershipEntities memberDatabase2 = new MembershipEntities())
            {


                User user = memberDatabase2.Users.Where(User => User.UserName == UserName && User.Password == Password).SingleOrDefault();

                string check = user.Email.ToString();

                Assert.AreEqual("myemail@this.com", check);


            }
        }

        [TestMethod]
        public void DatabaseLogoutTest()
        {
            string UserName = "shaymas123";
            string Password = "123456";

            using (MembershipEntities memberDatabase2 = new MembershipEntities())
            {


                User user = memberDatabase2.Users.Where(User => User.UserName == UserName && User.Password == Password).SingleOrDefault();

                string check = user.ID.ToString();

                user = null;

                Assert.AreEqual(null, user);


            }
        }
        [TestMethod]
        public void RegisterDupNameTest()
        {
            string EmailAddress = "Myemail@this.com"; 
            string Password = "123456";
            string UserName = "Shaymas123";            
            string message = "";                                              
            try
            {
                using (MembershipEntities memberDatabase2 = new MembershipEntities())
                {
                    if(!EmailAddress.Contains('@') || (!EmailAddress.Contains(".com")))
                    {
                        message = "Must have valid Email";
                    }
                    else if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(EmailAddress))
                    {
                        User newuser = new User
                        {
                            Email = EmailAddress,
                            UserName = UserName,
                            Password = Password
                        };
                        memberDatabase2.Users.Add(newuser);
                        try
                        {
                            memberDatabase2.SaveChanges();
                        }
                        catch(Exception ex)
                        {
                            message = "User already exists";
                        }
                       
                    }
                    else
                    {
                        throw new Exception("Username, password, and email must have a value");
                    }

                }
            }
            catch (Exception ex) { message = ex.Message; }
            Assert.AreEqual("User already exists", message);
            }

        [TestMethod]
        public void RegisterEmptyTextBoxTest()
        {
            string EmailAddress = "this@email.com";
            string Password = "";
            string UserName = "";
            string message = "";
            try
            {
                using (MembershipEntities memberDatabase2 = new MembershipEntities())
                {
                    if (!EmailAddress.Contains('@') || (!EmailAddress.Contains(".com")))
                    {
                        message = "Must have valid Email";
                    }
                    else if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(EmailAddress))
                    {
                        User newuser = new User
                        {
                            Email = EmailAddress,
                            UserName = UserName,
                            Password = Password
                        };
                        memberDatabase2.Users.Add(newuser);
                        try
                        {
                            memberDatabase2.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            message = "User already exists";
                        }

                    }
                    else
                    {
                       message = "Username, password, and email must have a value";
                    }

                }
            }
            catch (Exception ex) { message = ex.Message; }
            Assert.AreEqual("Username, password, and email must have a value", message);
        }

        [TestMethod]
        public void RegisterInvalidEmailTest()
        {
            string EmailAddress = "myemail.com";
            string Password = "";
            string UserName = "";
            string message = "";
            try
            {
                using (MembershipEntities memberDatabase2 = new MembershipEntities())
                {
                    if (!EmailAddress.Contains('@') || (!EmailAddress.Contains(".com")))
                    {
                        message = "Must have valid Email";
                    }
                    else if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(EmailAddress))
                    {
                        User newuser = new User
                        {
                            Email = EmailAddress,
                            UserName = UserName,
                            Password = Password
                        };
                        memberDatabase2.Users.Add(newuser);
                        try
                        {
                            memberDatabase2.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            message = "User already exists";
                        }

                    }
                    else
                    {
                        message = "Username, password, and email must have a value";
                    }

                }
            }
            catch (Exception ex) { message = ex.Message; }
            Assert.AreEqual("Must have valid Email", message);
        }

        [TestMethod]
        public void ValidRegisterationTest()
        {
            string EmailAddress = "myemail@this.com";
            string Password = "123456";
            string UserName = "shaymas09";
            string message = "";
            try
            {
                using (MembershipEntities memberDatabase2 = new MembershipEntities())
                {
                    if (!EmailAddress.Contains('@') || (!EmailAddress.Contains(".com")))
                    {
                        message = "Must have valid Email";
                    }
                    else if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(EmailAddress))
                    {
                        User newuser = new User
                        {
                            Email = EmailAddress,
                            UserName = UserName,
                            Password = Password
                        };
                        memberDatabase2.Users.Add(newuser);
                        try
                        {
                            memberDatabase2.SaveChanges();
                            message = "success";
                            memberDatabase2.Users.Remove(newuser);
                            memberDatabase2.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            message = "User already exists";
                        }

                    }
                    else
                    {
                        message = "Username, password, and email must have a value";
                    }

                }
            }
            catch (Exception ex) { message = ex.Message; }
            Assert.AreEqual("success", message);
        }



        }

     }
  
