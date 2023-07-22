using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infra.Data.Mappings;

public class UsuarioMap : IEntityTypeConfiguration<UsuarioEntity>
{
    public void Configure(EntityTypeBuilder<UsuarioEntity> builder)
    {
        builder.ToTable("Usuario");
        builder.HasKey(u => u.Id);

        builder.HasIndex(u => u.Email)
                .IsUnique();

        builder.Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(60);

        builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);
    }
}