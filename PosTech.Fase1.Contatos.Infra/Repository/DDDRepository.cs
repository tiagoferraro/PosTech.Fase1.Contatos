using Microsoft.EntityFrameworkCore;
using PosTech.Fase1.Contatos.Domain.Entities;
using PosTech.Fase1.Contatos.Infra.Context;
using PosTech.Fase1.Contatos.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosTech.Fase1.Contatos.Infra.Repository
{
    public class DDDRepository : IDDDRepository
    {
        private readonly AppDBContext _context;

        public DDDRepository(AppDBContext context)
        {
            _context = context;
        }
        public async Task<DDD> Adicionar(DDD d)
        {
            _context.DDD.Add(d);
            await _context.SaveChangesAsync();
            return d;
        }

        public async Task Atualizar(DDD d)
        {
            _context.DDD.Update(d);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DDD>> Listar()
        {
            return await _context.DDD.AsNoTracking().ToListAsync();

        }

        public async Task<DDD> Obter(int dddId)
        {
            return await _context.DDD.FindAsync(dddId) ?? throw new InvalidOperationException("DDD não encontrado.");
        }
    }
}
