using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.Master.Chefe.Core.Model
{
    public class Ingredientes
    {
        public int IngredientesId { get; set; }

        public string Nome { get; set; }

        public string Observacao { get; set; }

        public virtual ICollection<ReceitaIngredientes> ReceitaIngredientes { get; set; }
        
    }
}
