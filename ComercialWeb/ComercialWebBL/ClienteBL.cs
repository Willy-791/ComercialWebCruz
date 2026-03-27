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

        public async Task<ClienteEN> ObtenerTodosPorIdAsync(ClienteEN pCliente)
        {
            return await ClienteDAL.ObtenerTodosPorIdAsync(pCliente);
        }

        public async Task<List<ClienteEN>> BuscarNombreAsync(ClienteEN pCliente)
        {
            return await ClienteDAL.BuscarNombreAsync(pCliente);
        }

        public async Task<List<ClienteEN>> BuscarDocumentoAsync(ClienteEN pCliente)
        {
            return await ClienteDAL.BuscarDocumentoAsync(pCliente);
        }
    }
}
