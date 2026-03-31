using ComercialWebEN;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace ComercialWebDAL
{
    public class ProductoDAL
    {
        public static async Task<int> GuardarAsync(ProductoEN pProducto)
        {
            int result = 0;
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    dbContexto.Add(pProducto);
                    result = await dbContexto.SaveChangesAsync();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar el Producto: " + ex.Message);
            }
        }

        public static async Task<int> ModificarAsync(ProductoEN pProducto)
        {
            int result = 0;
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    var Producto = await dbContexto.Producto
                        .FirstOrDefaultAsync(r => r.IdProducto == pProducto.IdProducto);

                    Producto.Nombre = pProducto.Nombre;
                    Producto.Estado = pProducto.Estado;
                    Producto.Descripcion = pProducto.Descripcion;
                    Producto.Precio = pProducto.Precio;
                    Producto.Stock = pProducto.Stock;
                    Producto.Estado = pProducto.Estado;

                    dbContexto.Update(Producto);
                    result = await dbContexto.SaveChangesAsync();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el Producto: " + ex.Message);
            }
        }

        public static async Task<int> EliminarAsync(ProductoEN pProducto)
        {
            int result = 0;
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    var Producto = await dbContexto.Producto
                        .FirstOrDefaultAsync(x => x.IdProducto == pProducto.IdProducto);

                    dbContexto.Producto.Remove(Producto);
                    result = await dbContexto.SaveChangesAsync();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el Producto: " + ex.Message);
            }
        }

        public static async Task<ProductoEN> ObtenerPorIdAsync(ProductoEN pProducto)
        {
            ProductoEN Producto = new ProductoEN();
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    Producto = await dbContexto.Producto
                        .FirstOrDefaultAsync(s => s.IdProducto == pProducto.IdProducto);
                }
                return Producto;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el Producto por id: " + ex.Message);
            }
        }

        public static async Task<List<ProductoEN>> ObtenerTodosAsync()
        {
            List<ProductoEN> Producto = new List<ProductoEN>();
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    Producto = await dbContexto.Producto.ToListAsync();
                }
                return Producto;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener todos los Producto: " + ex.Message);
            }
        }

        internal static IQueryable<ProductoEN> QuerySelect(IQueryable<ProductoEN> pQuery,ProductoEN pProducto)
        {
            if (pProducto.IdProducto > 0)
                pQuery = pQuery.Where(s => s.IdProducto == pProducto.IdProducto);

            if (pProducto.IdCategoria > 0)
                pQuery = pQuery.Where(s => s.IdCategoria == pProducto.IdCategoria);

            if (pProducto.IdMarca > 0)
                pQuery = pQuery.Where(s => s.IdMarca == pProducto.IdMarca);

            if (!string.IsNullOrWhiteSpace(pProducto.Nombre))
                pQuery = pQuery.Where(s => s.Nombre == pProducto.Nombre);

            if (pProducto.Estado)
                pQuery = pQuery.Where(s => s.Estado == pProducto.Estado);

            if (pProducto.Top_Aux > 0)
                pQuery = pQuery.Take(pProducto.Top_Aux).AsQueryable();

            return pQuery;
        }

        public static async Task<List<ProductoEN>> BuscarAsync(ProductoEN pProducto)
        {
            var Producto = new List<ProductoEN>();
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    var select = dbContexto.Producto.AsQueryable();
                    select = QuerySelect(select, pProducto);
                    Producto = await select.ToListAsync();
                }
                return Producto;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar los Producto: " + ex.Message);
            }
        }
    }
}
