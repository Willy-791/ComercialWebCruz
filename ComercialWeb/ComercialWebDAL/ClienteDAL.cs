using ComercialWebEN;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ComercialWebDAL
{
    public class ClienteDAL
    {
        public static async Task<int> GuardarAsync(ClienteEN pCliente)
        {
            int result = 0;
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    dbContexto.Add(pCliente);
                    result = await dbContexto.SaveChangesAsync();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar el Cliente: " + ex.Message);
            }
        }

        public static async Task<int> ModificarAsync(ClienteEN pCliente)
        {
            int result = 0;
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    var Cliente = await dbContexto.Cliente
                        .FirstOrDefaultAsync(r => r.IdCliente == pCliente.IdCliente);

                    Cliente.Nombre = pCliente.Nombre;
                    Cliente.Apellido = pCliente.Apellido;
                    Cliente.Celular = pCliente.Celular;
                    Cliente.Estado = pCliente.Estado;

                    dbContexto.Update(Cliente);
                    result = await dbContexto.SaveChangesAsync();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el Cliente: " + ex.Message);
            }
        }

        public static async Task<int> EliminarAsync(ClienteEN pCliente)
        {
            int result = 0;
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    var Cliente = await dbContexto.Cliente
                        .FirstOrDefaultAsync(x => x.IdCliente == pCliente.IdCliente);

                    dbContexto.Cliente.Remove(Cliente);
                    result = await dbContexto.SaveChangesAsync();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el Cliente: " + ex.Message);
            }
        }

        public static async Task<ClienteEN> ObtenerPorIdAsync(ClienteEN pCliente)
        {
            ClienteEN Cliente = new ClienteEN();
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    Cliente = await dbContexto.Cliente
                        .FirstOrDefaultAsync(s => s.IdCliente == pCliente.IdCliente);
                }
                return Cliente;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el Cliente por id: " + ex.Message);
            }
        }

        public static async Task<List<ClienteEN>> ObtenerTodosAsync()
        {
            List<ClienteEN> Cliente = new List<ClienteEN>();
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    Cliente = await dbContexto.Cliente.ToListAsync();
                }
                return Cliente;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener todos los Cliente: " + ex.Message);
            }
        }

        internal static IQueryable<ClienteEN> QuerySelect(IQueryable<ClienteEN> pQuery, ClienteEN pCliente)
        {
            if (pCliente.IdCliente > 0)
                pQuery = pQuery.Where(s => s.IdCliente == pCliente.IdCliente);

            if (pCliente.IdResidencia > 0)
                pQuery = pQuery.Where(s => s.IdResidencia == pCliente.IdResidencia);

            if (!string.IsNullOrWhiteSpace(pCliente.Nombre))
                pQuery = pQuery.Where(s => s.Nombre == pCliente.Nombre);
           

            if (!string.IsNullOrWhiteSpace(pCliente.Apellido))
                pQuery = pQuery.Where(s => s.Apellido == pCliente.Apellido);

            if (!string.IsNullOrWhiteSpace(pCliente.Celular))
                pQuery = pQuery.Where(s => s.Celular == pCliente.Celular);

            pQuery = pQuery.Where(s => s.Estado == pCliente.Estado);

            if (pCliente.Top_Aux > 0)
                pQuery = pQuery.Take(pCliente.Top_Aux).AsQueryable();

            return pQuery;
        }

        public static async Task<List<ClienteEN>> BuscarAsync(ClienteEN pCliente)
        {
            var Cliente = new List<ClienteEN>();
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    var select = dbContexto.Cliente.AsQueryable();
                    select = QuerySelect(select, pCliente);
                    Cliente = await select.ToListAsync();
                }
                return Cliente;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar los Cliente: " + ex.Message);
            }
        }
    }
}
