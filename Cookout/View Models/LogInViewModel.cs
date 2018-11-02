using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Cookout
{
    public class LogInViewModel : ViewModelBase
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string email;
        private string password;
        public ICommand register_clicked { protected set; get; }
        public ICommand login_Clicked { protected set; get; }
        private RegistrationManager manager;
        public NavigationPage mainPage = new NavigationPage(new TabPage());

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

        public LogInViewModel()
        {
            //if session is valid, redirect the user
            if (Application.Current.Properties.ContainsKey("email"))
            {
                Context.Navigation.PushModalAsync(new TabPage());
            }


            manager = RegistrationManager.DefaultManager;
            register_clicked = new Command(async () =>
            {

                await Context.Navigation.PushModalAsync(new Registration());

            });
            login_Clicked = new Command(async () =>
            {

                int count = 0;
                UserRegistration getsingleuser=null;

                if (Email == null || Password == null)
                {
                    await Context.DisplayAlert("Error", "You can't leave any field empty.", "OK");
                    count++;
                }
                else
                {
                    try
                    {
                        var findpwd = await manager.GetPassword(Email);
                        var list = new List<UserRegistration>(findpwd);
                        getsingleuser = list.ToArray()[0];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        await Context.DisplayAlert("Error", "The email doesn't exist", "OK");
                        count++;
                    }
                }

                if(count<=0 && !Application.Current.Properties.ContainsKey("email"))
                {

                    try
                    {
                        byte[] encryptpwd = System.Text.Encoding.ASCII.GetBytes(Password);
                        encryptpwd = new System.Security.Cryptography.SHA256Managed().ComputeHash(encryptpwd);
                        String hashedpwd = System.Text.Encoding.ASCII.GetString(encryptpwd);
                        if (getsingleuser.Pwd == hashedpwd && count <= 0)
                        {
                            Application.Current.Properties["first"] = getsingleuser.FirstName;
                            Application.Current.Properties["last"] = getsingleuser.LastName;
                            Application.Current.Properties["phone"] = getsingleuser.PhoneNumber;
                            Application.Current.Properties["email"] = getsingleuser.Email;
                            Application.Current.Properties["password"] = getsingleuser.Pwd;
                            //Application.Current.Properties.Clear();
                            await Context.DisplayAlert("Successful", "You now logged in.", "OK");
                            await Context.Navigation.PushModalAsync(mainPage);

                        }
                        else
                        {
                            await Context.DisplayAlert("Error", "You have entered a wrong password.", "OK");
                            count++;
                        }
                    }
                    catch (NullReferenceException)
                    {
                        count++;
                    }


                }











            });


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
    }
}
