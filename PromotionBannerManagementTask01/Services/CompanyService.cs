using PromotionBannerManagementTask01.DTOs;
using PromotionBannerManagementTask01.Entities;
using PromotionBannerManagementTask01.Repositories;

namespace PromotionBannerManagementTask01.Services
{
    public class CompanyService : ICompanyService
    {
        private ICompanyRepository _companyRepo;

        public CompanyService(ICompanyRepository companyRepo)
        {
            _companyRepo = companyRepo;
        }
        
        public bool CreateCompany(CompanyCreateDTO companyDTO)
        {
            Company existingCompany = GetCompanyByName(companyDTO.Name);
            //company with name already exist
            if (existingCompany != null)
            {
                throw new Exception("Company Name is already used. Enter a new name.");
            }

            Company company = new Company
            {
                Name = companyDTO.Name,
                Description = companyDTO.Description
            };

            try
            {
                _companyRepo.CreateCompany(company);
                return true;
            }catch(Exception e)
            {
                Console.WriteLine("Exception Occured While Creating Company. " + e.Message);
                throw;
            }
        }

        //update company name and description
        public bool UpdateCompany(CompanyUpdateDTO companyDTO)
        {
            Company existingCompany = GetCompanyById(companyDTO.Id);
            if (existingCompany == null)
            {
                throw new Exception("Company with given id not found. Check the id.");
            }

            //allow name change to unique name or keep it the same.
            Company checkName = GetCompanyByName(companyDTO.Name);
            if ((checkName != null) && (checkName.Id != companyDTO.Id))
            {
                throw new Exception("Company Name belongs to another company. Check the name.");
            }

            existingCompany.Description = companyDTO.Description;
            existingCompany.Name = companyDTO.Name;

            try
            {
                _companyRepo.UpdateCompany(existingCompany);
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception Occured While Updating Company. " + e.Message);
                throw;
            }   
        }

        public List<CompanyResponseDTO> GetAllCompanies()
        {
            List<Company> companies = _companyRepo.GetAllCompanies();
            if (companies.Count == 0)
            {
                throw new Exception("Company not found.");
            }
            List<CompanyResponseDTO> companyDtoList = [];
            foreach (Company company in companies)
            {
                CompanyResponseDTO companyDTO = ConvertToDto(company);
                companyDtoList.Add(companyDTO);
            }
            return companyDtoList;
        }

        public Company GetCompanyByName(string name)
        {
            return _companyRepo.GetCompanyByName(name);
        }

        public bool DeleteCompany(string name)
        {
            Company existingCompany = GetCompanyByName(name);
            if (existingCompany == null)
            {
                throw new Exception("Company with given name not found. Check the name.");
            }

            try
            {
                _companyRepo.DeleteCompany(existingCompany);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Occured While Deleting Company. " + e.Message);
                throw;
            }
        }

        private Company GetCompanyById(int id)
        {
            return _companyRepo.GetCompanyById(id);
        }

        private CompanyResponseDTO ConvertToDto(Company company)
        {

            CompanyResponseDTO dto = new CompanyResponseDTO
            {
                Id = company.Id,
                Name = company.Name,
                Description = company.Description
            };

            //if company doesn't contain banners, return it. else convert the banner to their dto and add it to banners list.
            if (company.Banners.Count == 0)
            {
                return dto;
            }

            foreach (Banner banner in company.Banners)
            {
                BannerOnlyDTO bannerDto = new BannerOnlyDTO
                {
                    Id = banner.Id,
                    StartDate = banner.StartDate,
                    EndDate = banner.EndDate,
                    Description = banner.Description
                };
                dto.Banners.Add(bannerDto);
            }
            return dto;
        }

    }
}
