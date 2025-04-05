using Microsoft.EntityFrameworkCore;
using PromotionBannerManagementTask01.Entities;

namespace PromotionBannerManagementTask01
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Banner> Banners { get; set; }
    }
}
