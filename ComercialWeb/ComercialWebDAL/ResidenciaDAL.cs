using System;
using System.Collections.Generic;
using System.Text;

using ComercialWebEN;
using Microsoft.EntityFrameworkCore;

namespace ComercialWebDAL
{
    public class ResidenciaDAL
    {
        public static async Task<int> GuardarAsync(ResidenciaEN pResidencia)
        {
            int result = 0;
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    dbContexto.Add(pResidencia);
                    result = await dbContexto.SaveChangesAsync();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar la Residencia: " + ex.Message);
            }
        }
        public static async Task<int> ModificarAsync(ResidenciaEN pResidencia)
        {
            int result = 0;
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    var Residencia = await dbContexto.Residencia.FirstOrDefaultAsync(r => r.IdResidencia == pResidencia.IdResidencia);
                    Residencia.Nombre = pResidencia.Nombre;
                    dbContexto.Update(Residencia);
                    result = await dbContexto.SaveChangesAsync();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar la Residencia: " + ex.Message);
            }
        }
        public static async Task<int> EliminarAsync(ResidenciaEN pResidencia)
        {
            int result = 0;
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    var Residencia = await dbContexto.Residencia.FirstOrDefaultAsync(x => x.IdResidencia == pResidencia.IdResidencia);
                    dbContexto.Residencia.Remove(Residencia);
                    result = await dbContexto.SaveChangesAsync();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la Residencia: " + ex.Message);
            }
        }
        public static async Task<ResidenciaEN> ObtenerPorIdAsync(ResidenciaEN pResidencia)
        {
            ResidenciaEN Residencia = new ResidenciaEN();
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    //Select Id, Nombre From Residencia Where Id = 1; 
                    Residencia = await dbContexto.Residencia.FirstOrDefaultAsync(s => s.IdResidencia == pResidencia.IdResidencia);
                }
                return Residencia;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la Residencia por id: " + ex.Message);
            }
        }
        public static async Task<List<ResidenciaEN>> ObtenerTodosAsync()
        {
            List<ResidenciaEN> Residenciaes = new List<ResidenciaEN>();
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    Residenciaes = await dbContexto.Residencia.ToListAsync();
                }
                return Residenciaes;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener todos las Residencias: " + ex.Message);
            }
        }
        internal static IQueryable<ResidenciaEN> QuerySelect(IQueryable<ResidenciaEN> pQuery, ResidenciaEN pResidencia)
        {
            if (pResidencia.IdResidencia > 0)
                pQuery = pQuery.Where(s => s.IdResidencia == pResidencia.IdResidencia);
            if (!string.IsNullOrWhiteSpace(pResidencia.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pResidencia.Nombre));
            pQuery = pQuery.OrderByDescending(s => s.IdResidencia).AsQueryable();
            if (pResidencia.Top_Aux > 0)
                pQuery = pQuery.Take(pResidencia.Top_Aux).AsQueryable();
            return pQuery;
        }

        // Este metodo se ocupa para hacer las busqueda de uno o varios Residenciaes por medio de condiciones
        public static async Task<List<ResidenciaEN>> BuscarAsync(ResidenciaEN pResidencia)
        {
            var Residenciaes = new List<ResidenciaEN>();
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    var select = dbContexto.Residencia.AsQueryable();
                    select = QuerySelect(select, pResidencia);
                    Residenciaes = await select.ToListAsync();
                }
                return Residenciaes;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar las Residencias: " + ex.Message);
            }
        }
    }
}
