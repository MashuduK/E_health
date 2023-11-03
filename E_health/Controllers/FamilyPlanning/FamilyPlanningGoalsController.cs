using E_health.Areas.Identity.Data;
using E_health.Models.FamilyPlanning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_health.Controllers.FamilyPlanning
{
    public class FamilyPlanningGoalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FamilyPlanningGoalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FamilyPlanningGoals
        public async Task<IActionResult> Index()
        {
            var familyPlanningGoals = await _context.FamilyPlanningGoals.ToListAsync();
            return View(familyPlanningGoals);
        }

        // GET: FamilyPlanningGoals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familyPlanningGoal = await _context.FamilyPlanningGoals.FindAsync(id);
            if (familyPlanningGoal == null)
            {
                return NotFound();
            }

            return View(familyPlanningGoal);
        }

        // CREATE: FamilyPlanningGoals
        public IActionResult Create()
        {
            return View();
        }

        // POST: FamilyPlanningGoals/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,DesiredNumberOfChildren,DesiredSpacingBetweenChildren,DesiredAgeAtFirstPregnancy")] FamilyPlanningGoal familyPlanningGoal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(familyPlanningGoal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(familyPlanningGoal);
        }

        // EDIT: FamilyPlanningGoals/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familyPlanningGoal = await _context.FamilyPlanningGoals.FindAsync(id);
            if (familyPlanningGoal == null)
            {
                return NotFound();
            }

            return View(familyPlanningGoal);
        }

        // POST: FamilyPlanningGoals/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,DesiredNumberOfChildren,DesiredSpacingBetweenChildren,DesiredAgeAtFirstPregnancy")] FamilyPlanningGoal familyPlanningGoal)
        {
            if (id != familyPlanningGoal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(familyPlanningGoal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(familyPlanningGoal);
        }

        // DELETE: FamilyPlanningGoals/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familyPlanningGoal = await _context.FamilyPlanningGoals.FindAsync(id);
            if (familyPlanningGoal == null)
            {
                return NotFound();
            }

            return View(familyPlanningGoal);
        }

        // POST: FamilyPlanningGoals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var familyPlanningGoal = await _context.FamilyPlanningGoals.FindAsync(id);
            _context.FamilyPlanningGoals.Remove(familyPlanningGoal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }


}
