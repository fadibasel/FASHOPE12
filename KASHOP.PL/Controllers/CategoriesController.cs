using FASHOP.DAL.Data;
using FASHOP.DAL.DTO.Request;
using FASHOP.DAL.DTO.Response;
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
        private readonly ApplicationDbContext _context;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public  CategoriesController(ApplicationDbContext context,IStringLocalizer<SharedResource> localizer)
          {
            _context = context;
            _localizer = localizer;
        }
        [HttpGet("")]
        public IActionResult index()
        {
           var categories = _context.Categories.Include(c=>c.Translations).ToList();
            var response =categories.Adapt<List<CategoryResponse>>();
            return Ok(new {message = _localizer["Success"].Value ,response });
        }
        [HttpPost("")]
        public IActionResult Create(CategoryRequest Request)
        {
            var category = Request.Adapt<FASHOP.DAL.Models.Category>();
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok(new { message = _localizer["Success"].Value });
        }
    }
}
