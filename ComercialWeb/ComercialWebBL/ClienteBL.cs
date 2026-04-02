using ComercialWebDAL;
using ComercialWebEN;
using System;
using System.Collections.Generic;
using System.Text;
using static ComercialWebBL.ProductoBL;

namespace ComercialWebBL
{
    public class ClienteBL
    {
        public async Task<int> GuardarAsync(ClienteEN pCliente)
        {
            return await ClienteDAL.GuardarAsync(pCliente);
        }

        public async Task<int> ModificarAsync(ClienteEN pCliente)
        {
            return await ClienteDAL.ModificarAsync(pCliente);
        }

        public async Task<int> EliminarAsync(ClienteEN pCliente)
        {
            return await ClienteDAL.EliminarAsync(pCliente);
        }

        public async Task<ClienteEN> ObtenerPorIdAsync(ClienteEN pCliente)
        {
            return await ClienteDAL.ObtenerPorIdAsync(pCliente);
        }

        public async Task<List<ClienteEN>> ObtenerTodosAsync()
        {
            return await ClienteDAL.ObtenerTodosAsync();
        }

        public async Task<List<ClienteEN>> BuscarAsync(ClienteEN pCliente)
        {
            return await ClienteDAL.BuscarAsync(pCliente);
        }
    }
}
