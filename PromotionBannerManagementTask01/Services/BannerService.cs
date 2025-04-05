using PromotionBannerManagementTask01.DTOs;
using PromotionBannerManagementTask01.Entities;
using PromotionBannerManagementTask01.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PromotionBannerManagementTask01.Services
{
    public class BannerService : IBannerService
    {
        private IBannerRepository _bannerRepo;
        private ICompanyService _companyService;

        public BannerService(IBannerRepository bannerRepo, ICompanyService companyService)
        {
            _bannerRepo = bannerRepo;
            _companyService = companyService;
        }
        
        public bool CreateBanner(BannerCreateDTO bannerDTO)
        {
            Company company = _companyService.GetCompanyByName(bannerDTO.CompanyName);
            if (company == null)
            {
                throw new Exception("Provided company doesn't exist. Please provide an existing company or register the company.");
            }

            Banner banner = new Banner
            {
                StartDate = bannerDTO.StartDate,
                EndDate = bannerDTO.EndDate,
                Description = bannerDTO.Description,
                Company = company
            };

            try
            {
                _bannerRepo.CreateBanner(banner);
                return true;
            }catch(Exception e)
            {
                Console.WriteLine("Exception Occured While Creating Banner. " + e.Message);
                throw;
            }
        }

        //update banner 
        public bool UpdateBanner(BannerUpdateDTO bannerDTO)
        {
            Banner existingBanner = GetBannerById(bannerDTO.Id);
            if (existingBanner == null)
            {
                throw new Exception("Banner with given id not found. Check the id.");
            }
            //Not allowing to change company
            existingBanner.StartDate = bannerDTO.StartDate;
            existingBanner.EndDate = bannerDTO.EndDate;
            existingBanner.Description = bannerDTO.Description;
            try
            {
                _bannerRepo.UpdateBanner(existingBanner);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Occured While Updating Banner. " + e.Message);
                throw;
            }
        }

        public List<BannerResponseDTO> GetAllBanners()
        {
            List<Banner> banners = _bannerRepo.GetAllBanners();
            if (banners.Count == 0)
            {
                throw new Exception("No banners found. ");
            }

            List<BannerResponseDTO> bannerResponseDTOList = [];
            foreach (Banner banner in banners)
            {
                BannerResponseDTO bannerResponse = ConvertToDto(banner);
                bannerResponseDTOList.Add(bannerResponse);
            }
            return bannerResponseDTOList;
        }

        public List<BannerResponseDTO> GetCompanysBanner(string companyName)
        {
            Company company = _companyService.GetCompanyByName(companyName);
            if (company == null)
            {
                throw new Exception("Provided company doesn't exist. Please provide an existing company.");
            }

            List<Banner> banners = _bannerRepo.GetBannersByCompany(companyName);
            if (banners.Count == 0)
            {
                throw new Exception("No banners found.");
            }

            List<BannerResponseDTO> bannerResponseDTOList = [];
            foreach (Banner banner in banners)
            {
                BannerResponseDTO bannerResponse = ConvertToDto(banner);
                bannerResponseDTOList.Add(bannerResponse);
            }
            return bannerResponseDTOList;
        }

        public List<BannerResponseDTO> GetActiveBanners()
        {
            //DateTime.Now gives local time, use UTC as postgres requires utc.
            List<Banner> banners = _bannerRepo.GetActiveBanners(DateTime.UtcNow);
            if (banners.Count == 0)
            {
                throw new Exception("No banners found. ");
            }

            List<BannerResponseDTO> bannerResponseDTOList = [];
            foreach (Banner banner in banners)
            {
                BannerResponseDTO bannerResponse = ConvertToDto(banner);
                bannerResponseDTOList.Add(bannerResponse);
            }
            return bannerResponseDTOList;
        }

        public bool DeleteBanner(int id)
        {
            Banner existingBanner = GetBannerById(id);
            if (existingBanner == null)
            {
                throw new Exception("Banner with given id not found. Check the id.");
            }

            try
            {
                _bannerRepo.DeleteBanner(existingBanner);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Occured While Deleting Banner. " + e.Message);
                throw;
            }
        }


        private Banner GetBannerById(int id)
        {
            return _bannerRepo.GetBannerById(id);
        }

        private BannerResponseDTO ConvertToDto(Banner banner)
        {
            return new BannerResponseDTO
            {
                Id = banner.Id,
                StartDate = banner.StartDate,
                EndDate = banner.EndDate,
                Description = banner.Description,
                CompanyId = banner.Company.Id,
                CompanyName = banner.Company.Name,
                CompanyDescription = banner.Company.Description
            };
        }

    }
}
