using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Comun.Cache;
namespace Vista
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }
        private void Menu_Load(object sender, EventArgs e)
        {
            CargarCredencialUsuario();
        }

        private void CargarCredencialUsuario()
        {
            label1.Text = "Bienvenido: " + UserCache.NomUsu;
        }

        private void CategoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Categoria cat = new Categoria();
            cat.Show();
            this.Hide();
        }

        private void comunasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Comuna com = new Comuna();
            com.Show();
            this.Hide();
        }

        private void marcasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Marca mar = new Marca();
            mar.Show();
            this.Hide();
        }

        private void ubicacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ubicacion ubi = new Ubicacion();
            ubi.Show();
            this.Hide();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuarios usu = new Usuarios();
            usu.Show();
            this.Hide();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clientes cli = new Clientes();
            cli.Show();
            this.Hide();
        }
        private void respaldarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Respaldo resp = new Respaldo();
            resp.Show();
            this.Hide();
        }

        private void restaurarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Restaurar rest = new Restaurar();
            rest.Show();
            this.Hide();
        }
        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Productos prod = new Productos();
            prod.Show();
            this.Hide();
        }
        private void terminaLaAplicaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ventas ven = new Ventas();
            ven.Show();
            this.Hide();
        }

        private void ayudaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Ayuda help = new Ayuda();
            help.Show();
            this.Hide();
        }
    }
}
