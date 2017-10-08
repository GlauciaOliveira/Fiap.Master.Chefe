using Fiap.Master.Chefe.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Master.Chefe.Site.Models.ManageViewModels
{
    public class ConsultaViewModel
    {        
        public int ReceitasId { get; set; }

        [Required]
        [Display]
        public string Titulo { get; set; }

        public DateTime DataCadastro { get; set; }

        [Required]
        [Display(Name ="Modo de Preparo")]
        public string ModoPreparo { get; set; }

        [Required]
        [Display(Name ="Ingredientes")]
        public ICollection<IngredientesModelView> IngredientesModelView { get; set; }

        public double PontuacaoMedia { get; set; }

        [Required]
        [Display(Name ="Comentários")]
        public ICollection<Comentarios> Comentarios { get; set; }

        public virtual Usuarios Usuario { get; set; }

        [Required]
        [Display(Name="Categoria")]
        public virtual Categorias Categoria { get; set; }
    }
}
