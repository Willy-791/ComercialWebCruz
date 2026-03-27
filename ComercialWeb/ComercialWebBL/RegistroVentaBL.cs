using ComercialWebEN;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComercialWebBL
{
    public class RegistroVentaBL
    {
        public async Task<int> GuardarAsync(RegistroVentaEN pRegistroVenta)
        {
            return await RegistroVentaDAL.GuardarAsync(pRegistroVenta);
        }

        public async Task<int> ModificarAsync(RegistroVentaEN pRegistroVenta)
        {
            return await RegistroVentaDAL.ModificarAsync(pRegistroVenta);
        }

        public async Task<int> EliminarAsync(RegistroVentaEN pRegistroVenta)
        {
            return await RegistroVentaDAL.EliminarAsync(pRegistroVenta);
        }

        public async Task<RegistroVentaEN> ObtenerTodosPorIdAsync(RegistroVentaEN pRegistroVenta)
        {
            return await RegistroVentaDAL.ObtenerTodosPorIdAsync(pRegistroVenta);
        }

        public async Task<List<RegistroVentaEN>> BuscarAsync(RegistroVentaEN pRegistroVenta)
        {
            return await RegistroVentaDAL.BuscarAsync(pRegistroVenta);
        }

    }
}
