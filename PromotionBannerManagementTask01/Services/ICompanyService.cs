using PromotionBannerManagementTask01.DTOs;
using PromotionBannerManagementTask01.Entities;

namespace PromotionBannerManagementTask01.Services
{
    public interface ICompanyService
    {
        bool CreateCompany(CompanyCreateDTO companyDTO);
        bool UpdateCompany(CompanyUpdateDTO companyDTO);
        List<CompanyResponseDTO> GetAllCompanies();
        Company GetCompanyByName(string name);
        //Company GetCompanyById(int id);
        bool DeleteCompany(string name);

    }
}
