using System;
using System.Collections.Generic;
using System.Text;

using ComercialWebEN;
using Microsoft.EntityFrameworkCore;

namespace ComercialWebDAL
{
    public class EstadoPrestamoDAL
    {
        public static async Task<int> GuardarAsync(EstadoPrestamo pEstado)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                dbContexto.Add(pEstado);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(EstadoPrestamo pEstado)
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

        public static async Task<int> EliminarAsync(EstadoPrestamo pEstado)
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

        public static async Task<EstadoPrestamo> ObtenerPorIdAsync(EstadoPrestamo pEstado)
        {
            EstadoPrestamo Estado = new EstadoPrestamo();
            using (var dbContexto = new DBContexto())
            {
                Estado = await dbContexto.EstadoPrestamo
                    .FirstOrDefaultAsync(s => s.IdEstadoPrestamo == pEstado.IdEstadoPrestamo);
            }
            return Estado;
        }

        public static async Task<List<EstadoPrestamo>> ObtenerTodosAsync()
        {
            List<EstadoPrestamo> Estados = new List<EstadoPrestamo>();
            using (var dbContexto = new DBContexto())
            {
                Estados = await dbContexto.EstadoPrestamo.ToListAsync();
            }
            return Estados;
        }

        internal static IQueryable<EstadoPrestamo> QuerySelect(IQueryable<EstadoPrestamo> pQuery, EstadoPrestamo pEstado)
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

        public static async Task<List<EstadoPrestamo>> BuscarAsync(EstadoPrestamo pEstado)
        {
            var Estados = new List<EstadoPrestamo>();
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
