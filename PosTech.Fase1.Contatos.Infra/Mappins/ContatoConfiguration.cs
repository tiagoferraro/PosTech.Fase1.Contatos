using Microsoft.EntityFrameworkCore;
using PosTech.Fase1.Contatos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PosTech.Fase1.Contatos.Infra.Mappins
{
    public class ContatoConfiguration : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.ToTable("Contato");
            builder.HasKey(x => x.ContatoId);
            builder.Property(x => x.Nome).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(200);
            builder.Property(x => x.DataInclusao).HasColumnType("smalldatetime");
         
        }
    }
}
