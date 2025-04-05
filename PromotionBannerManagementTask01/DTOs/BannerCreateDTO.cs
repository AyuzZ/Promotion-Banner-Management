using PromotionBannerManagementTask01.Entities;

namespace PromotionBannerManagementTask01.DTOs
{
    public class BannerCreateDTO
    {
        public required DateTime StartDate { get; set; }
        public required DateTime EndDate { get; set; }
        public required string Description { get; set; }

        public required string CompanyName { get; set; }

    }
}
