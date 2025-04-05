using System.ComponentModel.DataAnnotations;

namespace PromotionBannerManagementTask01.Entities
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public ICollection<Banner> Banners { get; set; } = [];
    }
}
