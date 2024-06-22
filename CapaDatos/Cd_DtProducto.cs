using CapaModelo;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class Cd_DtProducto
    {
        public static Cd_DtProducto _instancia = null;
        private Cd_DtProducto() 
        {
        }

        public static Cd_DtProducto Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia= new Cd_DtProducto();
                }
                return _instancia;
            }
        }

        public List<DtProducto> ObtenerDtProducto()
        {
            var rptListaDtProducto = new List<DtProducto>();
            using (SqlConnection oConexion = new SqlConnection(Connection.ConnectionString()))
            {
                //  SqlCommand cmd = new SqlCommand("VerProductos", oConexion);
                SqlCommand cmd = new SqlCommand("USP_DtProductosObtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rptListaDtProducto.Add(new DtProducto()
                        {
                            Id = Guid.Parse(dr["IdDetalleProd"].ToString()),
                            IdProducto = Guid.Parse(dr["IdProducto"].ToString()),
                            IdMedida = Guid.Parse(dr["IdMedida"].ToString()),
                            Descripcion = dr["Descripcion"].ToString(),
                         //   Estado = Convert.ToBoolean(dr["Estado"].ToString()),
                            Marca = dr["Marca"].ToString(),
                            objProducto = new Producto() { NombreProducto = dr["NombreProducto"].ToString() },
                              Estado= dr["Estado"] == DBNull.Value ? false : Convert.ToBoolean(dr["Estado"].ToString())


                        });
                    }
                    dr.Close();
                    return rptListaDtProducto;
                }
                catch
                {
                    rptListaDtProducto = null;
                    return rptListaDtProducto;
                }
            }
        }

        public bool RegistrarDtProducto(DtProducto oDtProducto)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Connection.ConnectionString()))
            {
                try
                {
                    //SqlCommand cmd = new SqlCommand("sp_RegistrarProductoConGuid", oConexion);
                    SqlCommand cmd = new SqlCommand("USP_AñadirDtProducto", oConexion);
                    Guid NewId = Guid.NewGuid();

                    cmd.Parameters.AddWithValue("IdDetalleProd", NewId);
                    cmd.Parameters.AddWithValue("IdProducto", oDtProducto.IdProducto);
                    cmd.Parameters.AddWithValue("IdMedida", oDtProducto.IdMedida);
                    cmd.Parameters.AddWithValue("Descripcion", oDtProducto.Descripcion);
                    cmd.Parameters.AddWithValue("Estado", oDtProducto.Estado);
                    cmd.Parameters.AddWithValue("Marca", oDtProducto.Marca);
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


        public bool ModificarDtProducto(DtProducto oDtProducto)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Connection.ConnectionString()))
            {
                try
                {
                    //   SqlCommand cmd = new SqlCommand("sp_ModificarProductoConGuid", oConexion);
                    SqlCommand cmd = new SqlCommand("USP_DtProductoActualizar", oConexion);
                    cmd.Parameters.AddWithValue("IdDetalleProd", oDtProducto.Id);
                    cmd.Parameters.AddWithValue("IdProducto", oDtProducto.IdProducto);
                    cmd.Parameters.AddWithValue("IdMedida", oDtProducto.IdMedida);
                    cmd.Parameters.AddWithValue("Descripcion", oDtProducto.Descripcion);
                    cmd.Parameters.AddWithValue("Estado", oDtProducto.Estado);
                    cmd.Parameters.AddWithValue("Marca", oDtProducto.Marca);
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

        public bool EliminarDtProducto(Guid IdDtProducto)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Connection.ConnectionString()))
            {
                try
                {
                    //  SqlCommand cmd = new SqlCommand("spEliminarGuidProducto", oConexion);
                    SqlCommand cmd = new SqlCommand("USP_DtProductoEliminar", oConexion);
                    cmd.Parameters.AddWithValue("IdDetalleProd", IdDtProducto);
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