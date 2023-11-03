using E_health.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_health.Controllers.FamilyPlanning
{
    public class FamilyPlanningMethodsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FamilyPlanningMethodsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FamilyPlanningMethods
        public async Task<IActionResult> Index()
        {
            var familyPlanningMethods = await _context.FamilyPlanningMethods.ToListAsync();
            return View(familyPlanningMethods);
        }

        // GET: FamilyPlanningMethods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familyPlanningMethod = await _context.FamilyPlanningMethods.FindAsync(id);
            if (familyPlanningMethod == null)
            {
                return NotFound();
            }

            return View(familyPlanningMethod);
        }
    }

}
