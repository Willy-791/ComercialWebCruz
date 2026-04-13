using ComercialWebDAL;
using ComercialWebEN;
using System;
using System.Collections.Generic;
using System.Text;
using static ComercialWebBL.ProductoBL;

namespace ComercialWebBL
{
    public class EstadoPrestamoBL
    {
        public async Task<int> GuardarAsync(EstadoPrestamoEN pEstadoPrestamo)
        {
            return await EstadoPrestamoDAL.GuardarAsync(pEstadoPrestamo);
        }

        public async Task<int> ModificarAsync(EstadoPrestamoEN pEstadoPrestamo)
        {
            return await EstadoPrestamoDAL.ModificarAsync(pEstadoPrestamo);
        }

        public async Task<int> EliminarAsync(EstadoPrestamoEN pEstadoPrestamo)
        {
            return await EstadoPrestamoDAL.EliminarAsync(pEstadoPrestamo);
        }

        public async Task<EstadoPrestamoEN> ObtenerPorIdAsync(EstadoPrestamoEN pEstadoPrestamo)
        {
            return await EstadoPrestamoDAL.ObtenerPorIdAsync(pEstadoPrestamo);
        }

        public async Task<List<EstadoPrestamoEN>> ObtenerTodosAsync()
        {
            return await EstadoPrestamoDAL.ObtenerTodosAsync();
        }

        public async Task<List<EstadoPrestamoEN>> BuscarAsync(EstadoPrestamoEN pEstadoPrestamo)
        {
            return await EstadoPrestamoDAL.BuscarAsync(pEstadoPrestamo);
        }
    }
}
