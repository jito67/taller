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
    public partial class Usuarios : Form
    {
        UserModel Modelo = new UserModel();
        public Usuarios()
        {
            InitializeComponent();
            CargarTabla();
            CargarCMB();
            Restringir();
        }

        private void CargarCMB()
        {
            Modelo.CargarComboUsuarios(txtPerfiles);
        }
        private void CargarTabla()
        {
            Modelo.LeerSimple(DGVUsuario, "usuarios", "id_usu");
        }
        private void LimpiarCajaTXT()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtClave.Clear();
            txtPerfiles.SelectedIndex = 0;
        }
        private void Restringir()
        {
            if (UserCache.PerUsu != "1")
            {
                btnInsertar.Enabled = false;
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
                DGVUsuario.Visible = false;
                txtPerfiles.Visible = false;
                label4.Visible = false;
            }

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombre.Text != "" && txtClave.Text != "" && txtPerfiles.Text != "")
                {
                    Modelo.InsertarUsuario(txtNombre.Text, txtClave.Text, txtPerfiles.Text);
                    Modelo.InsertarTransaccion("usuarios");
                    CargarTabla();
                    LimpiarCajaTXT();
                }
                else
                {
                    MessageBox.Show("Complete todos los campos");
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
                Modelo.ModificarrUsuario(txtNombre.Text, txtClave.Text, txtPerfiles.Text, txtID.Text);
                Modelo.Modificartransaccion("usuarios");
                CargarTabla();
                LimpiarCajaTXT();
            }
            catch (Exception)
            {
                MessageBox.Show("Error en la modificacion de usuarios");
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text != "")
                {
                    Modelo.EliminarUsuario(txtID.Text);
                    CargarTabla();
                    LimpiarCajaTXT();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al eliminar usuarios");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Menu principal = new Menu();
            principal.Show();
            this.Hide();
        }

        private void txtPerfiles_SelectedValueChanged(object sender, EventArgs e)
        {
            if (txtPerfiles.Text == "1")
            {
                label4.Text = "Supervisor";
            }
            else if (txtPerfiles.Text == "2")
            {
                label4.Text = "Digitador";
            }
            else if (txtPerfiles.Text == "3")
            {
                label4.Text = "Vendedor";
            }
        }

        private void DGVUsuario_DoubleClick(object sender, EventArgs e)
        {
            var row = (sender as DataGridView).CurrentRow;
            txtID.Text = row.Cells[0].Value.ToString();
            txtNombre.Text = row.Cells[1].Value.ToString();
            txtClave.Text = row.Cells[2].Value.ToString();
            txtPerfiles.Text = row.Cells[3].Value.ToString();
        }
    }
}
