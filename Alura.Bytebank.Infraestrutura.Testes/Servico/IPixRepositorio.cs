using Alura.Bytebank.Infraestrutura.Testes.Servico.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Bytebank.Infraestrutura.Testes.Servico
{
    public interface IPixRepositorio
    {
        public PixDTO consultaPix(Guid pix);
    }
}
