using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace Cookout {
    public partial class RecipeManager {

        static RecipeManager defaultInstance = new RecipeManager();
        MobileServiceClient client;

        IMobileServiceTable<Recipe> RecipeTable;
        IMobileServiceTable<UserRegistration> userTable;

        public RecipeManager() {
            this.client = new MobileServiceClient(Constants.ApplicationURL);
            this.userTable = client.GetTable<UserRegistration>();
            this.RecipeTable = client.GetTable<Recipe>();
        }

        public static RecipeManager DefaultManager{
            get {
                return defaultInstance;
            }
            private set {
                defaultInstance = value;
            }
        }

        public MobileServiceClient CurrentClient {
            get { return client; }
        }

        public async Task<ObservableCollection<Recipe>> GetRecipesAsync (bool syncItems = false){
            try{
                IEnumerable<Recipe> recipes = await RecipeTable.ToEnumerableAsync();

                return new ObservableCollection<Recipe>(recipes);
            } catch (MobileServiceInvalidOperationException msioe) {
                Debug.WriteLine("Invalid sync operation: {0}", new[] { msioe.Message });
            } catch (Exception e) {
                Debug.WriteLine("Sync error: {0}", new[] { e.Message });
            }
            return null;
        }

        public async Task<ObservableCollection<Recipe>> GetUserRecipesAsync(string email, bool syncItems = false)
        {
            try
            {
                IEnumerable<Recipe> recipes = await RecipeTable.Where(recipe => recipe.Email == email).ToEnumerableAsync();

                return new ObservableCollection<Recipe>(recipes);
            }
            catch (MobileServiceInvalidOperationException msioe)
            {
                Debug.WriteLine("Invalid sync operation: {0}", new[] { msioe.Message });
            }
            catch (Exception e)
            {
                Debug.WriteLine("Sync error: {0}", new[] { e.Message });
            }
            return null;
        }

        public async Task<Recipe> GetRecipe(string nameOfRecipe){
            try {
                IEnumerable<Recipe> recipes = await RecipeTable.Where(recipe => recipe.RecipeName == nameOfRecipe).ToEnumerableAsync();

                if (recipes.Count() > 0){
                    return recipes.ElementAt(0);
                } else {
                    throw new Exception();
                }

            } catch (MobileServiceInvalidOperationException msioe) {
                Debug.WriteLine("Invalid sync operation: {0}", new[] { msioe.Message });
            } catch (Exception e) {
                Debug.WriteLine("Sync error: {0}", new[] { e.Message });
            }
            return null;
        }

        public async Task SaveRecipeAsync(Recipe recipe){
            try {
                if (recipe.Id == null){
                    await RecipeTable.InsertAsync(recipe);
                } else {
                    await RecipeTable.UpdateAsync(recipe);
                }
            } catch (Exception e) {
                Debug.WriteLine("Save error: {0}", new[] { e.Message });
            }
        }
    }
}
