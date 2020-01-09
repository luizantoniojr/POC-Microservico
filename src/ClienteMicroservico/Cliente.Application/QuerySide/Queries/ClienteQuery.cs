using Cliente.Application.QuerySide.QueryResults;
using System;

namespace Cliente.Application.QuerySide.Queries
{
    public class ClienteQuery : Query<ClienteQueryResult>
    {
        public Guid Id { get; set; }
    }
}
