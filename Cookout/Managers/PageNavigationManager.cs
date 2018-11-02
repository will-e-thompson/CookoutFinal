using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Cookout
{
    public class PageNavigationManager
    {
        private static PageNavigationManager instance;
        private INavigation navigation;

        private PageNavigationManager() { }

        public static PageNavigationManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PageNavigationManager();
                }
                return instance;
            }
        }

        public INavigation Navigation
        {
            set { navigation = value; }
        }

        public void showUserPage()
        {
            navigation.PushAsync(new ViewProfile());
        }

        public void showRecipePage()
        {
            navigation.PushAsync(new RecipeViewer());
        }

        public void ShowAddRecipePage()
        {
            navigation.PushAsync(new addRecipe());
        }
    }
}
