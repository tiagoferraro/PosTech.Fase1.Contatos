﻿using Microsoft.EntityFrameworkCore;
using PosTech.Fase1.Contatos.Domain.Entities;
using PosTech.Fase1.Contatos.Infra.Context;
using PosTech.Fase1.Contatos.Infra.Interfaces;


namespace PosTech.Fase1.Contatos.Infra.Repository;

public class ContatoRepository(AppDBContext context) : IContatoRepository
{
    public async Task<Contato> Adicionar(Contato c)
    {
        context.Contatos.Add(c);
        await context.SaveChangesAsync();
        await context.Entry(c).Reference(x => x.Ddd).LoadAsync();
        return c;
    }

    public async Task Atualizar(Contato c)
    {
        context.Contatos.Update(c);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Contato>> Listar()
    {
        return await context.Contatos.Include(c => c.Ddd).AsNoTracking().Where(c => c.Ativo).ToListAsync();
    }

    public async Task<IEnumerable<Contato>> ListarComDDD(int dddId)
    {
        return await context.Contatos.Include(c => c.Ddd).AsNoTracking().Where(c => c.DddId == dddId && c.Ativo)
            .ToListAsync();
    }

    public async Task<Contato?> Obter(int contatoId)
    {
        return await context.Contatos.Include(c => c.Ddd).FirstOrDefaultAsync(c => c.ContatoId == contatoId && c.Ativo);
    }

    public async Task<bool> Existe(Contato c)
    {
        return await context.Contatos.AsNoTracking().AnyAsync(contato =>
            contato.Nome.Equals(c.Nome) && contato.Telefone.Equals(c.Telefone) && contato.DddId.Equals(c.DddId));
    }
}

