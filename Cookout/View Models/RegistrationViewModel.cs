using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Cookout
{
    public class RegistrationViewModel : ViewModelBase
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string email;
        private string mobile;
        private string first;
        private string last;
        private string password;
        private string confirm_password;
        public ICommand register_clicked { protected set; get; }
        public ICommand signin_clicked { protected set; get; }
        private RegistrationManager manager;

        public ContentPage Context { get; set; }


        public async Task<bool> IsEmailValid(string email)
        {
            if (email != null)
            {
                var isanyuser = await manager.IsUserValid(email);
                //Debug.WriteLine("//====================any user " + isanyuser.Count);

                if (isanyuser.Count <= 0)
                {
                    return true;
                }
            }
            return false;
        }

        public RegistrationViewModel()
        {

            //if session is valid, redirect the user
            if (Application.Current.Properties.ContainsKey("email"))
            {
                Context.Navigation.PushModalAsync(new TabPage());
            }

            manager = RegistrationManager.DefaultManager;
            register_clicked = new Command(async () =>
            {
                //create db if not exists
                int count = 0;

                bool validEmail= await IsEmailValid(Email);

                //if any field is empty
                if (First == null || Last == null || Mobile == null
                        || Email == null || Password == null || Confirm_password == null)
                {
                    await Context.DisplayAlert("Error", "You can't leave any field empty.", "OK");
                    count++;
                }
                //if the email already exists               
                else if (!validEmail)
                {
                    await Context.DisplayAlert("Error", "The email already exists. Please use a different email.", "OK");
                    count++;
                }
                //if password doesn't match
                else if (Password != Confirm_password)
                {
                    await Context.DisplayAlert("Error", "Password Doesn't match.", "OK");
                    count++;
                }
                //if password length is less than 6
                else if (Password.Length < 6)
                {
                    await Context.DisplayAlert("Error", "Password Length should be greater than 5.", "OK");
                    count++;
                }
                //if mobile number length is less than 10 and does not cosist of numerical numbers
                else if (!Regex.IsMatch(Mobile, @"^[0-9]{10}$"))
                {
                    await Context.DisplayAlert("Error", "Mobile Number length must be 10 and consist of numerical numbers.", "OK");
                    count++;
                }
                //check if it is name
                else if (!Regex.IsMatch(First, @"^[\p{L} \.\-]+$") || !Regex.IsMatch(Last, @"^[\p{L} \.\-]+$"))
                {
                    await Context.DisplayAlert("Error", "Your first name or last name is not a name", "OK");
                    count++;
                }
                //check if it is in email format, catch the exception when it is not formatted well
                if (count <= 0)
                {
                    try
                    {
                        MailAddress m = new MailAddress(Email);
                    }
                    catch (FormatException)
                    {
                        await Context.DisplayAlert("Error", "Please check the format of your email.", "OK");
                        count++;
                    }
                    catch (System.ArgumentNullException)
                    {
                        await Context.DisplayAlert("Error", "You can't leave any field empty.", "OK");
                        count++;
                    }
                }

                //if there is no problem, insert the user to db
                if (count <= 0)
                {

                    UserRegistration registeruser = new UserRegistration();
                    registeruser.Email = Email;
                    registeruser.FirstName = First;
                    registeruser.LastName = Last;
                    registeruser.ImageURL = "";

                    //encrypt password
                    byte[] encryptpwd = System.Text.Encoding.ASCII.GetBytes(Password);
                    encryptpwd = new System.Security.Cryptography.SHA256Managed().ComputeHash(encryptpwd);
                    String hashedpwd= System.Text.Encoding.ASCII.GetString(encryptpwd);


                    registeruser.Pwd = hashedpwd;
                    registeruser.PhoneNumber = Mobile;
                    try
                    {
                        RegisterProcess(registeruser);

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message.ToString());
                    }
                    await Context.DisplayAlert("Successful", "You have successfully registered.", "OK");
                    await Context.Navigation.PushModalAsync(new LogIn());

                }

            });//register_clicked event triggered


            signin_clicked = new Command(() =>
            {
                Context.Navigation.PushModalAsync(new LogIn());
            });

        }

        private async void RegisterProcess(UserRegistration singleuser)
        {
            await manager.SaveTaskAsync(singleuser);
            //await manager.CurrentClient.GetTable<UserRegistration>().InsertAsync(singleuser);
        }
      
        public String Email
        {
            set
            {
                if (email != value)
                {
                    email = value;
                }
                OnPropertyChanged();
            }
            get
            {
                return email;
            }
        }

        public String Mobile
        {
            set
            {
                if (mobile != value)
                {
                    mobile = value;
                }
                OnPropertyChanged();
            }
            get
            {
                return mobile;
            }
        }
        public String First
        {
            set
            {
                if (first != value)
                {
                    first = value;
                }
                OnPropertyChanged();
            }
            get
            {
                return first;
            }
        }
        public String Last
        {
            set
            {
                if (last != value)
                {
                    last = value;
                }
                OnPropertyChanged();
            }
            get
            {
                return last;
            }
        }
        public String Password
        {
            set
            {
                if (password != value)
                {
                    password = value;
                }
                OnPropertyChanged();

            }
            get
            {
                return password;
            }
        }
        public String Confirm_password
        {
            set
            {
                if (confirm_password != value)
                {
                    confirm_password = value;
                }
                OnPropertyChanged();
            }
            get
            {
                return confirm_password;
            }
        }
    }
}
