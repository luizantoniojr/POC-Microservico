using Cliente.Application.Bus;
using Cliente.Application.CommandSide.Commands;
using Cliente.Application.EventSide.Events;
using Cliente.Application.QuerySide.Queries;
using MediatR;
using System.Threading.Tasks;

namespace Cliente.Infra.Bus
{
    public class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }

        public Task<R> SendQuery<R, T>(T query) where T : Query<R>
        {
            return _mediator.Send<R>(query);
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            return _mediator.Publish(@event);
        }
    }
}