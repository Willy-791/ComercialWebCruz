
using System;
using System.Collections.Generic;
using System.Text;

using ComercialWebEN;
using ComercialWebDAL;


namespace ComercialWebBL
{
    public class MarcaBL
    {
        public async Task<int> GuardarAsync(MarcaEN pMarca)
        {
            return await MarcaDAL.GuardarAsync(pMarca);
        }

        public async Task<int> ModificarAsync(MarcaEN pMarca)
        {
            return await MarcaDAL.ModificarAsync(pMarca);
        }

        public async Task<int> EliminarAsync(MarcaEN pMarca)
        {
            return await MarcaDAL.EliminarAsync(pMarca);
        }

        public async Task<MarcaEN> ObtenerPorIdAsync(MarcaEN pMarca)
        {
            return await MarcaDAL.ObtenerPorIdAsync(pMarca);
        }

        public async Task<List<MarcaEN>> ObtenerTodosAsync()
        {
            return await MarcaDAL.ObtenerTodosAsync();
        }

        public async Task<List<MarcaEN>> BuscarAsync(MarcaEN pMarca)
        {
            return await MarcaDAL.BuscarAsync(pMarca);
        }

    }
}
