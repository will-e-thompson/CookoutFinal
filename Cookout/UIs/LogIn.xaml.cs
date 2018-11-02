using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Cookout
{
    public partial class LogIn : ContentPage
    {
        private LogInViewModel model;

        public LogIn()
        {
            InitializeComponent();
            model = new LogInViewModel();
            model.Context = this;
            this.BindingContext = model;
        }
    }
}
