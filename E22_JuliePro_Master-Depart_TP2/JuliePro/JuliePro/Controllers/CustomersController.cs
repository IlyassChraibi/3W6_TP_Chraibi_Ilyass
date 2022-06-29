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
    public class CustomersController : Controller
    {
        private readonly JulieProDbContext _db;

        public CustomersController(JulieProDbContext db)
        {
            _db = db;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            return View(
                    new CustomersIndexVM(
                        "Customers",
                        "Customers",
                        new List<PageLinks>() { PageLinks.Create },
                        await _db.Customers
                            .Include(c => c.Trainer)
                            .ToListAsync()
                    )
            );
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer customer = await _db.Customers
                                                
.Include(c => c.Trainer)
                                                    .FirstOrDefaultAsync(e => e.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(
                    "Display",
                    new CustomersDisplayVM(
                        true,
                        "Customer",
                        "Customer",
                        new List<PageLinks>() { PageLinks.BackToList, PageLinks.Edit },
                        customer
                    )
            );
        }

        // GET: Customers/Upsert/5
        public async Task<IActionResult> Upsert(int? id)
        {
            bool isCreate = id == null;
            Customer customer = null;

            if (!isCreate)
            {
                // Extra stuff for Edit
                customer = await _db.Customers.FirstOrDefaultAsync(e => e.Id == id);
                if (customer == null)
                {
                    return NotFound();
                }
            }

            return View(
                GetCustomersUpsertVM(
                    isCreate, 
                    new Dictionary<string,SelectList­>(){
                        { "ListForTrainer_Id", new SelectList(_db.Trainers, "Id", "Email") },
                    }, 
                    customer
                )
            );
        }

        // POST: Customers/Upsert
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(CustomersUpsertVM vm)
        {
                if(vm.IsCreate)
            {
                ModelState.Remove("Customer.Id");
            }

            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                if (vm.IsCreate)
                {
                 
                     vm.Customer.Objectives = new List<Objective>();
                        vm.Customer.Objectives.Add(vm.objective);
                   

                    _db.Add(vm.Customer);
                }
                else
                {
                    try
                    {
                        _db.Update(vm.Customer);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CustomerExists(vm.Customer.Id))
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
                    GetCustomersUpsertVM(
                        vm.IsCreate, 
                        new Dictionary<string,SelectList­>(){
                        { "ListForTrainer_Id", new SelectList(_db.Trainers, "Id", "Email") },
                        }, 
                        vm.Customer
                    )
            );
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer customer = await _db.Customers
                                                
.Include(c => c.Trainer)
                                                    .FirstOrDefaultAsync(e => e.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(
                    "Display",
                    new CustomersDisplayVM(
                        false,
                        "Customer",
                        "Are you sure you want to delete this Customer",
                        new List<PageLinks>() { PageLinks.BackToList },
                        customer,
                        "Supprimer"
                    )
            );
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Customer customer = await _db.Customers.FindAsync(id);
            _db.Customers.Remove(customer);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _db.Customers.Any(e => e.Id == id);
        }

        private CustomersUpsertVM GetCustomersUpsertVM(bool isCreate, Dictionary<string,SelectList­> selectLists, Customer customer = null)
        {
            return new CustomersUpsertVM(
                        isCreate,
                        "Customer",
                        "Customer",
                        new List<PageLinks>() { PageLinks.BackToList },
                        isCreate ? "Ajouter" : "Modifier",
                        selectLists,
                        customer
            );
        }
    }
}
