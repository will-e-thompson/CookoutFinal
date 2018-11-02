using System;
using System.ComponentModel;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;


namespace Cookout {
    public partial class Recipe  {

        string id;        
        string recipeName;
        string ingredients;
        string description;
        string instructions;
        string email;
        string imageURL;

        [JsonProperty(PropertyName = "id")]
        public string Id {
            get { return id; }
            set { id = value; }
        }        

        [JsonProperty(PropertyName = "email")]
        public string Email {
            get { return email; }
            set {
                if (email != value) {

                    email = value;

                    //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(UserId));
                    //OnPropertyChanged("UserId");
                }
            }
        }

        [JsonProperty(PropertyName = "ingredients")]
        public string Ingredients {
            get { return ingredients; }
            set {
                if (ingredients != value) {
                    ingredients = value;

                    //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(ingredients));
                    //OnPropertyChanged("Ingredients");
                }
            }

        }

        //[JsonProperty(PropertyName = "imageURL")]
        //public string ImageURL {
        //    get { return imageURL; }
        //    set {
        //        if (imageURL != value) {
        //            imageURL = value;

        //            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(ingredients));
        //            //OnPropertyChanged("Ingredients");
        //        }
        //    }
        //}

        [JsonProperty(PropertyName = "instructions")]
        public string Instructions {
            get { return instructions; }
            set {
                if (instructions != value) {
                    instructions = value;
                    //OnPropertyChanged("Directions");
                }
            }
        }

        [JsonProperty(PropertyName = "recipeName")]
        public string RecipeName {
            get { return recipeName; }
            set {
                if (recipeName != value) {
                    recipeName = value;
                    //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
                    //OnPropertyChanged("Name");
                }
            }
        }

        [JsonProperty(PropertyName = "recipeDescription")]
        public string Description {
            get { return description; }
            set {
                if (description != value) {
                    description = value;
                    //OnPropertyChanged("Description");
                }

            }
        }

        //[JsonProperty(PropertyName = "difficulty")]
        //public string Difficulty {
        //    get { return difficulty; }
        //    set { difficulty = value; }
        //}





       

    }
}
