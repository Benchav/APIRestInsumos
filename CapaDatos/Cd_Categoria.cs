using CapaModelo;
using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class Cd_Categoria  
    {
        public static Cd_Categoria _instancia = null;
        private Cd_Categoria()
        {
        }
        public static Cd_Categoria Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new Cd_Categoria();
                }
                return _instancia;
            }
        }
        public List<Categoria> ObtenerCategoria()
        {
            var rptListaCategoria = new List<Categoria>();
            using (SqlConnection oConexion = new SqlConnection(Connection.ConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VerCategorias", oConexion);
             //   SqlCommand cmd = new SqlCommand("sp_MostrarCategoria", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rptListaCategoria.Add(new Categoria()
                        {
                            Id = Guid.Parse(dr["IdCategoria"].ToString()),
                            Descripcion = dr["Descripcion"].ToString(),
                            Estado = Convert.ToBoolean(dr["Estado"].ToString()),
                            FechaCreacion = Convert.ToDateTime(dr["FechaCreacion"].ToString()),
                        }) ;
                    }
                    dr.Close();
                    return rptListaCategoria;
                }
                catch
                {
                    rptListaCategoria = null;
                    return rptListaCategoria;
                }
            }
        }
        public bool RegistrarCategoria(Categoria oCategoria)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Connection.ConnectionString()))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarCategoriaConGuid", oConexion);

                    Guid NewId = Guid.NewGuid();

                    cmd.Parameters.AddWithValue("IdCategoria", NewId);
                    cmd.Parameters.AddWithValue("Descripcion", oCategoria.Descripcion);
                    cmd.Parameters.AddWithValue("Estado", oCategoria.Estado);
                    cmd.Parameters.AddWithValue("FechaCreacion", oCategoria.FechaCreacion);
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
        public bool ModificarCategoria(Categoria oCategoria ) 
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Connection.ConnectionString()))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_ModificarCategoriaConGuid", oConexion);

                    cmd.Parameters.AddWithValue("IdCategoria" , oCategoria.Id);
                    cmd.Parameters.AddWithValue("Descripcion", oCategoria.Descripcion);
                    cmd.Parameters.AddWithValue("Estado", oCategoria.Estado);
                    cmd.Parameters.AddWithValue("FechaCreacion", oCategoria.FechaCreacion);
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

        public bool EliminarCategoria(Guid IdCategoria)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Connection.ConnectionString()))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spEliminarGuidCat", oConexion);
                    cmd.Parameters.AddWithValue("IdCategoria", IdCategoria);
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
