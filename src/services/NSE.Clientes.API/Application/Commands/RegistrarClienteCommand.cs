using FluentValidation;
using NSE.Core.DomainObjects;
using NSE.Core.Messages;
using System;

namespace NSE.Clientes.API.Application.Commands
{
    public class RegistrarClienteCommand : Command
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }

        public RegistrarClienteCommand(Guid id, string nome, string email, string cpf)
        {
            AggregateId = id;
            Id = id;
            Nome = nome;
            Email = email;
            Cpf = cpf;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegistrarClienteCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class RegistrarClienteCommandValidator : AbstractValidator<RegistrarClienteCommand>
    {
        public RegistrarClienteCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("O Id do cliente deve ser informado.");

            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("O nome do cliente deve ser informado.");

            RuleFor(c => c.Cpf)
                .Must(TerCpfValido)
                .WithMessage("O CPF informado não é válido.");

            RuleFor(c => c.Email)
                .Must(TerEmailValido)
                .WithMessage("O E-mail informado não é válido.");
        }

        protected static bool TerCpfValido(string cpf)
        {
            return Cpf.Validar(cpf);
        }

        protected static bool TerEmailValido(string email)
        {
            return Email.Validar(email);
        }
    }
}
