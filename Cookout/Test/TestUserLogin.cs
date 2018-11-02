using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace tryyyy.UITests
{
    [TestFixture(Platform.Android)]
    public class TestUserLogin
    {
        IApp app;
        Platform platform;
        Stopwatch stopwatch;



        public TestUserLogin(Platform platform)
        {
            this.platform = Platform.Android;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
            stopwatch = new Stopwatch();


        }
     


        //test whether any field is empty
        [Test]
        public void LogInEmptyTest1()
        {
            app.Screenshot("Log In");

            app.Tap("automationEmail");
            app.EnterText("");
            app.Back();

            app.Tap("automationPassword");
            app.EnterText("");
            app.Back();

            app.Tap("automationLogin");

            WaitAndTest(5000, "You can't leave any field empty.");


        }
        //test whether any field is empty
        [Test]
        public void LogInEmptyTest2()
        {

            app.Screenshot("Log In");

            app.Tap("automationEmail");
            app.EnterText("fawfawfawfaw");
            app.Back();

            app.Tap("automationPassword");
            app.EnterText("");
            app.Back();

            app.Tap("automationLogin");

            WaitAndTest(5000, "You can't leave any field empty.");


        }
        //test whether any field is empty
        [Test]
        public void LogInEmptyTest3()
        {

            app.Screenshot("Log In");

            app.Tap("automationEmail");
            app.EnterText("");
            app.Back();

            app.Tap("automationPassword");
            app.EnterText("fawfawfawfaw");
            app.Back();

            app.Tap("automationLogin");

            WaitAndTest(5000, "You can't leave any field empty.");


        }
        //test whether users cannot login with invalid user information in the database
        [Test]
        public void LogInWithInvalidUserTest()
        {
            //InvalidUserIdontexist@gmail.com - this email doesn't exist in db
            app.Screenshot("Log In");

            app.Tap("automationEmail");
            app.EnterText("InvalidUserIdontexist@gmail.com");
            app.Back();

            app.Tap("automationPassword");
            app.EnterText("fawfawfawfaw");
            app.Back();

            app.Tap("automationLogin");


            WaitAndTest(10000, "The email doesn't exist");

        }

        //test whether the user can login successfully
        [Test]
        public void LogInWithValidUserTest()
        {
            //The following user already exists in the Database
            //email: yyoon91@gmail.com
            //password: aaaaaa (hashed password: ?\u0002E{\\A?d????\t????u(??^\u001a?[R?I?sW?)
            app.Screenshot("Log In");

            app.Tap("automationEmail");
            app.EnterText("yyoon91@gmail.com");
            app.Back();

            app.Tap("automationPassword");
            app.EnterText("aaaaaa");
            app.Back();

            app.Tap("automationLogin");

            WaitAndTest(10000, "You now logged in.");
        }



        //test whether it would not allow when the user enters a wrong password
        [Test]
        public void LogInWithValidUserWrongPasswordTest()
        {
            //The following user already exists in the Database
            //email: yyoon91@gmail.com
            //password: aaaaaa (hashed password: ?\u0002E{\\A?d????\t????u(??^\u001a?[R?I?sW?)
            app.Screenshot("Log In");

            app.Tap("automationEmail");
            app.EnterText("yyoon91@gmail.com");
            app.Back();

            app.Tap("automationPassword");
            app.EnterText("aefawfwafqwfwafwaffwa");
            app.Back();

            app.Tap("automationLogin");

            WaitAndTest(10000, "You have entered a wrong password.");
        }
        //wait for the result because it takes a long time to fetch data from db
        private void WaitAndTest(int stopTime, string alertDialogText)
        {

            stopwatch.Start();
            bool continueLoop = true;
            while (continueLoop)
            {
                if (stopwatch.ElapsedMilliseconds > stopTime)
                {
                    var expectedDialogAlert = app.Query(c => c.Class("AlertDialogLayout").Descendant().Text(alertDialogText)).FirstOrDefault().Text;
                    Assert.IsTrue(expectedDialogAlert != null);
                    stopwatch.Reset();
                    stopwatch.Stop();
                    continueLoop = false;
                }

            }
        }

 



    }
}
