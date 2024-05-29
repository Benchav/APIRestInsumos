using CapaModelo;
using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{

    //el get del usuario no funciona el sakoekuka
    public class Cd_Usuario
    {
        public static Cd_Usuario _instancia = null;
        private Cd_Usuario()
        {
        }
        public static Cd_Usuario Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new Cd_Usuario();
                }
                return _instancia;
            }
        }
        public List<Usuario> ObtenerUsuario()
        {
            var rptListaUsuario = new List<Usuario>();
            using (SqlConnection oConexion = new SqlConnection(Connection.ConnectionString()))
            {
                //buscar como puede funcionar el sp de usp_Usuariosobtene
                SqlCommand cmd = new SqlCommand("USP_UsuarioObtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rptListaUsuario.Add(new Usuario()
                        {
                            Id = Guid.Parse(dr["IdUsuario"].ToString()),
                            IdRol = Guid.Parse(dr["IdRol"].ToString()),
                            PrimerNombre = dr["PrimerNombre"].ToString(),
                            SegundoNombre = dr["SegundoNombre"].ToString(),
                            PrimerApellido = dr["PrimerApellido"].ToString(),
                            SegundoApellido = dr["SegundoApellido"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            //   IdRol= Convert.ToInt32(dr["IdRol"].ToString()),
                            Estado = Convert.ToBoolean(dr["Estado"].ToString()),
                            Sexo = dr["Sexo"].ToString(),
                            Username = dr["Username"].ToString(),
                            Contraseña = dr["Contraseña"].ToString(),
                            FechaCreacion = Convert.ToDateTime(dr["FechaCreacion"].ToString()),
                          //  objRol = new Rol() { Descripcion = dr["Descripcion"].ToString() }
                        });
                    }
                    dr.Close();
                    return rptListaUsuario;
                }
                catch
                {
                    rptListaUsuario = null;
                    return rptListaUsuario;
                }
            }
        }
        public bool RegistrarUsuario(Usuario oUsuario)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Connection.ConnectionString()))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_AñadirUsuario", oConexion);
                    Guid NewId = Guid.NewGuid();

                    cmd.Parameters.AddWithValue("IdUsuario", NewId);
                    cmd.Parameters.AddWithValue("IdRol", oUsuario.IdRol);
                    cmd.Parameters.AddWithValue("PrimerNombre", oUsuario.PrimerNombre);
                    cmd.Parameters.AddWithValue("SegundoNombre", oUsuario.SegundoNombre);
                    cmd.Parameters.AddWithValue("PrimerApellido", oUsuario.PrimerApellido);
                    cmd.Parameters.AddWithValue("SegundoApellido", oUsuario.SegundoApellido);
                    cmd.Parameters.AddWithValue("Correo", oUsuario.Correo);
                    cmd.Parameters.AddWithValue("Estado", oUsuario.Estado);
                    cmd.Parameters.AddWithValue("Sexo", oUsuario.Sexo);
                    cmd.Parameters.AddWithValue("Username", oUsuario.Username);
                    cmd.Parameters.AddWithValue("Contraseña", oUsuario.Contraseña);
                    cmd.Parameters.AddWithValue("FechaCreacion", oUsuario.FechaCreacion);
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
        public bool ModificarUsuario(Usuario oUsuario)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Connection.ConnectionString()))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_UsuarioActualizar", oConexion);

                    cmd.Parameters.AddWithValue("IdUsuario", oUsuario.Id);
                    cmd.Parameters.AddWithValue("IdRol", oUsuario.IdRol);
                    cmd.Parameters.AddWithValue("PrimerNombre", oUsuario.PrimerNombre);
                    cmd.Parameters.AddWithValue("SegundoNombre", oUsuario.SegundoNombre);
                    cmd.Parameters.AddWithValue("PrimerApellido", oUsuario.PrimerApellido);
                    cmd.Parameters.AddWithValue("SegundoApellido", oUsuario.SegundoApellido);
                    cmd.Parameters.AddWithValue("Correo", oUsuario.Correo);
                    cmd.Parameters.AddWithValue("Estado", oUsuario.Estado);
                    cmd.Parameters.AddWithValue("Sexo", oUsuario.Sexo);
                    cmd.Parameters.AddWithValue("Username", oUsuario.Username);
                    cmd.Parameters.AddWithValue("Contraseña", oUsuario.Contraseña);
                    cmd.Parameters.AddWithValue("FechaCreacion", oUsuario.FechaCreacion);
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
        public bool EliminarUsuario(Guid IdProveedor)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Connection.ConnectionString()))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_UsuarioEliminar", oConexion);
                    cmd.Parameters.AddWithValue("IdUsuario", IdProveedor);
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
