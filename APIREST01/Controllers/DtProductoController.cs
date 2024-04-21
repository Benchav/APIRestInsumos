using CapaDatos;
using CapaModelo;
using Microsoft.AspNetCore.Mvc;

namespace APIREST01.Controllers
{
    [ApiController]
    [Route("DtProducto")]
    public class DtProductoController : ControllerBase
    {
        [HttpGet]
        [Route("ListarDtProductos")]
        public JsonResult Obtener()
        {
            List<DtProducto> lista = Cd_DtProducto.Instancia.ObtenerDtProducto();
            return new JsonResult(new { data = lista });
        }

        [HttpGet]
        [Route("Listar")]
        public string GetDtProducto()
        {
            var DtProductoJson = Cd_DtProducto.Instancia.ObtenerDtProducto();
            return Newtonsoft.Json.JsonConvert.SerializeObject(DtProductoJson);
        }

        [HttpPost]
        [Route("Agregar")]
        public string PostDtProducto(DtProducto oDtProducto)
        {
            var DtProductoJson = Cd_DtProducto.Instancia.RegistrarDtProducto(oDtProducto);
            return Newtonsoft.Json.JsonConvert.SerializeObject(DtProductoJson);
        }

        [HttpPut]
        [Route("Modificar")]
        public string PutDtProducto(DtProducto oDtProducto)
        {
            var DtProductoJson = Cd_DtProducto.Instancia.ModificarDtProducto(oDtProducto);
            return Newtonsoft.Json.JsonConvert.SerializeObject(DtProductoJson);
        }

        [HttpDelete]
        [Route("Eliminar/{Id}")]
        public string EliminarDtProducto(Guid Id)
        {
            var DtProductoJson = Cd_DtProducto.Instancia.EliminarDtProducto(Id);
            return Newtonsoft.Json.JsonConvert.SerializeObject(DtProductoJson);
        }

    }
}
