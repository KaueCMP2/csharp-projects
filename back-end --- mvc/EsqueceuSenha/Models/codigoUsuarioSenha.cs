using System;
using System.Collections.Generic;

namespace EsqueceuSenha.Models;

public partial class codigoUsuarioSenha
{
    public int? idUsuario { get; set; }

    public int? codigoSenha { get; set; }

    public int id { get; set; }

    public virtual Usuario? idUsuarioNavigation { get; set; }
}
