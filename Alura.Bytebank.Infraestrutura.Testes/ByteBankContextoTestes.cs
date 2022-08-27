using Alura.ByteBank.Dados.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Bytebank.Infraestrutura.Testes
{
    public class ByteBankContextoTestes
    {

        [Fact]
        public void TEstaConextaoContextoComBDMySQL()
        {
            //Arrange
            var context = new ByteBankContexto();
            bool conectado;

            //Act
            try
            {
                conectado = context.Database.CanConnect();
            }
            catch(Exception e)
            {
                throw new Exception("Nao foi possivel conectar a base de dados.");
            }

            //Assert
            Assert.True(conectado);
        }
    }
}
