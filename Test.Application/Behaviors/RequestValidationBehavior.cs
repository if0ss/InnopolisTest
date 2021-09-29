using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Test.Application.CustomValidations;


namespace Test.Application.Behaviors
{
    /// <summary>
    /// Обработчик для валидации входных запросов
    /// </summary>
    public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }


        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var failures = _validators.Select(v => v.Validate(context)).SelectMany(e => e.Errors)
                    .Where(f => f != null).ToList();

                if (failures.Count > 0)
                    throw new CustomValidationException(failures);
            }

            return next();
        }
    }
}