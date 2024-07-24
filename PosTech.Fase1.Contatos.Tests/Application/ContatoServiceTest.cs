using AutoMapper;
using Moq;
using PosTech.Fase1.Contatos.Application.DTO;
using PosTech.Fase1.Contatos.Application.Mappins;
using PosTech.Fase1.Contatos.Application.Services;
using PosTech.Fase1.Contatos.Domain.Entities;
using PosTech.Fase1.Contatos.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosTech.Fase1.Contatos.Tests.Application
{
    public class ContatoServiceTest
    {
        [Fact]
        public async void ContatoService_Adiconar_ContatoServiceAdicionadoComSucesso()
        {
            //arrange
            var ContatoServiceRepository = new Mock<IContatoRepository>();
            var dddRepository = new Mock<IDDDRepository>();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ContatoMapingProfile());
            });
            var _mapper = mockMapper.CreateMapper();

            var ContatoService = new ContatoService(ContatoServiceRepository.Object, _mapper, dddRepository.Object);
            var ContatoDTO = new ContatoDTO()
            {
                ContatoId = 2,
                Nome = "João da Silva",
                Telefone = "7198875566",
                Email = "joao.silva@gmail.com",
                //Ativo = true,
                DddId = 11
            };

            //act
            var ContatoResult = await ContatoService.Adicionar(ContatoDTO);

            //assert
            Assert.True(ContatoResult.IsSuccess);
        }

        [Fact]
        public async void ContatoService_Excluir_ContatoServiceExcluidoComSucesso()
        {
            //arrange
            var ContatoServiceRepository = new Mock<IContatoRepository>();
            var dddRepository = new Mock<IDDDRepository>();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ContatoMapingProfile());
            });
            var _mapper = mockMapper.CreateMapper();

            var ContatoService = new ContatoService(ContatoServiceRepository.Object, _mapper, dddRepository.Object);

            //act
            var ContatoResult = await ContatoService.Excluir(2);

            //assert
            Assert.True(ContatoResult.IsSuccess);
        }
    }
}
