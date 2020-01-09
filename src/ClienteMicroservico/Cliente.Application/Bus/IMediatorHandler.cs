using Cliente.Application.CommandSide.Commands;
using Cliente.Application.EventSide.Events;
using Cliente.Application.QuerySide.Queries;
using System.Threading.Tasks;

namespace Cliente.Application.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task<R> SendQuery<R, T>(T query) where T : Query<R>;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
