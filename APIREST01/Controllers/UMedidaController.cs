using CapaDatos;
using CapaModelo;
using Microsoft.AspNetCore.Mvc;

namespace APIREST01.Controllers
{
    [ApiController]
    [Route("UMedida")]

    public class UMedidaController : ControllerBase
    {
        [HttpGet]
        [Route("ListarUMedida")]
        public JsonResult Obtener()
        {
            List<UMedida> lista = Cd_UMedida.Instancia.ObtenerMedida();
            return new JsonResult(new { data = lista });
        }

        [HttpGet]
        [Route("Listar")]
        public string Get()
        {
            var MedidaJson = Cd_UMedida.Instancia.ObtenerMedida();
            return Newtonsoft.Json.JsonConvert.SerializeObject(MedidaJson);
        }

        [HttpPost]
        [Route("Agregar")]
        public string Post(UMedida medida)
        {
            var MedidaJson = Cd_UMedida.Instancia.RegistrarMedida(medida);
            return Newtonsoft.Json.JsonConvert.SerializeObject(MedidaJson);
        }

        [HttpPut]
        [Route("Modificar")]
        public string Put(UMedida medida)
        {
            var MedidaJson = Cd_UMedida.Instancia.ModificarMedida(medida);
            return Newtonsoft.Json.JsonConvert.SerializeObject(MedidaJson);
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(Guid Id)
        {
            var RolJson = Cd_UMedida.Instancia.EliminarMedida(Id);
            return Newtonsoft.Json.JsonConvert.SerializeObject(RolJson);
        }
    }
}
