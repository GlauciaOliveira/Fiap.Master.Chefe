using Fiap.Master.Chefe.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Master.Chefe.Site.Models.ManageViewModels
{
    public class CadastroViewModel
    {
        public int ReceitasId { get; set; }

        [Required]
        [Display(Name = "Título da Receita")]
        public string Titulo { get; set; }

        public DateTime DataCadastro { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(1024)]
        [Display(Name = "Modo de Preparo")]
        public string ModoPreparo { get; set; }

        public int CategoriasId { get; set; }

        public int UsuariosId { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(1024)]
        [Display(Name = "Ingredientes")]
        public ICollection<ReceitaIngredientes> ReceitaIngredientes { get; set; }

        public ICollection<ReceitaPontuacao> ReceitaPontuacao { get; set; }
                
        [MinLength(5)]
        [MaxLength(1024)]
        [Display(Name = "Comentarios")]
        public ICollection<Comentarios> Comentarios { get; set; }

        public virtual Usuarios Usuario { get; set; }

        public virtual Categorias Categoria { get; set; }

         
    }
}
