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

namespace Vista
{
    public partial class Restaurar : Form
    {
        public Restaurar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //youtube.com/watch?v=wbVb6tH_BDc
            string ruta = "";
            OpenFileDialog abrir = new OpenFileDialog();
            abrir.Filter = "Archivos SQL (*.sql)|*.sql";
            abrir.Title = "Seleccione el respaldo";
            abrir.InitialDirectory = "D:\\IACC\\2022-03-TIS\\Respaldo\\";
            if (abrir.ShowDialog() == DialogResult.OK)
            {
                ruta = abrir.FileName;

                MySqlConnection conexion = new MySqlConnection("Data Source = 54.94.32.11; Database=admin_iacc; Uid=Supervisor; Password=Supervisor;");
                MySqlCommand comando = new MySqlCommand();
                MySqlBackup respaldo = new MySqlBackup(comando);

                comando.Connection = conexion;
                conexion.Open();
                respaldo.ImportFromFile(ruta);
                MessageBox.Show("Base de datos restaurada");
                conexion.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Menu principal = new Menu();
            principal.Show();
            this.Hide();
        }
    }
}
