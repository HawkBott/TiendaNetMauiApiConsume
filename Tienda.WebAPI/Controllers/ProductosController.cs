using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using Tienda.WebAPI.Contratos;
using Tienda.WebAPI.Tienda.DAL;
using Tienda.WebAPI.Tienda.Entities;

namespace Tienda.WebAPI.Controllers
{
    public class ProductosController : ApiController
    {
        readonly IProducto Prod;
        List<Producto> DatosProductos;

        public ProductosController()
        {
            Prod = new ProductoDAL();
        }

        [HttpGet]
        public async Task<List<Producto>> ListaProductos()
        {
            DatosProductos = await Prod.ObtenerProductos();
            return DatosProductos;
        }

        [HttpGet]
        public async Task<List<Producto>> ProductoPorNombre(string x)
        {
            DatosProductos = await Prod.ObtenerProductoPorNombre(x);

            return DatosProductos;
        }
    }
}
