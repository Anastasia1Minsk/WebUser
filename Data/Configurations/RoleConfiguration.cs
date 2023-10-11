using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebUser.Models;

namespace WebUser.Data.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");
            
            builder.HasMany(x => x.Relations).WithOne(x => x.Role).HasForeignKey(x => x.RoleId);
        }
    }
}
