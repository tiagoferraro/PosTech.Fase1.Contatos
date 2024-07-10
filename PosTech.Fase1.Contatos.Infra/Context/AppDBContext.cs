

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PosTech.Fase1.Contatos.Domain.Entities;

namespace PosTech.Fase1.Contatos.Infra.Context;

public class AppDBContext(IConfiguration _configuration) : DbContext
{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.ApplyConfigurationsFromAssembly(typeof(AppDBContext).Assembly);
        }


    public DbSet<DDD> DDD { get; set; }
    public DbSet<Contato> Contatos { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataInclusao") != null))
        {
            if (entry.State == EntityState.Modified)
            {
                entry.Property("DataInclusao").IsModified = false;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

}

