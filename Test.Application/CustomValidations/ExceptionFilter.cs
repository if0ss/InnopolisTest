using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Test.Application.CustomValidations
{
    /// <summary>
    /// Фильтрация ошибок + обработка
    /// </summary>
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

        public ExceptionFilter()
        {
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {
                {
                    typeof(CustomValidationException), HandleCustomValidationException
                }

            };


        }

        public override void OnException(ExceptionContext context)
        {
            HandleException(context);
            base.OnException(context);
        }

        /// <summary>
        /// Обработка ожидаемых ошибок
        /// </summary>
        private void HandleException(ExceptionContext context)
        {
            var type = context.Exception.GetType();

            if (_exceptionHandlers.Keys.Contains(type))
            {
                _exceptionHandlers[type].Invoke(context);
            }
        }

        /// <summary>
        /// Обработка ошибок валидации
        /// </summary>
        private void HandleCustomValidationException(ExceptionContext context)
        {
            var exception = context.Exception as CustomValidationException;

            var detail = new ValidationProblemDetails(exception?.Errors);

            context.Result = new BadRequestObjectResult(detail);
            context.ExceptionHandled = true;
        }
    }
}