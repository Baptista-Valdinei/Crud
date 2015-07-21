using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cadastrocliente
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CarregarGRid();
              
        }

        private void CarregarGRid()
        {
            Connection con = new Connection();
            dgvcliente.DataSource = con.ExecutaConsulta(Comandos.Select());
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Connection con = new Connection();
            con.ExecutaComando(Comandos.Insert(txtName.Text, txtLastName.Text, txtCity.Text, txtEstado.Text));
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Connection con = new Connection();
            if (con.ExecutaComando(Comandos.Delete(Convert.ToInt32(dgvcliente.CurrentRow.Cells["id"].Value))) == true)
            {
              CarregarGRid();  
            }
           
        }

        /*private void btnUpdate_Click(object sender, EventArgs e)
        {
            Connection con = new Connection();
            if (con.ExecutaComando(Comandos.Update(Convert.ToInt32(dgvcliente.CurrentRow.Cells["id"].Value))) == true)
            {
                CarregarGRid();
            }
        }*/

        private void dgvcliente_DoubleClick(object sender, EventArgs e)
        {
            Connection con = new Connection();

            Comandos.getbyId(Convert.ToInt32(dgvcliente.CurrentRow.Cells["id"].Value));
            DataRow linhaCliente = null;
            Cliente cliente = null;
            string cmd;
            cmd = Comandos.getbyId(Convert.ToInt32(dgvcliente.CurrentRow.Cells["id"].Value));
            if ((linhaCliente = con.ExecutaConsulta(cmd).Rows[0])!= null)
            {
                cliente = new Cliente();
                cliente.id = Convert.ToInt32(linhaCliente["id"]);
                cliente.name = linhaCliente["name"].ToString();
                cliente.lastname = linhaCliente["lastname"].ToString();
                cliente.city = linhaCliente["city"].ToString();
                cliente.estado = linhaCliente["estado"].ToString();

                populatxt(objeto: cliente);
            }            
        }

        private void populatxt(Cliente objeto)
        {
            txtName.Text = objeto.name;
            txtLastName.Text = objeto.lastname;
            txtCity.Text = objeto.city;
            txtEstado.Text = objeto.estado;
            txtid.Text = objeto.id.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            populaobjeto(cli: new Cliente());
        }

        private void populaobjeto(Cliente cli)
        {
            cli.id = Convert.ToInt32(txtid.Text);
            cli.name = txtName.Text;
            cli.lastname = txtLastName.Text;
            cli.city = txtCity.Text;
            cli.estado = txtEstado.Text;
            Connection con = new Connection();
            if (con.ExecutaComando(Comandos.Update(cli))) //sempre retorna um true qnd não especificado
            {
                MessageBox.Show("Cliente alterado com sucesso");
                limparTxt(txtlist: new TextBox[] {txtid, txtName, txtLastName, txtCity, txtEstado});
                CarregarGRid();
            }
        }

        private void limparTxt(TextBox[] txtlist)
        {
            foreach (TextBox txt in txtlist)
            {
                txt.Text = string.Empty;
            }
        }

    }
}

        

      