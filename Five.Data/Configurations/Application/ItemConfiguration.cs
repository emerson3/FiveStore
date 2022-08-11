namespace Five.Data.Configurations.Application
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("item");

            builder.HasKey(property => property.Id).HasName("pk_item");

            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(60);
            builder.Property(x => x.Cor).HasColumnName("cor").HasMaxLength(100);
            builder.Property(x => x.Preco).HasColumnName("preco").HasMaxLength(64);
            builder.Property(x => x.QtdEstoque).HasColumnName("qtdEstoque");
            builder.Property(x => x.IdCategoria).HasColumnName("idCategoria");
        }
    }
}