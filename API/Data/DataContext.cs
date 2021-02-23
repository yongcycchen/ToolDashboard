using API.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace API.Data
{
    public class DataContext : IdentityDbContext
        <FSUser,FSRole,int,
        IdentityUserClaim<int>,FSUserRole,IdentityUserLogin<int>,
        IdentityRoleClaim<int>,IdentityUserToken<int>>
    {
         public DataContext(DbContextOptions options) : base(options)
         {
         }
         public DbSet<UserTool> Notifications { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<FSUser>()
                .HasMany(user => user.UserRoles)
                .WithOne(user => user.User)
                .HasForeignKey(user => user.UserId)
                .IsRequired();
            
            builder.Entity<FSRole>()
                .HasMany(user => user.UserRoles)
                .WithOne(user => user.Role)
                .HasForeignKey(user => user.RoleId)
                .IsRequired();
            
            builder.Entity<UserTool>()
                .HasKey(k => new {k.ToolId,k.SubscriberId});

            builder.Entity<FSUser>()
                .HasMany(user => user.NotificationList)
                .WithOne(list => list.Subscriber)
                .HasForeignKey(user => user.SubscriberId)
                .IsRequired();
            
            builder.Entity<Tool>()
                .HasMany(tool => tool.NotificationList)
                .WithOne(list => list.NotificationTool)
                .HasForeignKey(tool => tool.ToolId)
                .IsRequired();
            
        }
    }
}