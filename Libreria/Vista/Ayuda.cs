using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class Ayuda : Form
    {
        public Ayuda()
        {
            InitializeComponent();
            textBox1.Text = "Menú de ayuda";
        }

        private void HlpCategoria_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Categorías:\r\n\r\n" +
                "En esta tabla se codifica y almacena las distintas categorias de productos, tales como lápices, papelería, pegamentos, etc. Son definiciones generales para la agrupación de productos." +
                "\r\n\r\nInsertar Registros:\r\n\r\n" +
                "Para realizar el ingreso de una categoría bastará que el usuario ingrese el nombre de la categoría y de click en Insertar. Una vez insertados, las categorías aparecerán en el sector derecho como se aprecia en la siguiente imagen." +
                "\r\n\r\nModificar Registros: \r\n\r\n" +
                " Para la modificación de datos, el usuario deberá dar doble clic en la categoría a modificar, de esta manera los datos, pasaran desde el sector derecho al izquierdo, donde se realizará la modificación y luego se dará click en el botón Modificar. " +
                "\r\n\r\nEliminar Registros: \r\n\r\n" +
                "Para la eliminación de un registro, y por motivos de seguridad se requiere permisos de administrador o supervisor. El procedimiento de eliminación es muy simple, y basta con dar doble click en el registro a borrar, pasando los datos a la izquierda del formulario y dar click en el botón Eliminar. De esta manera el registro aparece eliminado en el sector derecho.";
        }

        private void hlpComuna_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Comunas:\r\n\r\n" +
                "En esta tabla se codifica y almacena las distintas categorias de productos, tales como lápices, papelería, pegamentos, etc. Son definiciones generales para la agrupación de productos." +
                "\r\n\r\nInsertar Registros:\r\n\r\n" +
                "Para realizar el ingreso de una categoría bastará que el usuario ingrese el nombre de la categoría y de click en Insertar. Una vez insertados, las categorías aparecerán en el sector derecho como se aprecia en la siguiente imagen." +
                "\r\n\r\nModificar Registros: \r\n\r\n" +
                " Para la modificación de datos, el usuario deberá dar doble clic en la categoría a modificar, de esta manera los datos, pasaran desde el sector derecho al izquierdo, donde se realizará la modificación y luego se dará click en el botón Modificar. " +
                "\r\n\r\nEliminar Registros: \r\n\r\n" +
                "Para la eliminación de un registro, y por motivos de seguridad se requiere permisos de administrador o supervisor. El procedimiento de eliminación es muy simple, y basta con dar doble click en el registro a borrar, pasando los datos a la izquierda del formulario y dar click en el botón Eliminar. De esta manera el registro aparece eliminado en el sector derecho."; 
        }

        private void txtUbicacion_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Ubicacion:\r\n\r\n" +
                "En esta tabla se codifica y almacena las distintas ubicaciones de productos, tales como lápices, papelería, pegamentos, etc. Son definiciones generales para la agrupación de productos." +
                "\r\n\r\nInsertar Registros:\r\n\r\n" +
                "Para realizar el ingreso de una categoría bastará que el usuario ingrese el nombre de la categoría y de click en Insertar. Una vez insertados, las categorías aparecerán en el sector derecho como se aprecia en la siguiente imagen." +
                "\r\n\r\nModificar Registros: \r\n\r\n" +
                " Para la modificación de datos, el usuario deberá dar doble clic en la categoría a modificar, de esta manera los datos, pasaran desde el sector derecho al izquierdo, donde se realizará la modificación y luego se dará click en el botón Modificar. " +
                "\r\n\r\nEliminar Registros: \r\n\r\n" +
                "Para la eliminación de un registro, y por motivos de seguridad se requiere permisos de administrador o supervisor. El procedimiento de eliminación es muy simple, y basta con dar doble click en el registro a borrar, pasando los datos a la izquierda del formulario y dar click en el botón Eliminar. De esta manera el registro aparece eliminado en el sector derecho.";
        }

        private void txtMarcas_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Marcas:\r\n\r\n" +
                "En esta tabla se codifica y almacena las distintas marcas de productos, tales como lápices, papelería, pegamentos, etc. Son definiciones generales para la agrupación de productos." +
                "\r\n\r\nInsertar Registros:\r\n\r\n" +
                "Para realizar el ingreso de una marca bastará que el usuario ingrese el nombre de la categoría y de click en Insertar. Una vez insertados, las categorías aparecerán en el sector derecho como se aprecia en la siguiente imagen." +
                "\r\n\r\nModificar Registros: \r\n\r\n" +
                " Para la modificación de datos, el usuario deberá dar doble clic en la categoría a modificar, de esta manera los datos, pasaran desde el sector derecho al izquierdo, donde se realizará la modificación y luego se dará click en el botón Modificar. " +
                "\r\n\r\nEliminar Registros: \r\n\r\n" +
                "Para la eliminación de un registro, y por motivos de seguridad se requiere permisos de administrador o supervisor. El procedimiento de eliminación es muy simple, y basta con dar doble click en el registro a borrar, pasando los datos a la izquierda del formulario y dar click en el botón Eliminar. De esta manera el registro aparece eliminado en el sector derecho.";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu principal = new Menu();
            principal.Show();
            this.Hide();
        }
    }
}
