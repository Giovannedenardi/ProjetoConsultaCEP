using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsultaEndereco
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

 
        private void BtnPesquisa_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(TxtCep.Text))
            {
                using (var ws = new ConsultaCorreios.AtendeClienteClient())
                {
                    try
                    {
                        var endereco = ws.consultaCEP(TxtCep.Text.Trim());
                       
                        TxtRua.Text = endereco.end;
                        TxtBairro.Text = endereco.bairro;
                        TxtCidade.Text = endereco.cidade;
                        TxtEstado.Text = endereco.uf;
                        
                    }
                    catch (System.NullReferenceException)
                    {
                        MessageBox.Show("CEP não existente",this.Text,MessageBoxButtons.OK, MessageBoxIcon.Error);
                       // MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Informe um CEP válido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            TxtRua.Clear();
            TxtBairro.Clear();  
            TxtEstado.Clear();  
            TxtCep.Clear(); 
            TxtCidade.Clear();  

        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
