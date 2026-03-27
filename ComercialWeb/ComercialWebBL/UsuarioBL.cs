using System;
using System.Collections.Generic;
using System.Text;

using ComercialWebEN;
using ComercialWebDAL;

namespace ComercialWebBL
{
    public class UsuarioBL
    {
        public async Task<int> GuardarAsync(UsuarioEN pUsuario)
        {
            return await UsuarioDAL.GuardarAsync(pUsuario);
        }

        public async Task<int> ModificarAsync(UsuarioEN pUsuario)
        {
            return await UsuarioDAL.ModificarAsync(pUsuario);
        }

        public async Task<int> EliminarAsync(UsuarioEN pUsuario)
        {
            return await UsuarioDAL.EliminarAsync(pUsuario);
        }

        public async Task<UsuarioEN> ObtenerTodosPorIdAsync(UsuarioEN pUsuario)
        {
            return await UsuarioDAL.ObtenerTodosPorIdAsync(pUsuario);
        }

        public async Task<List<UsuarioEN>> BuscarAsync(UsuarioEN pUsuario)
        {
            return await UsuarioDAL.BuscarAsync(pUsuario);
        }
    }
}
