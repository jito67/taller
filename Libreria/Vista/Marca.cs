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
    public partial class Marca : Form
    {
        Validacion val = new Validacion();
        UserModel Modelo = new UserModel();
        public Marca()
        {
            InitializeComponent();
            CargarTabla();
            Restringir();
        }

        private void CargarTabla()
        {
            Modelo.LeerSimple(DGVMarca, "marca", "id_marca");
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
            txtID.Clear();
            txtNombre.Clear();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombre.Text != "")
                {
                    Modelo.InsertarSimple("marca", "desc_marca", txtNombre.Text);
                    Modelo.InsertarTransaccion("marca");
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
            if (txtNombre.Text != "" && txtNombre.Text != "")
            {
                Modelo.ModificarSimple("marca", "desc_marca", "id_marca", txtNombre.Text, txtID.Text);
                Modelo.Modificartransaccion("marca");
                CargarTabla();
                LimpiaCajaTXT();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                Modelo.EliminarSimple("marca", "id_marca", txtID.Text);
                Modelo.EliminarTransaccion("marca");
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

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloNumeros(e);
        }

        private void DGVMarca_DoubleClick(object sender, EventArgs e)
        {
            var row = (sender as DataGridView).CurrentRow;
            txtID.Text = row.Cells[0].Value.ToString();
            txtNombre.Text = row.Cells[1].Value.ToString();
        }
    }
}
