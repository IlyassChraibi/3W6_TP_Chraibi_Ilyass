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
    public class SpecialitiesController : Controller
    {
        private readonly JulieProDbContext _db;

        public SpecialitiesController(JulieProDbContext db)
        {
            _db = db;
        }

        // GET: Specialities
        public async Task<IActionResult> Index()
        {
            return View(
                    new SpecialitiesIndexVM(
                        "Specialities",
                        "Specialities",
                        new List<PageLinks>() { PageLinks.Create },
                        await _db.Specialities
                            
                            .ToListAsync()
                    )
            );
        }

        // GET: Specialities/Details/5
        public async Task<IActionResult> Display(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Speciality speciality = await _db.Specialities
                                                
                                                    .FirstOrDefaultAsync(e => e.Id == id);
            if (speciality == null)
            {
                return NotFound();
            }

            return View(
                    "Display",
                    new SpecialitiesDisplayVM(
                        true,
                        "Speciality",
                        "Speciality",
                        new List<PageLinks>() { PageLinks.BackToList, PageLinks.Edit },
                        speciality
                    )
            );
        }

        // GET: Specialities/Upsert/5
        public async Task<IActionResult> Upsert(int? id)
        {
            bool isCreate = id == null;
            Speciality speciality = null;

            if (!isCreate)
            {
                // Extra stuff for Edit
                speciality = await _db.Specialities.FirstOrDefaultAsync(e => e.Id == id);
                if (speciality == null)
                {
                    return NotFound();
                }
            }

            return View(
                GetSpecialitiesUpsertVM(
                    isCreate, 
                    new Dictionary<string,SelectList­>(){
                    }, 
                    speciality
                )
            );
        }

        // POST: Specialities/Upsert
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(SpecialitiesUpsertVM vm)
        {
            if(vm.IsCreate)
            {
                ModelState.Remove("Speciality.Id");
            }

            if (ModelState.IsValid)
            {
                if (vm.IsCreate)
                {
                    _db.Add(vm.Speciality);
                }
                else
                {
                    try
                    {
                        _db.Update(vm.Speciality);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!SpecialityExists(vm.Speciality.Id))
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
                    GetSpecialitiesUpsertVM(
                        vm.IsCreate, 
                        new Dictionary<string,SelectList­>(){
                        }, 
                        vm.Speciality
                    )
            );
        }

        //// GET: Specialities/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    Speciality speciality = await _db.Specialities
                                                
        //                                            .FirstOrDefaultAsync(e => e.Id == id);
        //    if (speciality == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(
        //            "Display",
        //            new SpecialitiesDisplayVM(
        //                false,
        //                "Speciality",
        //                "Are you sure you want to delete this Speciality",
        //                new List<PageLinks>() { PageLinks.BackToList },
        //                speciality,
        //                "Supprimer"
        //            )
        //    );
        //}

        //// POST: Specialities/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    Speciality speciality = await _db.Specialities.FindAsync(id);
        //    _db.Specialities.Remove(speciality);
        //    await _db.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool SpecialityExists(int id)
        {
            return _db.Specialities.Any(e => e.Id == id);
        }

        private SpecialitiesUpsertVM GetSpecialitiesUpsertVM(bool isCreate, Dictionary<string,SelectList­> selectLists, Speciality speciality = null)
        {
            return new SpecialitiesUpsertVM(
                        isCreate,
                        "Speciality",
                        "Speciality",
                        new List<PageLinks>() { PageLinks.BackToList },
                        isCreate ? "Ajouter" : "Modifier",
                        selectLists,
                        speciality
            );
        }
    }
}
