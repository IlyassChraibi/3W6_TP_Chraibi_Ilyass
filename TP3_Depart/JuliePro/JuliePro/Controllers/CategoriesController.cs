﻿using JuliePro_Core.Interfaces;
using JuliePro_Models;
using JuliePro_Models.ViewModels;
using JuliePro_Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuliePro.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService _categoriesSvc;

        public CategoriesController(ICategoriesService categoriesSvc)
        {
            _categoriesSvc = categoriesSvc;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            return View(await _categoriesSvc.GetIndexVM());
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || !(await _categoriesSvc.ExistsAsync((int)id)))
            {
                return NotFound();
            }

            return View("Display", await _categoriesSvc.GetDisplayVM(ControllerAction.Details, (int)id));
        }

        // GET: Categories/Upsert/5
        public async Task<IActionResult> Upsert(int? id)
        {    
            if (id != null && !(await _categoriesSvc.ExistsAsync((int)id)))
            {
                return NotFound();
            }

            return View(await _categoriesSvc.GetUpsertVM(id == null ? ControllerAction.Create : ControllerAction.Edit, id));
        }

        // POST: Categories/Upsert
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(GenericControllerUpsertVM<Category> vm)
        {
            if(vm.IsCreate)
            {
                ModelState.Remove("Entity.Id");
            }

            if (!ModelState.IsValid)
            {
                return View(_categoriesSvc.GetUpsertVM(vm.IsCreate ? ControllerAction.Create : ControllerAction.Edit, vm.Entity));
            }

            if (vm.IsCreate)
            {
                await _categoriesSvc.AddAsync(vm.Entity);
            }
            else
            {
                if (!(await _categoriesSvc.ExistsAsync(vm.Entity.Id)))
                {
                    return NotFound();
                }

                await _categoriesSvc.UpdateAsync(vm.Entity);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || !(await _categoriesSvc.ExistsAsync((int)id)))
            {
                return NotFound();
            }

            return View("Display", await _categoriesSvc.GetDisplayVM(ControllerAction.Delete, (int)id));
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _categoriesSvc.DeleteAsync<Category>(id);

            return RedirectToAction(nameof(Index));
        }
    }
}