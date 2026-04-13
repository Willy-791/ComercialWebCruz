using ComercialWebEN;
using Microsoft.EntityFrameworkCore;

namespace ComercialWebDAL
{
    public class RegistroPrestamoDAL
    {
        public static async Task<int> GuardarAsync(RegistroPrestamoEN pPrestamo)
        {
            try
            {
                using (var db = new DBContexto())
                {
                    db.Add(pPrestamo);
                    return await db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar préstamo: " + ex.Message);
            }
        }

        public static async Task<int> ModificarAsync(RegistroPrestamoEN pPrestamo)
        {
            try
            {
                using (var db = new DBContexto())
                {
                    var prestamo = await db.RegistroPrestamo
                        .FirstOrDefaultAsync(x => x.IdRegistroPrestamo == pPrestamo.IdRegistroPrestamo);

                    if (prestamo == null)
                        throw new Exception("Préstamo no encontrado");

                    prestamo.IdCliente = pPrestamo.IdCliente;
                    prestamo.IdProducto = pPrestamo.IdProducto;
                    prestamo.IdEstadoPrestamo = pPrestamo.IdEstadoPrestamo;
                    prestamo.FechaFin = pPrestamo.FechaFin;
                    prestamo.Detalle = pPrestamo.Detalle;

                    db.Update(prestamo);
                    return await db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar préstamo: " + ex.Message);
            }
        }

        public static async Task<int> EliminarAsync(RegistroPrestamoEN pPrestamo)
        {
            try
            {
                using (var db = new DBContexto())
                {
                    var prestamo = await db.RegistroPrestamo
                        .FirstOrDefaultAsync(x => x.IdRegistroPrestamo == pPrestamo.IdRegistroPrestamo);

                    if (prestamo == null)
                        throw new Exception("Préstamo no encontrado");

                    db.Remove(prestamo);
                    return await db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar préstamo: " + ex.Message);
            }
        }

        public static async Task<RegistroPrestamoEN> ObtenerPorIdAsync(RegistroPrestamoEN pPrestamo)
        {
            using (var db = new DBContexto())
            {
                return await db.RegistroPrestamo
                    .Include(x => x.Cliente)
                    .Include(x => x.Producto)
                    .Include(x => x.EstadoPrestamo)
                    .FirstOrDefaultAsync(x => x.IdRegistroPrestamo == pPrestamo.IdRegistroPrestamo);
            }
        }

        public static async Task<List<RegistroPrestamoEN>> ObtenerTodosAsync()
        {
            using (var db = new DBContexto())
            {
                return await db.RegistroPrestamo
                    .Include(x => x.Cliente)
                    .Include(x => x.Producto)
                    .Include(x => x.EstadoPrestamo)
                    .ToListAsync();
            }
        }

        public static async Task<List<RegistroPrestamoEN>> BuscarAsync(RegistroPrestamoEN pPrestamo)
        {
            using (var db = new DBContexto())
            {
                var query = db.RegistroPrestamo
                    .Include(x => x.Cliente)
                    .Include(x => x.Producto)
                    .Include(x => x.EstadoPrestamo)
                    .AsQueryable();

                if (pPrestamo.IdCliente > 0)
                    query = query.Where(x => x.IdCliente == pPrestamo.IdCliente);

                if (pPrestamo.IdProducto > 0)
                    query = query.Where(x => x.IdProducto == pPrestamo.IdProducto);

                if (pPrestamo.Top_Aux > 0)
                    query = query.Take(pPrestamo.Top_Aux);

                return await query.ToListAsync();
            }
        }
    }
}