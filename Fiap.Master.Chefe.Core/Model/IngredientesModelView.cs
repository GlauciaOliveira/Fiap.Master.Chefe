using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Master.Chefe.Core.Model
{
    public class IngredientesModelView
    {
        public int IngredientesId { get; set; }

        public int Quantidade { get; set; }

        public string Unidade { get; set; }

        public string NomeIngrediente { get; set; }
    }
}
