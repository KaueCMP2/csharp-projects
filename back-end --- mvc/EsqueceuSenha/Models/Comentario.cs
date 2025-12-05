using System;
using System.Collections.Generic;

namespace EsqueceuSenha.Models;

public partial class Comentario
{
    public int id_comentario { get; set; }

    public string? tipo_comentario { get; set; }

    public int? id_usuario { get; set; }

    public DateTime? data_postagem { get; set; }

    public int? id_filme { get; set; }

    public virtual Filme? id_filmeNavigation { get; set; }

    public virtual Usuario? id_usuarioNavigation { get; set; }
}
