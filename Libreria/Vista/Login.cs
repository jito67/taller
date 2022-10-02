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
namespace Vista
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (textBox2.Text != "")
                {
                    UserModel modelo = new UserModel();
                    var ValidarLogin = modelo.Login(textBox1.Text, textBox2.Text);
                    if (ValidarLogin == true)
                    {
                        Menu principal = new Menu();
                        principal.Show();
                        this.Hide();
                    }
                    else
                    {
                        MensajeError("Usuario o clave incorrectas");
                        textBox2.Clear();
                        textBox1.Focus();
                    }
                }
                else MensajeError("Ingrese clave");
            }
            else MensajeError("Ingrese usuario");
        }
        private void MensajeError(string msg)
        {
            label3.Text = " " + msg;
            label3.Visible = true;
        }
    }
}
