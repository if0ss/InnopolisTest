using FluentValidation;
using Test.Application.CustomValidations;

namespace Test.Application.Products.Commands.Add
{
    public class AddProductValidator : CustomValidator<AddProduct>
    {
        public override void DefineValidation()
        {
            RuleFor(e => e.Name)
                .NotEmpty()
                .WithMessage("'Name' is required'");

            RuleFor(e => e.OkeiId)
                .NotNull()
                .WithMessage("'OkeiId' is required'");

            RuleFor(e => e.UnitPrice)
                .NotNull()
                .WithMessage("'UnitPrice' is required'");
        }
    }
}