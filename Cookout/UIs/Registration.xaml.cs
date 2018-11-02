using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.WindowsAzure.MobileServices;
using System.ComponentModel;
using System.Windows.Input;

#if OFFLINE_SYNC_ENABLED
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
#endif

namespace Cookout
{
    public partial class Registration : ContentPage
    {
        private RegistrationViewModel model;

        public Registration()
        {
            InitializeComponent();
            model = new RegistrationViewModel();
            model.Context = this;
            this.BindingContext = model;
        }

        private void siginin_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushModalAsync(new MainPage());
        }

        private void register_Clicked(object sender, EventArgs e)
        {
            /*           
            //create db if not exists
            var email_value = Email;
            var first_value = First;
            var last_value = Last;
            var phone_value = Mobile;
            var password_value = Password;
            var confirmpassword_value = Confirm_password;


            Debug.WriteLine(email_value);
            Debug.WriteLine(first_value);
            Debug.WriteLine(last_value);
            Debug.WriteLine(phone_value);
            Debug.WriteLine(password_value);
         
            UserRegistration registeruser = new UserRegistration();
            registeruser.Email = "wafawfwa";
            registeruser.FirstName = "test";
            registeruser.LastName = "test";
            registeruser.ImageURL = "test";
            registeruser.Pwd = "test";
            registeruser.PhoneNumber = "test";
            try{
                RegisterProcess(registeruser);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message.ToString());
            }
            DisplayAlert("Successful", "You have successfully registered.", "OK");    

            int count = 0;
            //if any field is empty
            if (first_value == null || last_value == null || phone_value == null
                    || email_value == null || password_value == null || confirmpassword_value == null)
            {
                DisplayAlert("Error", "You can't leave any field empty.", "OK");
                count++;
            }
            //if the email already exists
            else if (UserDB.IsthereAnyUser(email_value) > 0)
            {
                DisplayAlert("Error", "The email already exists. Please use a different email.", "OK");
                count++;
            }

            //if password doesn't match
            else if (password_value != confirmpassword_value)
            {
                DisplayAlert("Error", "Password Doesn't match.", "OK");
                count++;
            }
            //if password length is less than 6
            else if (password_value.Length < 6)
            {
                DisplayAlert("Error", "Password Length should be greater than 5.", "OK");
                count++;
            }
            //if mobile number length is less than 10 and does not cosist of numerical numbers
            else if (!Regex.IsMatch(phone_value, @"^[0-9]{10}$"))
            {
                DisplayAlert("Error", "Mobile Number length must be 10 and consist of numerical numbers.", "OK");
                count++;
            }
            //check if it is name
            else if (!Regex.IsMatch(first_value, @"^[\p{L} \.\-]+$") || !Regex.IsMatch(last_value, @"^[\p{L} \.\-]+$"))
            {
                DisplayAlert("Error", "Your first name or last name is not a name", "OK");
                count++;
            }
            //check if it is in email format, catch the exception when it is not formatted well
            if (count <= 0)
            {
                try
                {
                    MailAddress m = new MailAddress(email_value);
                }
                catch (FormatException)
                {
                    DisplayAlert("Error", "Please check the format of your email.", "OK");
                    count++;
                }
                catch (System.ArgumentNullException)
                {
                    DisplayAlert("Error", "You can't leave any field empty.", "OK");
                    count++;
                }
            }

            //if there is no problem, insert the user to db
            if (count <= 0)
            {

                users singleuser = new users();
                singleuser.email = email_value;
                singleuser.firstName = first_value;
                singleuser.lastName = last_value;
                singleuser.password = password_value;
                singleuser.phoneNumber = phone_value;
                UserDB.insertUser(singleuser);
                DisplayAlert("Successful", "You have successfully registered.", "OK");
                //Navigation.PushModalAsync(new MainPage());

            }
            */
        }
    }
}
