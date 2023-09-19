using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mindit.Data;
using Mindit.Models;

namespace Mindit.ViewComponents
{
    public class LayoutComboCategoriesViewComponent: ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public LayoutComboCategoriesViewComponent(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public IViewComponentResult Invoke()
        { 
            var categories = from category in _context.MinditCategoryModel select category;
            return View(categories);
        }
    }
}
