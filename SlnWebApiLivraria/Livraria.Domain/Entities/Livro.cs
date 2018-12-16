using System;

namespace Livraria.Domain.Entities
{
    public class Livro
    {
        public int LivroId { get; set; }

        public string LivroISBN { get; set; }

        public string NomeLivro { get; set; }

        public string NomeAutor { get; set; }

        public decimal Preco { get; set; }

        public DateTime DataPublicacao { get; set; }

        public DateTime DataInclusao { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public string Ativo { get; set; }

        public string FileName { get; set; }

        public string FileLength { get; set; }

        public DateTime? FileCreatedTime { get; set; }
    }
}
