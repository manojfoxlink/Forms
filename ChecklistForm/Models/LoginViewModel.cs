using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace ChecklistForm.Models
{
    public class LoginViewModel
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool IsRememberMe { get; set; }

        public string ReturnUrl { get; set; }
        public string hdrandomSeed { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "User Id")]
        public string UserId { get; set; }
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


        [Display(Name = "Profile Picture")]
      
        public string ProfilePicture { get; set; }
        public DataTable EmployeeList { get; set; }

        [Required]
        public string Designation { get; set; }
        
     
        [Required]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }




    }
}