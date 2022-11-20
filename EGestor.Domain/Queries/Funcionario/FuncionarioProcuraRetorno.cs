using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGestor.Domain.Queries;

public class FuncionarioProcuraRetorno
{
    public FuncionarioProcuraRetorno(Guid id, string nome, string? observacao, DateTime? dataAdmissao)
    {
        Id = id;
        Nome = nome;
        Observacao = observacao;
        DataAdmissao = dataAdmissao;
    }

    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string? Observacao { get; set; }
    public DateTime? DataAdmissao { get; set; }
}
