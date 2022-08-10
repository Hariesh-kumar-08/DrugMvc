using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DrugMvc.Models;

namespace DrugMvc.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<DrugMvc.Models.Products>? Products { get; set; }
        public DbSet<DrugMvc.Models.Users>? Users { get; set; }
    }
}