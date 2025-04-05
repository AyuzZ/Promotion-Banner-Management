using PromotionBannerManagementTask01.Entities;

namespace PromotionBannerManagementTask01.Repositories
{
    public interface ICompanyRepository
    {
        void CreateCompany(Company company);

        void UpdateCompany(Company company);

        List<Company> GetAllCompanies();

        Company GetCompanyById(int id);

        Company GetCompanyByName(string name);

        void DeleteCompany(Company company);
    }
}
