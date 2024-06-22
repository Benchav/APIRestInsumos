using CapaModelo;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class Cd_Producto 
    {
        public static Cd_Producto _instancia = null;
        private Cd_Producto()
        {
        }
        public static Cd_Producto Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new Cd_Producto();
                }
                return _instancia;
            }
        }
        public List<Producto> ObtenerProducto()
        {
            var rptListaProducto = new List<Producto>();
            using (SqlConnection oConexion = new SqlConnection(Connection.ConnectionString()))
            {
                //  SqlCommand cmd = new SqlCommand("VerProductos", oConexion);
                SqlCommand cmd = new SqlCommand("USP_ProductosObtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rptListaProducto.Add(new Producto()
                        {
                            Id = Guid.Parse(dr["IdProducto"].ToString()),
                            NombreProducto = dr["NombreProducto"].ToString(),
                            IdCategoria = Guid.Parse(dr["IdCategoria"].ToString()),
                            objCategoria = new Categoria() { Descripcion = dr["Descripcion"].ToString() }
                           // Estado = dr["Estado"] == DBNull.Value ? false : Convert.ToBoolean(dr["Estado"].ToString())

                        });
                    }
                    dr.Close();
                    return rptListaProducto;
                }
                catch (Exception ex) 
                {
                    rptListaProducto = null;
                    return rptListaProducto;
                }
            }
        }
        public bool RegistrarProducto(Producto oProducto)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Connection.ConnectionString()))
            {
                try
                {
                    //SqlCommand cmd = new SqlCommand("sp_RegistrarProductoConGuid", oConexion);
                    SqlCommand cmd = new SqlCommand("USP_AñadirProducto", oConexion);
                    Guid NewId = Guid.NewGuid();

                    cmd.Parameters.AddWithValue("IdProducto", NewId);
                    cmd.Parameters.AddWithValue("NombreProducto", oProducto.NombreProducto);
                    cmd.Parameters.AddWithValue("IdCategoria", oProducto.IdCategoria);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                }
                catch
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }
        public bool ModificarProducto(Producto oProducto)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Connection.ConnectionString()))
            {
                try
                {
                 //   SqlCommand cmd = new SqlCommand("sp_ModificarProductoConGuid", oConexion);
                    SqlCommand cmd = new SqlCommand("USP_ProductoActualizar", oConexion);
                    cmd.Parameters.AddWithValue("IdProducto", oProducto.Id);
                    cmd.Parameters.AddWithValue("NombreProducto", oProducto.NombreProducto);
                    cmd.Parameters.AddWithValue("IdCategoria", oProducto.IdCategoria);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                }
                catch
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }
        public bool EliminarProducto(Guid IdProducto)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Connection.ConnectionString()))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_ProductoEliminar", oConexion);
                    cmd.Parameters.AddWithValue("IdProducto", IdProducto);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                }
                catch
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }
    }
}
