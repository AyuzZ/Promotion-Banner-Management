using Microsoft.AspNetCore.Mvc;
using PromotionBannerManagementTask01.DTOs;
using PromotionBannerManagementTask01.Services;

namespace PromotionBannerManagementTask01.Controllers;

[ApiController]
public class CompanyController : Controller
{
    private ICompanyService _companyService;

    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpPost("create-company")]
    public IActionResult CreateCompany(CompanyCreateDTO companyDto)
    {
        try
        {
            var result = _companyService.CreateCompany(companyDto);
            if (result)
            {
                return Created("Company Created.", 201);
            }
            else
            {
                return BadRequest("Couldn't Create Company.");
            }
        }catch(Exception e)
        {
            return BadRequest("Exception Occured." + e.Message);
        }
    }

    [HttpPost("update-company")]
    public IActionResult UpdateCompany(CompanyUpdateDTO companyDto)
    {
        try
        {
            var result = _companyService.UpdateCompany(companyDto);
            if (result)
            {
                return Ok("Company Updated.");
            }
            else
            {
                return BadRequest("Couldn't Update Company.");
            }
        }
        catch (Exception e)
        {
            return BadRequest("Exception Occured." + e.Message);
        }
    }

    [HttpDelete("delete-company")]
    public IActionResult DeleteCompany(string name)
    {
        try
        {
            var result = _companyService.DeleteCompany(name);
            if (result)
            {
                return Ok("Company Deleted.");
            }
            else
            {
                return BadRequest("Couldn't Delete Company.");
            }
        }
        catch (Exception e)
        {
            return BadRequest("Exception Occured." + e.Message);
        }
    }

    [HttpGet("get-companies")]
    public IActionResult GetCompanies()
    {
        try
        {
            var result = _companyService.GetAllCompanies();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return Ok("No companies found.");
            }
        }
        catch (Exception e)
        {
            return BadRequest("Exception Occured." + e.Message);
        }
    }
}
