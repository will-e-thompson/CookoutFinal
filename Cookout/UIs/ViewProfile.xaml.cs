using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cookout
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ViewProfile : ContentPage
	{
		public ViewProfile ()
		{
            System.Diagnostics.Debug.WriteLine("Starting initialise");
			InitializeComponent();
            System.Diagnostics.Debug.WriteLine("Finishing Initialise");
		}
	}
}