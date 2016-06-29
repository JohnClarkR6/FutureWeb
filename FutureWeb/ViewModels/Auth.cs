using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureWeb.ViewModels
{
    public class AuthLogin     //view model for every action, contract between the view and the controller.
    {
        [Required]  //Telling the form that this is required to login.  //Need to set what happens with required in the controller.
        public string Username { get; set; }   //properties that will be in the view and will add up.

        [Required, DataType(DataType.Password)]  //sets password form field in the EditorFor to be a password.
        public string Password { get; set; }   
    }

    public class AuthRegister     //view model for every action, contract between the view and the controller.
    {
        [Required]  //Telling the form that this is required to login.  //Need to set what happens with required in the controller.
        public string Username { get; set; }   //properties that will be in the view and will add up.

        [Required, DataType(DataType.EmailAddress)]  //Telling the form that this is required to login.  //Need to set what happens with required in the controller.
        public string Email { get; set; }   //properties that will be in the view and will add up.

        [Required, DataType(DataType.Password)]  //sets password form field in the EditorFor to be a password.
        public string Password { get; set; }

        [Required, DataType(DataType.Password), Compare("Password", ErrorMessage = "Password doesn't match")]
        public string ConfirmPassword { get; set; }
    }
}
