using PromotionBannerManagementTask01.Entities;

namespace PromotionBannerManagementTask01.Repositories
{
    public interface IBannerRepository
    {
        void CreateBanner(Banner banner);

        void UpdateBanner(Banner banner);

        List<Banner> GetAllBanners();

        List<Banner> GetBannersByCompany(string companyName);

        List<Banner> GetActiveBanners(DateTime currentDate);

        Banner GetBannerById(int id);

        void DeleteBanner(Banner banner);
    }
}
