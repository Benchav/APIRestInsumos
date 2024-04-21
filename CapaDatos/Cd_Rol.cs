using CapaModelo;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
   public class Cd_Rol 
    {
        public static Cd_Rol _instancia = null;
        private Cd_Rol() 
        {
        }

        public static Cd_Rol Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new Cd_Rol();
                }
                return _instancia;
            }
        }
        public List<Rol> ObtenerRol()
        {
            var rptListarRol = new List<Rol>();
            using (SqlConnection oConexion = new SqlConnection(Connection.ConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VerRol", oConexion);
                //   SqlCommand cmd = new SqlCommand("sp_MostrarCategoria", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rptListarRol.Add(new Rol()
                        {
                            Id = Guid.Parse(dr["IdRol"].ToString()),
                            Descripcion = dr["Descripcion"].ToString(),                       
                            FechaCreacion = Convert.ToDateTime(dr["FechaCreacion"].ToString()),
                        });
                    }
                    dr.Close();
                    return rptListarRol;
                }
                catch
                {
                    rptListarRol = null;
                    return rptListarRol;
                }
            }
        }
        public bool RegistrarRol(Rol oRol)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Connection.ConnectionString()))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarRolConGuid", oConexion);

                    Guid NewId = Guid.NewGuid();

                    cmd.Parameters.AddWithValue("IdRol", NewId);
                    cmd.Parameters.AddWithValue("Descripcion", oRol.Descripcion);
                    cmd.Parameters.AddWithValue("FechaCreacion", oRol.FechaCreacion);
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
        public bool ModificarRol(Rol oRol)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Connection.ConnectionString()))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_ModificarRolConGuid", oConexion);

                    cmd.Parameters.AddWithValue("IdRol", oRol.Id);
                    cmd.Parameters.AddWithValue("Descripcion", oRol.Descripcion);
                    cmd.Parameters.AddWithValue("FechaCreacion", oRol.FechaCreacion);
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

        public bool EliminarRol(Guid IdCategoria)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Connection.ConnectionString()))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spEliminarGuidRol", oConexion);
                    cmd.Parameters.AddWithValue("IdRol", IdCategoria);
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
