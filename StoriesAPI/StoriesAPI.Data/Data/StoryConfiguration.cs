using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoriesAPI.Infrastructure.Models;

namespace StoriesAPI.Infrastructure.Data
{
    public class StoryConfiguration : IEntityTypeConfiguration<Story>
    {        
        public void Configure(EntityTypeBuilder<Story> builder)
        {
            builder.ToTable("Story", Data.MyDatabase.DEFAULT_SCHEMA);

            builder.Property<int>("Id")
                .ValueGeneratedOnAdd();

            builder.Property("Title")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property("Description")
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

            builder.Property("Department")
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

        }
    }
}
