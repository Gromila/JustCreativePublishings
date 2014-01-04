using System;
using System.ComponentModel.DataAnnotations;

namespace JustCreativePublishings.Web.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }
    }

    public class ManageUserViewModel
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessageResourceType = typeof(App_LocalResources.GlobalRes), ErrorMessageResourceName = "PasswordRequired")]
        [Display(ResourceType = typeof(App_LocalResources.GlobalRes), Name = "Password")]
        public string OldPassword { get; set; }

        [Required(ErrorMessageResourceType = typeof(App_LocalResources.GlobalRes), ErrorMessageResourceName = "NewPasswordRequired")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessageResourceType = typeof(App_LocalResources.GlobalRes), ErrorMessageResourceName = "ValueLength", MinimumLength = 6)]
        [Display(ResourceType = typeof(App_LocalResources.GlobalRes), Name = "NewPassword")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(App_LocalResources.GlobalRes), Name = "PasswordConfirmation")]
        [Compare("NewPassword", ErrorMessageResourceType = typeof(App_LocalResources.GlobalRes), ErrorMessageResourceName = "BadPasswords")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessageResourceType = typeof(App_LocalResources.GlobalRes), ErrorMessageResourceName = "UsernameRequired")]
        [Display(ResourceType = typeof(App_LocalResources.GlobalRes), Name = "Username")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessageResourceType = typeof(App_LocalResources.GlobalRes), ErrorMessageResourceName = "PasswordRequired")]
        [Display(ResourceType = typeof(App_LocalResources.GlobalRes), Name = "Password")]
        public string Password { get; set; }

        [Display(ResourceType = typeof(App_LocalResources.GlobalRes), Name = "RememberMe")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessageResourceType = typeof(App_LocalResources.GlobalRes), ErrorMessageResourceName = "UsernameRequired")]
        [Display(ResourceType = typeof(App_LocalResources.GlobalRes), Name = "Username")]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(App_LocalResources.GlobalRes), ErrorMessageResourceName = "PasswordRequired")]
        [StringLength(100, ErrorMessageResourceType = typeof(App_LocalResources.GlobalRes), ErrorMessageResourceName = "ValueLength", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(App_LocalResources.GlobalRes), Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(App_LocalResources.GlobalRes), Name = "PasswordConfirmation")]
        [Compare("Password", ErrorMessageResourceType = typeof(App_LocalResources.GlobalRes), ErrorMessageResourceName = "BadPasswords")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessageResourceType = typeof(App_LocalResources.GlobalRes), ErrorMessageResourceName = "EmailRequired")]
        [DataType(DataType.EmailAddress)]
        [Display(ResourceType = typeof(App_LocalResources.GlobalRes), Name = "Email")]
        public String Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(App_LocalResources.GlobalRes), ErrorMessageResourceName = "DateOfBirthRequired")]
        [DataType(DataType.DateTime)]
        [Display(ResourceType = typeof(App_LocalResources.GlobalRes), Name = "DateOfBirth")]
        public DateTime DateOfBirth { get; set; }
    }
}
