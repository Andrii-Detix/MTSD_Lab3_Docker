using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DockerLab.Database;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("user");
        
        builder.HasKey(u => u.Id)
            .HasName("user_id");

        builder.Property(u => u.Id)
            .HasColumnName("id");

        builder.Property(u => u.Name)
            .HasMaxLength(100)
            .IsRequired()
            .HasColumnName("name");
        
        builder.Property(u => u.Age)
            .IsRequired()
            .HasColumnName("age");
    }
}