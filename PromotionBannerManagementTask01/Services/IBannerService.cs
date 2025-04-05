using PromotionBannerManagementTask01.DTOs;
using PromotionBannerManagementTask01.Entities;

namespace PromotionBannerManagementTask01.Services
{
    public interface IBannerService
    {
        bool CreateBanner(BannerCreateDTO bannerDTO);
        bool UpdateBanner(BannerUpdateDTO bannerDTO);
        List<BannerResponseDTO> GetAllBanners();
        List<BannerResponseDTO> GetCompanysBanner(string companyName);
        List<BannerResponseDTO> GetActiveBanners();
        bool DeleteBanner(int id);
    }
}
