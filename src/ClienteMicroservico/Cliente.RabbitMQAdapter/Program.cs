using Cliente.Infra.IoC;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Cliente.Application.Bus;
using Cliente.Application.CommandSide.Commands;

namespace Cliente.RabbitMQAdapter
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            InjectorBootStrapper.RegisterServices(services);
            services.AddMediatR(typeof(Program));
            var serviceProvider = services.BuildServiceProvider();


            var bus = serviceProvider.GetService<IMediatorHandler>();
            bus.SendCommand(new CadastroClienteCommand());
        }
    }
}
