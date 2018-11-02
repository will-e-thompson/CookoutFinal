using System;
using System.Collections.Generic;
using System.Text;

namespace Cookout.Classes
{
    public static class GlobalVariables
    {
        public static UserRegistration currentUser = new UserRegistration();
        public static UserRegistration selectedUser = new UserRegistration();
        public static Recipe selectedRecipe = new Recipe();
    }
}
