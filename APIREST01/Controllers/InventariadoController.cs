using CapaDatos;
using CapaModelo;
using Microsoft.AspNetCore.Mvc;

namespace APIREST01.Controllers
{
    [ApiController]
    [Route("Inventariado")]
    public class InventariadoController : ControllerBase
    {
        [HttpGet]
        [Route("ListarInventariado")]
        public JsonResult Obtener()
        {
            List<Inventariado> lista = Cd_Inventariado.Instancia.ObtenerInventario();
            return new JsonResult(new { data = lista });
        }

        [HttpGet]
        [Route("Listar")]
        public string GetInventario()
        {
            var InventarioJson = Cd_Inventariado.Instancia.ObtenerInventario();
            return Newtonsoft.Json.JsonConvert.SerializeObject(InventarioJson);
        }

        [HttpPost]
        [Route("Agregar")]
        public string PostInventario(Inventariado oInventario)
        {
            var InventarioJson = Cd_Inventariado.Instancia.RegistrarInventario(oInventario);
            return Newtonsoft.Json.JsonConvert.SerializeObject(InventarioJson);
        }

        [HttpPut]
        [Route("Modificar")]
        public string PutInventario(Inventariado oInventario)
        {
            var InventarioJson = Cd_Inventariado.Instancia.ModificarInventario(oInventario);
            return Newtonsoft.Json.JsonConvert.SerializeObject(InventarioJson);
        }

        [HttpDelete]
        [Route("Eliminar/{Id}")]
        public string EliminarCategorias(Guid Id)
        {
            var InventarioJson = Cd_Inventariado.Instancia.EliminarInventario(Id);
            return Newtonsoft.Json.JsonConvert.SerializeObject(InventarioJson);
        }

    }
}