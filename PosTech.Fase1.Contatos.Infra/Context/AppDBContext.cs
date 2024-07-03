using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PosTech.Fase1.Contatos.Domain.Entities;

namespace PosTech.Fase1.Contatos.Infra.Context
{
    public class AppDBContext: DbContext
    {
        private readonly IConfiguration _configuration;
        public AppDBContext(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
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


    }
}
