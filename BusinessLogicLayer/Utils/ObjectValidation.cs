using System.ComponentModel.DataAnnotations;
using DataAccessLayer.Commons.Exceptions;
using DataAccessLayer.Models.EntityAbstractions;

namespace BusinessLogicLayer.Utils
{
    public static class ObjectValidation
    {
        public static void TryValidate(this Entity entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResults = new List<ValidationResult>();

            Validator.TryValidateObject(entity, validationContext, validationResults, true);

            if (validationResults.Count != 0)
            {
                throw new ValidationFailureException(validationResults);
            }
        }
    }
}
