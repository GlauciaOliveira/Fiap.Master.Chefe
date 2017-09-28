namespace Fiap.Master.Chefe.Core.Model
{
    public class ReceitaPontuacao
    {
        public int ReceitasId { get; set; }

        public int PontuacaoId { get; set; }

        public Receitas Receita { get; set; }

        public Pontuacao Pontuacao { get; set; }
    }
}