using CapaModelo;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class Cd_Proveedor
    {
        public static Cd_Proveedor _instancia = null;
        private Cd_Proveedor()
        {
        }
        public static Cd_Proveedor Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new Cd_Proveedor();
                }
                return _instancia;
            }
        }
        public List<Proveedor> ObtenerProveedor()
        {
            var rptListaProveedor = new List<Proveedor>();
            using (SqlConnection oConexion = new SqlConnection(Connection.ConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VerProveedores", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rptListaProveedor.Add(new Proveedor()
                        {
                            Id = Guid.Parse(dr["IdProveedor"].ToString()),
                            NombreCompañia = dr["NombreCompañia"].ToString(),
                            Correo= dr["Correo"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Estado = Convert.ToBoolean(dr["Estado"].ToString()),
                            FechaCreacion = Convert.ToDateTime(dr["FechaCreacion"].ToString()),
                        });
                    }
                    dr.Close();
                    return rptListaProveedor;
                }
                catch
                {
                    rptListaProveedor = null;
                    return rptListaProveedor;
                }
            }
        }
        public bool RegistrarProveedor(Proveedor oProveedor)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Connection.ConnectionString()))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarProveedorConGuid", oConexion);
                    Guid NewId = Guid.NewGuid();

                    cmd.Parameters.AddWithValue("IdProveedor", NewId);
                    cmd.Parameters.AddWithValue("NombreCompañia", oProveedor.NombreCompañia);
                    cmd.Parameters.AddWithValue("Correo", oProveedor.Correo);
                    cmd.Parameters.AddWithValue("Telefono", oProveedor.Telefono);
                    cmd.Parameters.AddWithValue("Estado", oProveedor.Estado);
                    cmd.Parameters.AddWithValue("FechaCreacion", oProveedor.FechaCreacion);
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
        public bool ModificarProveedor(Proveedor oProveedor)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Connection.ConnectionString()))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ModificarProveedorConGuid", oConexion);
                    cmd.Parameters.AddWithValue("IdProveedor", oProveedor.Id);
                    cmd.Parameters.AddWithValue("NombreCompañia", oProveedor.NombreCompañia);
                    cmd.Parameters.AddWithValue("Correo", oProveedor.Correo);
                    cmd.Parameters.AddWithValue("Telefono", oProveedor.Telefono);
                    cmd.Parameters.AddWithValue("Estado", oProveedor.Estado);
                    cmd.Parameters.AddWithValue("FechaCreacion", oProveedor.FechaCreacion);
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
        public bool EliminarProveedor(Guid Id)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Connection.ConnectionString()))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spEliminarGuidProveedor", oConexion);
                    cmd.Parameters.AddWithValue("IdProveedor", Id);
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
