using Cliente.Application.Bus;
using Cliente.Application.QuerySide.Queries;
using Cliente.Application.QuerySide.QueryResults;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cliente.Application.QuerySide.QueryHandlers
{
    public class ClienteQueryHandler : IRequestHandler<ClienteQuery, ClienteQueryResult>
    {
        private readonly IMediatorHandler bus;

        public ClienteQueryHandler(IMediatorHandler bus)
        {
            this.bus = bus;
        }

        public Task<ClienteQueryResult> Handle(ClienteQuery query, CancellationToken cancellationToken)
        {
            //ToDo: Buscar invoices.

            return Task.FromResult(new ClienteQueryResult() { Id = Guid.NewGuid() });
        }
    }
}