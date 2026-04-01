using ComercialWebDAL;
using ComercialWebEN;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComercialWebBL
{
    public class ProductoBL
    {
        public class UsuarioBL
        {
            public async Task<int> GuardarAsync(ProductoEN pProducto)
            {
                return await ProductoDAL.GuardarAsync(pProducto);
            }

            public async Task<int> ModificarAsync(ProductoEN pProducto)
            {
                return await ProductoDAL.ModificarAsync(pProducto);
            }

            public async Task<int> EliminarAsync(ProductoEN pProducto)
            {
                return await ProductoDAL.EliminarAsync(pProducto);
            }

            public async Task<ProductoEN> ObtenerPorIdAsync(ProductoEN pProducto)
            {
                return await ProductoDAL.ObtenerPorIdAsync(pProducto);
            }

            public async Task<List<ProductoEN>> ObtenerTodosAsync()
            {
                return await ProductoDAL.ObtenerTodosAsync();
            }

            public async Task<List<ProductoEN>> BuscarAsync(ProductoEN pProducto)
            {
                return await ProductoDAL.BuscarAsync(pProducto);
            }

            //public async Task<int> ActualizarStockAsync(int idProducto, int cantidad)
            //{
            //    return await ProductoDAL.ActualizarStockAsync(idProducto, cantidad);
            //}

            //public async Task<List<ProductoEN>> ObtenerBajoStockAsync(int stockMinimo)
            //{
            //    return await ProductoDAL.ObtenerBajoStockAsync(stockMinimo);
            //}

        }
    }
}
