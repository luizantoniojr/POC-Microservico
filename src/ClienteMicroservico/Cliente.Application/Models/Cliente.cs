using Cliente.Application.Validations;
using FluentValidation.Results;
using System;

namespace Cliente.Application.Models
{
    public class Cliente
    {
        public Cliente(string nome, string email, DateTime dataNascimento)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }

        public ValidationResult Validar() 
        {
            var validator = new ClienteValidator();
            return validator.Validate(this);
        }
    }
}