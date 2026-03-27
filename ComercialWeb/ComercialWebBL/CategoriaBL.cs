using ComercialWebEN;
using System;
using System.Collections.Generic;
using System.Text;
using static ComercialWebBL.ProductoBL;

namespace ComercialWebBL
{
    public class CategoriaBL
    {
        public async Task<int> GuardarAsync(CategoriaEN pCategoria)
        {
            return await CategoriaDAL.GuardarAsync(pCategoria);
        }

        public async Task<int> ModificarAsync(CategoriaEN pCategoria)
        {
            return await CategoriaDAL.ModificarAsync(pCategoria);
        }

        public async Task<int> EliminarAsync(CategoriaEN pCategoria)
        {
            return await CategoriaDAL.EliminarAsync(pCategoria);
        }

        public async Task<CategoriaEN> ObtenerTodosPorIdAsync(CategoriaEN pCategoria)
        {
            return await CategoriaDAL.ObtenerTodosPorIdAsync(pCategoria);
        }

        public async Task<List<CategoriaEN>> BuscarAsync(CategoriaEN pCategoria)
        {
            return await CategoriaDAL.BuscarAsync(pCategoria);
        }
    }
}
