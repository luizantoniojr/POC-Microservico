using Cliente.Infra.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Cliente.RabbitMQAdapter
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection();
            InjectorBootStrapper.RegisterServices(serviceProvider);
            serviceProvider.BuildServiceProvider();
        }
    }
}
