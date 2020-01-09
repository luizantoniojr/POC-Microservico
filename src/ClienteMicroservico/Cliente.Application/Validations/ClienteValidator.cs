using FluentValidation;
using System;

namespace Cliente.Application.Validations
{
    public class ClienteValidator : AbstractValidator<Models.Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(cliente => cliente.Nome)
                .NotEmpty().WithMessage("Favor informar o Nome");

            RuleFor(cliente => cliente.Email)
                .NotEmpty().WithMessage("Favor informar o E-mail")
                .EmailAddress().WithMessage("E-mail inválido");

            RuleFor(cliente => cliente.DataNascimento)
                .Must((dataNascimento) => dataNascimento <= DateTime.Now.AddYears(-18))
                .WithMessage("O Cliente precisa ter 18 anos ou mais");
        }
    }
}