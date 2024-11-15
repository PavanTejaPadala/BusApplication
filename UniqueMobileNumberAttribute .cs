
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;

namespace Assignment_BusApplication
{
   

    public class UniqueMobileNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var userManager = validationContext.GetService(typeof(UserManager<IdentityUser>)) as UserManager<IdentityUser>;
            var mobileNumber = value as string;

            if (userManager != null && !string.IsNullOrEmpty(mobileNumber))
            {
                var user = userManager.Users.FirstOrDefault(u => u.PhoneNumber == mobileNumber);
                if (user != null)
                {
                    return new ValidationResult("The mobile number is already registered.");
                }
            }

            return ValidationResult.Success;
        }
    }

}
