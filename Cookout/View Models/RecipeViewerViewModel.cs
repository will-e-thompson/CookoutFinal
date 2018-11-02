using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Cookout {
    public class RecipeViewerViewModel: ViewModelBase {

        private string recipeContent;

        //public RecipeViewerViewModel() {
        //public event PropertyChangedEventHandler PropertyChanged;

        private Recipe recipe = new Recipe();

        public ICommand DescriptionClicked { protected set; get; }
        public ICommand InstructionClicked { protected set; get; }
        public ICommand IngredientsClicked { protected set; get; }

        public ContentPage Context { get; set; }

        private RecipeManager manager;


        public Recipe Recipe {
            get { return recipe; }
            set {
                recipe = value;
                OnPropertyChanged("Recipe");
            }
        }

        public String RecipeContent { 
            get { return recipeContent; } 
            set {
                recipeContent = value;
                OnPropertyChanged();
                
              }
        }

        public async Task<Recipe> GetRecipe(string recipeN) {
            if (recipeN != null) {

                Debug.WriteLine("trying the database");
                var anyRec = await manager.GetRecipesAsync();
                var rec = await manager.GetRecipe("eggs");

                //if (anyRec.Count > 0){
                if (rec != null) {
                    Debug.WriteLine("found something");
                    Debug.WriteLine(rec.RecipeName);
                    Recipe = rec;
                    RecipeContent = String.Concat("\u2022", Recipe.Description);
                    return rec;
                } else {
                    Debug.WriteLine("Couldnt find anything");
                    return null;
                }
            } else {
                Debug.WriteLine("Couldnt find anything");
                return null;
            }
        }

        public RecipeViewerViewModel(){
            Debug.WriteLine("Setting up ViewModel");

            manager = RecipeManager.DefaultManager;

            Debug.WriteLine("fetching list");

            //Recipe.RecipeName = "Scrambled Eggs";
            //Recipe.Ingredients = "Eggs";
            //Recipe.Instructions = "Whip eggs briskly";
            //Recipe.Description = "A nice simple recipe for making scrambled eggs";

            RecipeContent = String.Concat("\u2022", Recipe.Description);

            //var RecipeList = manager.GetRecipe("eggs");


            //Recipe = manager.GetRecipe("eggs").Result;
            //var RL = manager.GetRecipesAsync();

            var ye = GetRecipe("eggs");
            Debug.WriteLine(ye);

            //Recipe = RL;
            //Debug.WriteLine(RL);

            //if (/*RecipeList*/ RL == null){
            //    Recipe.RecipeName = "Scrambled Eggs";
            //    Recipe.Ingredients = "Eggs";
            //    Recipe.Instructions = "Whip eggs briskly";
            //    Recipe.Description = "A nice simple recipe for making scrambled eggs";
            //} else {
            //    Debug.WriteLine("Found something??");
            //    Debug.WriteLine(RL.Status);
            //}


            DescriptionClicked = new Command( () => {
                RecipeContent = String.Concat("\u2022", Recipe.Description);
            });

            InstructionClicked = new Command( () => {
                RecipeContent = String.Concat("\u2022", Recipe.Instructions);
            });

            IngredientsClicked = new Command( () => {
                RecipeContent = String.Concat("\u2022", Recipe.Ingredients);
            });



            System.Diagnostics.Debug.WriteLine("Set up ViewModel");





        }




        //void DescriptionClicked(object sender, EventArgs args) {
        //    RecipeContent = recipe.Description;
        //    //recipeContentlbl.Text = recipe.Description;
        //    System.Diagnostics.Debug.WriteLine("Description");
        //}

        //void InstructionsClicked(object sender, EventArgs args) {
        //    RecipeContent = recipe.Directions;
        //    System.Diagnostics.Debug.WriteLine("Instructions");
        //}

        //void IngredientsClicked(object sender, EventArgs args) {
        //    RecipeContent = recipe.Ingredients;
        //    System.Diagnostics.Debug.WriteLine("Ingredients");
        //}

    }
}
