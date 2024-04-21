using CapaModelo;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class Cd_UMedida
    {
        public static Cd_UMedida _instancia = null;
        private Cd_UMedida() 
        {
        }

        public static Cd_UMedida Instancia
        {
            get
            {
                if (_instancia == null) 
                {
                    _instancia= new Cd_UMedida();
                }
                return _instancia;
            }
        }

        public List<UMedida> ObtenerMedida()
        {
            var rptListarMedida = new List<UMedida>();
            using (SqlConnection oConexion = new SqlConnection(Connection.ConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VerMedida", oConexion);
                //   SqlCommand cmd = new SqlCommand("sp_MostrarCategoria", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rptListarMedida.Add(new UMedida()
                        {
                            Id = Guid.Parse(dr["IdMedida"].ToString()),
                            TipoMedida = dr["TipoMedida"].ToString(),
                            Abreviatura = dr["Abreviatura"].ToString(),

                        });
                    }
                    dr.Close();
                    return rptListarMedida;
                }
                catch
                {
                    rptListarMedida = null;
                    return rptListarMedida;
                }
            }
        }

        public bool RegistrarMedida(UMedida medida)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Connection.ConnectionString()))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarMedidaConGuid", oConexion);

                    Guid NewId = Guid.NewGuid();

                    cmd.Parameters.AddWithValue("IdMedida", NewId);
                    cmd.Parameters.AddWithValue("TipoMedida", medida.TipoMedida);
                    cmd.Parameters.AddWithValue("Abreviatura", medida.Abreviatura);
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

        public bool ModificarMedida(UMedida medida)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Connection.ConnectionString()))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_ModificarMedidaConGuid", oConexion);

                    cmd.Parameters.AddWithValue("IdMedida", medida.Id);
                    cmd.Parameters.AddWithValue("TipoMedida", medida.TipoMedida);
                    cmd.Parameters.AddWithValue("Abreviatura", medida.Abreviatura);
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

        public bool EliminarMedida(Guid IdMedida)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Connection.ConnectionString()))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spEliminarGuidMedida", oConexion);
                    cmd.Parameters.AddWithValue("IdMedida", IdMedida);
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
