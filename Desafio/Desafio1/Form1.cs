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
                List<Endereco> enderecos = new List<Endereco>();
                Modelos.Endereco endereco = new Modelos.Endereco();
                ChromeOptions options = new ChromeOptions();
                ChromeDriver driver = new ChromeDriver(options);

                driver.Navigate().GoToUrl("https://cep.guiamais.com.br/");
                Thread.Sleep(1500);
                driver.FindElement(By.XPath("//*[@id='campoCEP']")).SendKeys(txtCep.Text);
                Thread.Sleep(1500);
                driver.FindElement(By.XPath("//*[@id='tabDDD']/form/span/div/div/span/button")).Click();
                Thread.Sleep(1500);

                string estadoBairro = driver.FindElement(By.XPath("/html/body/div[2]/div[6]/div[1]/table/tbody/tr/td[4]/a")).Text;
                string[] estadoBairroSeparado = estadoBairro.Split(',');
                endereco.localidade = estadoBairroSeparado[2];
                endereco.estado = estadoBairroSeparado[1];
                endereco.logradouro = driver.FindElement(By.XPath("/html/body/div[2]/div[6]/div[1]/table/tbody/tr/td[1]/a")).Text;
                endereco.cep = txtCep.Text;

                if (!String.IsNullOrEmpty(endereco.localidade) && !String.IsNullOrEmpty(endereco.logradouro) && !String.IsNullOrEmpty(endereco.estado)) 
                {
                    ExibirResultado(endereco);
                }
                else
                {
                    txtCep.Text = "CEP NAO EXISTE";
                }

                
                //ExibirEndereco exibirEndereco = new ExibirEndereco(endereco);
                //exibirEndereco.Show();
                cbCep.Items.Add(txtCep.Text + ", " + endereco.logradouro + ","+endereco.localidade);
                enderecos.Add(endereco);
                driver.Quit();
            }
            catch (Exception ex)
            {
                txtCep.Text = "CEP NAO EXISTE";
            }

            
        }


        public void LimpaLbl()
        {
            lblLogradouro.Text = "";
            lblCep.Text = "";
            lblBairro.Text = "";
            //lblBairro.Text = "Bairro: " + endereco.localidade;
            lblLocalidade.Text = "";
        }
        public void ExibirResultado(Endereco endereco)
        {
            lblLogradouro.Text = "Nome: " + endereco.logradouro;
            lblCep.Text = "Cep: " + endereco.cep;
            lblBairro.Text = "Estado: " + endereco.localidade;
            //lblBairro.Text = "Bairro: " + endereco.localidade;
            lblLocalidade.Text = "Bairro: "+endereco.estado;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] separarCep = cbCep.Text.Split(',');
            txtCep.Text = separarCep[0];
        }
    }
}
