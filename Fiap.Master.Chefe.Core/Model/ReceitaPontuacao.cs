using System.Collections.Generic;

namespace Fiap.Master.Chefe.Core.Model
{
    public class ReceitaPontuacao
    {
        public int ReceitaPontuacaoId { get; set; }

        public int ReceitasId { get; set; }

        //public virtual ICollection<Receitas> Receita { get; set; }

        public double Nota { get; set; }
    }
}