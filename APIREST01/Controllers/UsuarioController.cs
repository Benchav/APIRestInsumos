using CapaDatos;
using CapaModelo;
using Microsoft.AspNetCore.Mvc;

namespace APIREST01.Controllers
{
    [ApiController]
    [Route("Usuarios")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        [Route("ListarUsuarios")]
        public JsonResult Obtener()
        {
            List<Usuario> lista = Cd_Usuario.Instancia.ObtenerUsuario();
            return new JsonResult(new { data = lista });
        }

        [HttpGet]
        [Route("Listar")]
        public string GetUser()
        {
            var UserJson = Cd_Usuario.Instancia.ObtenerUsuario();
            return Newtonsoft.Json.JsonConvert.SerializeObject(UserJson);
        }

        [HttpPost]
        [Route("Agregar")]
        public string PostUser(Usuario oUser)
        {
            var UserJson = Cd_Usuario.Instancia.RegistrarUsuario(oUser);
            return Newtonsoft.Json.JsonConvert.SerializeObject(UserJson);
        }

        [HttpPut]
        [Route("Modificar")]
        public string PutUser(Usuario oUser)
        {
            var UserJson = Cd_Usuario.Instancia.ModificarUsuario(oUser);
            return Newtonsoft.Json.JsonConvert.SerializeObject(UserJson);
        }

        [HttpDelete]
        [Route("Eliminar/{Id}")]
        public string EliminarUser(Guid Id)
        {
            var UserJson = Cd_Usuario.Instancia.EliminarUsuario(Id);
            return Newtonsoft.Json.JsonConvert.SerializeObject(UserJson);
        }
    }
}
