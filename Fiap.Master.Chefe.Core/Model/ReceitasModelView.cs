using Fiap.Master.Chefe.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Master.Chefe.Core.Model
{
    public class ReceitasModelView
    {

        public int ReceitasId { get; set; }

        public string Titulo { get; set; }

        public DateTime DataCadastro { get; set; }

        public string ModoPreparo { get; set; }

        public ICollection<IngredientesModelView> IngredientesModelView { get; set; }

        public double PontuacaoMedia { get; set; }

        public ICollection<Comentarios> Comentarios { get; set; }

        public virtual Usuarios Usuario { get; set; }

        public virtual Categorias Categoria { get; set; }

    }
}
