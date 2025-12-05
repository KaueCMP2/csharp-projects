using System;
using System.Collections.Generic;

namespace EsqueceuSenha.Models;

public partial class Filme
{
    public int id_filme { get; set; }

    public string nome { get; set; } = null!;

    public string descricao_filme { get; set; } = null!;

    public DateOnly data_postagem { get; set; }

    public int? id_diretor { get; set; }

    public int? id_genero { get; set; }

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual diretorFilme? id_diretorNavigation { get; set; }

    public virtual generoFilme? id_generoNavigation { get; set; }
}
