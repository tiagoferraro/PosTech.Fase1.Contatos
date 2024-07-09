using Microsoft.EntityFrameworkCore;
using PosTech.Fase1.Contatos.Domain.Entities;
using PosTech.Fase1.Contatos.Infra.Context;
using PosTech.Fase1.Contatos.Infra.Interfaces;

namespace PosTech.Fase1.Contatos.Infra.Repository;

public class DDDRepository(AppDBContext context) : IDDDRepository
{
    public async Task<DDD> Adicionar(DDD d)
    {
        context.DDD.Add(d);
        await context.SaveChangesAsync();
        return d;
    }

    public async Task Atualizar(DDD d)
    {
        context.DDD.Update(d);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<DDD>> Listar()
    {
        return await context.DDD.AsNoTracking().ToListAsync();

    }

    public async Task<DDD> Obter(int DDDId)
    {
        return await context.DDD.FindAsync(DDDId);
    }
}

