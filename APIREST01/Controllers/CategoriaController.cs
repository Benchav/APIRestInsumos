using Microsoft.AspNetCore.Mvc;
using CapaDatos;
using CapaModelo;

namespace APIREST01.Controllers
{
    [ApiController]
    [Route("Categoria")]
    public class CategoriaController : ControllerBase
    {
        [HttpGet]
        [Route("ListarCategorias")]
        public JsonResult Obtener()
        {
            List <Categoria> lista = Cd_Categoria.Instancia.ObtenerCategoria();
            return new JsonResult(new { data= lista });
        }

        [HttpGet]
        [Route ("Listar")]
        public string GetCategorias()
        {
            var CategoriasJson = Cd_Categoria.Instancia.ObtenerCategoria();
            return Newtonsoft.Json.JsonConvert.SerializeObject(CategoriasJson);
        }

        [HttpPost]
        [Route("Agregar")]
        public string PostCategorias(Categoria oCategoria )
        {
            var CategoriasJson = Cd_Categoria.Instancia.RegistrarCategoria(oCategoria); 
            return Newtonsoft.Json.JsonConvert.SerializeObject(CategoriasJson);
        }

        [HttpPut]
        [Route("Modificar")]
        public string PutCategorias(Categoria oCategoria)
        {
            var CategoriasJson = Cd_Categoria.Instancia.ModificarCategoria(oCategoria);
            return Newtonsoft.Json.JsonConvert.SerializeObject(CategoriasJson);
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string EliminarCategorias( Guid Id )
        {
            var CategoriasJson = Cd_Categoria.Instancia.EliminarCategoria(Id);
            return Newtonsoft.Json.JsonConvert.SerializeObject(CategoriasJson);
        }
    }
}
