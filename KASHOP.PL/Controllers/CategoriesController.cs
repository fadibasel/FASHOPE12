using FASHOP.BLL.Service;
using FASHOP.DAL.Data;
using FASHOP.DAL.DTO.Request;
using FASHOP.DAL.DTO.Response;
using FASHOP.DAL.Repository;
using FASHOP.PL.Resourses;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace FASHOP.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IStringLocalizer<SharedResource> _localizer;
        private readonly ICategoryService _CategoryService;

        public CategoriesController(IStringLocalizer<SharedResource> localizer, ICategoryService CategoryService)
        {
            _localizer = localizer;
            _CategoryService = CategoryService;
        }
        [HttpGet("")]
        public IActionResult index()
        {
            var response = _CategoryService.GetAllCategories();

            return Ok(new { message = _localizer["Success"].Value, response });
        }
        [HttpPost("")]
        public IActionResult Create(CategoryRequest Request)
        {
           var response = _CategoryService.CreateCategory(Request);
            return Ok(new { message = _localizer["Success"].Value });
        }
    }
}