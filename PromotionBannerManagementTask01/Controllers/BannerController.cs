using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromotionBannerManagementTask01.DTOs;
using PromotionBannerManagementTask01.Services;

namespace PromotionBannerManagementTask01.Controllers;

[ApiController]
public class BannerController : Controller
{
    private IBannerService _bannerService;

    public BannerController(IBannerService bannerService)
    {
        _bannerService = bannerService;
    }

    [HttpPost("create-banner")]
    public IActionResult CreateBanner(BannerCreateDTO bannerDto)
    {
        try
        {
            var result = _bannerService.CreateBanner(bannerDto);
            if (result)
            {
                return Created("Banner Created.", 201);
            }
            else
            {
                return BadRequest("Couldn't Create Banner.");
            }
        }
        catch (Exception e)
        {
            return BadRequest("Exception Occured. " + e.Message);
        }
    }

    [HttpPost("update-banner")]
    public IActionResult UpdateBanner(BannerUpdateDTO bannerDto)
    {
        try
        {
            var result = _bannerService.UpdateBanner(bannerDto);
            if (result)
            {
                return Ok("Banner Updated.");
            }
            else
            {
                return BadRequest("Couldn't Update Banner.");
            }
        }
        catch (Exception e)
        {
            return BadRequest("Exception Occured. " + e.Message);
        }
    }

    [HttpDelete("delete-banner")]
    public IActionResult DeleteBanner(int id)
    {
        try
        {
            var result = _bannerService.DeleteBanner(id);
            if (result)
            {
                return Ok("Banner Deleted.");
            }
            else
            {
                return BadRequest("Couldn't Delete Banner.");
            }
        }
        catch (Exception e)
        {
            return BadRequest("Exception Occured. " + e.Message);
        }
    }

    [HttpGet("get-banners")]
    public IActionResult GetBanners()
    {
        try
        {
            var result = _bannerService.GetAllBanners();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return Ok("No banners found.");
            }
        }
        catch (Exception e)
        {
            return BadRequest("Exception Occured. " + e.Message);
        }
    }

    [HttpGet("get-company-banners")]
    public IActionResult GetCompanyBanners(string companyName)
    {
        try
        {
            var result = _bannerService.GetCompanysBanner(companyName);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return Ok("No banners found. ");
            }
        }
        catch (Exception e)
        {
            return BadRequest("Exception Occured. " + e.Message);
        }
    }

    [HttpGet("get-active-banners")]
    public IActionResult GetActiveBanners()
    {
        try
        {
            var result = _bannerService.GetActiveBanners();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return Ok("No banners found. ");
            }
        }
        catch (Exception e)
        {
            return BadRequest("Exception Occured. " + e.Message);
        }
    }
}
