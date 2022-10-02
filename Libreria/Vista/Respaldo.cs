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
    public partial class Respaldo : Form
    {
        public Respaldo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string conec = "Data Source = 54.94.32.11; Database = admin_iacc; Uid = Supervisor; Password = Supervisor;";
            string archivo = "D:\\IACC\\2022-03-TIS\\Respaldo\\respaldo.sql";
            using (MySqlConnection conexion = new MySqlConnection(conec))
            {
                using (MySqlCommand comando = new MySqlCommand())
                {
                    using (MySqlBackup respaldo = new MySqlBackup(comando))
                    {
                        try
                        {
                            comando.Connection = conexion;
                            conexion.Open();
                            respaldo.ExportToFile(archivo);
                            MessageBox.Show("Respaldo finalizado");
                            conexion.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
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
