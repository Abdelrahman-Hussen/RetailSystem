using FluentValidation.Results;
using System.Text;

namespace RetailSystem.Application.Utils
{
    public static class Helpers
    {
        public static string ArrangeValidationErrors(List<ValidationFailure> validationFailures)
        {
            StringBuilder errors = new StringBuilder();

            foreach (var error in validationFailures)
                errors.Append($"{error}\n");

            return errors.ToString();
        }
    }
}
