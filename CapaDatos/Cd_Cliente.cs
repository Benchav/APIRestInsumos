using CapaModelo;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class Cd_Cliente
    {
        public static Cd_Cliente _instancia = null;
        private Cd_Cliente() 
        {
        }

        public static Cd_Cliente Instancia
        {
            get
            {
                if (_instancia == null) 
                {
                  _instancia = new Cd_Cliente();
                }
                return _instancia;
            }
        }

        public List<Cliente> ObtenerCliente()
        {
            var rptListaCliente = new List<Cliente>();
            using (SqlConnection oConexion = new SqlConnection(Connection.ConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VerCliente", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rptListaCliente.Add(new Cliente()
                        {
                            Id = Guid.Parse(dr["IdCliente"].ToString()),
                            PrimerNombre = dr["PrimerNombre"].ToString(),
                            SegundoNombre = dr["SegundoNombre"].ToString(),
                            PrimerApellido = dr["PrimerApellido"].ToString(),
                            SegundoApellido = dr["SegundoApellido"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Estado = Convert.ToBoolean(dr["Estado"].ToString()),
                            FechaCreacion = Convert.ToDateTime(dr["FechaCreacion"].ToString()),
                        });
                    }
                    dr.Close();
                    return rptListaCliente;
                }
                catch
                {
                    rptListaCliente = null;
                    return rptListaCliente;
                }
            }
        }

        public bool RegistrarCliente(Cliente oCliente)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Connection.ConnectionString()))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarClienteConGuid", oConexion);

                    Guid NewId = Guid.NewGuid();

                    cmd.Parameters.AddWithValue("IdCliente", NewId);
                    cmd.Parameters.AddWithValue("PrimerNombre", oCliente.PrimerNombre);
                    cmd.Parameters.AddWithValue("SegundoNombre", oCliente.SegundoNombre);
                    cmd.Parameters.AddWithValue("PrimerApellido", oCliente.PrimerApellido);
                    cmd.Parameters.AddWithValue("SegundoApellido", oCliente.SegundoApellido);
                    cmd.Parameters.AddWithValue("Correo", oCliente.Correo);
                    cmd.Parameters.AddWithValue("Telefono", oCliente.Telefono);
                    cmd.Parameters.AddWithValue("Estado", oCliente.Estado);
                    cmd.Parameters.AddWithValue("FechaCreacion", oCliente.FechaCreacion);
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

        public bool ModificarCliente(Cliente oCliente)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Connection.ConnectionString()))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_ModificarClienteConGuid", oConexion);

                    cmd.Parameters.AddWithValue("IdCliente",oCliente.Id);
                    cmd.Parameters.AddWithValue("PrimerNombre", oCliente.PrimerNombre);
                    cmd.Parameters.AddWithValue("SegundoNombre", oCliente.SegundoNombre);
                    cmd.Parameters.AddWithValue("PrimerApellido", oCliente.PrimerApellido);
                    cmd.Parameters.AddWithValue("SegundoApellido", oCliente.SegundoApellido);
                    cmd.Parameters.AddWithValue("Correo", oCliente.Correo);
                    cmd.Parameters.AddWithValue("Telefono", oCliente.Telefono);
                    cmd.Parameters.AddWithValue("Estado", oCliente.Estado);
                    cmd.Parameters.AddWithValue("FechaCreacion", oCliente.FechaCreacion);
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

        public bool EliminarCliente(Guid IdCliente)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Connection.ConnectionString()))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spEliminarGuidCliente", oConexion);
                    cmd.Parameters.AddWithValue("IdCliente", IdCliente);
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
