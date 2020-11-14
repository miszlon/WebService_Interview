using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Task_PPE.Models;

namespace Task_PPE.Controllers
{
    public class DelegationController : Controller
    {
        private readonly Business_TripsContext _context;

        public DelegationController(Business_TripsContext context)
        {
            _context = context;
        }

        // GET: Delegation
        public async Task<IActionResult> Index()
        {
            if (this.User.IsInRole("bf628660-5b08-48eb-9d3a-eee9c1f89dbf"))
            {
                var business_TripsContext = _context.Delegation.Include(d => d.EmployeeNavigation);
                return View(await business_TripsContext.ToListAsync());
            }
            else
            {
                var business_TripsContext = _context.Delegation.Include(d => d.EmployeeNavigation).Where(x => x.CreatedBy == User.Identity.Name);
                return View(await business_TripsContext.ToListAsync());
            }


        }

        // GET: Delegation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var delegation = await _context.Delegation
                .Include(d => d.EmployeeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (delegation == null)
            {
                return NotFound();
            }

            return View(delegation);
        }

        // GET: Delegation/Create
        public IActionResult Create()
        {
            ViewData["Employee"] = new SelectList(_context.Employee, "Id", "Id");
            return View();
        }

        // POST: Delegation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CreatedOn,Departure,Destination,Employee,StartDate,FinishDate,Description")] Delegation delegation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(delegation);
                delegation.CreatedOn = DateTime.Now;
                delegation.CreatedBy = User.Identity.Name;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Employee"] = new SelectList(_context.Employee, "Id");
            return View(delegation);
        }

        // GET: Delegation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var delegation = await _context.Delegation.FindAsync(id);
            if (delegation == null)
            {
                return NotFound();
            }
            ViewData["Employee"] = new SelectList(_context.Employee, "Id", "Id", delegation.Employee);
            return View(delegation);
        }

        // POST: Delegation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "bf628660-5b08-48eb-9d3a-eee9c1f89dbf")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CreatedOn,Departure,Destination,Employee,StartDate,FinishDate,Description")] Delegation delegation)
        {
            if (id != delegation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(delegation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DelegationExists(delegation.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Employee"] = new SelectList(_context.Employee, "Id", "Id", delegation.Employee);
            return View(delegation);
        }

        // GET: Delegation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var delegation = await _context.Delegation
                .Include(d => d.EmployeeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (delegation == null)
            {
                return NotFound();
            }

            return View(delegation);
        }

        // POST: Delegation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var delegation = await _context.Delegation.FindAsync(id);
            _context.Delegation.Remove(delegation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DelegationExists(int id)
        {
            return _context.Delegation.Any(e => e.Id == id);
        }
    }
}
