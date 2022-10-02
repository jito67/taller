using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Dominio;
using Comun.Cache;
namespace Vista
{
    public partial class Clientes : Form
    {
        UserModel Modelo = new UserModel();
        Validacion val = new Validacion();
        public Clientes()
        {
            InitializeComponent();
            CargarTabla();
            CargarCMB();
            Restringir();
        }

        private void CargarCMB()
        {
            Modelo.CargarComboClientes(txtComuna);
        }
        private void CargarTabla()
        {
            Modelo.LeerSimple(DGVClientes, "clientes", "id_cli");
        }
        public void Restringir()
        {
            if (UserCache.PerUsu == "2" || UserCache.PerUsu == "3")
            {
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }
        public void LimpiaCajaTXT()
        {
            textBox1.Clear();
            txtRut.Clear();
            txtDv.Clear();
            txtNombre.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtComuna.SelectedIndex = 0;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRut.Text != "" && txtDv.Text != "" && txtNombre.Text != "" && txtDireccion.Text != "" && txtTelefono.Text != "")
                {
                    Modelo.InsertarCliente(txtRut.Text + "-" + txtDv.Text, txtNombre.Text, txtDireccion.Text, txtTelefono.Text, txtComuna.Text);
                    Modelo.InsertarTransaccion("clientes");
                    CargarTabla();
                    LimpiaCajaTXT();
                }

            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    MessageBox.Show("Error: Entrada duplicada.");
                }
            }
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    Modelo.ModificarCliente(txtRut.Text + "-" + txtDv.Text, txtNombre.Text, txtDireccion.Text, txtTelefono.Text, txtComuna.Text, textBox1.Text);
                    Modelo.InsertarTransaccion("clientes");
                    CargarTabla();
                    LimpiaCajaTXT();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Modelo.EliminarCliente(textBox1.Text);
                Modelo.InsertarTransaccion("clientes");
                CargarTabla();
                LimpiaCajaTXT();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Menu principal = new Menu();
            principal.Show();
            this.Hide();
        }

        //Rut
        private void txtRut_TextChanged(object sender, EventArgs e)
        {
            if (txtRut.TextLength == 8)
            {
                val.validaRut(txtRut.Text, txtRut);
            }
        }
        private void txtDv_TextChanged(object sender, EventArgs e)
        {
            if (val.validaRut(txtRut.Text, txtRut) == txtDv.Text)
            {
                MessageBox.Show("Rut Valido");
            }
            else
            {
                if (txtDv.Text == "")
                {
                    return;
                }
                else
                {
                    //textBox2.Clear();
                    MessageBox.Show("Rut incorrecto. Ingrese nuevamente");
                    txtDv.Clear();
                }

            }
        }

        private void txtRut_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloNumeros(e);
        }

        private void DGVClientes_DoubleClick(object sender, EventArgs e)
        {
            var row = (sender as DataGridView).CurrentRow;
            textBox1.Text = row.Cells[0].Value.ToString();

            txtNombre.Text = row.Cells[2].Value.ToString();
            txtDireccion.Text = row.Cells[3].Value.ToString();
            txtTelefono.Text = row.Cells[4].Value.ToString();
            txtComuna.Text = row.Cells[5].Value.ToString();
        }
    }
}
