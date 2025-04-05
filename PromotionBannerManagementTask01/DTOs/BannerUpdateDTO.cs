namespace PromotionBannerManagementTask01.DTOs
{
    public class BannerUpdateDTO
    {
        public required int Id { get; set; }
        public required DateTime StartDate { get; set; }
        public required DateTime EndDate { get; set; }
        public required string Description { get; set; }

    }
}
