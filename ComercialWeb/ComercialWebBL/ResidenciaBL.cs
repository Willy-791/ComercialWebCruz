using ComercialWebEN;
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

        public async Task<ResidenciaEN> ObtenerTodosPorIdAsync(ResidenciaEN pResidencia)
        {
            return await ResidenciaDAL.ObtenerTodosPorIdAsync(pResidencia);
        }

        public async Task<List<ResidenciaEN>> BuscarAsync(ResidenciaEN pResidencia)
        {
            return await ResidenciaDAL.BuscarAsync(pResidencia);
        }
    }
}
