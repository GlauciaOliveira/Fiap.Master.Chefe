using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.Master.Chefe.Core.Model
{
    public class ReceitaIngredientes
    {
        public int ReceitasId { get; set; }

        public int IngredientesId { get; set; }

        public Receitas Receita { get; set; }

        public Ingredientes Ingrediente { get; set; }
    }
}
