using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace P01_BillsPaymentSystem.Data.Models.Attributes
{
    
    public class NonUnicodeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var message = new ValidationResult("");
            string nullError = "Value can not be null";
            string nonUnicodeChar = "Value can not contain unicode characters!";

            if (value == null)
            {
                message = new ValidationResult(nullError);
            }
            else if(value.ToString().Any(s=> s>255))
            {
                message = new ValidationResult(nonUnicodeChar);
            }
            else
            {
                message = ValidationResult.Success;
            }

            return message;
        }
    }
}
