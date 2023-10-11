using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebUser.Models;

namespace WebUser.Data.Configurations
{
    public class RelationshipConfiguration : IEntityTypeConfiguration<Relationship>
    {
        public void Configure(EntityTypeBuilder<Relationship> builder)
        {
            builder.ToTable("UserRoles");
            builder.HasKey(x => new {x.UserId, x.RoleId});

            builder.HasOne(x => x.User).WithMany(x => x.Relations);
            builder.HasOne(x => x.Role).WithMany(x => x.Relations);

            
        }
    }
}
