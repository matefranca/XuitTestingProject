﻿using Alura.Bytebank.Infraestrutura.Testes.Servico;
using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit.Abstractions;

namespace Alura.Bytebank.Infraestrutura.Testes
{
    public class AgenciaRepositorioTestes
    {
        private readonly IAgenciaRepositorio _repositorio;
        public ITestOutputHelper SaidaConsoleTeste { get; set; }

        public AgenciaRepositorioTestes(ITestOutputHelper _saidaConsoleTeste)
        {
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor executado com sucesso!");

            var servico = new ServiceCollection();
            servico.AddTransient<IAgenciaRepositorio, AgenciaRepositorio>();

            var provedor = servico.BuildServiceProvider();
            _repositorio = provedor.GetService<IAgenciaRepositorio>();
        }

        [Fact]
        public void TestaObterTodasAgencias()
        {
            //Arrange         

            //Act
            List<Agencia> lista = _repositorio.ObterTodos();

            //Assert
            Assert.NotNull(lista);
        }

        [Fact]
        public void TestaObterAgenciaPorId()
        {
            //Arrange

            //Act
            var agencia = _repositorio.ObterPorId(1);

            //Assert
            Assert.NotNull(agencia);

        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void TestaObterAgenciasPorVariosId(int id)
        {
            //Arrange       

            //Act
            var agencia = _repositorio.ObterPorId(id);

            //Assert
            Assert.NotNull(agencia);

        }

        [Fact]
        public void TesteInserirUmaNovaAgenciaNaBaseDeDados()
        {
            //Arrange
            string nome = "Agência Guarapari";
            int numero = 125982;
            Guid identificador = Guid.NewGuid();
            string endereco = "Rua: 7 de Setembro - Centro";

            var agencia = new Agencia()
            {
                Nome = nome,
                Identificador = identificador,
                Endereco = endereco,
                Numero = numero
            };

            //Act 
            var retorno = _repositorio.Adicionar(agencia);

            //Assert
            Assert.True(retorno);
        }

        [Fact]

        public void TestaAtualizacaoInformacaoDeterminadaAgencia()
        {
            //Arrange
            var agencia = _repositorio.ObterPorId(2);
            var nomeNovo = "Agencia Nova";
            agencia.Nome = nomeNovo;

            //Act
            var atualizado = _repositorio.Atualizar(2, agencia);

            //Assert
            Assert.True(atualizado);
        }

        [Fact]
        public void TestaRemoverInformacaoDeterminadaAgencia()
        {
            //Arrange
            //Act
            var atualizado = _repositorio.Excluir(6);

            //Assert
            Assert.True(atualizado);
        }

        [Fact]
        public void TestarExcecaoConsultaPorAgenciaPorId()
        {
            //Act
            //Assert
            Assert.Throws<Exception>(
                    () => _repositorio.ObterPorId(33)
                );
        }

        [Fact]
        public void TestaAdicionarAgenciaMock()
        {
            //Arrange
            var agencia = new Agencia()
            {
                Nome = "Agencia Amaral",
                Identificador = Guid.NewGuid(),
                Id = 4,
                Endereco = "Rua Arthur Costa",
                Numero = 6497
            };

            var repositorioMock = new ByteBankRepositorio();

            //Act
            var adicionado = repositorioMock.AdicionarAgencia(agencia);

            //Assert
            Assert.True(adicionado);
        }

        [Fact]
        public void TestaObterAgenciaMock()
        {
            //Arrange
            var bytebankRepositorioMock = new Mock<IByteBankRepositorio>();
            var mock = bytebankRepositorioMock.Object;

            //Act
            var lista = mock.BuscarAgencias();

            //Assert
            bytebankRepositorioMock.Verify(b => b.BuscarAgencias());
        }
    }
}
