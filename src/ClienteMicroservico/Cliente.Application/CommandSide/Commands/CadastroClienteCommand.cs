using System;

namespace Cliente.Application.CommandSide.Commands
{
    public class CadastroClienteCommand : Command
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
