using Cliente.Application.Bus;
using Cliente.Application.CommandSide.CommandHandlers;
using Cliente.Application.CommandSide.Commands;
using Cliente.Application.EventSide.Events;
using Cliente.Application.Repositories;
using NSubstitute;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using Xunit;

namespace Cliente.Specs.Cliente
{
    [Binding]
    public class CadastroDeClienteSteps
    {
        private readonly IMediatorHandler bus;
        private readonly IClienteRepository repository;
        private bool retorno;
        private CadastroClienteCommand command;

        public CadastroDeClienteSteps()
        {
            command = new CadastroClienteCommand();
            bus = Substitute.For<IMediatorHandler>();
            repository = Substitute.For<IClienteRepository>();
        }

        [Given(@"que o vendedor informe um nome válido")]
        public void DadoQueOVendedorInformeUmNomeValido()
        {
            command.Nome = "João Balão";
        }

        [Given(@"informe um e-mail válido")]
        public void DadoInformeUmE_MailValido()
        {
            command.Email = "jbalao@gmail.com";
        }

        [Given(@"informe uma data de nascimento maior ou igual a (.*) anos")]
        public void DadoInformeUmaDataDeNascimentoMaiorOuIgualAAnos(int idadePermitida)
        {
            var idadePermitidaNegativa = idadePermitida * -1;
            var dataNascimento = DateTime.Now.AddYears(idadePermitidaNegativa);
            command.DataNascimento = dataNascimento;
        }

        [Given(@"que o vendedor informe um nome vazio")]
        public void DadoQueOVendedorInformeONomeVazio()
        {
            command.Nome = string.Empty;
        }

        [Given(@"informe um e-mail vazio")]
        public void DadoInformeUmE_MailVazio()
        {
            command.Email = string.Empty;
        }

        [Given(@"informe um e-mail inválido")]
        public void DadoInformeUmE_MailInvalido()
        {
            command.Email = "jbalao";
        }

        [Given(@"informe uma data de nascimento menor que (.*) anos")]
        public void DadoInformeUmaDataDeNascimentoMenorQueAnos(int idadePermitida)
        {
            var dataNascimento = DateTime.Now;
            dataNascimento.AddYears(idadePermitida - 1);
            command.DataNascimento = dataNascimento;
        }

        [When(@"for solicitado o cadastro")]
        public void QuandoForSolicitadoOCadastro()
        {
            bus.RaiseEvent(Arg.Any<ClienteCadastradoEvent>());
            repository.InserirCliente(Arg.Any<Application.Models.Cliente>());

            var handler = new ClienteCommandHandler(bus, repository);

            retorno = handler.Handle(command, CancellationToken.None).Result;
        }

        [Then(@"o cliente deve ser criado")]
        public void EntaoOClienteDeveSerCriado()
        {
            Assert.True(retorno);
            bus.Received().RaiseEvent(Arg.Any<ClienteCadastradoEvent>());
        }

        [Then(@"deve ser solicitado informar o nome")]
        public void EntaoDeveSerSolicitadoInformarONome()
        {
            Assert.False(retorno);
            bus.Received().RaiseEvent(Arg.Any<ClienteInvalidoEvent>());
        }

        [Then(@"deve ser solicitado informar o e-mail")]
        public void EntaoDeveSerSolicitadoInformarOE_Mail()
        {
            Assert.False(retorno);
            bus.Received().RaiseEvent(Arg.Any<ClienteInvalidoEvent>());
        }

        [Then(@"deve retornar que o e-mail esta inválido")]
        public void EntaoDeveRetornarQueOE_MailEstaInvalido()
        {
            Assert.False(retorno);
            bus.Received().RaiseEvent(Arg.Any<ClienteInvalidoEvent>());
        }

        [Then(@"deve retornar que o cliente precisa ter (.*) anos ou mais")]
        public void EntaoDeveRetornarQueOClientePrecisaTerAnosOuMais(int idade)
        {
            Assert.False(retorno);
            bus.Received().RaiseEvent(Arg.Any<ClienteInvalidoEvent>());
        }
    }
}
