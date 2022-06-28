using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JuliePro_DataAccess.Data;
using JuliePro_Models;
using JuliePro_Models.ViewModels;
using JuliePro_Utility;

namespace JuliePro.Controllers
{
    public class ScheduledSessionsController : Controller
    {
        private readonly JulieProDbContext _db;

        public ScheduledSessionsController(JulieProDbContext db)
        {
            _db = db;
        }

        // GET: ScheduledSessions
        public async Task<IActionResult> Index()
        {
            return View(
                    new ScheduledSessionsIndexVM(
                        "ScheduledSessions",
                        "ScheduledSessions",
                        new List<PageLinks>() { PageLinks.Create },
                        await _db.ScheduledSessions
                            .Include(s => s.Customer).Include(s => s.Training)
                            .ToListAsync()
                    )
            );
        }

        // GET: ScheduledSessions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ScheduledSession scheduledSession = await _db.ScheduledSessions
                                                
.Include(s => s.Customer)
.Include(s => s.Training)
                                                    .FirstOrDefaultAsync(e => e.Id == id);
            if (scheduledSession == null)
            {
                return NotFound();
            }

            return View(
                    "Display",
                    new ScheduledSessionsDisplayVM(
                        true,
                        "ScheduledSession",
                        "ScheduledSession",
                        new List<PageLinks>() { PageLinks.BackToList, PageLinks.Edit },
                        scheduledSession
                    )
            );
        }

        // GET: ScheduledSessions/Upsert/5
        public async Task<IActionResult> Upsert(int? id)
        {
            bool isCreate = id == null;
            ScheduledSession scheduledSession = null;

            if (!isCreate)
            {
                // Extra stuff for Edit
                scheduledSession = await _db.ScheduledSessions.FirstOrDefaultAsync(e => e.Id == id);
                if (scheduledSession == null)
                {
                    return NotFound();
                }
            }

            return View(
                GetScheduledSessionsUpsertVM(
                    isCreate, 
                    new Dictionary<string,SelectList­>(){
                        { "ListForCustomer_Id", new SelectList(_db.Customers, "Id", "Email") },
                        { "ListForTraining_Id", new SelectList(_db.Trainings, "Id", "Category") },
                    }, 
                    scheduledSession
                )
            );
        }

        // POST: ScheduledSessions/Upsert
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(ScheduledSessionsUpsertVM vm)
        {
            if(vm.IsCreate)
            {
                ModelState.Remove("ScheduledSession.Id");
            }

            if (ModelState.IsValid)
            {
                if (vm.IsCreate)
                {
                    _db.Add(vm.ScheduledSession);
                }
                else
                {
                    try
                    {
                        _db.Update(vm.ScheduledSession);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ScheduledSessionExists(vm.ScheduledSession.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(
                    GetScheduledSessionsUpsertVM(
                        vm.IsCreate, 
                        new Dictionary<string,SelectList­>(){
                        { "ListForCustomer_Id", new SelectList(_db.Customers, "Id", "Email") },
                        { "ListForTraining_Id", new SelectList(_db.Trainings, "Id", "Category") },
                        }, 
                        vm.ScheduledSession
                    )
            );
        }

        // GET: ScheduledSessions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ScheduledSession scheduledSession = await _db.ScheduledSessions
                                                
.Include(s => s.Customer)
.Include(s => s.Training)
                                                    .FirstOrDefaultAsync(e => e.Id == id);
            if (scheduledSession == null)
            {
                return NotFound();
            }

            return View(
                    "Display",
                    new ScheduledSessionsDisplayVM(
                        false,
                        "ScheduledSession",
                        "Are you sure you want to delete this ScheduledSession",
                        new List<PageLinks>() { PageLinks.BackToList },
                        scheduledSession,
                        "Supprimer"
                    )
            );
        }

        // POST: ScheduledSessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ScheduledSession scheduledSession = await _db.ScheduledSessions.FindAsync(id);
            _db.ScheduledSessions.Remove(scheduledSession);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScheduledSessionExists(int id)
        {
            return _db.ScheduledSessions.Any(e => e.Id == id);
        }

        private ScheduledSessionsUpsertVM GetScheduledSessionsUpsertVM(bool isCreate, Dictionary<string,SelectList­> selectLists, ScheduledSession scheduledSession = null)
        {
            return new ScheduledSessionsUpsertVM(
                        isCreate,
                        "ScheduledSession",
                        "ScheduledSession",
                        new List<PageLinks>() { PageLinks.BackToList },
                        isCreate ? "Ajouter" : "Modifier",
                        selectLists,
                        scheduledSession
            );
        }
    }
}
