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
    public class TrainingsController : Controller
    {
        private readonly JulieProDbContext _db;

        public TrainingsController(JulieProDbContext db)
        {
            _db = db;
        }

        // GET: Trainings
        public async Task<IActionResult> Index()
        {
            return View(
                    new TrainingsIndexVM(
                        "Trainings",
                        "Trainings",
                        new List<PageLinks>() { PageLinks.Create },
                        await _db.Trainings
                            
                            .ToListAsync()
                    )
            );
        }

        // GET: Trainings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Training training = await _db.Trainings
                                                
                                                    .FirstOrDefaultAsync(e => e.Id == id);
            if (training == null)
            {
                return NotFound();
            }

            return View(
                    "Display",
                    new TrainingsDisplayVM(
                        true,
                        "Training",
                        "Training",
                        new List<PageLinks>() { PageLinks.BackToList, PageLinks.Edit },
                        training
                    )
            );
        }

        // GET: Trainings/Upsert/5
        public async Task<IActionResult> Upsert(int? id)
        {
            bool isCreate = id == null;
            Training training = null;

            if (!isCreate)
            {
                // Extra stuff for Edit
                training = await _db.Trainings.FirstOrDefaultAsync(e => e.Id == id);
                if (training == null)
                {
                    return NotFound();
                }
            }

            return View(
                GetTrainingsUpsertVM(
                    isCreate, 
                    new Dictionary<string,SelectList­>(){
                    }, 
                    training
                )
            );
        }

        // POST: Trainings/Upsert
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(TrainingsUpsertVM vm)
        {
            if(vm.IsCreate)
            {
                ModelState.Remove("Training.Id");
            }

            if (ModelState.IsValid)
            {
                if (vm.IsCreate)
                {
                    _db.Add(vm.Training);
                }
                else
                {
                    try
                    {
                        _db.Update(vm.Training);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TrainingExists(vm.Training.Id))
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
                    GetTrainingsUpsertVM(
                        vm.IsCreate, 
                        new Dictionary<string,SelectList­>(){
                        }, 
                        vm.Training
                    )
            );
        }

        // GET: Trainings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Training training = await _db.Trainings
                                                
                                                    .FirstOrDefaultAsync(e => e.Id == id);
            if (training == null)
            {
                return NotFound();
            }

            return View(
                    "Display",
                    new TrainingsDisplayVM(
                        false,
                        "Training",
                        "Are you sure you want to delete this Training",
                        new List<PageLinks>() { PageLinks.BackToList },
                        training,
                        "Supprimer"
                    )
            );
        }

        // POST: Trainings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Training training = await _db.Trainings.FindAsync(id);
            _db.Trainings.Remove(training);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainingExists(int id)
        {
            return _db.Trainings.Any(e => e.Id == id);
        }

        private TrainingsUpsertVM GetTrainingsUpsertVM(bool isCreate, Dictionary<string,SelectList­> selectLists, Training training = null)
        {
            return new TrainingsUpsertVM(
                        isCreate,
                        "Training",
                        "Training",
                        new List<PageLinks>() { PageLinks.BackToList },
                        isCreate ? "Ajouter" : "Modifier",
                        selectLists,
                        training
            );
        }
    }
}
