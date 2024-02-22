using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoriesAPI.Infrastructure.Models;

namespace StoriesAPI.Infrastructure.Data
{
    public class VoteConfiguration : IEntityTypeConfiguration<Vote>
    {        
        public void Configure(EntityTypeBuilder<Vote> builder)
        {
            builder.ToTable("Vote", MyDatabase.DEFAULT_SCHEMA);

            builder.Property<int>("Id")
                .ValueGeneratedOnAdd();

            builder.Property("Like")
                .IsRequired();
        }
    }
}
