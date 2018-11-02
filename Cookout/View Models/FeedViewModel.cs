using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;
using System.Collections;
using System.Collections.ObjectModel;

namespace Cookout
{
    public class FeedViewModel : ViewModelBase
    {
        public ICommand UserClicked { protected set; get; }
        public ICommand RecipeClicked { protected set; get; }
        public ICommand AddClicked { protected set; get; }

        public ContentPage Context { get; set; }

        private UserManager userManager;
        private RecipeManager recipeManager;
        private PageNavigationManager navManager;
        public Recipe recipe = new Recipe();
        public UserRegistration user = new UserRegistration();

        public string userName;

        public Recipe recipe1 = new Recipe();
        public Recipe recipe2 = new Recipe();
        public Recipe recipe3 = new Recipe();
        public ObservableCollection<Recipe> recipes = new ObservableCollection<Recipe>();
        
        public UserRegistration user1 = new UserRegistration();
        public UserRegistration user2 = new UserRegistration();
        public UserRegistration user3 = new UserRegistration();
        public ObservableCollection<UserRegistration> users = new ObservableCollection<UserRegistration>();

        public Recipe Recipe
        {
            get { return recipe; }
            set { recipe = value; }
        }

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

        public FeedViewModel()
        {
            userManager = UserManager.DefaultManager;
            recipeManager = RecipeManager.DefaultManager;
            navManager = PageNavigationManager.Instance;

            //recipe1.RecipeName = "Butter Chicken";
            //recipe1.Ingredients = "Chicken breasts, Coriander, Garam masala, Brown onion, Tomato puree, Chicken stock, Thickened cream, Basmati rice";
            //recipe1.Description = "A simple and easy butter chicken recipe for beginners";
            //recipe1.Instructions = "Marinate chicken in herb mixture, cook onion, cook chicken, add cream, simmer, cook rice, serve";
            //recipe1.Email = "lazyboy123@gmail.com";

            //recipe2.RecipeName = "Spaghetti Bolognese";
            //recipe2.Ingredients = "Beef mince, Angel hair spaghetti, Tomato paste, Chunky tomato, Carrot, Zucchini, Brown onion, Parmesan cheese";
            //recipe2.Description = "A classic spaghetti bolognese big enough for the whole family";
            //recipe2.Instructions = "Sautee onion, cook mince, add carrot and zucchini, add tomato paste and chunky tomato, simmer, cook spaghetti, serve topped with parmesan cheese";
            //recipe2.Email = "gamergirl691@hotmail.com";

            //recipe3.RecipeName = "Asian Chicken Stir-Fry";
            //recipe3.Ingredients = "Sliced chicken breasts, capsicum, soy sauce, broccoli, carrot, noodles";
            //recipe3.Description = "A basic asian-style chicken stir-fry";
            //recipe.Instructions = "Cook chicken, cook broccoli and carrot, add soy sauce, add capsicum, cook noodles, serve";
            //recipe3.Email = "John-Smith@gmail.com";

            //user1.FirstName = "Joe";
            //user1.LastName = "Bloggs";
            //user1.Email = "lazyboy123@gmail.com";

            //user2.FirstName = "Jane";
            //user2.LastName = "Doe";
            //user2.Email = "gamergirl691@hotmail.com";

            //user3.FirstName = "John";
            //user3.LastName = "Smith";
            //user3.Email = "John-Smith@gmail.com";

            //recipes.Add(recipe1);
            //recipes.Add(recipe2);
            //recipes.Add(recipe3);

            //users.Add(user1);
            //users.Add(user2);
            //users.Add(user3);

            //UserName = FindUsername(users);

            //users = userManager.GetUsersAsync().Result;
            //recipes = recipeManager.GetRecipesAsync().Result;

            UserClicked = new Command(() => {
                navManager.showUserPage();
            });

            RecipeClicked = new Command(() => {
                navManager.showRecipePage();
            });

            AddClicked = new Command(() => {
                navManager.ShowAddRecipePage();
            });
        }

        public string FindUsername(ObservableCollection<UserRegistration> users)
        {
            string userName = "";
            foreach (UserRegistration user in users)
            {
                if (recipe.Email == user.Email)
                {
                    userName = user.FirstName + user.LastName;
                }
            }
            return userName;
        }

        public UserRegistration FindUserWithID(string ID, ObservableCollection<UserRegistration> users)
        {
            UserRegistration user = new UserRegistration();
            foreach (UserRegistration newUser in users)
            {
                if(newUser.Id == ID)
                {
                    user = newUser;
                }
            }
            return user;
        }

        public Recipe FindRecipeWithID(string ID, ObservableCollection<Recipe> recipes)
        {
            Recipe recipe = new Recipe();
            foreach (Recipe newRecipe in recipes)
            {
                if (newRecipe.Id ==ID)
                {
                    recipe = newRecipe;
                }
            }
            return recipe;
        }
    }
}
