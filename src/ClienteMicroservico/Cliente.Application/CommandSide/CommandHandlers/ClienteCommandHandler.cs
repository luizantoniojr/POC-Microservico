using Cliente.Application.Bus;
using Cliente.Application.CommandSide.Commands;
using Cliente.Application.EventSide.Events;
using Cliente.Application.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Cliente.Application.CommandSide.CommandHandlers
{
    public class ClienteCommandHandler : IRequestHandler<CadastroClienteCommand, bool>
    {
        private readonly IMediatorHandler bus;
        private readonly IClienteRepository repository;

        public ClienteCommandHandler(IMediatorHandler bus, IClienteRepository repository)
        {
            this.bus = bus;
            this.repository = repository;
        }

        public Task<bool> Handle(CadastroClienteCommand command, CancellationToken cancellationToken)
        {
            var cliente = new Models.Cliente(command.Nome, command.Email, command.DataNascimento);

            var resultadoValidacao = cliente.Validar();

            if (resultadoValidacao.IsValid)
            {
                repository.InserirCliente(cliente);
                bus.RaiseEvent(new ClienteCadastradoEvent(cliente.Id, 
                    cliente.Nome, cliente.Email, cliente.DataNascimento));

                return Task.FromResult(true);
            }

            bus.RaiseEvent(new ClienteInvalidoEvent(resultadoValidacao.Errors));

            return Task.FromResult(false);
        }
    }
}
