using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PosTech.Fase1.Contatos.Domain.Entities;

namespace PosTech.Fase1.Contatos.Infra.Mappins;

public class DDDConfiguration : IEntityTypeConfiguration<DDD>
{
    public void Configure(EntityTypeBuilder<DDD> builder)
    {
        builder.ToTable("Ddd");
        builder.HasKey(x => x.DddId);
        builder.Property(x => x.Regiao).HasMaxLength(50).IsRequired();
        builder.Property(x => x.UfSigla).HasMaxLength(2).IsRequired();
        builder.Property(x => x.UfNome).HasMaxLength(100).IsRequired();
    
    }
}

