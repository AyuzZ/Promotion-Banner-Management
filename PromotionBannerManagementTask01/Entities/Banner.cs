using System.ComponentModel.DataAnnotations;

namespace PromotionBannerManagementTask01.Entities
{
    public class Banner
    {
        [Key]
        public int Id { get; set; }
        public required DateTime StartDate { get; set; }
        public required DateTime EndDate { get; set; }
        public required string Description { get; set; }

        public int CompanyId { get; set; }

        public required Company Company { get; set; }
    }
}
