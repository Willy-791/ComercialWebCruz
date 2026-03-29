using ComercialWebEN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ComercialWebDAL
{
    public class UsuarioDAL
    {
        private static void EncriptarMD5(UsuarioEN pUsuario)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.UTF8.GetBytes(
                    pUsuario.Password));
                var strEncriptar = "";
                for (int i = 0; i < result.Length; i++)
                    strEncriptar += result[i].ToString("x2").ToLower();
                pUsuario.Password = strEncriptar;
            }
        }

        private static async Task<bool> ExisteLogin(UsuarioEN pUsuario,
            DBContexto pDContexto)
        {
            bool result = false;
            var loginUsuarioExiste = await pDContexto.Usuario.FirstOrDefaultAsync(
                a => a.Login == pUsuario.Login && a.IdUsuario != pUsuario.IdUsuario);
            if (loginUsuarioExiste != null && loginUsuarioExiste.IdUsuario > 0 &&
                loginUsuarioExiste.Login == pUsuario.Login)
                result = true;
            return result;
        }

        #region "CRUD"
        public static async Task<int> GuardarAsync(UsuarioEN pUsuario)
        {
            int result = 0;
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    bool existeLogin = await ExisteLogin(pUsuario, dbContexto);
                    if (existeLogin == false)
                    {
                        EncriptarMD5(pUsuario);
                        pUsuario.FechaRegistro = DateTime.Now;
                        dbContexto.Add(pUsuario);
                        result = await dbContexto.SaveChangesAsync();
                    }
                    else
                    {
                        throw new Exception("Login ya existe");
                    }
                }
            }
            catch (Exception ex)
            {
                result = 0;
                throw new Exception(ex.Message);
            }
            return result;
        }

        public static async Task<int> ModificarAsync(UsuarioEN pUsuario)
        {
            int result = 0;
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    bool existeLogin = await ExisteLogin(pUsuario, dbContexto);
                    if (existeLogin == false)
                    {
                        var usuario = await dbContexto.Usuario.FirstOrDefaultAsync(
                            d => d.IdUsuario == pUsuario.IdUsuario);
                        usuario.IdRol = pUsuario.IdRol;
                        usuario.Nombre = pUsuario.Nombre;
                        usuario.Apellido = pUsuario.Apellido;
                        usuario.Login = pUsuario.Login;
                        usuario.Estatus = pUsuario.Estatus;
                        dbContexto.Update(usuario);
                        result = await dbContexto.SaveChangesAsync();
                    }
                    else
                        throw new Exception("Login ya existe");
                }
            }
            catch (Exception ex)
            {
                result = 0;
                throw new Exception(ex.Message);
            }
            return result;
        }

        public static async Task<int> EliminarAsync(UsuarioEN pUsuario)
        {
            int result = 0;
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    var usuario = await dbContexto.Usuario.FirstOrDefaultAsync(f => f.IdUsuario == pUsuario.IdUsuario);
                    dbContexto.Usuario.Remove(usuario);
                    result = await dbContexto.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                result = 0;
                throw new Exception("Ocurrio un error interno");
            }
            return result;
        }

        public static async Task<UsuarioEN> ObtenerPorId(UsuarioEN pUsuario)
        {
            var usuario = new UsuarioEN();
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    usuario = await dbContexto.Usuario.FirstOrDefaultAsync(s => s.IdUsuario == pUsuario.IdUsuario);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error interno");
            }
            return usuario;
        }

        public static async Task<List<UsuarioEN>> ObtenerTodosAsync()
        {
            List<UsuarioEN> usuarios = new List<UsuarioEN>();
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    usuarios = await dbContexto.Usuario.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return usuarios;
        }

        internal static IQueryable<UsuarioEN> QuerySelect(IQueryable<UsuarioEN> pQuery, UsuarioEN pUsuario)
        {
            if (pUsuario.IdUsuario > 0)
                pQuery = pQuery.Where(s => s.IdUsuario  == pUsuario.IdUsuario);
            if (pUsuario.IdRol > 0)
                pQuery = pQuery.Where(s => s.IdRol == pUsuario.IdRol);
            if (!string.IsNullOrWhiteSpace(pUsuario.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pUsuario.Nombre));
            if (!string.IsNullOrWhiteSpace(pUsuario.Apellido))
                pQuery = pQuery.Where(s => s.Apellido.Contains(pUsuario.Apellido));
            if (!string.IsNullOrWhiteSpace(pUsuario.Login))
                pQuery = pQuery.Where(s => s.Login == pUsuario.Login);
            if (pUsuario.Estatus > 0)
                pQuery = pQuery.Where(s => s.Estatus == pUsuario.Estatus);
            if (pUsuario.FechaRegistro.Year > 1000)
            {
                DateTime fechaInicial = new DateTime(pUsuario.FechaRegistro.Year,
                    pUsuario.FechaRegistro.Month, pUsuario.FechaRegistro.Day, 0, 0, 0);
                DateTime fechaFinal = fechaInicial.AddDays(1).AddMilliseconds(-1);
                pQuery = pQuery.Where(s => s.FechaRegistro >= fechaInicial &&
                s.FechaRegistro <= fechaFinal);
            }
            pQuery = pQuery.OrderByDescending(s => s.IdUsuario).AsQueryable();
            if (pUsuario.Top_Aux > 0)
                pQuery = pQuery.Take(pUsuario.Top_Aux).AsQueryable();
            return pQuery;

        }

        public static async Task<List<UsuarioEN>> BuscarAsync(UsuarioEN pUsuario)
        {
            var usuarios = new List<UsuarioEN>();
            using (var dbContexto = new DBContexto())
            {
                var select = dbContexto.Usuario.AsQueryable();
                select = QuerySelect(select, pUsuario);
                usuarios = await select.ToListAsync();
            }
            return usuarios;
        }
        #endregion

        public static async Task<List<UsuarioEN>> BuscarIncluirRolesAsync(UsuarioEN pUsuario)
        {
            var usuarios = new List<UsuarioEN>();
            using (var dbContexto = new DBContexto())
            {
                var select = dbContexto.Usuario.AsQueryable();
                select = QuerySelect(select, pUsuario).Include(s => s.Rol).AsQueryable();
                usuarios = await select.ToListAsync();
            }
            return usuarios;
        }
        
        
        public static async Task<UsuarioEN> LoginAsync(UsuarioEN pUsuario)
        {
            var usuario = new UsuarioEN();
            using (var dbContexto = new DBContexto())
            {
                EncriptarMD5(pUsuario);
                usuario = await dbContexto.Usuario.FirstOrDefaultAsync(
                    s => s.Login == pUsuario.Login && s.Password == pUsuario.Password
                    && s.Estatus == (byte)Estatus_Usuario.ACTIVO
                    );
            }

            return usuario;
        }
    }
}
