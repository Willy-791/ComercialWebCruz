using ComercialWebEN;
using System;
using System.Collections.Generic;
using System.Text;
using static ComercialWebBL.ProductoBL;

namespace ComercialWebBL
{
    public class MarcaBL
    {
        public async Task<int> GuardarAsync(MarcaBL pMarca)
        {
            return await MarcaDAL.GuardarAsync(pMarca);
        }

        public async Task<int> ModificarAsync(MarcaBL pMarca)
        {
            return await MarcaDAL.ModificarAsync(pMarca);
        }

        public async Task<int> EliminarAsync(MarcaBL pMarca)
        {
            return await MarcaDAL.EliminarAsync(pMarca);
        }

        public async Task<MarcaBL> ObtenerTodosPorIdAsync(MarcaBL pMarca)
        {
            return await MarcaDAL.ObtenerTodosPorIdAsync(pMarca);
        }

        public async Task<List<MarcaBL>> BuscarPorMarcaAsync(MarcaBL pMarca)
        {
            return await MarcaDAL.BuscarPorMarcaAsync(pMarca);
        }

    }
}
