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
    public partial class Comuna : Form
    {
        Validacion val = new Validacion();
        UserModel Modelo = new UserModel();
        public Comuna()
        {
            InitializeComponent();
            CargarTabla();
            Restringir();
        }

        private void CargarTabla()
        {
            Modelo.LeerSimple(DGVComunas, "comunas", "id_com");
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
                    Modelo.InsertarSimple("comunas", "nom_com", txtNombre.Text);
                    Modelo.InsertarTransaccion("comunas");
                    CargarTabla();
                    LimpiaCajaTXT();
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number==1062)
                {
                    MessageBox.Show("Error: Entrada duplicada.");
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtNombre.Text != "")
            {
                Modelo.ModificarSimple("comunas", "nom_com", "id_com", txtNombre.Text, txtID.Text);
                Modelo.Modificartransaccion("comunas");
                CargarTabla();
                LimpiaCajaTXT();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                Modelo.EliminarSimple("comunas", "id_com", txtID.Text);
                Modelo.EliminarTransaccion("comunas");
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

        private void DGVComunas_DoubleClick(object sender, EventArgs e)
        {
            var row = (sender as DataGridView).CurrentRow;
            txtID.Text = row.Cells[0].Value.ToString();
            txtNombre.Text = row.Cells[1].Value.ToString();
        }
    }
}
