using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mindit.Models;

namespace Mindit.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Mindit.Models.ForumPost>? ForumPost { get; set; }
        public DbSet<Mindit.Models.PostVotes>? PostVotes { get; set; }
        public DbSet<Mindit.Models.MinditCategoryModel>? MinditCategoryModel { get; set; }
        public DbSet<Mindit.Models.ForumReply>? ForumReply { get; set; }
    }
}