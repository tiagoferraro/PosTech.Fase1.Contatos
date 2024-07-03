﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PosTech.Fase1.Contatos.Domain.Entities;

namespace PosTech.Fase1.Contatos.Infra.Interfaces
{
    public interface IContatoRepository
    {
        Task<Contato> Adicionar(Contato c);
        Task Atualizar(Contato c);
        Task<IEnumerable<Contato>> Listar();
        Task<IEnumerable<Contato>> ListarComDDD(int DDD);
        Task<Contato> Obter(int ContatoId);
    }
}