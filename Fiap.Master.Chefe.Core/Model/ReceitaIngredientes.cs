using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.Master.Chefe.Core.Model
{
    public class ReceitaIngredientes
    {
        public int ReceitaId { get; set; }

        public int IngredienteId { get; set; }

        public Receita Receita { get; set; }

        public Ingrediente Ingrediente { get; set; }
    }
}
