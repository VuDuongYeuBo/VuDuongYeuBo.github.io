using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ASM2_VuHaiDuong.Models;

namespace ASM2_VuHaiDuong.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ASM2_VuHaiDuong.Models.Genre>? Genre { get; set; }
        public DbSet<ASM2_VuHaiDuong.Models.Book>? Book { get; set; }
        public DbSet<ASM2_VuHaiDuong.Models.Cart>? Cart { get; set; }
        public DbSet<ASM2_VuHaiDuong.Models.Order>? Order { get; set; }
    }
}