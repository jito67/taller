using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Comun.Cache;


namespace AccesoDatos
{
    //HEREDA DE CONEXION
    public class UserDAO : Conexion
    {
        //FECHAS PARA LA HORA DE LA TRANSACCION.
        static string fec = DateTime.Now.ToString(@"yyyy-MM-dd");
        static string hora = DateTime.Now.ToString(@"HH:mm:ss");
        string fecha = fec + " " + hora;
        DataTable dt2 = new DataTable();
        DataTable max = new DataTable();
        /**************************************LOGIN******************************************************/
        public bool Login(string user, string pass)
        {
            using (var conexion = Conectarse())
            {
                conexion.Open();
                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = "SELECT * FROM usuarios where nom_usu=?user and clave_usu=?pass";
                    comando.Parameters.AddWithValue("?user", user);
                    comando.Parameters.AddWithValue("?pass", pass);
                    comando.CommandType = CommandType.Text;
                    MySqlDataReader reader = comando.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            UserCache.NomUsu = reader.GetString(1);
                            UserCache.PerUsu = reader.GetString(3);
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        /**************************************FIN LOGIN**************************************************/

        /***********************************TRANSACCIONES*************************************************/
        public void InsertarTransacciones(string TablaSQL)
        {
            string Consulta = "INSERT INTO transacciones (operacion,usuario,modificado,tabla)" +
                " VALUES ('INSERTAR','" + UserCache.NomUsu + "','" + fecha + "','" + TablaSQL + "')";
            using (var conexion = Conectarse())
            {
                conexion.Open();
                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = Consulta;
                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                }
            }
        }
        public void ModificarTransacciones(string TablaSQL)
        {
            string Consulta = "INSERT INTO transacciones (operacion,usuario,modificado,tabla)" +
                " VALUES ('MODIFICAR','" + UserCache.NomUsu + "','" + fecha + "','" + TablaSQL + "')";
            using (var conexion = Conectarse())
            {
                conexion.Open();
                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = Consulta;
                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                }
            }
        }
        public void EliminarTransacciones(string TablaSQL)
        {
            string Consulta = "INSERT INTO transacciones (operacion,usuario,modificado,tabla)" +
                " VALUES ('ELIMINAR','" + UserCache.NomUsu + "','" + fecha + "','" + TablaSQL + "')";
            using (var conexion = Conectarse())
            {
                conexion.Open();
                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = Consulta;
                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                }
            }
        }
        /**********************************FIN TRANSACCIONES*********************************************/

