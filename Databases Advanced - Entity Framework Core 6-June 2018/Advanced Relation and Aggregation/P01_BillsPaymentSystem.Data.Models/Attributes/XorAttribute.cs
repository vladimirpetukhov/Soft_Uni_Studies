using System;
using System.ComponentModel.DataAnnotations;

namespace P01_BillsPaymentSystem.Data.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class XorAttribute : ValidationAttribute
    {
        private string targetAttribute;

        public XorAttribute(string targetAttribute)
        {
            this.targetAttribute = targetAttribute;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var result = new ValidationResult("");
            string error = "Must have at least one Payment Method!";

            var targetAttribute = validationContext.ObjectType
                .GetProperty(this.targetAttribute)
                .GetValue(validationContext.ObjectInstance);
            
            if((targetAttribute==null && value!=null) || (targetAttribute!=null && value == null))
            {
                result = ValidationResult.Success;
            }
            else
            {
                result =new ValidationResult(error);
            }

            return result;
        }
    }
}
