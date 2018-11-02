using System;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

namespace tryyyy.UITests
{
    [TestFixture(Platform.Android)]
    public class TestRegistration
    {
        IApp app;
        Platform platform;
        Stopwatch stopwatch;



        public TestRegistration(Platform platform)
        {
            this.platform = Platform.Android;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
            try{
                app.Tap("redirectregistration");
            }
            catch(Exception)
            {
                Debug.WriteLine("it doesn't exist in the other page");
            }
            stopwatch = new Stopwatch();
            //app.Screenshot("On " + this.GetType().Name);

        }

        /*   */
        //==================================test whether text field can be empty
        [Test]
        public void RegistrationEmptyTest1()
        {
            //EntryInputText(string first, string last, string mobile, string email, string password, string confirm_password)
            EntryInputText("afawfawf", "", "", "", "", "");
            WaitAndTest(5000, "You can't leave any field empty.");
        }
        [Test]
        public void RegistrationEmptyTest2()
        {
            //EntryInputText(string first, string last, string mobile, string email, string password, string confirm_password)
            EntryInputText("", "faefwafw", "", "", "", "");
            WaitAndTest(5000, "You can't leave any field empty.");

        }
        [Test]
        public void RegistrationEmptyTest3()
        {
            //EntryInputText(string first, string last, string mobile, string email, string password, string confirm_password)
            EntryInputText("", "", "fqwfqwfqw", "", "", "");
            WaitAndTest(5000, "You can't leave any field empty.");
        }
        [Test]
        public void RegistrationEmptyTest4()
        {
            //EntryInputText(string first, string last, string mobile, string email, string password, string confirm_password)
            EntryInputText("", "", "", "qwfqwfqwf", "", "");
            WaitAndTest(5000, "You can't leave any field empty.");
        }
        [Test]
        public void RegistrationEmptyTest5()
        {
            //EntryInputText(string first, string last, string mobile, string email, string password, string confirm_password)
            EntryInputText("", "", "", "", "qwfqwfqwf", "");
            WaitAndTest(5000, "You can't leave any field empty.");
        }
        [Test]
        public void RegistrationEmptyTest6()
        {
            //EntryInputText(string first, string last, string mobile, string email, string password, string confirm_password)
            EntryInputText("", "", "", "", "", "qefqfqwfqw");
            WaitAndTest(5000, "You can't leave any field empty.");
        }
        [Test]
        public void RegistrationEmptyTest7()
        {
            //EntryInputText(string first, string last, string mobile, string email, string password, string confirm_password)
            EntryInputText("", "", "", "", "", "");
            WaitAndTest(5000, "You can't leave any field empty.");
        }
        //==================================test whether text field can be empty

        //check when email already exists in db. email is unique column in db.
        [Test]
        public void RegistrationEmailAlreadyExists()
        {
            //EntryInputText(string first, string last, string mobile, string email, string password, string confirm_password)
            EntryInputText("firstname", "lastname", "0401420594", "yyoon91@gmail.com", "bbbbbb", "bbbbbb");
            WaitAndTest(10000, "The email already exists. Please use a different email.");
        }

        //password doesn't match
        [Test]
        public void RegistrationPasswordDoesntMatch()
        {
            //EntryInputText(string first, string last, string mobile, string email, string password, string confirm_password)
            EntryInputText("firstname", "lastname", "0401420594", "unique95@gmail.com", "aaaaaa", "bbbbbb");
            WaitAndTest(10000, "Password Doesn't match.");
        }


        //password length should be greater than 5
        [Test]
        public void RegistrationPasswordLength()
        {
            //EntryInputText(string first, string last, string mobile, string email, string password, string confirm_password)
            EntryInputText("firstname", "lastname", "0401420594", "unique95@gmail.com", "abcde", "abcde");
            WaitAndTest(10000, "Password Length should be greater than 5.");
        }

        //entering invalid mobile number format
        [Test]
        public void RegistrationMobile1()
        {
            //EntryInputText(string first, string last, string mobile, string email, string password, string confirm_password)
            EntryInputText("firstname", "lastname", "12345", "unique95@gmail.com", "bbbbbb", "bbbbbb");
            WaitAndTest(10000, "Mobile Number length must be 10 and consist of numerical numbers.");
        }

        //entering invalid mobile number format
        [Test]
        public void RegistrationMobile2()
        {
            //EntryInputText(string first, string last, string mobile, string email, string password, string confirm_password)
            EntryInputText("firstname", "lastname", "eafqfqwqfqw", "unique95@gmail.com", "bbbbbb", "bbbbbb");
            WaitAndTest(10000, "Mobile Number length must be 10 and consist of numerical numbers.");
        }

        //check first name field can be number or special characters
        [Test]
        public void RegistrationName1()
        {
            //EntryInputText(string first, string last, string mobile, string email, string password, string confirm_password)
            EntryInputText("32424", "aafawfawf", "0401420594", "unique95@gmail.com", "bbbbbb", "bbbbbb");
            WaitAndTest(10000, "Your first name or last name is not a name");
        }

        //check last name field can be number or special characters
        [Test]
        public void RegistrationName2()
        {
            //EntryInputText(string first, string last, string mobile, string email, string password, string confirm_password)
            EntryInputText("aefafafaf", "%@#%@%", "0401420594", "unique95@gmail.com", "bbbbbb", "bbbbbb");
            WaitAndTest(10000, "Your first name or last name is not a name");
        }


        //check email format
        [Test]
        public void RegistrationEmailFormat1()
        {
            //EntryInputText(string first, string last, string mobile, string email, string password, string confirm_password)
            EntryInputText("firstname", "lastname", "0401420594", "unique95", "bbbbbb", "bbbbbb");
            WaitAndTest(10000, "Please check the format of your email.");
        }

        //check whether registration can happen successfully
        [Test]
        public void RegistrationIsItSuccessful()
        {
            /*
            //EntryInputText(string first, string last, string mobile, string email, string password, string confirm_password)
            EntryInputText("firstname", "lastname", "0401420594", "unique95@gmail.com", "bbbbbb", "bbbbbb");
            WaitAndTest(10000, "You have successfully registered.");
            */
        }








        private void EntryInputText(string first, string last, string mobile, string email, string password, string confirm_password)
        {
            app.Tap("automationfirst");
            app.EnterText(first);
            app.Back();

            app.Tap("automationlast");
            app.EnterText(last);
            app.Back();

            app.Tap("automationmobile");
            app.EnterText(mobile);
            app.Back();

            app.Tap("automationemail");
            app.EnterText(email);
            app.Back();


            app.Tap("automationpassword");
            app.EnterText(password);
            app.Back();

            app.ScrollDownTo("autoRegister", strategy: ScrollStrategy.Gesture, timeout: new TimeSpan(0, 1, 0));
            app.Tap("passwordconfirm");
            app.EnterText(confirm_password);
            app.Back();


            app.Tap("autoRegister");
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
