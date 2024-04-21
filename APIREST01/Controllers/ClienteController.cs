using CapaDatos;
using CapaModelo;
using Microsoft.AspNetCore.Mvc;

namespace APIREST01.Controllers
{
    [ApiController]
    [Route("Cliente")]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        [Route("ListarClientes")]
        public JsonResult Obtener()
        {
            List<Cliente> lista = Cd_Cliente.Instancia.ObtenerCliente();
            return new JsonResult(new { data = lista });
        }

        [HttpGet]
        [Route("Listar")]
        public string GetCliente()
        {
            var ClienteJson = Cd_Cliente.Instancia.ObtenerCliente();
            return Newtonsoft.Json.JsonConvert.SerializeObject(ClienteJson);
        }

        [HttpPost]
        [Route("Agregar")]
        public string PostCliente(Cliente oCliente)
        {
            var ClienteJson = Cd_Cliente.Instancia.RegistrarCliente(oCliente);
            return Newtonsoft.Json.JsonConvert.SerializeObject(ClienteJson);
        }

        [HttpPut]
        [Route("Modificar")]
        public string PutCliente(Cliente oCliente)
        {
            var ClienteJson = Cd_Cliente.Instancia.ModificarCliente(oCliente);
            return Newtonsoft.Json.JsonConvert.SerializeObject(ClienteJson);
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string EliminarCategorias(Guid Id)
        {
            var ClienteJson = Cd_Cliente.Instancia.EliminarCliente(Id);
            return Newtonsoft.Json.JsonConvert.SerializeObject(ClienteJson);
        }
    }
}
