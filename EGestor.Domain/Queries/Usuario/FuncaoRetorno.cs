namespace EGestor.Domain.Queries;

public class FuncaoRetorno
{
    public FuncaoRetorno(Guid id, string descricao)
    {
        Id = id;
        Descricao = descricao;
    }

    public Guid Id { get; set; }
    public string Descricao { get; set; }
}
