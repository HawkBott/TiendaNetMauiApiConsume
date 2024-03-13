using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.WebAPI.Tienda.Entities;

namespace Tienda.WebAPI.Contratos
{
    public interface IProducto
    {
        Task<List<Producto>> ObtenerProductos();
        Task<List<Producto>> ObtenerProductoPorNombre(string nombre);
    }
}
