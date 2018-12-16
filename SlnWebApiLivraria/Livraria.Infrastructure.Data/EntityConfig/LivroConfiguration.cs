using Livraria.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Livraria.Infrastructure.Data.EntityConfig
{
    public class LivroConfiguration : EntityTypeConfiguration<Livro>
    {
        public LivroConfiguration()
        {
            // Primary Key
            HasKey(c => c.LivroId);

            // Properties
            Property(c => c.LivroISBN)
               .IsRequired()
               .HasMaxLength(150);

            Property(c => c.NomeLivro)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.NomeAutor)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Preco);

            Property(c => c.Ativo)
                .HasMaxLength(1);

            Property(c => c.FileName)
                .HasMaxLength(500);

            Property(c => c.FileLength)
                .HasMaxLength(500);
                       
            Property(c => c.DataPublicacao);
            Property(c => c.DataInclusao);
            Property(c => c.DataAlteracao);
            Property(c => c.FileCreatedTime);
        }
    }
}
