using PromotionBannerManagementTask01.Entities;

namespace PromotionBannerManagementTask01.DTOs
{
    public class CompanyResponseDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public ICollection<BannerOnlyDTO> Banners { get; set; } = [];
    }
}
