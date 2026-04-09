using System;
using System.Collections.Generic;
using System.Text;

using ComercialWebEN;
using Microsoft.EntityFrameworkCore;

namespace ComercialWebDAL
{
    public class RegistroVentaDAL
    {
        public static async Task<int> GuardarAsync(RegistroVentaEN pRegistroVenta)
        {
            int result = 0;
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    dbContexto.Add(pRegistroVenta);
                    result = await dbContexto.SaveChangesAsync();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar el RegistroVenta: " + ex.Message);
            }
        }
        public static async Task<int> ModificarAsync(RegistroVentaEN pRegistroVenta)
        {
            int result = 0;
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    var RegistroVenta = await dbContexto.RegistroVenta
                        .FirstOrDefaultAsync(r => r.IdRegistroVenta == pRegistroVenta.IdRegistroVenta);

                    RegistroVenta.Detalle = pRegistroVenta.Detalle;
                

                    dbContexto.Update(RegistroVenta);
                    result = await dbContexto.SaveChangesAsync();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el RegistroVenta: " + ex.Message);
            }
        }
        public static async Task<int> EliminarAsync(RegistroVentaEN pRegistroVenta)
        {
            int result = 0;
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    var RegistroVenta = await dbContexto.RegistroVenta
                        .FirstOrDefaultAsync(x => x.IdRegistroVenta == pRegistroVenta.IdRegistroVenta);

                    dbContexto.RegistroVenta.Remove(RegistroVenta);
                    result = await dbContexto.SaveChangesAsync();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el RegistroVenta: " + ex.Message);
            }
        }
        public static async Task<RegistroVentaEN> ObtenerPorIdAsync(RegistroVentaEN pRegistroVenta)
        {
            RegistroVentaEN RegistroVenta = new RegistroVentaEN();
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    //Select Id, Nombre From RegistroVenta Where Id = 1; 
                    RegistroVenta = await dbContexto.RegistroVenta
                        .FirstOrDefaultAsync(s => s.IdRegistroVenta == pRegistroVenta.IdRegistroVenta);
                }
                return RegistroVenta;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el RegistroVenta por id: " + ex.Message);
            }
        }
        public static async Task<List<RegistroVentaEN>> ObtenerTodosAsync()
        {
            List<RegistroVentaEN> RegistroVentaes = new List<RegistroVentaEN>();
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    RegistroVentaes = await dbContexto.RegistroVenta.ToListAsync();
                }
                return RegistroVentaes;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener todas las RegistroVentas: " + ex.Message);
            }
        }
        internal static IQueryable<RegistroVentaEN> QuerySelect(IQueryable<RegistroVentaEN> pQuery, RegistroVentaEN pRegistroVenta)
        {
            if (pRegistroVenta.IdRegistroVenta > 0)
                pQuery = pQuery.Where(s => s.IdRegistroVenta == pRegistroVenta.IdRegistroVenta);

            if (pRegistroVenta.IdCliente > 0)
                pQuery = pQuery.Where(s => s.IdCliente == pRegistroVenta.IdCliente);

            if (pRegistroVenta.IdProducto > 0)
                pQuery = pQuery.Where(s => s.IdProducto == pRegistroVenta.IdProducto);

            

            if (pRegistroVenta.Top_Aux > 0)
                pQuery = pQuery.Take(pRegistroVenta.Top_Aux).AsQueryable();
            return pQuery;
        }

        // Este metodo se ocupa para hacer las busqueda de uno o varios RegistroVentaes por medio de condiciones
        public static async Task<List<RegistroVentaEN>> BuscarAsync(RegistroVentaEN pRegistroVenta)
        {
            var RegistroVentaes = new List<RegistroVentaEN>();
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    var select = dbContexto.RegistroVenta.AsQueryable();
                    select = QuerySelect(select, pRegistroVenta);
                    RegistroVentaes = await select.ToListAsync();
                }
                return RegistroVentaes;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar los RegistroVentas: " + ex.Message);
            }
        }
    }
}
