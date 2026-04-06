using ComercialWebEN;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ComercialWebDAL
{
    public class CategoriaDAL
    {
        public static async Task<int> GuardarAsync(CategoriaEN pCategoria)
        {
            int result = 0;
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    dbContexto.Add(pCategoria);
                    result = await dbContexto.SaveChangesAsync();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar el Categoria: " + ex.Message);
            }
        }

        public static async Task<int> ModificarAsync(CategoriaEN pCategoria)
        {
            int result = 0;
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    var Categoria = await dbContexto.Categoria
                        .FirstOrDefaultAsync(r => r.IdCategoria == pCategoria.IdCategoria);

                  
                    Categoria.Nombre = pCategoria.Nombre;
                    Categoria.Estado = pCategoria.Estado;

                    dbContexto.Update(Categoria);
                    result = await dbContexto.SaveChangesAsync();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el Categoria: " + ex.Message);
            }
        }

        public static async Task<int> EliminarAsync(CategoriaEN pCategoria)
        {
            int result = 0;
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    var Categoria = await dbContexto.Categoria
                        .FirstOrDefaultAsync(x => x.IdCategoria == pCategoria.IdCategoria);

                    dbContexto.Categoria.Remove(Categoria);
                    result = await dbContexto.SaveChangesAsync();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el Categoria: " + ex.Message);
            }
        }

        public static async Task<CategoriaEN> ObtenerPorIdAsync(CategoriaEN pCategoria)
        {
            CategoriaEN Categoria = new CategoriaEN();
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    Categoria = await dbContexto.Categoria
                        .FirstOrDefaultAsync(s => s.IdCategoria == pCategoria.IdCategoria);
                }
                return Categoria;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el Categoria por id: " + ex.Message);
            }
        }

        public static async Task<List<CategoriaEN>> ObtenerTodosAsync()
        {
            List<CategoriaEN> Categoria = new List<CategoriaEN>();
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    Categoria = await dbContexto.Categoria.ToListAsync();
                }
                return Categoria;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener todos los Categoria: " + ex.Message);
            }
        }

        internal static IQueryable<CategoriaEN> QuerySelect(IQueryable<CategoriaEN> pQuery, CategoriaEN pCategoria)
        {
            if (pCategoria.IdCategoria > 0)
                pQuery = pQuery.Where(s => s.IdCategoria == pCategoria.IdCategoria);

            if (!string.IsNullOrWhiteSpace(pCategoria.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pCategoria.Nombre));

            if (pCategoria.Estado == 0 || pCategoria.Estado == 1)
                pQuery = pQuery.Where(s => s.Estado == pCategoria.Estado);

            if (pCategoria.Top_Aux > 0)
                pQuery = pQuery.Take(pCategoria.Top_Aux);

            return pQuery;
        }

        public static async Task<List<CategoriaEN>> BuscarAsync(CategoriaEN pCategoria)
        {
            var Categoria = new List<CategoriaEN>();
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    var select = dbContexto.Categoria.AsQueryable();
                    select = QuerySelect(select, pCategoria);
                    Categoria = await select.ToListAsync();
                }
                return Categoria;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar los Categoria: " + ex.Message);
            }
        }
    }
}
