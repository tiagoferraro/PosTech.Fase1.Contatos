using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PosTech.Fase1.Contatos.Application.DTO;
using PosTech.Fase1.Contatos.Domain.Entities;

namespace PosTech.Fase1.Contatos.Application.Mappins;

    public class DDDMapingProfile:Profile
    {
        public DDDMapingProfile()
        {
            CreateMap<DDD, DDDDto>().ReverseMap();

        }
    }