        /*********************************TABLAS SIMPLES*************************************************/
        public DataTable LeerSimple(DataGridView ObjetoDGV, string NombreTablaSQL, string CampoSQL)
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            BindingSource bs = new BindingSource();
            da = null;
            using (var conexion = Conectarse())
            {
                da = new MySqlDataAdapter("SELECT * FROM " + NombreTablaSQL + " ORDER BY " + CampoSQL + " ASC;", conexion);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                dt.Clear();
                da.Fill(dt);
                bs.DataSource = dt;
                ObjetoDGV.DataSource = bs;
                da = null;
                conexion.Close();
                return dt;
            }
        }
        public void InsertarTablaSimple(string TablaSQL, string CampoSQL, string CajaTexto)
        {
            //SE CREA LA CONSULTA Y SE PASA AL COMANDO DE SQL
            string Consulta = "INSERT INTO " + TablaSQL + " (" + CampoSQL + ") VALUES ('" + CajaTexto + "')";
            using (var conexion = Conectarse())
            {
                conexion.Open();
                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = Consulta;
                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Registro insertado en " + TablaSQL);
                }
            }
        }
        public void ModificarTablaSimple(string TablaSQL, string CampoSQL, string CampoID, string CajaTexto, string CajaID)
        {
            string Consulta = "UPDATE " + TablaSQL + " SET " + CampoSQL + "=('" + CajaTexto + "') WHERE " + CampoID + "=('" + CajaID + "')";
            using (var conexion = Conectarse())
            {
                conexion.Open();
                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = Consulta;
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Registro modificado en " + TablaSQL);
                }
            }
        }
        public void EliminarTablaSimple(string TablaSQL, string CampoSQL, string CajaID)
        {
            string Consulta = "DELETE FROM " + TablaSQL + " WHERE " + CampoSQL + "=('" + CajaID + "')";
            using (var conexion = Conectarse())
            {
                conexion.Open();
                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = Consulta;
                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Registro eliminado en " + TablaSQL);
                }
            }
        }
        /********************************FIN TABLAS SIMPLES***************************************************/

        /**********************************USUARIOS***********************************************************/
        public void CargarComboBox(ComboBox NombreCombobox)
        {
            try
            {
                DataTable dtComboBox = new DataTable();
                MySqlDataReader dr;
                MySqlCommand cmd2 = new MySqlCommand();
                MySqlDataAdapter da2 = new MySqlDataAdapter();
                using (var conexion = Conectarse())
                {
                    conexion.Open();
                    cmd2 = new MySqlCommand("SELECT id_per from perfiles", conexion);
                    da2.SelectCommand = cmd2;
                    da2.Fill(dtComboBox);

                    dr = cmd2.ExecuteReader();

                    //dtComboBox.Load(dr);

                    NombreCombobox.ValueMember = "id_per";
                    NombreCombobox.DataSource = dtComboBox;

                    conexion.Close();
                    conexion.Dispose();
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "No se han podido cargar perfiles en ComboBox.");
            }
        }
        public void InsertarUsuarios(string CajaNombre, string CajaClave, string CajaPerfil)
        {
            string Consulta = "INSERT INTO usuarios (nom_usu, clave_usu, per_usu) VALUES" +
                " ('" + CajaNombre + "','" + CajaClave + "','" + CajaPerfil + "')";
            using (var conexion = Conectarse())
            {
                conexion.Open();
                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = Consulta;
                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Registro insertado en usuarios");
                }
            }
        }
        public void ModificarUsuarios(string CajaNombre, string CajaClave, string CajaPerfil, string CajaID)
        {
            string Consulta = "UPDATE usuarios SET " +
                                "nom_usu=('" + CajaNombre + "')," +
                                "clave_usu=('" + CajaClave + "')," +
                                "per_usu=('" + CajaPerfil + "') " +
                                "WHERE id_usu=('" + CajaID + "')";

            using (var conexion = Conectarse())
            {
                conexion.Open();
                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = Consulta;
                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Registro modificado" +
                        " en usuarios");
                }
            }
        }
        public void EliminarUsuarios(string CajaID)
        {
            string Consulta = "DELETE FROM usuarios WHERE id_usu=('" + CajaID + "')";
            using (var conexion = Conectarse())
            {
                conexion.Open();
                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = Consulta;
                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Registro insertado en usuarios");
                }
            }
        }
        /**********************************FIN USUARIOS******************************************************/

        /**********************************CLIENTES**********************************************************/
        public void CargarComboBoxClientes(ComboBox NombreCombobox)
        {
            try
            {
                DataTable dtComboBox = new DataTable();
                MySqlDataReader dr;
                MySqlCommand cmd2 = new MySqlCommand();
                MySqlDataAdapter da2 = new MySqlDataAdapter();
                using (var conexion = Conectarse())
                {
                    conexion.Open();
                    cmd2 = new MySqlCommand("SELECT id_com from comunas ORDER BY id_com ASC", conexion);
                    da2.SelectCommand = cmd2;
                    da2.Fill(dtComboBox);

                    dr = cmd2.ExecuteReader();

                    NombreCombobox.ValueMember = "id_com";
                    NombreCombobox.DataSource = dtComboBox;

                    conexion.Close();
                    conexion.Dispose();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "No se han podido cargar perfiles en ComboBox.");
            }
        }
        public void InsertarClientes(string CajaRut, string CajaNombre, string CajaDireccion, string CajaTelefono, string CajaComuna)
        {
            string Consulta = "INSERT INTO clientes (rut_cli, nom_cli, dir_cli,tel_cli,com_cli) VALUES" +
                " ('" + CajaRut + "','" + CajaNombre + "','" + CajaDireccion + "','" + CajaTelefono + "','" + CajaComuna + "')";
            using (var conexion = Conectarse())
            {
                conexion.Open();
                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = Consulta;
                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Registro insertado en clientes");
                }
            }
        }
        public void ModificarClientes(string CajaRut, string CajaNombre, string CajaDireccion, string CajaTelefono, string CajaComuna, string CajaID)
        {
            string Consulta = "UPDATE clientes SET " +
                                "rut_cli=('" + CajaRut + "')," +
                                "nom_cli=('" + CajaNombre + "')," +
                                "dir_cli=('" + CajaDireccion + "'), " +
                                "tel_cli=('" + CajaTelefono + "'), " +
                                "com_cli=('" + CajaComuna + "') " +
                                "WHERE id_cli=('" + CajaID + "')";

            using (var conexion = Conectarse())
            {
                conexion.Open();
                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = Consulta;
                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Registro modificado en clientes");
                }
            }
        }
        public void EliminarClientes(string CajaID)
        {
            string Consulta = "DELETE FROM clientes WHERE id_cli=('" + CajaID + "')";
            using (var conexion = Conectarse())
            {
                conexion.Open();
                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = Consulta;
                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Registro eliminado en clientes");
                }
            }
        }
        /*********************************FIN CLIENTES********************************************************/

        /***********************************PRODUCTOS**********************************************************/
        public void ComboBoxProductoCategoria(ComboBox NombreCombobox)
        {
            try
            {
                DataTable dtComboBox = new DataTable();
                MySqlDataReader dr;
                MySqlCommand cmd2 = new MySqlCommand();
                MySqlDataAdapter da2 = new MySqlDataAdapter();
                using (var conexion = Conectarse())
                {
                    conexion.Open();
                    cmd2 = new MySqlCommand("SELECT id_cat from categorias ORDER BY id_cat ASC", conexion);
                    da2.SelectCommand = cmd2;
                    da2.Fill(dtComboBox);

                    dr = cmd2.ExecuteReader();

                    NombreCombobox.ValueMember = "id_cat";
                    NombreCombobox.DataSource = dtComboBox;

                    conexion.Close();
                    conexion.Dispose();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "No se han podido cargar categorias en ComboBox.");
            }
        }
        public void ComboBoxProductoUbicacion(ComboBox NombreCombobox)
        {
            try
            {
                DataTable dtComboBox = new DataTable();
                MySqlDataReader dr;
                MySqlCommand cmd2 = new MySqlCommand();
                MySqlDataAdapter da2 = new MySqlDataAdapter();
                using (var conexion = Conectarse())
                {
                    conexion.Open();
                    cmd2 = new MySqlCommand("SELECT id_ubic from ubicacion ORDER BY id_ubic ASC", conexion);
                    da2.SelectCommand = cmd2;
                    da2.Fill(dtComboBox);

                    dr = cmd2.ExecuteReader();

                    NombreCombobox.ValueMember = "id_ubic";
                    NombreCombobox.DataSource = dtComboBox;

                    conexion.Close();
                    conexion.Dispose();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "No se han podido cargar ubicaciones en ComboBox.");
            }
        }
        public void ComboBoxProductoMarca(ComboBox NombreCombobox)
        {
            try
            {
                DataTable dtComboBox = new DataTable();
                MySqlDataReader dr;
                MySqlCommand cmd2 = new MySqlCommand();
                MySqlDataAdapter da2 = new MySqlDataAdapter();
                using (var conexion = Conectarse())
                {
                    conexion.Open();
                    cmd2 = new MySqlCommand("SELECT id_marca from marca ORDER BY id_marca ASC", conexion);
                    da2.SelectCommand = cmd2;
                    da2.Fill(dtComboBox);

                    dr = cmd2.ExecuteReader();

                    NombreCombobox.ValueMember = "id_marca";
                    NombreCombobox.DataSource = dtComboBox;

                    conexion.Close();
                    conexion.Dispose();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "No se han podido cargar categorias en ComboBox.");
            }
        }
        public void InsertarProductos(string CajaNombre, string CajaCantidad, string CajaStockMinimo, string CajaStockCritico, string CajaPrecio, string CajaCategoria, string CajaUbicacion, string CajaMarca)
        {
            string Consulta = "INSERT INTO productos (nom_prod, cant_prod, stmin_prod,stcrit_prod,precio_prod,cat_prod,ubic_prod,marca_prod) VALUES" +
                " ('" + CajaNombre + "','" + CajaCantidad + "','" + CajaStockMinimo + "','" + CajaStockCritico + "','" + CajaPrecio + "'" +
                ",'" + CajaCategoria + "','" + CajaUbicacion + "','" + CajaMarca + "')";
            using (var conexion = Conectarse())
            {
                conexion.Open();
                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = Consulta;
                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Registro insertado en productos");
                }
            }
        }
        public void ModificarProductos(string CajaNombre, string CajaCantidad, string CajaStockMinimo, string CajaStockCritico, string CajaPrecio, string CajaCategoria, string CajaUbicacion, string CajaMarca, string CajaID)
        {
            string Consulta = "UPDATE productos SET " +
                                "nom_prod=('" + CajaNombre + "')," +
                                "cant_prod=('" + CajaCantidad + "')," +
                                "stmin_prod=('" + CajaStockMinimo + "'), " +
                                "stcrit_prod=('" + CajaStockCritico + "'), " +
                                "precio_prod=('" + CajaPrecio + "'), " +
                                "cat_prod=('" + CajaCategoria + "'), " +
                                "ubic_prod=('" + CajaUbicacion + "'), " +
                                "marca_prod=('" + CajaMarca + "') " +
                                "WHERE id_prod=('" + CajaID + "')";

            using (var conexion = Conectarse())
            {
                conexion.Open();
                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = Consulta;
                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Registro modificado en productos");
                }
            }
        }
        public void EliminarProductos(string CajaID)
        {
            string Consulta = "DELETE FROM productos WHERE id_prod=('" + CajaID + "')";
            using (var conexion = Conectarse())
            {
                conexion.Open();
                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = Consulta;
                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Registro eliminado en productos");
                }
            }
        }
        /***********************************FIN PRODUCTOS*******************************************************/

        /*************************************VENTAS**************************************************************/
        //CARGA COMBOBOX
        public void ComboBoxProductoVentas(ComboBox NombreCombobox)
        {
            try
            {
                DataTable dtComboBox = new DataTable();
                MySqlDataReader dr;
                MySqlCommand cmd2 = new MySqlCommand();
                MySqlDataAdapter da2 = new MySqlDataAdapter();
                using (var conexion = Conectarse())
                {
                    conexion.Open();
                    cmd2 = new MySqlCommand("SELECT nom_prod from productos ORDER BY id_prod ASC", conexion);
                    da2.SelectCommand = cmd2;
                    da2.Fill(dtComboBox);

                    dr = cmd2.ExecuteReader();

                    NombreCombobox.ValueMember = "nom_prod";
                    NombreCombobox.DataSource = dtComboBox;

                    conexion.Close();
                    conexion.Dispose();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "No se han podido cargar productos en ComboBox.");
            }
        }
        public void CajasCMB(ComboBox NombreCombobox, TextBox CajaID, TextBox CajaMin, TextBox CajaPrecio)
        {
            MySqlDataReader dr;
            MySqlCommand cmd2 = new MySqlCommand();
            MySqlDataAdapter da2 = new MySqlDataAdapter();
            using (var conexion = Conectarse())
            {
                conexion.Open();
                cmd2 = new MySqlCommand("SELECT id_prod,stmin_prod,precio_prod from productos WHERE nom_prod= '" + NombreCombobox.Text + "' ORDER BY id_prod ASC", conexion);
                cmd2.ExecuteNonQuery();
                dr = cmd2.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        CajaID.Text = dr.GetString("id_prod"); ;
                        CajaMin.Text = dr.GetString("stmin_prod");
                        CajaPrecio.Text = dr.GetString("precio_prod");
                    }
                }
            }
        }
        public void ComboBoxClienteVentas(ComboBox NombreCombobox)
        {
            try
            {
                DataTable dtComboBox = new DataTable();
                MySqlDataReader dr;
                MySqlCommand cmd2 = new MySqlCommand();
                MySqlDataAdapter da2 = new MySqlDataAdapter();
                using (var conexion = Conectarse())
                {
                    conexion.Open();
                    cmd2 = new MySqlCommand("SELECT rut_cli from clientes ORDER BY id_cli ASC", conexion);
                    da2.SelectCommand = cmd2;
                    da2.Fill(dtComboBox);

                    dr = cmd2.ExecuteReader();

                    NombreCombobox.ValueMember = "rut_cli";
                    NombreCombobox.DataSource = dtComboBox;

                    conexion.Close();
                    conexion.Dispose();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "No se han podido cargar clientes en ComboBox.");
            }
        }
        public void CajaCMBCliente(ComboBox CajaRut, TextBox CajaNombre, TextBox CajaDir, TextBox CajaCom)
        {
            MySqlDataReader dr;
            MySqlCommand cmd2 = new MySqlCommand();
            MySqlDataAdapter da2 = new MySqlDataAdapter();
            using (var conexion = Conectarse())
            {
                conexion.Open();
                cmd2 = new MySqlCommand("SELECT nom_cli,dir_cli,com_cli from clientes WHERE rut_cli= '" + CajaRut.Text + "' ORDER BY id_cli ASC", conexion);
                cmd2.ExecuteNonQuery();
                dr = cmd2.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        CajaNombre.Text = dr.GetString("nom_cli"); ;
                        CajaDir.Text = dr.GetString("dir_cli");
                        CajaCom.Text = dr.GetString("com_cli");
                    }
                }
            }
        }
        //FIN CARGA COMBOBOX
        public int MaxIDVenta()
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            BindingSource bs = new BindingSource();
            da = null;
            using (var conexion = Conectarse())
            {
                conexion.Open();
                using (var comando = new MySqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = "SELECT MAX(id_venta) FROM ventas";

                    if (!DBNull.Value.Equals(comando.CommandText))
                    {
                        int maxId = Convert.ToInt32(comando.ExecuteScalar());
                        return maxId+1;
                    }
                    else
                    {
                        int maxId = Convert.ToInt32(comando.ExecuteScalar());
                        return maxId + 1;

                    }

                }
            }

        }

        public void insertarVenta(DataGridView DGVVenta)
        {
            string StrQuery;
            try
            {
                using (var conexion = Conectarse())
                {
                    using (MySqlCommand comm = new MySqlCommand())
                    {
                        comm.Connection = conexion;
                        conexion.Open();
                        for (int i = 0; i < DGVVenta.Rows.Count; i++)
                        {
                            StrQuery = @"INSERT INTO ventas (id_venta,fec_vta,id_cli,idprodvta,cant_vta,precio_prod,iva,total_vta)
                                VALUES ('"
                                + DGVVenta.Rows[i].Cells[0].Value.ToString() + "', '"
                                + DGVVenta.Rows[i].Cells[1].Value.ToString() + "', '"
                                + DGVVenta.Rows[i].Cells[2].Value.ToString() + "', '"
                                + DGVVenta.Rows[i].Cells[3].Value.ToString() + "', '"
                                + DGVVenta.Rows[i].Cells[4].Value.ToString() + "', '"
                                + DGVVenta.Rows[i].Cells[5].Value.ToString() + "', '"
                                + DGVVenta.Rows[i].Cells[6].Value.ToString() + "', '"
                                + DGVVenta.Rows[i].Cells[7].Value.ToString() + "');";
                            comm.CommandText = StrQuery;
                            comm.ExecuteNonQuery();

                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        /************************************FIN VENTAS**********************************************************/
    }
}
