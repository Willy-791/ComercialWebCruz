using System;
using System.Collections.Generic;
using System.Text;

using ComercialWebEN;
using Microsoft.EntityFrameworkCore;

namespace ComercialWebDAL
{
    public class RegistroPrestamoDAL
    {
        public static async Task<int> GuardarAsync(RegistroPrestamo pRegistroPrestamo)
        {
            int result = 0;
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    dbContexto.Add(pRegistroPrestamo);
                    result = await dbContexto.SaveChangesAsync();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar el RegistroPrestamo: " + ex.Message);
            }
        }

        public static async Task<int> ModificarAsync(RegistroPrestamo pRegistroPrestamo)
        {
            int result = 0;
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    var RegistroPrestamo = await dbContexto.RegistroPrestamos
                        .FirstOrDefaultAsync(r => r.IdRegistroPrestamo == pRegistroPrestamo.IdRegistroPrestamo);

                    RegistroPrestamo.Detalle = pRegistroPrestamo.Detalle;
                    RegistroPrestamo.Estado = pRegistroPrestamo.Estado;

                    dbContexto.Update(RegistroPrestamo);
                    result = await dbContexto.SaveChangesAsync();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el RegistroPrestamo: " + ex.Message);
            }
        }

        public static async Task<int> EliminarAsync(RegistroPrestamo pRegistroPrestamo)
        {
            int result = 0;
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    var RegistroPrestamo = await dbContexto.RegistroPrestamos
                        .FirstOrDefaultAsync(x => x.IdRegistroPrestamo == pRegistroPrestamo.IdRegistroPrestamo);

                    dbContexto.RegistroPrestamos.Remove(RegistroPrestamo);
                    result = await dbContexto.SaveChangesAsync();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el RegistroPrestamo: " + ex.Message);
            }
        }

        public static async Task<RegistroPrestamo> ObtenerPorIdAsync(RegistroPrestamo pRegistroPrestamo)
        {
            RegistroPrestamo RegistroPrestamo = new RegistroPrestamo();
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    RegistroPrestamo = await dbContexto.RegistroPrestamos
                        .FirstOrDefaultAsync(s => s.IdRegistroPrestamo == pRegistroPrestamo.IdRegistroPrestamo);
                }
                return RegistroPrestamo;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el RegistroPrestamo por id: " + ex.Message);
            }
        }

        public static async Task<List<RegistroPrestamo>> ObtenerTodosAsync()
        {
            List<RegistroPrestamo> RegistroPrestamos = new List<RegistroPrestamo>();
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    RegistroPrestamos = await dbContexto.RegistroPrestamos.ToListAsync();
                }
                return RegistroPrestamos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener todos los RegistroPrestamos: " + ex.Message);
            }
        }

        internal static IQueryable<RegistroPrestamo> QuerySelect(IQueryable<RegistroPrestamo> pQuery, RegistroPrestamo pRegistroPrestamo)
        {
            if (pRegistroPrestamo.IdRegistroPrestamo > 0)
                pQuery = pQuery.Where(s => s.IdRegistroPrestamo == pRegistroPrestamo.IdRegistroPrestamo);

            if (pRegistroPrestamo.IdCliente > 0)
                pQuery = pQuery.Where(s => s.IdCliente == pRegistroPrestamo.IdCliente);

            if (pRegistroPrestamo.IdProducto > 0)
                pQuery = pQuery.Where(s => s.IdProducto == pRegistroPrestamo.IdProducto);

            if (pRegistroPrestamo.IdEstadoPrestamo > 0)
                pQuery = pQuery.Where(s => s.IdEstadoPrestamo == pRegistroPrestamo.IdEstadoPrestamo);

            if (pRegistroPrestamo.Estado)
                pQuery = pQuery.Where(s => s.Estado == pRegistroPrestamo.Estado);

            if (pRegistroPrestamo.Top_Aux > 0)
                pQuery = pQuery.Take(pRegistroPrestamo.Top_Aux).AsQueryable();

            return pQuery;
        }

        public static async Task<List<RegistroPrestamo>> BuscarAsync(RegistroPrestamo pRegistroPrestamo)
        {
            var RegistroPrestamos = new List<RegistroPrestamo>();
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    var select = dbContexto.RegistroPrestamos.AsQueryable();
                    select = QuerySelect(select, pRegistroPrestamo);
                    RegistroPrestamos = await select.ToListAsync();
                }
                return RegistroPrestamos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar los RegistroPrestamos: " + ex.Message);
            }
        }

        public static async Task<int> RegistrarDevolucionAsync(RegistroPrestamo pRegistroPrestamo)
        {
            int result = 0;
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    var registro = await dbContexto.RegistroPrestamos
                        .FirstOrDefaultAsync(r => r.IdRegistroPrestamo == pRegistroPrestamo.IdRegistroPrestamo);

                    if (registro != null)
                    {
                        // Aquí marcas como devuelto
                        registro.Estado = false; // o true dependiendo cómo lo manejemos el estado
                        registro.Detalle = pRegistroPrestamo.Detalle;

                        dbContexto.Update(registro);
                        result = await dbContexto.SaveChangesAsync();
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar la devolución: " + ex.Message);
            }
        }
    }
}
