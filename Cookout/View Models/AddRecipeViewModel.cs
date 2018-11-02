using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace Cookout {
    public class AddRecipeViewModel: ViewModelBase {

        //public event PropertyChangedEventHandler PropertyChanged;

        private Recipe recipe = new Recipe();

        //private string description;
        //private string name;
        //private string instructions;
        //private string ingredients;


        public ContentPage Context { get; set; }

        private RecipeManager manager;

        public ICommand AddRecipeClicked { protected set; get; }

        public Recipe Recipe {
            get { return recipe; }
            set {
                recipe = value;
                OnPropertyChanged();
            }
        }

        //public String Name{
        //    get { return name; }
        //    set {
        //        name = value;
        //        OnPropertyChanged("Name");
        //    }
        //}

        //public String Description {
        //    get { return description; }
        //    set {
        //        description = value;
        //        OnPropertyChanged();
        //    }
        //}



        public AddRecipeViewModel() {

            manager = RecipeManager.DefaultManager;


            AddRecipeClicked = new Command( () => {
                Recipe newRecipe = new Recipe();
                newRecipe.RecipeName = Recipe.RecipeName;

                newRecipe.RecipeName = "eggs";
                newRecipe.Ingredients = "eggs";
                newRecipe.Instructions = "whip eggs";
                newRecipe.Email = "goodboy@gmail.com";



                //newRecipe.ImageURL = "";

                //newRecipe.Description = Recipe.Description;
                //newRecipe.Instructions = Instructions;
                //newRecipe.Ingredients = Ingredients;
                //newRecipe = Recipe;

                //Debug.WriteLine(newRecipe.Description);
                Debug.WriteLine(Recipe.RecipeName);
                Debug.WriteLine(Recipe.Ingredients);
                Debug.WriteLine(Recipe.Instructions);

                try {
                    RegisterRecipe(newRecipe);
                    Debug.WriteLine("Added Recipe successfully");

                } catch (Exception ex) {
                    Debug.WriteLine(ex.Message.ToString());
                }
            });

        }

        private async void RegisterRecipe(Recipe Trecipe){
            await manager.SaveRecipeAsync(Trecipe);
        }




    }
}
