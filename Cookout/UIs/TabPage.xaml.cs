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
    public partial class TabPage : TabbedPage
    {
        public TabPage()
        {
            this.Children.Add(new Feed());
            this.Children.Add(new Grocery());
            this.Children.Add(new Search());
            this.Children.Add(new Favourites());
            this.Children.Add(new Profile());
            InitializeComponent();

        }
    }
}