using System.Collections.Generic;

namespace Fiap.Master.Chefe.Core.Model
{
    public class Pontuacao
    {
        public int PontuacaoId { get; set; }

        public int Nota { get; set; }
        
        public virtual ICollection<ReceitaPontuacao> ReceitaPontuacao { get; set; }
    }
}