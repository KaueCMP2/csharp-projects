using System;
using System.Collections.Generic;

namespace EsqueceuSenha.Models;

public partial class generoFilme
{
    public int id_genero { get; set; }

    public string nome_genero { get; set; } = null!;

    public virtual ICollection<Filme> Filmes { get; set; } = new List<Filme>();
}
