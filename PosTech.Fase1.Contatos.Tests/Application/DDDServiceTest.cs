using AutoMapper;
using Moq;
using PosTech.Fase1.Contatos.Application.DTO;
using PosTech.Fase1.Contatos.Application.Mappins;
using PosTech.Fase1.Contatos.Application.Services;
using PosTech.Fase1.Contatos.Infra.Interfaces;

namespace PosTech.Fase1.Contatos.Tests.Application;

public class DDDServiceTest
{
    [Fact]
    public async void DDDService_Adiconar_DDDAdicionadoComSucesso()
    {
        //arrange
        var dddRepository = new Mock<IDDDRepository>();
        var mockMapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new DDDMapingProfile());
        });
        var _mapper = mockMapper.CreateMapper();
        var dddService = new DDDService(dddRepository.Object, _mapper);
        var dddDto = new DDDDto()
        {
            DddId = 11,
            Regiao = "São Paulo",
            UfNome = "São Paulo",
            UfSigla = "SP"
        };

        //act
        var dddResult = await dddService.Adicionar(dddDto);

        //assert
        Assert.True(dddResult.IsSuccess);
    }
}

