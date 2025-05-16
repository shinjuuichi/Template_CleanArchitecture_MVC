using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models.EntityAnnotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class MessageMaxLengthAttribute : MaxLengthAttribute
    {
        private readonly int _maxLength;

        public MessageMaxLengthAttribute(int maxLength) : base(maxLength)
        {
            _maxLength = maxLength;
            ErrorMessage = "{0} can't exceed {1} characters";
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string str && str.Length > _maxLength)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }

            return ValidationResult.Success;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name, _maxLength);
        }
    }
}
