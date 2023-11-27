using FluentValidation;
using Person.Application.Commands;
using Person.Application.Commands.Dtos;
using Person.Infra.Validator;

namespace Person.Application.Validators
{
    public interface ICreatePersonCommandValidator : IValidator<CreatePersonCommand> { }

    public class CreatePersonCommandValidator : CommandValidator<CreatePersonCommand>, ICreatePersonCommandValidator
    {
        public CreatePersonCommandValidator()
        {

        }

        protected override void CreateRules()
        {
            RuleFor(x => x.Email)
             .NotEmpty()
             .WithMessage("Input is required");

            RuleFor(x => x.Email)
             .EmailAddress()
             .WithMessage("Email inválido");

            RuleFor(x => x.Products)
              .NotNull()
              .WithMessage("Lista de produtos está vazia");

            RuleForEach(p => p.Products).ChildRules(child =>
            {
                child.RuleFor(x => x.Value).NotNull().WithMessage("Valor do produto não pode ser vazio");
                child.RuleFor(x => x.Amount).NotNull().WithMessage("Quantidade do produto não pode ser vazio");
                child.RuleFor(x => x.Name).NotNull().WithMessage("Nome do produto não pode ser vazio");
            });
        }
    }
}
