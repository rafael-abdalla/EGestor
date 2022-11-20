using EGestor.Domain.Commands;
using EGestor.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGestor.Domain.Services;

public interface IUsuarioService
{
    Task<CommandResult> Inserir(InserirUsuarioCommand command);
}
