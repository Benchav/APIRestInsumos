using CapaModelo;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public  class Cd_Inventariado
    {
        public static Cd_Inventariado _instancia = null;
        private Cd_Inventariado() 
        {
        }

        public static Cd_Inventariado Instancia
        {
            get
            {
                if (_instancia == null) 
                {
                    _instancia= new Cd_Inventariado();
                }
                return _instancia;
            }
        }


        public List<Inventariado> ObtenerInventario()
        {
            var rptListaInventario = new List<Inventariado>();
            using (SqlConnection oConexion = new SqlConnection(Connection.ConnectionString()))
            {
                //  SqlCommand cmd = new SqlCommand("VerProductos", oConexion);
                SqlCommand cmd = new SqlCommand("USP_InventarioObtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rptListaInventario.Add(new Inventariado()
                        {
                            Id = Guid.Parse(dr["IdInventario"].ToString()),
                            IdDetalleProd = Guid.Parse(dr["IdDetalleProd"].ToString()),
                            IdProveedor = Guid.Parse(dr["IdProveedor"].ToString()),
                            Existencia = Convert.ToInt32(dr["Existencia"].ToString()),
                            Lote = dr["Lote"].ToString(),
                            PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"].ToString()),
                            PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"].ToString()),
                            FechaCompra = Convert.ToDateTime(dr["FechaCompra"].ToString()),
                            FechaVencimiento = Convert.ToDateTime(dr["FechaVencimiento"].ToString()),
                            objDtProducto = new DtProducto() { Descripcion = dr["Descripcion"].ToString() }
                            //    Estado= Convert.ToBoolean(dr["Estado"].ToString())


                        });
                    }
                    dr.Close();
                    return rptListaInventario;
                }
                catch
                {
                    rptListaInventario = null;
                    return rptListaInventario;
                }
            }
        }


        public bool RegistrarInventario(Inventariado oInventario)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Connection.ConnectionString()))
            {
                try
                {
                    //SqlCommand cmd = new SqlCommand("sp_RegistrarProductoConGuid", oConexion);
                    SqlCommand cmd = new SqlCommand("USP_AñadirInventario", oConexion);
                    Guid NewId = Guid.NewGuid();

                    cmd.Parameters.AddWithValue("IdInventario", NewId);
                    cmd.Parameters.AddWithValue("IdDetalleprod", oInventario.IdDetalleProd);
                    cmd.Parameters.AddWithValue("IdProveedor", oInventario.IdProveedor);
                    cmd.Parameters.AddWithValue("Existencia", oInventario.Existencia);
                    cmd.Parameters.AddWithValue("Lote", oInventario.Lote);
                    cmd.Parameters.AddWithValue("PrecioVenta", oInventario.PrecioVenta);
                    cmd.Parameters.AddWithValue("PrecioCompra", oInventario.PrecioCompra);
                    cmd.Parameters.AddWithValue("FechaCompra", oInventario.FechaCompra);
                    cmd.Parameters.AddWithValue("FechaVencimiento", oInventario.FechaVencimiento);
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


        public bool ModificarInventario(Inventariado oInventario)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Connection.ConnectionString()))
            {
                try
                {
                    //   SqlCommand cmd = new SqlCommand("sp_ModificarProductoConGuid", oConexion);
                    SqlCommand cmd = new SqlCommand("USP_InventarioActualizar", oConexion);
                    cmd.Parameters.AddWithValue("IdInventario", oInventario.Id);
                    cmd.Parameters.AddWithValue("IdDetalleprod", oInventario.IdDetalleProd);
                    cmd.Parameters.AddWithValue("IdProveedor", oInventario.IdProveedor);
                    cmd.Parameters.AddWithValue("Existencia", oInventario.Existencia);
                    cmd.Parameters.AddWithValue("Lote", oInventario.Lote);
                    cmd.Parameters.AddWithValue("PrecioVenta", oInventario.PrecioVenta);
                    cmd.Parameters.AddWithValue("PrecioCompra", oInventario.PrecioCompra);
                    cmd.Parameters.AddWithValue("FechaCompra", oInventario.FechaCompra);
                    cmd.Parameters.AddWithValue("FechaVencimiento", oInventario.FechaVencimiento);
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


        public bool EliminarInventario(Guid IdInventariado)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Connection.ConnectionString()))
            {
                try
                {
                    //  SqlCommand cmd = new SqlCommand("spEliminarGuidProducto", oConexion);
                    SqlCommand cmd = new SqlCommand("USP_InventarioEliminar", oConexion);
                    cmd.Parameters.AddWithValue("IdInventario", IdInventariado);
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
