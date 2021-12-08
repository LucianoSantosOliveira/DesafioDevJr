using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desafio1.Modelos;

namespace Desafio1.ControleBancodeDados
{
    public class InserirBD
    {
        Endereco Endereco { get; set; }

        public InserirBD(Endereco endereco)
        {
            this.Endereco = endereco;
            InserirEndereco();
        }

        public void InserirEndereco()
        {

        }
    }
}
