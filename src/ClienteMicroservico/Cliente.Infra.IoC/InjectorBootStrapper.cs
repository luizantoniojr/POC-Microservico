using Cliente.Application.Bus;
using Cliente.Application.CommandSide.CommandHandlers;
using Cliente.Application.CommandSide.Commands;
using Cliente.Application.EventSide.EventHandlers;
using Cliente.Application.EventSide.Events;
using Cliente.Application.QuerySide.Queries;
using Cliente.Application.QuerySide.QueryHandlers;
using Cliente.Application.QuerySide.QueryResults;
using Cliente.Application.Repositories;
using Cliente.Infra.Bus;
using Cliente.Infra.Data;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Cliente.Infra.IoC
{
    public class InjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, InMemoryBus>();


            services.AddScoped<IRequestHandler<CadastroClienteCommand, bool>, ClienteCommandHandler>();
            
            services.AddScoped<IRequestHandler<ClienteQuery, ClienteQueryResult>, ClienteQueryHandler>();
           
            services.AddScoped<INotificationHandler<ClienteCadastradoEvent>, ClienteEventHandler>();
            services.AddScoped<INotificationHandler<ClienteInvalidoEvent>, ClienteEventHandler>();


            services.AddScoped<IClienteRepository, ClienteRepository>();
        }
    }
}
