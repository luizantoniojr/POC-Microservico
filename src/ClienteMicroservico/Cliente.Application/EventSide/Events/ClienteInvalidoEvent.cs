using FluentValidation.Results;
using System.Collections.Generic;

namespace Cliente.Application.EventSide.Events
{
    public class ClienteInvalidoEvent : Event
    {
        public ClienteInvalidoEvent(IList<ValidationFailure> validacoes)
        {
            Validacoes = validacoes;
        }

        public IList<ValidationFailure> Validacoes { get; private set; }
    }
}