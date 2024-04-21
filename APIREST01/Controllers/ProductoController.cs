using CapaDatos;
using CapaModelo;
using Microsoft.AspNetCore.Mvc;

namespace APIREST01.Controllers
{
    [ApiController]
    [Route("Producto")]
    public class ProductoController : ControllerBase
    {
        [HttpGet]
        [Route("ListarProductos")]
        public JsonResult Obtener()
        {
            List<Producto> lista = Cd_Producto.Instancia.ObtenerProducto();
            return new JsonResult(new { data = lista });
        }

        [HttpGet]
        [Route("Listar")]
        public string GetProducto()
        {
            var ProductoJson = Cd_Producto.Instancia.ObtenerProducto();
            return Newtonsoft.Json.JsonConvert.SerializeObject(ProductoJson);
        }

        [HttpPost]
        [Route("Agregar")]
        public string PostProducto(Producto oProducto)
        {
            var ProductoJson = Cd_Producto.Instancia.RegistrarProducto(oProducto);
            return Newtonsoft.Json.JsonConvert.SerializeObject(ProductoJson);
        }

        [HttpPut]
        [Route("Modificar")]
        public string PutProducto(Producto oProducto)
        {
            var ProductoJson = Cd_Producto.Instancia.ModificarProducto(oProducto);
            return Newtonsoft.Json.JsonConvert.SerializeObject(ProductoJson);
        }

        [HttpDelete]
        [Route("Eliminar/{Id}")]
        public string EliminarProducto(Guid Id)
        {
            var ProductoJson = Cd_Producto.Instancia.EliminarProducto(Id);
            return Newtonsoft.Json.JsonConvert.SerializeObject(ProductoJson);
        }
    }
}


