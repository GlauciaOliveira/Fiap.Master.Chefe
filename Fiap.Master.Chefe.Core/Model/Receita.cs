using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.Master.Chefe.Core.Model
{
    public class Receita
    {

        public int ReceitaId { get; set; }

        public string Titulo { get; set; }
        
        public DateTime DataCadastro { get; set; }

        public ICollection<ReceitaIngredientes> ReceitaIngredientes { get; set; }

        public virtual Usuario Usuario { get; set; }

        //public virtual ReceitaIngredientes ReceitaIngredientes { get; set; }
    }
}
