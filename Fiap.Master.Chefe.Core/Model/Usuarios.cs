using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.Master.Chefe.Core.Model
{
    public class Usuarios
    {
        public int UsuariosId { get; set; }

        public string Nome { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Receitas> Receitas { get; set; }

        public virtual ICollection<Comentarios> Comentarios { get; set; }
    }
}
