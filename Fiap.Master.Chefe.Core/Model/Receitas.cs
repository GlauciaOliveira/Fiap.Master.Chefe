using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.Master.Chefe.Core.Model
{
    public class Receitas
    {

        public int ReceitasId { get; set; }

        public string Titulo { get; set; }
        
        public DateTime DataCadastro { get; set; }

        public string ModoPreparo { get; set; }

        public ICollection<ReceitaIngredientes> ReceitaIngredientes { get; set; }

        public ICollection<ReceitaPontuacao> ReceitaPontuacao { get; set; }

        public ICollection<Comentarios> Comentarios { get; set; }

        public virtual Usuarios Usuario { get; set; }

        public virtual Categorias Categoria { get; set; }
        
    }
}
