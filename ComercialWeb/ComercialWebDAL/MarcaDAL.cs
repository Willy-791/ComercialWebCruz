using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using ComercialWebEN;

namespace ComercialWebDAL
{
    public class MarcaDAL
    {
        public static async Task<int>GuardarAsync(MarcaEN pMarca)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                dbContexto.Add(pMarca);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(MarcaEN pMarca)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var Marca = await dbContexto.Marca.FirstOrDefaultAsync(s => s.IdMarca == pMarca.IdMarca);//Select 
                Marca.Nombre = pMarca.Nombre;
                dbContexto.Update(Marca);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(MarcaEN pMarca)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var Marca = await dbContexto.Marca.FirstOrDefaultAsync(x => x.IdMarca == pMarca.IdMarca);
                dbContexto.Marca.Remove(Marca);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<MarcaEN> ObtenerPorIdAsync(MarcaEN pMarca)
        {
            MarcaEN Marca = new MarcaEN();
            using (var dbContexto = new DBContexto())
            {
                //Select IdMarca, Nombre From Marca Where IdMarca = 1; 
                Marca = await dbContexto.Marca.FirstOrDefaultAsync(s => s.IdMarca == pMarca.IdMarca);
            }
            return Marca;
        }

        public static async Task<List<MarcaEN>> ObtenerTodosAsync()
        {
            List<MarcaEN> Marcaes = new List<MarcaEN>();
            using (var dbContexto = new DBContexto())
            {
                Marcaes = await dbContexto.Marca.ToListAsync();
            }
            return Marcaes;
        }

        internal static IQueryable<MarcaEN> QuerySelect(IQueryable<MarcaEN> pQuery, MarcaEN pMarca)
        {
            if (pMarca.IdMarca > 0)
                pQuery = pQuery.Where(s => s.IdMarca == pMarca.IdMarca);
            if (!string.IsNullOrWhiteSpace(pMarca.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pMarca.Nombre));//like
            pQuery = pQuery.OrderByDescending(s => s.IdMarca).AsQueryable();
            if (pMarca.Top_Aux > 0)
                pQuery = pQuery.Take(pMarca.Top_Aux).AsQueryable();
            return pQuery;
        }

      
        // Este metodo se ocupa para hacer las busqueda de uno o varios Marcaes por medio de condiciones
       
        public static async Task<List<MarcaEN>> BuscarAsync(MarcaEN pMarca)
        {
            var Marcas = new List<MarcaEN>();
            using (var dbContexto = new DBContexto())
            {
                var select = dbContexto.Marca.AsQueryable();
                select = QuerySelect(select, pMarca);
                Marcas = await select.ToListAsync();
            }
            return Marcas;
        }

    }
}
