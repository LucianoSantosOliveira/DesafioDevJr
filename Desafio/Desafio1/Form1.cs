using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SeleniumExtras;
using System.Threading;
using Desafio1.Modelos;


namespace Desafio1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LimpaLbl();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                LimpaLbl();
                List<Endereco> enderecos = new List<Endereco>();
                Modelos.Endereco endereco = new Modelos.Endereco();
                ChromeOptions options = new ChromeOptions();
                ChromeDriver driver = new ChromeDriver(options);

                #region Navegar ate o site, inserir Cep e pesquisar


                if (txtCep.Text.Length == 8 || (txtCep.Text.Length == 9 && txtCep.Text.IndexOf('-') == 5)) 
                {
                    driver.Navigate().GoToUrl("https://cep.guiamais.com.br/");
                    Thread.Sleep(1500);
                    driver.FindElement(By.XPath("//*[@id='campoCEP']")).SendKeys(txtCep.Text);
                    Thread.Sleep(1500);
                    driver.FindElement(By.XPath("//*[@id='tabDDD']/form/span/div/div/span/button")).Click();
                    Thread.Sleep(1500);
                }
                else
                {
                    lblAvisoCepInvalid.BackColor = Color.Red;
                    lblAvisoCepInvalid.Text = "CEP Invalido";
                    driver.Quit();
                }
                
                #endregion

                #region Montar Objeto Endereço
                    #region Slip para pegar Estado e Bairro
                    string estadoBairro = driver.FindElement(By.XPath("/html/body/div[2]/div[6]/div[1]/table/tbody/tr/td[4]/a")).Text;
                    string[] estadoBairroSeparado = estadoBairro.Split(',');
                    #endregion                
                endereco.localidade = estadoBairroSeparado[2];
                endereco.estado = estadoBairroSeparado[0];
                endereco.logradouro = driver.FindElement(By.XPath("/html/body/div[2]/div[6]/div[1]/table/tbody/tr/td[1]/a")).Text;
                endereco.cep = txtCep.Text;
                #endregion

                #region Verificar se o objeto está preenchido
                if (!String.IsNullOrEmpty(endereco.localidade) && !String.IsNullOrEmpty(endereco.logradouro) && !String.IsNullOrEmpty(endereco.estado)) 
                {
                    ExibirResultado(endereco);
                }
                else
                {
                    txtCep.Text = "CEP NAO EXISTE";
                }
                #endregion

                //ExibirEndereco exibirEndereco = new ExibirEndereco(endereco);
                //exibirEndereco.Show();
                #region Popular combobox de historico de ceps
                cbCep.Items.Add(txtCep.Text + ", " + endereco.logradouro + ","+endereco.localidade);
                #endregion

                #region Alimentar lista de endereços já pesquisada (Lista de objetos endereço)
                enderecos.Add(endereco);
                #endregion
                driver.Quit();
            }
            catch (Exception ex)
            {
                txtCep.Text = "CEP NAO EXISTE";
            }

            
        }


        public void LimpaLbl()
        {
            #region Limpar Labels
            lblLogradouro.Text = "";
            lblCep.Text = "";
            lblBairro.Text = "";
            //lblBairro.Text = "Bairro: " + endereco.localidade;
            lblLocalidade.Text = "";
            lblAvisoCepInvalid.Text = "";
            #endregion
        }
        public void ExibirResultado(Endereco endereco)
        {
            #region Coloca os atributos do objeto endereço para serem exibidos nas Labels
            lblLogradouro.Text = "Nome: " + endereco.logradouro;
            lblCep.Text = "Cep: " + endereco.cep;
            lblBairro.Text = "Estado: " + endereco.localidade;
            //lblBairro.Text = "Bairro: " + endereco.localidade;
            lblLocalidade.Text = "Bairro: "+endereco.estado;
            #endregion
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Atribui o valor do Cep para a Text box de pesquisa, faz o Slip para pegar somente o Cep
            string[] separarCep = cbCep.Text.Split(',');
            txtCep.Text = separarCep[0];
            #endregion
        }
    }
}
