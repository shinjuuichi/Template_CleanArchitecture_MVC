using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Commons.Exceptions
{
    public class ValidationFailureException : Exception
    {
        public IList<string> Errors { get; }

        public ValidationFailureException() : base("One or more validation failures have occurred.")
            => Errors = [];

        public ValidationFailureException(List<ValidationResult> errors) : this()
        {
            Errors = errors.Select(e => e.ErrorMessage ?? string.Empty).ToList();
        }
    }
}
