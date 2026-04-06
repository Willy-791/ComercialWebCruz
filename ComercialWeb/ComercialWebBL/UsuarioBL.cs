using ComercialWebDAL;
using ComercialWebEN;
using System;
using System.Collections.Generic;
using System.Text;

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

        public async Task<UsuarioEN> ObtenerPorIdAsync(UsuarioEN pUsuario)
        {
            return await UsuarioDAL.ObtenerPorId(pUsuario);
        }

        public async Task<List<UsuarioEN>> ObtenerTodosAsync()
        {
            return await UsuarioDAL.ObtenerTodosAsync();
        }

        public async Task<List<UsuarioEN>> BuscarAsync(UsuarioEN pUsuario)
        {
            return await UsuarioDAL.BuscarAsync(pUsuario);
        }

        public async Task<List<UsuarioEN>> BuscarIncluirRolesAsync(UsuarioEN pUsuario)
        {
            return await UsuarioDAL.BuscarIncluirRolesAsync(pUsuario);
        }
        public async Task<UsuarioEN> LoginAsync(UsuarioEN pUsuario)
        {
            return await UsuarioDAL.LoginAsync(pUsuario);
        }
    }
}
