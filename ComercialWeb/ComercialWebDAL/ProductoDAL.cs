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
                    var producto = await dbContexto.Producto
                        .FirstOrDefaultAsync(r => r.IdProducto == pProducto.IdProducto);

                    producto.Nombre = pProducto.Nombre;
                    producto.Descripcion = pProducto.Descripcion;
                    producto.Precio = pProducto.Precio;
                    producto.Stock = pProducto.Stock;
                    producto.Estado = pProducto.Estado;

                    dbContexto.Update(producto);
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
                    var producto = await dbContexto.Producto
                        .FirstOrDefaultAsync(x => x.IdProducto == pProducto.IdProducto);

                    dbContexto.Producto.Remove(producto);
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
            ProductoEN producto = new ProductoEN();
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    producto = await dbContexto.Producto
                        .FirstOrDefaultAsync(s => s.IdProducto == pProducto.IdProducto);
                }
                return producto;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el Producto por id: " + ex.Message);
            }
        }

        public static async Task<List<ProductoEN>> ObtenerTodosAsync()
        {
            var lista = new List<ProductoEN>();
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    lista = await dbContexto.Producto.ToListAsync();
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener todos los Producto: " + ex.Message);
            }
        }

        internal static IQueryable<ProductoEN> QuerySelect(IQueryable<ProductoEN> pQuery, ProductoEN pProducto)
        {
            if (pProducto.IdProducto > 0)
                pQuery = pQuery.Where(s => s.IdProducto == pProducto.IdProducto);

            if (pProducto.IdCategoria > 0)
                pQuery = pQuery.Where(s => s.IdCategoria == pProducto.IdCategoria);

            if (pProducto.IdMarca > 0)
                pQuery = pQuery.Where(s => s.IdMarca == pProducto.IdMarca);

            if (!string.IsNullOrWhiteSpace(pProducto.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pProducto.Nombre));

            if (pProducto.Estado)
                pQuery = pQuery.Where(s => s.Estado == pProducto.Estado);

            if (pProducto.Top_Aux > 0)
                pQuery = pQuery.Take(pProducto.Top_Aux).AsQueryable();

            return pQuery;
        }

        public static async Task<List<ProductoEN>> BuscarAsync(ProductoEN pProducto)
        {
            var lista = new List<ProductoEN>();
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    var select = dbContexto.Producto.AsQueryable();
                    select = QuerySelect(select, pProducto);
                    lista = await select.ToListAsync();
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar los Producto: " + ex.Message);
            }
        }

        // NUEVOS MÉTODOS

        public static async Task<int> ActualizarStockAsync(int idProducto, int cantidad)
        {
            int result = 0;
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    var producto = await dbContexto.Producto
                        .FirstOrDefaultAsync(p => p.IdProducto == idProducto);

                    if (producto != null)
                    {
                        producto.Stock += cantidad;
                        if (producto.Stock < 0)
                            producto.Stock = 0;

                        dbContexto.Update(producto);
                        result = await dbContexto.SaveChangesAsync();
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar stock: " + ex.Message);
            }
        }

        public static async Task<List<ProductoEN>> ObtenerBajoStockAsync(int stockMinimo)
        {
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    return await dbContexto.Producto
                        .Where(p => p.Stock <= stockMinimo && p.Estado == true)
                        .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener bajo stock: " + ex.Message);
            }
        }
    }
}