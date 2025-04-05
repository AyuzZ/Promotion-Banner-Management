using Microsoft.EntityFrameworkCore;
using PromotionBannerManagementTask01.Entities;

namespace PromotionBannerManagementTask01.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {

        private ApplicationDBContext _context;

        public CompanyRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public void CreateCompany(Company company)
        {
            _context.Companies.Add(company);
            _context.SaveChanges();
        }

        public void UpdateCompany(Company company)
        {
            _context.Companies.Update(company);
            _context.SaveChanges();
        }

        public List<Company> GetAllCompanies()
        {
            return _context.Companies
                .Include(c => c.Banners)
                .ToList();
            //same here, i am already converting them to dtos in service layer to avoid circular reference.
        }

        public Company GetCompanyById(int id)
        {
            return _context.Companies.FirstOrDefault(c => c.Id == id);
        }

        public Company GetCompanyByName(string name)
        {
            return _context.Companies.FirstOrDefault(c => c.Name == name);
        }

        public void DeleteCompany(Company company)
        {
            _context.Companies.Remove(company);
            _context.SaveChanges();
        }

    }
}
