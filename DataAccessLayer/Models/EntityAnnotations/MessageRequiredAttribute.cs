using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models.EntityAnnotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class MessageRequiredAttribute : RequiredAttribute
    {
        public MessageRequiredAttribute() : base()
        {
            ErrorMessage = "{0} is required";
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || value is string str && string.IsNullOrWhiteSpace(str))
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
