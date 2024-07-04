using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PosTech.Fase1.Contatos.Domain.Entities;

namespace PosTech.Fase1.Contatos.Infra.Mappins
{
    public class DDDConfiguration:IEntityTypeConfiguration<DDD>
    {
        public void Configure(EntityTypeBuilder<DDD> builder)
        {
            builder.ToTable("DDD");
            builder.HasKey(x => x.DddId);
            builder.Property(x => x.Regiao).HasMaxLength(50).IsRequired();
            builder.Property(x => x.UF).HasMaxLength(2).IsRequired();

        }
    }
}
