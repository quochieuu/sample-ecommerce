using Ecommerce.Data.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.WebApp.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        private readonly DataDbContext _context;

        public ProductController(DataDbContext context)
        {
            _context = context;
        }

        [Route("")]
        public async Task<IActionResult> Index()
        {
            ViewBag.ListCategories = _context.Categories.OrderByDescending(c => c.Id).ToList();  
            var item = _context.Products.OrderByDescending(p => p.Id).ToList();
            return View(item);
        }

        [Route("{slug}")]
        public async Task<IActionResult> Detail(string slug)
        {
            var item = await _context.Products.Where(p => p.Slug == slug).FirstOrDefaultAsync();
            return View(item);
        }
    }
}
