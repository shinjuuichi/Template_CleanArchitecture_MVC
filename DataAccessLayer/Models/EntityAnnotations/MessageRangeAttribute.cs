using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models.EntityAnnotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class MessageRangeAttribute : RangeAttribute
    {
        private readonly double _minimum;
        private readonly double _maximum;

        public MessageRangeAttribute(double minimum, double maximum) : base(minimum, maximum)
        {
            _minimum = minimum;
            _maximum = maximum;
            ErrorMessage = "{0} must be between {1} and {2}";
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is double number && (number < _minimum || number > _maximum))
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }

            return ValidationResult.Success;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name, _minimum, _maximum);
        }
    }
}
