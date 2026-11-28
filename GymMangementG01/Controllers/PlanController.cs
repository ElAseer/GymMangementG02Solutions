using GymMangementG01.Contexts;
using GymMangementG01.Entities;
using GymMangementG01.Repositoires.Classes;
using GymMangementG01.Repositoires.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymMangementG01.Controllers
{
    public class PlanController : Controller
    {
        // private GymDbContext dbContext = new GymDbContext();  ❌
        // private IPlanRepository planRepository = new PlanRepository();
        private IPlanRepository _planRepository;
        private readonly IMemberShipRepository _memberShipRepository;

        public PlanController(IPlanRepository planRepository, IMemberShipRepository memberShipRepository)
        {
            _planRepository = planRepository;
            _memberShipRepository = memberShipRepository;
        }
        public async Task<IActionResult> Index()
        {
            //  var Plans = await dbContext.Plans.ToListAsync();  ❌

            var Plans = await _planRepository.GetAllAsync();
            //ViewData["Hamada"] = "  Hamada at Route  ";
            //ViewBag.Age = 30;
            return View(Plans);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id, CancellationToken ct)
        {
            var plan = await _planRepository.GetPlanByIdAsync(id);
            if (plan is null || !plan.IsActive)
            {
                //  return NotFound();//Browser Behavior

                TempData["ErrorMessage"] = "This plan Can't be Edited";
                return RedirectToAction(nameof(Index));
            }

            var hasCurrentMemberShipsAsync = await _memberShipRepository.AnyAsync(m => m.PlanId == id && m.EndDate > DateTime.Now, ct);

            if (hasCurrentMemberShipsAsync)
            {
                // return BadRequest();//Browser Behavior
                TempData["ErrorMessage"] = "This plan has memberships.";
                return RedirectToAction(nameof(Index));
            }

            return View(plan);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute] int id , Plan UpdatePlan ,CancellationToken ct)
        {
            if (!ModelState.IsValid) return View(UpdatePlan);

            var plan = await _planRepository.GetPlanByIdAsync(id);

            if (plan is null || !plan.IsActive)
            {
                TempData["ErrorMessage"] = "This plan Can't be Edited";
                return RedirectToAction(nameof(Index));
            }

            var hasCurrentMembershipsAsync = await _memberShipRepository.AnyAsync(m => m.PlanId == id && m.EndDate > DateTime.Now, ct);

            if (hasCurrentMembershipsAsync)
            {
                TempData["ErrorMessage"] = "This plan has memberships.";
                return RedirectToAction(nameof(Index));
            }

            plan.DurationDays = UpdatePlan.DurationDays;
            plan.Price = UpdatePlan.Price;
            plan.Description = UpdatePlan.Description;
            var result = await _planRepository.UpdateAsync(ct);
            if (result == 0)
            {
                TempData["ErrorMessage"] = "Plan Failed To Update.";
                return RedirectToAction(nameof(Index));
            }

            TempData["SuccessMessage"] = "Plan updated successfully.";
            return RedirectToAction(nameof(Index));
        }
    }
}
