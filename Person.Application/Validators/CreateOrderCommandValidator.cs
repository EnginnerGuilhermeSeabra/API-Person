using FluentValidation;
using Person.Application.Commands;
using Person.Application.Util;
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
            RuleFor(x => x.Name)
             .NotEmpty()
             .WithMessage("Nome é obrigatório");

            RuleFor(x => x.BirthDate)
             .NotEmpty()
             .WithMessage("Data de nascimento é obrigatório");

            RuleFor(x => x.CPF)
             .NotEmpty()
             .WithMessage("CPF é obrigatório");


            RuleFor(x => x.CPF)
              .Must(CommonValidators.CPFValidation)
              .WithMessage("CPF inválido");

        }

        public static class CommonValidators
        {
            public static bool CPFValidation(string? arg)
            {
                return DocumentValidation.IsValidCpf(arg);
            }
        }
    }
}
