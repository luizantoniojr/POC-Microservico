using System;

namespace Cliente.Application.EventSide.Events
{
    public class ClienteCadastradoEvent : Event
    {
        public ClienteCadastradoEvent(Guid id, string nome, string email, DateTime dataNascimento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
    }
}