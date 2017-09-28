using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.Master.Chefe.Core.Model
{
    public class Comentarios
    {
        public int ComentariosId { get; set; }

        public string Texto { get; set; }

        public DateTime DataInclusao { get; set; }

        public virtual Usuarios Usuario { get; set; }
    }
}
