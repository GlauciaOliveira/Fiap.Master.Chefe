using Fiap.Master.Chefe.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Master.Chefe.Site.Models.ManageViewModels
{
    public class CadastroUsuarioViewModel
    {
        public int UsuariosId { get; set; }

        [Required]
        [Display(Name ="Nome")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Login { get; set; }

        [Required]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        public virtual ICollection<Receitas> Receitas { get; set; }

        public virtual ICollection<Comentarios> Comentarios { get; set; }
    }
}
