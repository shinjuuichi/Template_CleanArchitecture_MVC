using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models.EntityAnnotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class NumberPositiveAttribute() : ValidationAttribute("{0} can't be negative")
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is double number && number < 0)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            return ValidationResult.Success;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name);
        }
    }
}
