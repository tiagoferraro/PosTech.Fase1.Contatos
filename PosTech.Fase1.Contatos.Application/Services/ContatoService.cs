using AutoMapper;
using PosTech.Fase1.Contatos.Application.DTO;
using PosTech.Fase1.Contatos.Application.Interfaces;
using PosTech.Fase1.Contatos.Application.Result;
using PosTech.Fase1.Contatos.Domain.Entities;
using PosTech.Fase1.Contatos.Infra.Interfaces;


namespace PosTech.Fase1.Contatos.Application.Services;

public class ContatoService(IContatoRepository _contatoRepository,IMapper _mapper) : IContatoService
{
    public async Task<ServiceResult<ContatoDTO>> Adicionar(ContatoDTO c)
    {
        try
        {
            var contato = _mapper.Map<Contato>(c);
            var novoContato = await _contatoRepository.Adicionar(contato);

            return new ServiceResult<ContatoDTO>(_mapper.Map<ContatoDTO>(novoContato));
        }
        catch (Exception ex)
        {
            return new ServiceResult<ContatoDTO>(ex);
        }
    }

    public async Task<ServiceResult<bool>> Atualizar(ContatoDTO c)
    {
        try
        {
            var contato = _mapper.Map<Contato>(c);
            await _contatoRepository.Atualizar(contato);

            return new ServiceResult<bool>(true);
        }
        catch (Exception ex)
        {
            return new ServiceResult<bool>(ex);
        }
    }

  

    public async Task<ServiceResult<bool>> Excluir(int ContatoId)
    {
        try
        {
            var contato = await _contatoRepository.Obter(ContatoId);
            contato.DesativarContato();
            await _contatoRepository.Atualizar(contato);

            return new ServiceResult<bool>(true);
        }
        catch (Exception ex)
        {
            return new ServiceResult<bool>(ex);
        }
    }



    public async Task<ServiceResult<IEnumerable<ContatoDTO>>> Listar()
    {
        try
        {
            var contatos = await _contatoRepository.Listar();
            var listaContatosDto = _mapper.Map<IEnumerable<ContatoDTO>>(contatos);

            return new ServiceResult<IEnumerable<ContatoDTO>>(listaContatosDto);
        }
        catch (Exception ex)
        {
            return new ServiceResult<IEnumerable<ContatoDTO>>(ex);
        }
    }

    public async Task<ServiceResult<IEnumerable<ContatoDTO>>> ListarComDDD(int ddd)
    {
        try
        {
            var contatos = await _contatoRepository.ListarComDDD(ddd);
            var listaContatosDto = _mapper.Map<IEnumerable<ContatoDTO>>(contatos);
            return new ServiceResult<IEnumerable<ContatoDTO>>(listaContatosDto);
        }
        catch (Exception ex)
        {
            return new ServiceResult<IEnumerable<ContatoDTO>>(ex);
        }
    }

    public async Task<ServiceResult<ContatoDTO>> Obter(int contatoId)
    {
        try
        {
            var contato = await _contatoRepository.Obter(contatoId);

            var contatoDto = _mapper.Map<ContatoDTO>(contato);
            return new ServiceResult<ContatoDTO>(contatoDto);
        }
        catch (Exception ex)
        {
            return new ServiceResult<ContatoDTO>(ex);
        }
    }
}

