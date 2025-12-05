using System;
using System.Collections.Generic;

namespace EsqueceuSenha.Models;

public partial class Usuario
{
    public int id_usuario { get; set; }

    public string nome { get; set; } = null!;

    public string email { get; set; } = null!;

    public byte[] senha { get; set; } = null!;

    public string nick_name { get; set; } = null!;

    public DateOnly data_nascimento { get; set; }

    public string? desc_perfil { get; set; }

    public byte[]? foto_perfil { get; set; }

    public int RegraId { get; set; }

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual RegraPerfil Regra { get; set; } = null!;

    public virtual ICollection<codigoUsuarioSenha> codigoUsuarioSenhas { get; set; } = new List<codigoUsuarioSenha>();
}
