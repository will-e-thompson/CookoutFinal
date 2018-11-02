using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace Cookout.View_Models
{
    public class ProfileViewModel
    {
        public UserRegistration user = new UserRegistration();
        public Recipe recipe = new Recipe();
        public string userName;
        public ObservableCollection<Recipe> recipes = new ObservableCollection<Recipe>();

        private PageNavigationManager navManager;
        private UserManager userManager;
        private RecipeManager recipeManager;
        
        public ICommand RecipeClicked { protected set; get; }

        public UserRegistration User
        {
            get { return user; }
            set { user = value; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public ProfileViewModel()
        {
            navManager = PageNavigationManager.Instance;
            userManager = UserManager.DefaultManager;
            recipeManager = RecipeManager.DefaultManager;

            //User = Classes.GlobalVariables.currentUser;

            //UserName = User.FirstName + User.LastName;

            //recipes = recipeManager.GetUserRecipesAsync(User.Email).Result;

            RecipeClicked = new Command(() =>
            {
                navManager.showRecipePage();
            });
        }
    }
}
