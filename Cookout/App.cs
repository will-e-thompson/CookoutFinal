using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly:XamlCompilation(XamlCompilationOptions.Compile)]
namespace Cookout
{
	public class App : Application
	{
        private NavigationPage mainPage;

		public App ()
		{
            // The root page of your application
            mainPage = new NavigationPage(new TabPage());
            MainPage = mainPage;
            PageNavigationManager.Instance.Navigation = MainPage.Navigation;
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

