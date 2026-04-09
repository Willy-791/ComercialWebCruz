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
                throw new Exception("Error al guardar la venta: " + ex.Message);
            }
        }

        public static async Task<int> ModificarAsync(RegistroVentaEN pRegistroVenta)
        {
            int result = 0;
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    var venta = await dbContexto.RegistroVenta
                        .FirstOrDefaultAsync(x => x.IdRegistroVenta == pRegistroVenta.IdRegistroVenta);

                    if (venta == null)
                        throw new Exception("Venta no encontrada");

                    venta.IdCliente = pRegistroVenta.IdCliente;
                    venta.IdProducto = pRegistroVenta.IdProducto;

                    venta.Detalle = pRegistroVenta.Detalle;

                    dbContexto.Update(venta);
                    result = await dbContexto.SaveChangesAsync();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar la venta: " + ex.Message);
            }
        }

        public static async Task<int> EliminarAsync(RegistroVentaEN pRegistroVenta)
        {
            int result = 0;
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    var venta = await dbContexto.RegistroVenta
                        .FirstOrDefaultAsync(x => x.IdRegistroVenta == pRegistroVenta.IdRegistroVenta);

                    if (venta == null)
                        throw new Exception("Venta no encontrada");

                    dbContexto.Remove(venta);
                    result = await dbContexto.SaveChangesAsync();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la venta: " + ex.Message);
            }
        }

        public static async Task<RegistroVentaEN> ObtenerPorIdAsync(RegistroVentaEN pRegistroVenta)
        {
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    return await dbContexto.RegistroVenta
                        .Include(x => x.Cliente)
                        .Include(x => x.Producto)
                        .FirstOrDefaultAsync(x => x.IdRegistroVenta == pRegistroVenta.IdRegistroVenta);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la venta: " + ex.Message);
            }
        }

        public static async Task<List<RegistroVentaEN>> ObtenerTodosAsync()
        {
            using (var dbContexto = new DBContexto())
            {
                return await dbContexto.RegistroVenta
                    .Include(x => x.Cliente)
                    .Include(x => x.Producto)
                    .ToListAsync();
            }
        }

        internal static IQueryable<RegistroVentaEN> QuerySelect(IQueryable<RegistroVentaEN> pQuery, RegistroVentaEN pRegistroVenta)
        {
            if (pRegistroVenta.IdCliente > 0)
                pQuery = pQuery.Where(s => s.IdCliente == pRegistroVenta.IdCliente);

            if (pRegistroVenta.IdProducto > 0)
                pQuery = pQuery.Where(s => s.IdProducto == pRegistroVenta.IdProducto);

            if (pRegistroVenta.Top_Aux > 0)
                pQuery = pQuery.Take(pRegistroVenta.Top_Aux);

            return pQuery;
        }

        public static async Task<List<RegistroVentaEN>> BuscarAsync(RegistroVentaEN pRegistroVenta)
        {
            using (var dbContexto = new DBContexto())
            {
                var query = dbContexto.RegistroVenta
                    .Include(x => x.Cliente)
                    .Include(x => x.Producto)
                    .AsQueryable();

                query = QuerySelect(query, pRegistroVenta);

                return await query.ToListAsync();
            }
        }
    }
}