using CapaDatos;
using CapaModelo;
using Microsoft.AspNetCore.Mvc;

namespace APIREST01.Controllers
{
    [ApiController]
    [Route("Rol")]
    public class RolController : ControllerBase
    {
        [HttpGet]
        [Route("ListarRoles")]
        public JsonResult Obtener()
        {
            List<Rol> lista = Cd_Rol.Instancia.ObtenerRol();
            return new JsonResult(new { data = lista });
        }

        [HttpGet]
        [Route("Listar")]
        public string Get()
        {
            var RolJson = Cd_Rol.Instancia.ObtenerRol();
            return Newtonsoft.Json.JsonConvert.SerializeObject(RolJson);
        }

        [HttpPost]
        [Route("Agregar")]
        public string Post(Rol oRol)
        {
            var RolJson = Cd_Rol.Instancia.RegistrarRol(oRol);
            return Newtonsoft.Json.JsonConvert.SerializeObject(RolJson);
        }

        [HttpPut]
        [Route("Modificar")]
        public string Put(Rol oRol)
        {
            var RolJson = Cd_Rol.Instancia.ModificarRol(oRol);
            return Newtonsoft.Json.JsonConvert.SerializeObject(RolJson);
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(Guid Id)
        {
            var RolJson = Cd_Rol.Instancia.EliminarRol(Id);
            return Newtonsoft.Json.JsonConvert.SerializeObject(RolJson);
        }

    }
}
