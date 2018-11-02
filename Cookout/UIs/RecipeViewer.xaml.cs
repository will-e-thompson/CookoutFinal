using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Cookout {
    public partial class RecipeViewer : ContentPage {



        //RecipeManager manager;

        //public RecipeModel recipe;

        //string recipeSegueName;

        //private string recipeContent;

        //public string RecipeContent{
        //    get { return recipeContent; }
        //    set { recipeContent = value; }

        //}

        private RecipeViewerViewModel model;

        public RecipeViewer() {

            System.Diagnostics.Debug.WriteLine("setting up components");

            InitializeComponent();

            System.Diagnostics.Debug.WriteLine("inited comp");

            model = new RecipeViewerViewModel();
            model.Context = this;
            this.BindingContext = model;


            //manager = RecipeManager.DefaultManager;
            //recipe = new RecipeModel();

            //BindingContext = RecipeViewerViewModel;
            System.Diagnostics.Debug.WriteLine("set up components");
        }


        //    protected override void OnAppearing(){
        //        base.OnAppearing();


        //        //recipe = await manager.GetRecipe(recipeSegueName);
        //        recipe.Name = "scrambled eggs";
        //        recipe.Description = "A simple recipe for scrambled eggs";
        //        recipe.Ingredients = "2 eggs";
        //        recipe.Directions = "crack open both eggs into a bowl." +
        //            " whisk eggs " +
        //            "untill combined. Pour eggs " +
        //            "into a hot pan, stirring until cooked";
        //        System.Diagnostics.Debug.WriteLine("Set up recipe");

        //        recipeContentlbl.SetBinding(Label.TextProperty, new Binding("Value", source: RecipeContent));

        //        RecipeContent = recipe.Description;
        //        System.Diagnostics.Debug.WriteLine(recipe.Name);
        //        System.Diagnostics.Debug.WriteLine(recipe.Description);
        //        System.Diagnostics.Debug.WriteLine(recipe.Ingredients);
        //        System.Diagnostics.Debug.WriteLine(recipe.Directions);
        //    }

        //    //void DescriptionClicked(object sender, EventArgs args){
        //    //    RecipeContent = recipe.Description;
        //    //    recipeContentlbl.Text = recipe.Description;
        //    //    System.Diagnostics.Debug.WriteLine("Description");
        //    //}

        //    //void InstructionsClicked(object sender, EventArgs args) {
        //    //    RecipeContent = recipe.Directions;
        //    //    System.Diagnostics.Debug.WriteLine("Instructions");
        //    //}

        //    //void IngredientsClicked(object sender, EventArgs args) {
        //    //    RecipeContent = recipe.Ingredients;
        //    //    System.Diagnostics.Debug.WriteLine("Ingredients");
        //    //}


        //    //private async Task GetRecipe(string nameOfRecipe){

        //    //}
        //}


    }
}
