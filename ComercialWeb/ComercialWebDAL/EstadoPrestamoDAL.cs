using System;
using System.Collections.Generic;
using System.Text;

using ComercialWebEN;
using Microsoft.EntityFrameworkCore;

namespace ComercialWebDAL
{
    public class EstadoPrestamoDAL
    {
        public static async Task<int> GuardarAsync(EstadoPrestamoEN pEstado)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                dbContexto.Add(pEstado);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(EstadoPrestamoEN pEstado)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var Estado = await dbContexto.EstadoPrestamo
                    .FirstOrDefaultAsync(s => s.IdEstadoPrestamo == pEstado.IdEstadoPrestamo);

                Estado.Nombre = pEstado.Nombre;

                dbContexto.Update(Estado);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(EstadoPrestamoEN pEstado)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var Estado = await dbContexto.EstadoPrestamo
                    .FirstOrDefaultAsync(x => x.IdEstadoPrestamo == pEstado.IdEstadoPrestamo);

                dbContexto.EstadoPrestamo.Remove(Estado);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<EstadoPrestamoEN> ObtenerPorIdAsync(EstadoPrestamoEN pEstado)
        {
            EstadoPrestamoEN Estado = new EstadoPrestamoEN();
            using (var dbContexto = new DBContexto())
            {
                Estado = await dbContexto.EstadoPrestamo
                    .FirstOrDefaultAsync(s => s.IdEstadoPrestamo == pEstado.IdEstadoPrestamo);
            }
            return Estado;
        }

        public static async Task<List<EstadoPrestamoEN>> ObtenerTodosAsync()
        {
            List<EstadoPrestamoEN> Estados = new List<EstadoPrestamoEN>();
            using (var dbContexto = new DBContexto())
            {
                Estados = await dbContexto.EstadoPrestamo.ToListAsync();
            }
            return Estados;
        }

        internal static IQueryable<EstadoPrestamoEN> QuerySelect(IQueryable<EstadoPrestamoEN> pQuery, EstadoPrestamoEN pEstado)
        {
            if (pEstado.IdEstadoPrestamo > 0)
                pQuery = pQuery.Where(s => s.IdEstadoPrestamo == pEstado.IdEstadoPrestamo);

            if (!string.IsNullOrWhiteSpace(pEstado.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pEstado.Nombre));

            pQuery = pQuery.OrderByDescending(s => s.IdEstadoPrestamo).AsQueryable();

            if (pEstado.Top_Aux > 0)
                pQuery = pQuery.Take(pEstado.Top_Aux).AsQueryable();

            return pQuery;
        }

        public static async Task<List<EstadoPrestamoEN>> BuscarAsync(EstadoPrestamoEN pEstado)
        {
            var Estados = new List<EstadoPrestamoEN>();
            using (var dbContexto = new DBContexto())
            {
                var select = dbContexto.EstadoPrestamo.AsQueryable();
                select = QuerySelect(select, pEstado);
                Estados = await select.ToListAsync();
            }
            return Estados;
        }
    }
}
