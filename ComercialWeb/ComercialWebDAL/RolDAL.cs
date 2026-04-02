using System;
using System.Collections.Generic;
using System.Text;
using ComercialWebEN;
using Microsoft.EntityFrameworkCore;

namespace ComercialWebDAL
{
    public class RolDAL
    {
        public static async Task<int> GuardarAsync(RolEN pRol)
        {
            int result = 0;
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    dbContexto.Add(pRol);
                    result = await dbContexto.SaveChangesAsync();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar el rol: " + ex.Message);
            }
        }
        public static async Task<int> ModificarAsync(RolEN pRol)
        {
            int result = 0;
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    var rol = await dbContexto.Rol.FirstOrDefaultAsync(r => r.IdRol == pRol.IdRol);
                    rol.Nombre = pRol.Nombre;
                    dbContexto.Update(rol);
                    result = await dbContexto.SaveChangesAsync();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el rol: " + ex.Message);
            }
        }
        public static async Task<int> EliminarAsync(RolEN pRol)
        {
            int result = 0;
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    var rol = await dbContexto.Rol.FirstOrDefaultAsync(x => x.IdRol == pRol.IdRol);
                    dbContexto.Rol.Remove(rol);
                    result = await dbContexto.SaveChangesAsync();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el rol: " + ex.Message);
            }
        }
        public static async Task<RolEN> ObtenerPorIdAsync(RolEN pRol)
        {
            RolEN rol = new RolEN();
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    //Select Id, Nombre From Rol Where Id = 1; 
                    rol = await dbContexto.Rol.FirstOrDefaultAsync(s => s.IdRol == pRol.IdRol);
                }
                return rol;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el rol por id: " + ex.Message);
            }
        }
        public static async Task<List<RolEN>> ObtenerTodosAsync()
        {
            List<RolEN> roles = new List<RolEN>();
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    roles = await dbContexto.Rol.ToListAsync();
                }
                return roles;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener todos los roles: " + ex.Message);
            }
        }
        internal static IQueryable<RolEN> QuerySelect(IQueryable<RolEN> pQuery, RolEN pRol)
        {
            if (pRol.IdRol > 0)
                pQuery = pQuery.Where(s => s.IdRol == pRol.IdRol);
            if (!string.IsNullOrWhiteSpace(pRol.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pRol.Nombre));
            pQuery = pQuery.OrderByDescending(s => s.IdRol).AsQueryable();
            if (pRol.Top_Aux > 0)
                pQuery = pQuery.Take(pRol.Top_Aux).AsQueryable();
            return pQuery;
        }

        // Este metodo se ocupa para hacer las busqueda de uno o varios roles por medio de condiciones
        public static async Task<List<RolEN>> BuscarAsync(RolEN pRol)
        {
            var roles = new List<RolEN>();
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    var select = dbContexto.Rol.AsQueryable();
                    select = QuerySelect(select, pRol);
                    roles = await select.ToListAsync();
                }
                return roles;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar los roles: " + ex.Message);
            }
        }
    }
}
