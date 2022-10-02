using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using MySql.Data.MySqlClient;
using Comun.Cache;
namespace Vista
{
    public partial class Productos : Form
    {
        UserModel Modelo = new UserModel();
        Validacion val = new Validacion();
        public Productos()
        {
            InitializeComponent();
            CargarCMB();
            CargarTabla();
            Restringir();
        }

        public void Restringir()
        {
            if (UserCache.PerUsu == "2" || UserCache.PerUsu == "3")
            {
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }
        private void CargarCMB()
        {
            Modelo.CmbCategoriaProd(txtCategoria);
            Modelo.CmbUbicacionProd(txtUbicacion);
            Modelo.CmbMarcaProd(txtMarca);
        }
        private void CargarTabla()
        {
            Modelo.LeerSimple(DGVProductos,"productos","id_prod");
        }
        private void LimpiarCajaTXT()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtCantidad.Clear();
            txtMinimo.Clear();
            txtCritico.Clear();
            txtPrecio.Clear();
            txtCategoria.SelectedIndex = 0;
            txtUbicacion.SelectedIndex = 0;
            txtMarca.SelectedIndex = 0;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombre.Text != "")
                {
                    Modelo.InsertarProd(txtNombre.Text, txtCantidad.Text, txtMinimo.Text,
                    txtCritico.Text, txtPrecio.Text, txtCategoria.Text, txtUbicacion.Text, txtMarca.Text);
                    Modelo.InsertarTransaccion("productos");
                    CargarTabla();
                    LimpiarCajaTXT();
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
                if (txtID.Text != "")
                {
                    Modelo.ModificarProd(txtNombre.Text,txtCantidad .Text,txtMinimo.Text,txtCritico.Text,
                        txtPrecio.Text,txtCategoria.Text,txtUbicacion.Text,txtMarca.Text,txtID.Text);
                    Modelo.Modificartransaccion("productos");
                    CargarTabla();
                    LimpiarCajaTXT();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text != "")
                {
                    Modelo.EliminarProd(txtID.Text);
                    Modelo.EliminarTransaccion("productos");
                    CargarTabla();
                    LimpiarCajaTXT();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Menu principal = new Menu();
            principal.Show();
            this.Hide();
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloNumeros(e);
        }
        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloNumeros(e);
        }
        private void txtMinimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloNumeros(e);
        }
        private void txtCritico_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloNumeros(e);
        }
        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloNumeros(e);
        }

        private void DGVProductos_DoubleClick(object sender, EventArgs e)
        {
            var row = (sender as DataGridView).CurrentRow;
            txtID.Text = row.Cells[0].Value.ToString();
            txtNombre.Text = row.Cells[1].Value.ToString();
            txtCantidad.Text = row.Cells[2].Value.ToString();
            txtMinimo.Text = row.Cells[3].Value.ToString();
            txtCritico.Text = row.Cells[4].Value.ToString();
            txtPrecio.Text = row.Cells[5].Value.ToString();
            txtCategoria.Text = row.Cells[6].Value.ToString();
            txtUbicacion.Text = row.Cells[7].Value.ToString();
            txtMarca.Text = row.Cells[8].Value.ToString();
        }
    }
}
