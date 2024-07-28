using AutoMapper;
using Moq;
using PosTech.Fase1.Contatos.Application.DTO;
using PosTech.Fase1.Contatos.Application.Mappins;
using PosTech.Fase1.Contatos.Application.Model;
using PosTech.Fase1.Contatos.Application.Services;
using PosTech.Fase1.Contatos.Domain.Entities;
using PosTech.Fase1.Contatos.Infra.Interfaces;

namespace PosTech.Fase1.Contatos.Tests.Application
{
    public class ContatoServiceTest
    {
        [Fact]
        public async void ContatoService_Adicionar_ContatoServiceAdicionadoComSucesso()
        {
            //arrange
            var ContatoRepository = new Mock<IContatoRepository>();
            var DddRepository = new Mock<IDDDRepository>();

            var ContatoDTO = new ContatoDTO()
            {
                ContatoId = 2,
                Nome = "Mario",
                Telefone = "7198875566",
                Email = "mario.silveira@gmail.com",
                Ativo = true,
                DddId = 71
            };

            var DddDTO = new DDDDto
            {
                DddId = 71,
                UfSigla = "BA",
                UfNome = "Bahia",
                Regiao = "Salvador"
            };

            var configMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ContatoMapingProfile());
                cfg.AddProfile(new DDDMapingProfile());
            });

            var _mapper = configMapper.CreateMapper();

            var ContatoMap = _mapper.Map<Contato>(ContatoDTO);
            var DddMap = _mapper.Map<DDD>(DddDTO);

            //ContatoRepository
            //    .Setup(ContatoRepositoryMock => ContatoRepositoryMock.Obter(ContatoMap.ContatoId.Value))
            //    .ReturnsAsync(ContatoMap);

            DddRepository
                .Setup(DDDRepositoryMock => DDDRepositoryMock.Obter(DddMap.DddId))
                .ReturnsAsync(DddMap);

            var ContatoService = new ContatoService(ContatoRepository.Object, _mapper, DddRepository.Object);

            //act
            var ContatoResult = await ContatoService.Adicionar(ContatoDTO);

            //assert
            Assert.True(ContatoResult.IsSuccess);
        }

        [Fact]
        public async void ContatoService_Adicionar_ContatoServiceAdicionadoComErroDDDNaoExiste()
        {
            //arrange
            var ContatoRepository = new Mock<IContatoRepository>();
            var DddRepository = new Mock<IDDDRepository>();

            var ContatoDTO = new ContatoDTO()
            {
                ContatoId = 2,
                Nome = "Mario",
                Telefone = "7198875566",
                Email = "mario.silveira@gmail.com",
                Ativo = true,
                DddId = 888
            };

            var DddDTO = new DDDDto //Nao Mocado, para que o método Obter retorne null.
            {
                DddId = 71,
                UfSigla = "BA",
                UfNome = "Bahia",
                Regiao = "Salvador"
            };

            var configMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ContatoMapingProfile());
                cfg.AddProfile(new DDDMapingProfile());
            });

            var _mapper = configMapper.CreateMapper();

            var ContatoMap = _mapper.Map<Contato>(ContatoDTO);
            var DddMap = _mapper.Map<DDD>(DddDTO);

            ContatoRepository
                .Setup(ContatoRepositoryMock => ContatoRepositoryMock.Obter(ContatoMap.ContatoId.Value))
                .ReturnsAsync(ContatoMap);

            //DddRepository
            //    .Setup(DDDRepositoryMock => DDDRepositoryMock.Obter(DddMap.DddId))
            //    .ReturnsAsync(DddMap);

            var ContatoService = new ContatoService(ContatoRepository.Object, _mapper, DddRepository.Object);

            //act
            var ContatoResult = await ContatoService.Adicionar(ContatoDTO);

            //assert
            Assert.False(ContatoResult.IsSuccess);
            var ex = Assert.IsType<ValidacaoException>(ContatoResult.Error);
            Assert.Equal("DDD não existe", ex.Message);
        }

        [Fact]
        public async void ContatoService_Adicionar_ContatoServiceAdicionadoComErroContatoJaExistente()
        {
            //arrange
            var ContatoRepository = new Mock<IContatoRepository>();
            var DddRepository = new Mock<IDDDRepository>();

            var ContatoDTO = new ContatoDTO()
            {
                ContatoId = 2,
                Nome = "Mario",
                Telefone = "7198875566",
                Email = "mario.silveira@gmail.com",
                Ativo = true,
                DddId = 71,
                Ddd = new DDDDto
                {
                    DddId = 71,
                    UfSigla = "BA",
                    UfNome = "Bahia",
                    Regiao = "Salvador"
                }
            };

            var configMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ContatoMapingProfile());
                cfg.AddProfile(new DDDMapingProfile());
            });

            var _mapper = configMapper.CreateMapper();

            var ContatoMap = _mapper.Map<Contato>(ContatoDTO);
            var DddMap = _mapper.Map<DDD>(ContatoDTO.Ddd);

            DddRepository
                .Setup(DDDRepositoryMock => DDDRepositoryMock.Obter(DddMap.DddId))
                .ReturnsAsync(DddMap);

            ContatoRepository
                .Setup(contatoRepositoryMock => contatoRepositoryMock.Existe(It.IsAny<Contato>()))
                .ReturnsAsync(true);

            var ContatoService = new ContatoService(ContatoRepository.Object, _mapper, DddRepository.Object);

            //act
            var ContatoResult = await ContatoService.Adicionar(ContatoDTO);

            //assert
            Assert.False(ContatoResult.IsSuccess);
            var ex = Assert.IsType<ValidacaoException>(ContatoResult.Error);
            Assert.Equal("Cadastro de contato ja existe", ex.Message);
        }

        [Fact]
        public async void ContatoService_Adicionar_ContatoServiceAdicionadoComErro()
        {
            //arrange
            var ContatoRepository = new Mock<IContatoRepository>();
            var DddRepository = new Mock<IDDDRepository>();

            var ContatoDTO = new ContatoDTO()
            {
                ContatoId = 2,
                Nome = "Mario",
                Telefone = "7198875566",
                Email = "mario.silveira@gmail.com",
                Ativo = true,
                DddId = 71
            };

            var DddDTO = new DDDDto //Nao Mocado, para que o método Obter retorne null.
            {
                DddId = 71,
                UfSigla = "BA",
                UfNome = "Bahia",
                Regiao = "Salvador"
            };

            var configMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ContatoMapingProfile());
                cfg.AddProfile(new DDDMapingProfile());
            });

            var _mapper = configMapper.CreateMapper();

            var ContatoMap = _mapper.Map<Contato>(ContatoDTO);
            var DddMap = _mapper.Map<DDD>(DddDTO);

            DddRepository
                .Setup(DDDRepositoryMock => DDDRepositoryMock.Obter(DddMap.DddId))
                .Throws(new Exception());

            var ContatoService = new ContatoService(ContatoRepository.Object, _mapper, DddRepository.Object);

            //act
            var ContatoResult = await ContatoService.Adicionar(ContatoDTO);

            //assert
            Assert.False(ContatoResult.IsSuccess);
            var ex = Assert.IsType<Exception>(ContatoResult.Error);
        }



        [Fact]
        public async void ContatoService_Atualizar_ContatoServiceAtualizadoComSucesso()
        {
            //arrange
            var ContatoRepository = new Mock<IContatoRepository>();
            var DddRepository = new Mock<IDDDRepository>();

            var ContatoDTO = new ContatoDTO()
            {
                ContatoId = 2,
                Nome = "Mario",
                Telefone = "7198875566",
                Email = "mario.silveira@gmail.com",
                Ativo = true,
                DddId = 71,
                Ddd = new DDDDto
                {
                    DddId = 71,
                    UfSigla = "BA",
                    UfNome = "Bahia",
                    Regiao = "Salvador"
                }
            };

            var configMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ContatoMapingProfile());
                cfg.AddProfile(new DDDMapingProfile());
            });

            var _mapper = configMapper.CreateMapper();

            var ContatoMap = _mapper.Map<Contato>(ContatoDTO);
            var DddMap = _mapper.Map<DDD>(ContatoDTO.Ddd);

            DddRepository
                .Setup(DDDRepositoryMock => DDDRepositoryMock.Obter(DddMap.DddId))
                .ReturnsAsync(DddMap);

            ContatoRepository
                .Setup(ContatoRepositoryMock => ContatoRepositoryMock.Obter(ContatoMap.ContatoId!.Value))
                .ReturnsAsync(ContatoMap);

            var ContatoService = new ContatoService(ContatoRepository.Object, _mapper, DddRepository.Object);

            //act
            var ContatoResult = await ContatoService.Atualizar(ContatoDTO);

            //assert
            Assert.True(ContatoResult.IsSuccess);
        }

        [Fact]
        public async void ContatoService_Atualizar_ContatoServiceAtualizadoComErroDDDNaoExiste()
        {
            //arrange
            var ContatoRepository = new Mock<IContatoRepository>();
            var DddRepository = new Mock<IDDDRepository>();

            var ContatoDTO = new ContatoDTO()
            {
                ContatoId = 2,
                Nome = "Mario",
                Telefone = "7198875566",
                Email = "mario.silveira@gmail.com",
                Ativo = true,
                DddId = 888
            };

            var DddDTO = new DDDDto //Nao Mocado, para que o método Obter retorne null.
            {
                DddId = 71,
                UfSigla = "BA",
                UfNome = "Bahia",
                Regiao = "Salvador"
            };

            var configMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ContatoMapingProfile());
                cfg.AddProfile(new DDDMapingProfile());
            });

            var _mapper = configMapper.CreateMapper();

            var ContatoMap = _mapper.Map<Contato>(ContatoDTO);
            var DddMap = _mapper.Map<DDD>(DddDTO);

            ContatoRepository
                .Setup(ContatoRepositoryMock => ContatoRepositoryMock.Obter(ContatoMap.ContatoId.Value))
                .ReturnsAsync(ContatoMap);

            //DddRepository
            //    .Setup(DDDRepositoryMock => DDDRepositoryMock.Obter(DddMap.DddId))
            //    .ReturnsAsync(DddMap);

            var ContatoService = new ContatoService(ContatoRepository.Object, _mapper, DddRepository.Object);

            //act
            var ContatoResult = await ContatoService.Atualizar(ContatoDTO);

            //assert
            Assert.False(ContatoResult.IsSuccess);
            var ex = Assert.IsType<ValidacaoException>(ContatoResult.Error);
            Assert.Equal("DDD não existe", ex.Message);
        }

        [Fact]
        public async void ContatoService_Atualizar_ContatoServiceAtualizadoComErroContatoNaoPodeSerAlterado()
        {
            //arrange
            var ContatoRepository = new Mock<IContatoRepository>();
            var DddRepository = new Mock<IDDDRepository>();

            var ContatoDTO = new ContatoDTO()
            {
                ContatoId = 2,
                Nome = "Mario",
                Telefone = "7198875566",
                Email = "mario.silveira@gmail.com",
                Ativo = true,
                DddId = 71,
                Ddd = new DDDDto
                {
                    DddId = 71,
                    UfSigla = "BA",
                    UfNome = "Bahia",
                    Regiao = "Salvador"
                }
            };

            var configMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ContatoMapingProfile());
                cfg.AddProfile(new DDDMapingProfile());
            });

            var _mapper = configMapper.CreateMapper();

            var ContatoMap = _mapper.Map<Contato>(ContatoDTO);
            var DddMap = _mapper.Map<DDD>(ContatoDTO.Ddd);

            DddRepository
                .Setup(DDDRepositoryMock => DDDRepositoryMock.Obter(DddMap.DddId))
                .ReturnsAsync(DddMap);

            ContatoRepository
                .Setup(ContatoRepositoryMock => ContatoRepositoryMock.Obter(ContatoMap.ContatoId!.Value));

            var ContatoService = new ContatoService(ContatoRepository.Object, _mapper, DddRepository.Object);

            //act
            var ContatoResult = await ContatoService.Atualizar(ContatoDTO);

            //assert
            Assert.False(ContatoResult.IsSuccess);
            var ex = Assert.IsType<ValidacaoException>(ContatoResult.Error);
            Assert.Equal("Contato não pode ser alterado", ex.Message);
        }

        [Fact]
        public async void ContatoService_Atualizar_ContatoServiceAtualizadoComErro()
        {
            //arrange
            var ContatoRepository = new Mock<IContatoRepository>();
            var DddRepository = new Mock<IDDDRepository>();

            var ContatoDTO = new ContatoDTO()
            {
                ContatoId = 2,
                Nome = "Mario",
                Telefone = "7198875566",
                Email = "mario.silveira@gmail.com",
                Ativo = true,
                DddId = 71
            };

            var DddDTO = new DDDDto //Nao Mocado, para que o método Obter retorne null.
            {
                DddId = 71,
                UfSigla = "BA",
                UfNome = "Bahia",
                Regiao = "Salvador"
            };

            var configMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ContatoMapingProfile());
                cfg.AddProfile(new DDDMapingProfile());
            });

            var _mapper = configMapper.CreateMapper();

            var ContatoMap = _mapper.Map<Contato>(ContatoDTO);
            var DddMap = _mapper.Map<DDD>(DddDTO);

            DddRepository
                .Setup(DDDRepositoryMock => DDDRepositoryMock.Obter(DddMap.DddId))
                .Throws(new Exception());

            var ContatoService = new ContatoService(ContatoRepository.Object, _mapper, DddRepository.Object);

            //act
            var ContatoResult = await ContatoService.Adicionar(ContatoDTO);

            //assert
            Assert.False(ContatoResult.IsSuccess);
            var ex = Assert.IsType<Exception>(ContatoResult.Error);
        }



        [Fact]
        public async void ContatoService_Excluir_ContatoServiceExcluidoComSucesso()
        {
            //arrange
            var ContatoRepository = new Mock<IContatoRepository>();
            var DddRepository = new Mock<IDDDRepository>();

            var ContatoDTO = new ContatoDTO()
            {
                ContatoId = 2,
                Nome = "Mario",
                Telefone = "7198875566",
                Email = "mario.silveira@gmail.com",
                Ativo = true,
                DddId = 71
            };

            var DddDTO = new DDDDto
            {
                DddId = 71,
                UfSigla = "BA",
                UfNome = "Bahia",
                Regiao = "Salvador"
            };

            var configMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ContatoMapingProfile());
                cfg.AddProfile(new DDDMapingProfile());
            });

            var _mapper = configMapper.CreateMapper();

            var ContatoMap = _mapper.Map<Contato>(ContatoDTO);
            var DddMap = _mapper.Map<DDD>(DddDTO);

            ContatoRepository
                .Setup(ContatoRepositoryMock => ContatoRepositoryMock.Obter(ContatoMap.ContatoId.Value))
                .ReturnsAsync(ContatoMap);

            ContatoRepository
                .Setup(ContatoRepositoryMock => ContatoRepositoryMock.Atualizar(ContatoMap));

            var ContatoService = new ContatoService(ContatoRepository.Object, _mapper, DddRepository.Object);

            //act
            var ContatoResult = await ContatoService.Excluir(ContatoDTO.ContatoId.Value);

            //assert
            Assert.True(ContatoResult.IsSuccess);
        }

        [Fact]
        public async void ContatoService_Excluir_ContatoServiceExcluidoComErro()
        {
            //arrange
            var ContatoRepository = new Mock<IContatoRepository>();
            var DddRepository = new Mock<IDDDRepository>();

            var ContatoDTO = new ContatoDTO()
            {
                ContatoId = 2,
                Nome = "Mario",
                Telefone = "7198875566",
                Email = "mario.silveira@gmail.com",
                Ativo = true,
                DddId = 71
            };

            var DddDTO = new DDDDto //Nao Mocado, para que o método Obter retorne null.
            {
                DddId = 71,
                UfSigla = "BA",
                UfNome = "Bahia",
                Regiao = "Salvador"
            };

            var configMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ContatoMapingProfile());
                cfg.AddProfile(new DDDMapingProfile());
            });

            var _mapper = configMapper.CreateMapper();

            var ContatoMap = _mapper.Map<Contato>(ContatoDTO);
            var DddMap = _mapper.Map<DDD>(DddDTO);

            ContatoRepository
                .Setup(ContatoRepositoryMock => ContatoRepositoryMock.Obter(ContatoMap.ContatoId.Value))
                .Throws(new Exception());

            var ContatoService = new ContatoService(ContatoRepository.Object, _mapper, DddRepository.Object);

            //act
            var ContatoResult = await ContatoService.Excluir(ContatoDTO.ContatoId.Value);

            //assert
            Assert.False(ContatoResult.IsSuccess);
            var ex = Assert.IsType<Exception>(ContatoResult.Error);
        }



        [Fact]
        public async void ContatoService_Listar_ContatoServiceListadoComSucesso()
        {
            //arrange
            var ContatoRepository = new Mock<IContatoRepository>();
            var DddRepository = new Mock<IDDDRepository>();

            var ContatoDTO = new ContatoDTO()
            {
                ContatoId = 2,
                Nome = "Mario",
                Telefone = "7198875566",
                Email = "mario.silveira@gmail.com",
                Ativo = true,
                DddId = 71
            };

            var DddDTO = new DDDDto
            {
                DddId = 71,
                UfSigla = "BA",
                UfNome = "Bahia",
                Regiao = "Salvador"
            };

            var configMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ContatoMapingProfile());
                cfg.AddProfile(new DDDMapingProfile());
            });

            var _mapper = configMapper.CreateMapper();

            var ContatoMap = _mapper.Map<Contato>(ContatoDTO);
            var DddMap = _mapper.Map<DDD>(DddDTO);

            //ContatoRepository
            //    .Setup(ContatoRepositoryMock => ContatoRepositoryMock.Obter(ContatoMap.ContatoId.Value))
            //    .ReturnsAsync(ContatoMap);

            ContatoRepository
                .Setup(ContatoRepositoryMock => ContatoRepositoryMock.Listar())
                .ReturnsAsync(new List<Contato>());

            var ContatoService = new ContatoService(ContatoRepository.Object, _mapper, DddRepository.Object);

            //act
            var ContatoResult = await ContatoService.Listar();

            //assert
            Assert.True(ContatoResult.IsSuccess);
        }

        [Fact]
        public async void ContatoService_Listar_ContatoServiceListadoComErro()
        {
            //arrange
            var ContatoRepository = new Mock<IContatoRepository>();
            var DddRepository = new Mock<IDDDRepository>();

            var ContatoDTO = new ContatoDTO()
            {
                ContatoId = 2,
                Nome = "Mario",
                Telefone = "7198875566",
                Email = "mario.silveira@gmail.com",
                Ativo = true,
                DddId = 71
            };

            var DddDTO = new DDDDto
            {
                DddId = 71,
                UfSigla = "BA",
                UfNome = "Bahia",
                Regiao = "Salvador"
            };

            var configMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ContatoMapingProfile());
                cfg.AddProfile(new DDDMapingProfile());
            });

            var _mapper = configMapper.CreateMapper();

            var ContatoMap = _mapper.Map<Contato>(ContatoDTO);
            var DddMap = _mapper.Map<DDD>(DddDTO);

            ContatoRepository
                .Setup(ContatoRepositoryMock => ContatoRepositoryMock.Listar())
                .Throws(new Exception());

            var ContatoService = new ContatoService(ContatoRepository.Object, _mapper, DddRepository.Object);

            //act
            var ContatoResult = await ContatoService.Listar();

            //assert
            Assert.False(ContatoResult.IsSuccess);
            var ex = Assert.IsType<Exception>(ContatoResult.Error);
        }



        [Fact]
        public async void ContatoService_ListarComDDD_ContatoServiceListadoComSucesso()
        {
            //arrange
            var ContatoRepository = new Mock<IContatoRepository>();
            var DddRepository = new Mock<IDDDRepository>();

            var ContatoDTO = new ContatoDTO()
            {
                ContatoId = 2,
                Nome = "Mario",
                Telefone = "7198875566",
                Email = "mario.silveira@gmail.com",
                Ativo = true,
                DddId = 71
            };

            var DddDTO = new DDDDto
            {
                DddId = 71,
                UfSigla = "BA",
                UfNome = "Bahia",
                Regiao = "Salvador"
            };

            var configMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ContatoMapingProfile());
                cfg.AddProfile(new DDDMapingProfile());
            });

            var _mapper = configMapper.CreateMapper();

            var ContatoMap = _mapper.Map<Contato>(ContatoDTO);
            var DddMap = _mapper.Map<DDD>(DddDTO);

            ContatoRepository
                .Setup(ContatoRepositoryMock => ContatoRepositoryMock.ListarComDDD(ContatoMap.DddId))
                .ReturnsAsync(new List<Contato>());

            var ContatoService = new ContatoService(ContatoRepository.Object, _mapper, DddRepository.Object);

            //act
            var ContatoResult = await ContatoService.ListarComDDD(ContatoDTO.DddId);

            //assert
            Assert.True(ContatoResult.IsSuccess);
        }

        [Fact]
        public async void ContatoService_ListarComDDD_ContatoServiceListadoComErro()
        {
            //arrange
            var ContatoRepository = new Mock<IContatoRepository>();
            var DddRepository = new Mock<IDDDRepository>();

            var ContatoDTO = new ContatoDTO()
            {
                ContatoId = 2,
                Nome = "Mario",
                Telefone = "7198875566",
                Email = "mario.silveira@gmail.com",
                Ativo = true,
                DddId = 71
            };

            var DddDTO = new DDDDto
            {
                DddId = 71,
                UfSigla = "BA",
                UfNome = "Bahia",
                Regiao = "Salvador"
            };

            var configMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ContatoMapingProfile());
                cfg.AddProfile(new DDDMapingProfile());
            });

            var _mapper = configMapper.CreateMapper();

            var ContatoMap = _mapper.Map<Contato>(ContatoDTO);
            var DddMap = _mapper.Map<DDD>(DddDTO);

            ContatoRepository
                .Setup(ContatoRepositoryMock => ContatoRepositoryMock.ListarComDDD(ContatoMap.DddId))
                .Throws(new Exception());

            var ContatoService = new ContatoService(ContatoRepository.Object, _mapper, DddRepository.Object);

            //act
            var ContatoResult = await ContatoService.ListarComDDD(ContatoDTO.DddId);

            //assert
            Assert.False(ContatoResult.IsSuccess);
            var ex = Assert.IsType<Exception>(ContatoResult.Error);
        }



        [Fact]
        public async void ContatoService_Obter_ContatoServiceObtendoComSucesso()
        {
            //arrange
            var ContatoRepository = new Mock<IContatoRepository>();
            var DddRepository = new Mock<IDDDRepository>();

            var ContatoDTO = new ContatoDTO()
            {
                ContatoId = 2,
                Nome = "Mario",
                Telefone = "7198875566",
                Email = "mario.silveira@gmail.com",
                Ativo = true,
                DddId = 71,
                Ddd = new DDDDto
                {
                    DddId = 71,
                    UfSigla = "BA",
                    UfNome = "Bahia",
                    Regiao = "Salvador"
                }
            };

            var configMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ContatoMapingProfile());
                cfg.AddProfile(new DDDMapingProfile());
            });

            var _mapper = configMapper.CreateMapper();

            var ContatoMap = _mapper.Map<Contato>(ContatoDTO);
            var DddMap = _mapper.Map<DDD>(ContatoDTO.Ddd);

            ContatoRepository
                .Setup(ContatoRepositoryMock => ContatoRepositoryMock.Obter(ContatoMap.ContatoId.Value))
                .ReturnsAsync(ContatoMap);

            var ContatoService = new ContatoService(ContatoRepository.Object, _mapper, DddRepository.Object);

            //act
            var ContatoResult = await ContatoService.Obter(ContatoDTO.ContatoId.Value);

            //assert
            Assert.True(ContatoResult.IsSuccess);
        }

        [Fact]
        public async void ContatoService_Obter_ContatoServiceObtendoComErro()
        {
            //arrange
            var ContatoRepository = new Mock<IContatoRepository>();
            var DddRepository = new Mock<IDDDRepository>();

            var ContatoDTO = new ContatoDTO()
            {
                ContatoId = 2,
                Nome = "Mario",
                Telefone = "7198875566",
                Email = "mario.silveira@gmail.com",
                Ativo = true,
                DddId = 71,
                Ddd = new DDDDto
                {
                    DddId = 71,
                    UfSigla = "BA",
                    UfNome = "Bahia",
                    Regiao = "Salvador"
                }
            };

            var configMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ContatoMapingProfile());
                cfg.AddProfile(new DDDMapingProfile());
            });

            var _mapper = configMapper.CreateMapper();

            var ContatoMap = _mapper.Map<Contato>(ContatoDTO);
            var DddMap = _mapper.Map<DDD>(ContatoDTO.Ddd);

            ContatoRepository
                .Setup(ContatoRepositoryMock => ContatoRepositoryMock.Obter(ContatoMap.ContatoId.Value))
                .Throws(new Exception());

            var ContatoService = new ContatoService(ContatoRepository.Object, _mapper, DddRepository.Object);

            //act
            var ContatoResult = await ContatoService.Obter(ContatoDTO.ContatoId.Value);

            //assert
            Assert.False(ContatoResult.IsSuccess);
            var ex = Assert.IsType<Exception>(ContatoResult.Error);
        }
    }
}
