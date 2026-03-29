using ComercialWebEN;
using ComercialWebDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComercialWebBL
{
    public class ResidenciaBL
    {
        public async Task<int> GuardarAsync(ResidenciaEN pResidencia)
        {
            return await ResidenciaDAL.GuardarAsync(pResidencia);
        }

        public async Task<int> ModificarAsync(ResidenciaEN pResidencia)
        {
            return await ResidenciaDAL.ModificarAsync(pResidencia);
        }

        public async Task<int> EliminarAsync(ResidenciaEN pResidencia)
        {
            return await ResidenciaDAL.EliminarAsync(pResidencia);
        }

        public async Task<List<ResidenciaEN>> ObtenerTodosAsync()
        {
            return await ResidenciaDAL.ObtenerTodosAsync();
        }

        public async Task<ResidenciaEN> ObtenerPorIdAsync(ResidenciaEN pRol)
        {
            return await ResidenciaDAL.ObtenerPorIdAsync(pRol);
        }

        public async Task<List<ResidenciaEN>> BuscarAsync(ResidenciaEN pResidencia)
        {
            return await ResidenciaDAL.BuscarAsync(pResidencia);
        }
    }
}
