using Cliente.Application.EventSide.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Cliente.Application.EventSide.EventHandlers
{
    public class ClienteEventHandler : INotificationHandler<ClienteCadastradoEvent>,
                                        INotificationHandler<ClienteInvalidoEvent>
    {
        public Task Handle(ClienteCadastradoEvent mensagem, CancellationToken cancellationToken)
        {
            //ToDo: Posta mensagem no rabbitMQ

            return Task.CompletedTask;
        }

        public Task Handle(ClienteInvalidoEvent mensagem, CancellationToken cancellationToken)
        {
            //ToDo: Posta mensagem no rabbitMQ

            return Task.CompletedTask;
        }
    }
}