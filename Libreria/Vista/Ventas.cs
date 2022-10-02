using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using MySql.Data.MySqlClient;
namespace Vista
{
    public partial class Ventas : Form
    {
        //Hora de transaccion

        UserModel Modelo = new UserModel();

        public Ventas()
        {
            InitializeComponent();
            DGVProd.ColumnCount = 8;
            DGVProd.Columns[0].Name = "id_venta";
            DGVProd.Columns[1].Name = "fecha_venta";
            DGVProd.Columns[2].Name = "id_cli";
            DGVProd.Columns[3].Name = "idprod_vta";
            DGVProd.Columns[4].Name = "cant_vta";
            DGVProd.Columns[5].Name = "precio_prod";
            DGVProd.Columns[6].Name = "iva";
            DGVProd.Columns[7].Name = "total_vta";

            if (Modelo.GetMaxId()==0)
            {
                txtVenta.Text = "1";
            }
            else
            {
                txtVenta.Text = Modelo.GetMaxId().ToString();
            }
        }
        public void CargarCombos()
        {
            Modelo.cargarProductos(txtNombreProd);
            Modelo.CargarClientes(txtRut);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Menu principal = new Menu();
            principal.Show();
            this.Hide();
        }

        private void txtNombreProd_SelectedIndexChanged(object sender, EventArgs e)
        {
            Modelo.CajaCMB(txtNombreProd,txtIDProd,txtStockProd,txtPrecio);
        }
        private void txtRut_SelectedIndexChanged(object sender, EventArgs e)
        {
            Modelo.CajaCMBCliente(txtRut,txtNombreCli,txtDireccion,txtComuna);
        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            CargarCombos();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string fec = DateTime.Now.ToString(@"yyyy-MM-dd");
            string hora = DateTime.Now.ToString(@"HH:mm:ss");
            string fecha = fec + " " + hora;
            
            DGVProd.Rows.Add(txtVenta.Text,fecha,txtRut.Text, txtIDProd.Text, txtCantidad.Text,txtPrecio.Text ,txtIVA.Text,txtTotal.Text);
            SumarDGV();
        }

        private void txtQuitar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.DGVProd.SelectedRows)
            {
                DGVProd.Rows.RemoveAt(item.Index);
                SumarDGV();
            }
        }

        private void SumarDGV()
        {
            int sum = 0;
            for (int i = 0; i < DGVProd.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(DGVProd.Rows[i].Cells[7].Value);
            }
            string TotalFormated = sum.ToString("N", new CultureInfo("es-CL"));
            SumaLabel.Text = "$" + TotalFormated;
        }
        private void Subtotal()
        {
            int cant = Convert.ToInt32(txtCantidad.Text);
            double precio = Convert.ToDouble(txtPrecio.Text);
            double SubT = cant * precio;
            txtSub.Text = SubT.ToString();
            double iva = (SubT * 0.19);
            txtIVA.Text = Math.Round(iva,0).ToString();
            txtTotal.Text = Math.Round(SubT + iva,0).ToString();
            
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            if (txtCantidad.Text == "")
            {
                txtCantidad.Text = "0";
            }
            else
            {
                Subtotal();
            }            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DGVProd.Rows.Clear();
            txtRut.SelectedIndex = 0;
            txtNombreProd.SelectedIndex = 0;
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            try
            {
                Modelo.InsertarVentas(DGVProd);
                MessageBox.Show("Venta realizada con éxito");
                txtVenta.Text =  Modelo.GetMaxId().ToString();
                DGVProd.Rows.Clear();
                txtRut.SelectedIndex = 0;
                txtNombreProd.SelectedIndex = 0;
                txtIVA.Clear();
                txtSub.Clear();
                txtPrecio.Clear();
                txtTotal.Clear();
                txtCantidad.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }
    }
}
