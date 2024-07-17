using PosTech.Fase1.Contatos.Domain.ObjectValue;
namespace PosTech.Fase1.Contatos.Domain.Entities;

public class DDD
{
    public int DddId { get; private set; }
    public UnidadeFederativa UnidadeFederativa { get; private set; }
    public string Regiao { get; private set; }


    /// <summary>
    /// EF constructor
    /// </summary>
    private DDD(int dddId,  string regiao)
    {
        DddId = dddId;
        Regiao = regiao;
    }


    public DDD(int dddId, string siglaUf, string regiao)
    {
        DddId = dddId;
        Regiao = regiao;
        UnidadeFederativa = new UnidadeFederativa(siglaUf);
    }
}
