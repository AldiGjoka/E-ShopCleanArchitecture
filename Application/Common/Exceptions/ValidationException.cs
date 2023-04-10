using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(ValidationResult validationResult)
        {
            ValidationErrors = new List<string>();

            foreach (var error in validationResult.Errors)
            {
                ValidationErrors.Add(error.ErrorMessage);
            }
        }

        public ValidationException(IEnumerable<ValidationFailure> validationFailures)
            : base()
        {
            Errors = validationFailures.GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failure => failure.Key, failure => failure.ToArray());
        }

        public IDictionary<string, string[]> Errors { get; }
        public List<string> ValidationErrors { get; private set; }
    }
}
