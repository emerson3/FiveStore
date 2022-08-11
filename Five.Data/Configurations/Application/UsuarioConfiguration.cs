namespace Five.Data.Configurations.Application
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario");

            builder.HasKey(property => property.Id).HasName("pk_usuario");

            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(60);
            builder.Property(x => x.Email).HasColumnName("email").HasMaxLength(100);
            builder.Property(x => x.Senha).HasColumnName("senha").HasMaxLength(64);
            builder.Property(x => x.IdTipoUsuario).HasColumnName("idTipoUsuario");
            builder.Property(x => x.IdEndereco).HasColumnName("idEndereco");
        }
    }
}