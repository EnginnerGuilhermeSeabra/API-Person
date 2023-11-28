using FluentValidation;
using Person.Application.Commands;
using Person.Application.Util;
using Person.Infra.Validator;

namespace Person.Application.Validators
{
    public interface IUpdatePersonCommandValidator : IValidator<UpdatePersonCommand> { }

    public class UpdatePersonCommandValidator : CommandValidator<UpdatePersonCommand>, IUpdatePersonCommandValidator
    {
        public UpdatePersonCommandValidator()
        {

        }

        protected override void CreateRules()
        {
            RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("ID é obrigatório");

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
