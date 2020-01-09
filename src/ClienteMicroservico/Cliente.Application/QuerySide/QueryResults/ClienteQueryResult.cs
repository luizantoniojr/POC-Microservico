using System;

namespace Cliente.Application.QuerySide.QueryResults
{
    public class ClienteQueryResult
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
