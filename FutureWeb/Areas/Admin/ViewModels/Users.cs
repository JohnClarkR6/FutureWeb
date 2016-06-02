using FutureWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FutureWeb.Areas.Admin.ViewModels
{
    public class RoleCheckbox         
    {
        public int Id { get; set; }
        public bool IsChecked { get; set; }
        public string Name { get; set; }
    }

    public class UsersIndex    //users controller and Index action
    {
        public IEnumerable<User> Users { get; set; }  //represents a collection of users
    }

    public class UsersNew   //users controller and new action
    {
        public IList<RoleCheckbox> Roles { get; set; }

        [Required, MaxLength(128)]                  //form elements needed to crate a new user.
        public string Username { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, MaxLength(256), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }

    public class UsersEdit
    {
        public IList<RoleCheckbox> Roles { get; set; }

        [Required, MaxLength(128)]                  //form elements needed to crate a Edit user.
        public string Username { get; set; }

        [Required, MaxLength(256), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }

    public class UsersResetPassword
    {
        public string Username { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
