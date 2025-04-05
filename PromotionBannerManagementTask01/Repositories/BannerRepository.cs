using Microsoft.EntityFrameworkCore;
using PromotionBannerManagementTask01.Entities;

namespace PromotionBannerManagementTask01.Repositories
{
    public class BannerRepository : IBannerRepository
    {

        private ApplicationDBContext _context;

        public BannerRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public void CreateBanner(Banner banner)
        {
            _context.Banners.Add(banner);
            _context.SaveChanges();
        }

        public void UpdateBanner(Banner banner)
        {
            _context.Banners.Update(banner);
            _context.SaveChanges();
        }

        public List<Banner> GetAllBanners()
        {
            return _context.Banners
                .Include(b => b.Company)
                .ToList();
            //I have already added code to convert them into dtos to avoid circular reference in service class.
            //Alternate way to convert to dto is to use .Select().
        }

        public Banner GetBannerById(int id)
        {
            return _context.Banners
                .FirstOrDefault(b => b.Id == id);
        }

        public List<Banner> GetBannersByCompany(string companyName)
        {
            return _context.Banners
                .Where(b => b.Company.Name == companyName)
                .Include(b => b.Company)
                .ToList();
        }

        public List<Banner> GetActiveBanners(DateTime currentDate)
        {
            return _context.Banners
                .Where(b => b.StartDate <= currentDate && b.EndDate >= currentDate)
                .Include(b => b.Company)
                .ToList();
        }

        public void DeleteBanner(Banner banner)
        {
            _context.Banners.Remove(banner);
            _context.SaveChanges();
        }

    }
}
