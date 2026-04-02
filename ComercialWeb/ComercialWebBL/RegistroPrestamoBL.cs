using ComercialWebEN;
using ComercialWebDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComercialWebBL
{
    public class RegistroPrestamoBL
    {
        public async Task<int> GuardarAsync(RegistroPrestamo pRegistroPrestamo)
        {
            return await RegistroPrestamoDAL.GuardarAsync(pRegistroPrestamo);
        }

        public async Task<int> ModificarAsync(RegistroPrestamo pRegistroPrestamo)
        {
            return await RegistroPrestamoDAL.ModificarAsync(pRegistroPrestamo);
        }

        public async Task<int> EliminarAsync(RegistroPrestamo pRegistroPrestamo)
        {
            return await RegistroPrestamoDAL.EliminarAsync(pRegistroPrestamo);
        }

        public async Task<RegistroPrestamo> ObtenerPorIdAsync(RegistroPrestamo pRegistroPrestamo)
        {
            return await RegistroPrestamoDAL.ObtenerPorIdAsync(pRegistroPrestamo);
        }

        public async Task<List<RegistroPrestamo>> ObtenerTodosAsync()
        {
            return await RegistroPrestamoDAL.ObtenerTodosAsync();
        }

        public async Task<List<RegistroPrestamo>> BuscarAsync(RegistroPrestamo pRegistroPrestamo)
        {
            return await RegistroPrestamoDAL.BuscarAsync(pRegistroPrestamo);
        }

        // Agrega el método para registrar la devolución
        public async Task<int> RegistrarDevolucionAsync(RegistroPrestamo pRegistroPrestamo)
        {
            return await RegistroPrestamoDAL.RegistrarDevolucionAsync(pRegistroPrestamo);
        }
    }
}
