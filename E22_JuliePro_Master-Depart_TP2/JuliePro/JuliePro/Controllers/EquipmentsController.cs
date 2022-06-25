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
    public class EquipmentsController : Controller
    {
        private readonly JulieProDbContext _db;

        public EquipmentsController(JulieProDbContext db)
        {
            _db = db;
        }

        // GET: Equipments
        public async Task<IActionResult> Index()
        {
            return View(
                    new EquipmentsIndexVM(
                        "Equipments",
                        "Equipments",
                        new List<PageLinks>() { PageLinks.Create },
                        await _db.Equipments
                            
                            .ToListAsync()
                    )
            );
        }

        // GET: Equipments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Equipment equipment = await _db.Equipments
                                                
                                                    .FirstOrDefaultAsync(e => e.Id == id);
            if (equipment == null)
            {
                return NotFound();
            }

            return View(
                    "Display",
                    new EquipmentsDisplayVM(
                        true,
                        "Equipment",
                        "Equipment",
                        new List<PageLinks>() { PageLinks.BackToList, PageLinks.Edit },
                        equipment
                    )
            );
        }

        // GET: Equipments/Upsert/5
        public async Task<IActionResult> Upsert(int? id)
        {
            bool isCreate = id == null;
            Equipment equipment = null;

            if (!isCreate)
            {
                // Extra stuff for Edit
                equipment = await _db.Equipments.FirstOrDefaultAsync(e => e.Id == id);
                if (equipment == null)
                {
                    return NotFound();
                }
            }

            return View(
                GetEquipmentsUpsertVM(
                    isCreate, 
                    new Dictionary<string,SelectList­>(){
                    }, 
                    equipment
                )
            );
        }

        // POST: Equipments/Upsert
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(EquipmentsUpsertVM vm)
        {
            if(vm.IsCreate)
            {
                ModelState.Remove("Equipment.Id");
            }

            if (ModelState.IsValid)
            {
                if (vm.IsCreate)
                {
                    _db.Add(vm.Equipment);
                }
                else
                {
                    try
                    {
                        _db.Update(vm.Equipment);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!EquipmentExists(vm.Equipment.Id))
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
                    GetEquipmentsUpsertVM(
                        vm.IsCreate, 
                        new Dictionary<string,SelectList­>(){
                        }, 
                        vm.Equipment
                    )
            );
        }

        // GET: Equipments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Equipment equipment = await _db.Equipments
                                                
                                                    .FirstOrDefaultAsync(e => e.Id == id);
            if (equipment == null)
            {
                return NotFound();
            }

            return View(
                    "Display",
                    new EquipmentsDisplayVM(
                        false,
                        "Equipment",
                        "Are you sure you want to delete this Equipment",
                        new List<PageLinks>() { PageLinks.BackToList },
                        equipment,
                        "Supprimer"
                    )
            );
        }

        // POST: Equipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Equipment equipment = await _db.Equipments.FindAsync(id);
            _db.Equipments.Remove(equipment);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipmentExists(int id)
        {
            return _db.Equipments.Any(e => e.Id == id);
        }

        private EquipmentsUpsertVM GetEquipmentsUpsertVM(bool isCreate, Dictionary<string,SelectList­> selectLists, Equipment equipment = null)
        {
            return new EquipmentsUpsertVM(
                        isCreate,
                        "Equipment",
                        "Equipment",
                        new List<PageLinks>() { PageLinks.BackToList },
                        isCreate ? "Ajouter" : "Modifier",
                        selectLists,
                        equipment
            );
        }
    }
}
