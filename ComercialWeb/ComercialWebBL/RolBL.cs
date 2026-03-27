using ComercialWebEN;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComercialWebBL
{
    public class RolBL
    {
        public async Task<int> GuardarAsync(RolEN pRol)
        {
            return await RolDAL.GuardarAsync(pRol);
        }

        public async Task<int> ModificarAsync(RolEN pRol)
        {
            return await RolDAL.ModificarAsync(pRol);
        }

        public async Task<int> EliminarAsync(RolEN pRol)
        {
            return await RolDAL.EliminarAsync(pRol);
        }

        public async Task<RolEN> ObtenerTodosPorIdAsync(RolEN pRol)
        {
            return await RolDAL.ObtenerTodosPorIdAsync(pRol);
        }

        public async Task<List<RolEN>> BuscarAsync(RolEN pRol)
        {
            return await RolDAL.BuscarAsync(pRol);
        }
    }
}
