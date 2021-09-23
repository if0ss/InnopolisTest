using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace Test.Application.CustomValidations
{
    /// <summary>
    /// Ошибка валидации
    /// </summary>
    public class CustomValidationException : Exception
    {
        public CustomValidationException() : base("One or more validation failures have occurred")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public CustomValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            var failuresGroups = failures.GroupBy(ex => ex.PropertyName, ex => ex.ErrorMessage);

            foreach (var failure in failuresGroups)
            {
                var propertyName = failure.Key;
                var errors = failure.ToArray();

                Errors.Add(propertyName, errors);
            }
        }

        public IDictionary<string, string[]> Errors;
    }
}