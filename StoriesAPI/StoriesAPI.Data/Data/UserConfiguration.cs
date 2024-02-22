using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoriesAPI.Infrastructure.Models;

namespace StoriesAPI.Infrastructure.Data
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {        
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User", MyDatabase.DEFAULT_SCHEMA);

            builder.Property<int>("Id")
                .ValueGeneratedOnAdd();

            builder.Property("Name")
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false);
        }
    }
}
