using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cookout.Resources
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserViewCellLayout : ContentView
	{
		public UserViewCellLayout ()
		{
			InitializeComponent ();
		}
	}
}