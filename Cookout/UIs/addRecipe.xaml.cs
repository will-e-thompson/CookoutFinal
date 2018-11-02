using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Cookout {
    public partial class addRecipe : ContentPage {


        RecipeManager manager;

        public Recipe newRecipe;

        private AddRecipeViewModel model;

        public addRecipe() {
            InitializeComponent();

            //manager = RecipeManager.DefaultManager;
            //newRecipe = new RecipeModel();

            model = new AddRecipeViewModel();
            model.Context = this;
            this.BindingContext = model;
        }

        //public void Save(object sender, EventArgs args){
        //    //newRecipe.Name = Name.Text;
        //    newRecipe.Description = Description.Text;
        //    newRecipe.Instructions = Directions.Text;
        //    newRecipe.Ingredients = Ingredients.Text;
        //    if (newRecipe.Name != null){
        //        System.Diagnostics.Debug.WriteLine("recipe Name: " + newRecipe.Name);
        //    } else {
        //        System.Diagnostics.Debug.WriteLine("newRecipe is void");
        //    }
        //}




        //void Handle_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) {
        //    throw new NotImplementedException();
        //}
    }
}
