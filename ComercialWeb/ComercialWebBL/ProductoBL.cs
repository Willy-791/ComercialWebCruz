using ComercialWebEN;
using System;
using System.Collections.Generic;
using System.Text;
using static ComercialWebBL.ProductoBL;

namespace ComercialWebBL
{
    public class ProductoBL
    {
        public class UsuarioBL
        {
            public async Task<int> GuardarAsync(ProductoBL pProducto)
            {
                return await ProductoDAL.GuardarAsync(pProducto);
            }

            public async Task<int> ModificarAsync(ProductoBL pProducto)
            {
                return await ProductoDAL.ModificarAsync(pProducto);
            }

            public async Task<int> EliminarAsync(ProductoBL pProducto)
            {
                return await ProductoDAL.EliminarAsync(pProducto);
            }

            public async Task<ProductoBL> ObtenerTodosPorIdAsync(ProductoBL pProducto)
            {
                return await ProductoDAL.ObtenerTodosPorIdAsync(pProducto);
            }

            public async Task<List<ProductoBL>> BuscarAsync(ProductoBL pProducto)
            {
                return await ProductoDAL.BuscarAsync(pProducto);
            }

            public async Task<int> ActualizarStockAsync(int idProducto, int cantidad)
            {
                return await ProductoDAL.ActualizarStockAsync(idProducto, cantidad);
            }

            public async Task<List<ProductoEN>> ObtenerBajoStockAsync(int stockMinimo)
            {
                return await ProductoDAL.ObtenerBajoStockAsync(stockMinimo);
            }

        }
    }
}
