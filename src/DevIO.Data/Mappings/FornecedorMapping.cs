using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.DADOS.Mapeamentos
{
    class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Nome).IsRequired().HasColumnType("varchar(200)");
            builder.Property(f => f.Documento).IsRequired().HasColumnType("varchar(14)");

            // Relacionamento 1:1 => Fornecedor_Endereco
            builder.HasOne(f => f.Endereco).WithOne(e => e.Fornecedor);

            // Relacionamento 1:N => Fornecedor_Produtos
            builder.HasMany(p => p.Produtos).WithOne(f => f.Fornecedor).HasForeignKey(f => f.FornecedorId);

            builder.ToTable("Fornecedores");
        }
    }
}
