using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AccesoDatos; //Usando Capa de datos
using System.Windows.Forms;

namespace Dominio
{
    
    public class UserModel
    {
        UserDAO A = new UserDAO();
        /*INICIO LOGIN MODELO*********************************/
        public bool Login(string user, string pass)
        {
            return A.Login(user,pass);
        }
        /*FIN LOGIN MODELO************************************/

        /*INICIO TRANSACCIONES MODELO*************************/
        public void InsertarTransaccion(string TablaSQL)
        {
            A.InsertarTransacciones(TablaSQL);
        }
        public void Modificartransaccion(string TablaSQL)
        {
            A.ModificarTransacciones(TablaSQL);
        }
        public void EliminarTransaccion(string TablaSQL)
        {
            A.EliminarTransacciones(TablaSQL);
        }
        /*FIN TRANSACCIONES MODELO***************************/

        /*INICIO TABLAS SIMPLES******************************/
        public void LeerSimple(DataGridView ObjetoDGV, string NombreTablaSQL, string CampoSQL)
        {
            A.LeerSimple(ObjetoDGV, NombreTablaSQL, CampoSQL);
        }
        public void InsertarSimple(string TablaSQL, string CampoSQL, string CajaTexto)
        {
            A.InsertarTablaSimple(TablaSQL,CampoSQL,CajaTexto);
        }
        public void ModificarSimple(string TablaSQL, string CampoSQL, string CampoID,string CajaTexto,string CajaID)
        {
            A.ModificarTablaSimple(TablaSQL, CampoSQL, CampoID, CajaTexto, CajaID);
        }
        public void EliminarSimple(string TablaSQL, string CampoSQL, string CajaID)
        {
            A.EliminarTablaSimple(TablaSQL, CampoSQL, CajaID);
        }
        /*FIN TABLAS SIMPLES*********************************/

        /*INICIO MANTENEDOR USUARIOS*/
        public void CargarComboUsuarios(ComboBox comboUsuarios)
        {
            A.CargarComboBox(comboUsuarios);
        }
        public void InsertarUsuario(string CajaNombre, string CajaClave, string CajaPerfil)
        {
            A.InsertarUsuarios(CajaNombre, CajaClave, CajaPerfil);
        }
        public void ModificarrUsuario(string CajaNombre, string CajaClave, string CajaPerfil, string CajaID)
        {
            A.ModificarUsuarios(CajaNombre,CajaClave,CajaPerfil,CajaID);
        }
        public void EliminarUsuario(string CajaID)
        {
            A.EliminarUsuarios(CajaID);
        }
        /*FIN MANTENEDOR USUARIOS*/

        /*INICIO MANTENEDOR CLIENTES*/
        public void CargarComboClientes(ComboBox comboClientes)
        {
            A.CargarComboBoxClientes(comboClientes);
        }
        public void InsertarCliente(string CajaRut, string CajaNombre, string CajaDireccion, string CajaTelefono, string CajaComuna)
        {
            A.InsertarClientes(CajaRut,CajaNombre,CajaDireccion,CajaTelefono,CajaComuna);
        }
        public void ModificarCliente(string CajaRut, string CajaNombre, string CajaDireccion, string CajaTelefono, string CajaComuna, string CajaID)
        {
            A.ModificarClientes(CajaRut, CajaNombre, CajaDireccion, CajaTelefono, CajaComuna, CajaID);
        }
        public void EliminarCliente(string CajaID)
        {
            A.EliminarClientes(CajaID);
        }
        /*FIN MANTENEDOR CLIENTES*/

        /*INICIO MANTENEDOR PRODUCTOS*/
        public void CmbCategoriaProd(ComboBox NombreCombobox)
        {
            A.ComboBoxProductoCategoria(NombreCombobox);
        }
        public void CmbUbicacionProd(ComboBox NombreCombobox)
        {
            A.ComboBoxProductoUbicacion(NombreCombobox);
        }
        public void CmbMarcaProd(ComboBox NombreCombobox)
        {
            A.ComboBoxProductoMarca(NombreCombobox);
        }
        public void InsertarProd(string CajaNombre, string CajaCantidad, string CajaStockMinimo, string CajaStockCritico, string CajaPrecio, string CajaCategoria, string CajaUbicacion, string CajaMarca)
        {
            A.InsertarProductos(CajaNombre,CajaCantidad,CajaStockMinimo,CajaStockCritico,CajaPrecio,CajaCategoria,CajaUbicacion,CajaMarca);
        }
        public void ModificarProd(string CajaNombre, string CajaCantidad, string CajaStockMinimo, string CajaStockCritico, string CajaPrecio, string CajaCategoria, string CajaUbicacion, string CajaMarca, string CajaID) 
        {
            A.ModificarProductos(CajaNombre, CajaCantidad, CajaStockMinimo, CajaStockCritico, CajaPrecio, CajaCategoria, CajaUbicacion, CajaMarca,CajaID);
        }
        public void EliminarProd(string CajaID)
        {
            A.EliminarProductos(CajaID);
        }
        /*FIN MANTENEDOR PRODUCTOS*/

        /*INICIO VENTAS*/
        public void cargarProductos(ComboBox NombreCombobox)
        {
            A.ComboBoxProductoVentas(NombreCombobox);
        }
        public void CajaCMB(ComboBox NombreCombobox, TextBox CajaID, TextBox CajaMin, TextBox CajaPrecio)
        {
            A.CajasCMB(NombreCombobox,CajaID,CajaMin,CajaPrecio);
        }
        public void CargarClientes(ComboBox CajaRut)
        {
            A.ComboBoxClienteVentas(CajaRut);
        }
        public void CajaCMBCliente(ComboBox CajaRut, TextBox CajaNombre, TextBox CajaDir, TextBox CajaCom)
        {
            A.CajaCMBCliente(CajaRut,CajaNombre,CajaDir,CajaCom);
        }
        public int GetMaxId()
        {
            return A.MaxIDVenta();
        }
        public void InsertarVentas(DataGridView DGVenta)
        {
            A.insertarVenta(DGVenta);
        }
        /*FIN VENTAS*/
    }
}
