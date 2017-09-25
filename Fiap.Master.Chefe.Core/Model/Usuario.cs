using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.Master.Chefe.Core.Model
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        public string Nome { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Receita> Receitas { get; set; }
    }
}
