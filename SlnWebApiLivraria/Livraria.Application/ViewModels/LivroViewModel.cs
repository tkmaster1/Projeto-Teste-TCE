using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Livraria.Application.ViewModels
{
    public class LivroViewModel
    {
        [Key]
        public int LivroId { get; set; }

        [Display(Name = @"Nome")]
        [Required(ErrorMessage = @"Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage = "O campo Nome permite o máximo de 150 caracteres.")]
        [MinLength(4, ErrorMessage = "O campo Nome permite o mínimo de 4 caracteres.")]
        public string NomeLivro { get; set; }

        [Display(Name = @"Nome Autor")]
        [Required(ErrorMessage = @"Preencha o campo Nome Autor")]
        [MaxLength(150, ErrorMessage = "O campo Nome Autor permite o máximo de 150 caracteres.")]
        [MinLength(4, ErrorMessage = "O campo Nome Autor permite o mínimo de 4 caracteres.")]
        public string NomeAutor { get; set; }

        [Display(Name = @"ISBN")]
        [Required(ErrorMessage = @"Preencha o campo ISBN")]
        [MaxLength(150, ErrorMessage = "O campo ISBN permite o máximo de 150 caracteres.")]
        [MinLength(4, ErrorMessage = "O campo ISBN permite o mínimo de 4 caracteres.")]
        public string LivroISBN { get; set; }

        public decimal Preco { get; set; }

        [Display(Name = @"Data Publicação")]
        [Required(ErrorMessage = @"Preencha o campo Data Publicação")]
        public DateTime DataPublicacao { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataInclusao { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? DataAlteracao { get; set; }

        public string Ativo { get; set; }

        [NotMapped]
        public bool AtivoBool
        {
            get
            {
                return Ativo == "S" ? true : false;
            }
        }

        [NotMapped]
        public string SortField { get; set; }

        [NotMapped]
        public bool Ascending { get; set; }

        public string FileName { get; set; }

        public string FileLength { get; set; }

        public DateTime? FileCreatedTime { get; set; }
    }
}
