using PromotionBannerManagementTask01.Entities;

namespace PromotionBannerManagementTask01.DTOs
{
    public class BannerResponseDTO
    {
        public int Id { get; set; }
        public required DateTime StartDate { get; set; }
        public required DateTime EndDate { get; set; }
        public required string Description { get; set; }

        public int CompanyId { get; set; }
        public required string CompanyName { get; set; }
        public required string CompanyDescription { get; set; }
    }
}
