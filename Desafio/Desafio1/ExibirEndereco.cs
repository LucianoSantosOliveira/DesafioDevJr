using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Desafio1.Modelos;
namespace Desafio1
{
    public partial class ExibirEndereco : Form
    {
        public ExibirEndereco(Endereco endereco )
        {
            InitializeComponent();
            lblLogradouro.Text = endereco.logradouro;
            lblCep.Text = endereco.cep;
            lblBairro.Text = endereco.localidade;
            lblBairro.Text = endereco.localidade;
            lblLocalidade.Text = endereco.estado;
        }

        private void ExibirEndereco_Load(object sender, EventArgs e)
        {

        }

        private void lblCep_Click(object sender, EventArgs e)
        {

        }

        private void lblBairro_Click(object sender, EventArgs e)
        {

        }

        private void lblLocalidade_Click(object sender, EventArgs e)
        {

        }

        private void lblLogradouro_Click(object sender, EventArgs e)
        {

        }
    }
}
