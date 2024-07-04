using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PosTech.Fase1.Contatos.Domain.Entities;
using PosTech.Fase1.Contatos.Infra.Context;
using PosTech.Fase1.Contatos.Infra.Interfaces;

namespace PosTech.Fase1.Contatos.Infra.Repository
{
    public class ContatoRepository:IContatoRepository
    {
        private readonly AppDBContext _context;

        public ContatoRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<Contato> Adicionar(Contato c)
        {
            _context.Contatos.Add(c);
            await _context.SaveChangesAsync();
            return c;
        }

        public Task Atualizar(Contato c)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Contato>> Listar()
        {
            return await _context.Contatos.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Contato>> ListarComDDD(int DDD)
        {
            return await _context.Contatos.AsNoTracking().Where(c => c.DddId == DDD).ToListAsync();
        }

        public async Task<Contato> Obter(int ContatoId)
        {
            return await _context.Contatos.FindAsync(ContatoId);
        }
    }
}
