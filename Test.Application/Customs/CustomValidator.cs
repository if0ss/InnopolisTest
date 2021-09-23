using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace Test.Application.Customs
{
    /// <summary>
    /// Кастомный валидатор сущности
    /// </summary>
    public abstract class CustomValidator<T> : AbstractValidator<T>
    {
        public override ValidationResult Validate(ValidationContext<T> context)
        {
            DefineValidation();
            return base.Validate(context);
        }

        public async Task<ValidationResult> ValidateAsync(ValidationContext<T> context)
        {
            DefineValidation();
            return await base.ValidateAsync(context);
        }

        public abstract void DefineValidation();

    }
}