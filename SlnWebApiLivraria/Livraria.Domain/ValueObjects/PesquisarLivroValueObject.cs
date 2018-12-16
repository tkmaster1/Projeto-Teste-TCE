using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Livraria.Domain.ValueObjects
{
    public class PesquisarLivroValueObject
    {
        public int? LivroId { get; set; }

        public string LivroISBN { get; set; }

        public string NomeLivro { get; set; }

        public string NomeAutor { get; set; }

        public string Ativo { get; set; }

        public decimal? Preco { get; set; }

        public DateTime? DataPublicacao { get; set; }

        public DateTime? DataInclusao { get; set; }

        public DateTime? DataAlteracao { get; set; }

        [NotMapped]
        public string SortField { get; set; }

        [NotMapped]
        public bool Ascending { get; set; }
    }
}
