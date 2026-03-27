using ComercialWebEN;
using System;
using System.Collections.Generic;
using System.Text;
using static ComercialWebBL.ProductoBL;

namespace ComercialWebBL
{
    public class EstadoPrestamoBL
    {
        public async Task<int> GuardarAsync(EstadoPrestamo pEstadoPrestamo)
        {
            return await EstadoPrestamoDAL.GuardarAsync(pEstadoPrestamo);
        }

        public async Task<int> ModificarAsync(EstadoPrestamo pEstadoPrestamo)
        {
            return await EstadoPrestamoDAL.ModificarAsync(pEstadoPrestamo);
        }

        public async Task<int> EliminarAsync(EstadoPrestamo pEstadoPrestamo)
        {
            return await EstadoPrestamoDAL.EliminarAsync(pEstadoPrestamo);
        }

        public async Task<EstadoPrestamo> ObtenerTodosPorIdAsync(EstadoPrestamo pEstadoPrestamo)
        {
            return await EstadoPrestamoDAL.ObtenerTodosPorIdAsync(pEstadoPrestamo);
        }

        public async Task<List<EstadoPrestamo>> BuscarAsync(EstadoPrestamo pEstadoPrestamo)
        {
            return await EstadoPrestamoDAL.BuscarAsync(pEstadoPrestamo);
        }
    }
}
