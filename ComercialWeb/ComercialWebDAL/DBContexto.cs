using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ComercialWebEN;   

namespace ComercialWebDAL
{
    public class DBContexto : DbContext
    {
        public DbSet<RolEN> Rol { get; set; }
        public DbSet<UsuarioEN> Usuario { get; set; }
        public DbSet<ProductoEN> Producto { get; set; }
        public DbSet<ClienteEN> Cliente { get; set; }
        public DbSet<CategoriaEN> Categoria { get; set; }
        public DbSet<EstadoPrestamo> EstadoPrestamo { get; set; }
        public DbSet<MarcaEN> Marca { get; set; }
        public DbSet<RegistroPrestamo> RegistroPrestamos { get; set; }
        public DbSet<RegistroVentaEN> RegistroVenta { get; set; }
        public DbSet<ResidenciaEN> Residencia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=ALDANA_DESK;Initial Catalog=ComercialCruz;Integrated Security=True;Trust Server Certificate=True");
        }
    }
}
