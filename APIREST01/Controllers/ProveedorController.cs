using CapaDatos;
using CapaModelo;
using Microsoft.AspNetCore.Mvc;

namespace APIREST01.Controllers
{
    [ApiController]
    [Route("Proveedor")]
    public class ProveedorController : ControllerBase
    {
        [HttpGet]
        [Route("ListarProveedor")]
        public JsonResult Obtener()
        {
            List<Proveedor> lista = Cd_Proveedor.Instancia.ObtenerProveedor();
            return new JsonResult(new { data = lista });
        }

        [HttpGet]
        [Route("Listar")]
        public string GetProveedor()
        {
            var ProveedorJson = Cd_Proveedor.Instancia.ObtenerProveedor();
            return Newtonsoft.Json.JsonConvert.SerializeObject(ProveedorJson);
        }

        [HttpPost]
        [Route("Agregar")]
        public string PostProveedor(Proveedor oProveedor)
        {
            var ProveedorJson = Cd_Proveedor.Instancia.RegistrarProveedor(oProveedor);
            return Newtonsoft.Json.JsonConvert.SerializeObject(ProveedorJson);
        }

        [HttpPut]
        [Route("Modificar")]
        public string PutProveedor(Proveedor oProveedor)
        {
            var ProveedorJson = Cd_Proveedor.Instancia.ModificarProveedor(oProveedor);
            return Newtonsoft.Json.JsonConvert.SerializeObject(ProveedorJson);
        }

        [HttpDelete]
        [Route("Eliminar/{Id}")]
        public string EliminarProveedor(Guid Id)
        {
            var ProveedorJson = Cd_Proveedor.Instancia.EliminarProveedor(Id);
            return Newtonsoft.Json.JsonConvert.SerializeObject(ProveedorJson);
        }
    }
}
