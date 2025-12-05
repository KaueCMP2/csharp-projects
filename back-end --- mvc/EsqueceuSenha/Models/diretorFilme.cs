using System;
using System.Collections.Generic;

namespace EsqueceuSenha.Models;

public partial class diretorFilme
{
    public int id_diretor { get; set; }

    public string nome { get; set; } = null!;

    public virtual ICollection<Filme> Filmes { get; set; } = new List<Filme>();
}
