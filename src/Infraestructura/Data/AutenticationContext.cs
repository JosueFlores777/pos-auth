

using Dominio.Models;
using Dominio.Service;
using Infraestructura.Seeders;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infraestructura.Data
{
    public class AutenticationContext : DbContext
    {
        private readonly DbContextOptions<AutenticationContext> options;
        private readonly ITokenService tokenService;

        public AutenticationContext(DbContextOptions<AutenticationContext> options, ITokenService tokenService)
      : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
            this.options = options;
            this.tokenService = tokenService;
        }
        public DbSet<Usuario> usuario { get; set; }
        public DbSet<Permiso> permiso { get; set; }
        public DbSet<RolPermiso> rolPermiso { get; set; }
        public DbSet<UsuarioRegional> usuarioRegional { get; set; }
        public DbSet<UsuarioArea> usuarioArea { get; set; }
        public DbSet<Rol> rol { get; set; }
        public DbSet<Catalogo> catalogo { get; set; }
        public DbSet<UsuarioRol> usuarioRol { get; set; }
        public DbSet<Importardor> importador { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            PermisoSeeder.Seed(builder);
            UsuarioSeeder.Seed(builder);
            ImportadorPermisoSeeder.Seed(builder);
            PermisoCatalogosSeeder.Seed(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AutenticationContext).Assembly);
            base.OnModelCreating(builder);

        }
        public override int SaveChanges()
        {
            var changedEntities = ChangeTracker.Entries();

            foreach (var changedEntity in changedEntities)
            {
                if (changedEntity.Entity is IEntityAuditable)
                {
                    var entity = (IEntityAuditable)changedEntity.Entity;

                    if (changedEntity.State == EntityState.Added)
                    {
                        entity.FechaCreacion = DateTime.Now;
                        entity.UsuarioCreo = tokenService.GetIdUsuario();
                    }
                    if (changedEntity.State == EntityState.Modified)
                    {

                        changedEntity.Context.Entry(entity).Property(x => x.FechaCreacion).IsModified = false;
                        changedEntity.Context.Entry(entity).Property(x => x.UsuarioCreo).IsModified = false;
                        entity.FechaModificacion = DateTime.Now;
                        entity.UsuarioModifica = tokenService.GetIdUsuario();
                    }
                }
            }

            return base.SaveChanges();
        }

    }
}
