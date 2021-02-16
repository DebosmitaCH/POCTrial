using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using POCTrial.Models;

namespace POCTrial.Controllers
{
    public class EmployeeInformationsController : Controller
    {
        private readonly POCTrialContext _context;

        public EmployeeInformationsController(POCTrialContext context)
        {
            _context = context;
        }

        // GET: EmployeeInformations
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmployeeInformations.ToListAsync());
        }

        // GET: EmployeeInformations/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeInformation = await _context.EmployeeInformations
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employeeInformation == null)
            {
                return NotFound();
            }

            return View(employeeInformation);
        }

        // GET: EmployeeInformations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeInformations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,FirstName,MiddleName,LastName,Designation,Department,Supervisor,StartDate,ProjectId,WorkEmail,WorkLocation,WorkPhone")] EmployeeInformation employeeInformation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeInformation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeInformation);
        }

        // GET: EmployeeInformations/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeInformation = await _context.EmployeeInformations.FindAsync(id);
            if (employeeInformation == null)
            {
                return NotFound();
            }
            return View(employeeInformation);
        }

        // POST: EmployeeInformations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("EmployeeId,FirstName,MiddleName,LastName,Designation,Department,Supervisor,StartDate,ProjectId,WorkEmail,WorkLocation,WorkPhone")] EmployeeInformation employeeInformation)
        {
            if (id != employeeInformation.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeInformation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeInformationExists(employeeInformation.EmployeeId))
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
            return View(employeeInformation);
        }

        // GET: EmployeeInformations/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeInformation = await _context.EmployeeInformations
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employeeInformation == null)
            {
                return NotFound();
            }

            return View(employeeInformation);
        }

        // POST: EmployeeInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            var employeeInformation = await _context.EmployeeInformations.FindAsync(id);
            _context.EmployeeInformations.Remove(employeeInformation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeInformationExists(short id)
        {
            return _context.EmployeeInformations.Any(e => e.EmployeeId == id);
        }
    }
}
