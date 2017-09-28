using System.Collections.Generic;

namespace Fiap.Master.Chefe.Core.Model
{
    public class Categorias
    {
        public int CategoriasId { get; set; }

        public string Descricao { get; set; }

        public virtual ICollection<Receitas> Receitas { get; set; }
    }
}