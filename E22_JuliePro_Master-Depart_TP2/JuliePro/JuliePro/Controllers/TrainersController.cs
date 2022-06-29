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
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace JuliePro.Controllers
{
    public class TrainersController : Controller
    {
        private readonly JulieProDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TrainersController(JulieProDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Trainers
        public async Task<IActionResult> Index()
        {
            return View(
                    new TrainersIndexVM(
                        "Trainers",
                        "Trainers",
                        new List<PageLinks>() { PageLinks.Create },
                        await _db.Trainers
                            .Include(t => t.Speciality)
                            .ToListAsync()
                    )
            );
        }

        // GET: Trainers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Trainer trainer = await _db.Trainers
                                                
.Include(t => t.Speciality)
                                                    .FirstOrDefaultAsync(e => e.Id == id);
            if (trainer == null)
            {
                return NotFound();
            }

            return View(
                    "Display",
                    new TrainersDisplayVM(
                        true,
                        "Trainer",
                        "Trainer",
                        new List<PageLinks>() { PageLinks.BackToList, PageLinks.Edit },
                        trainer
                    )
            );
        }

        // GET: Trainers/Upsert/5
        public async Task<IActionResult> Upsert(int? id)
        {
            bool isCreate = id == null;
            Trainer trainer = null;

            if (!isCreate)
            {
                // Extra stuff for Edit
                trainer = await _db.Trainers.FirstOrDefaultAsync(e => e.Id == id);
                if (trainer == null)
                {
                    return NotFound();
                }
            }

            return View(
                GetTrainersUpsertVM(
                    isCreate, 
                    new Dictionary<string,SelectList­>(){
                        { "ListForSpeciality_Id", new SelectList(_db.Specialities, "Id", "Name") },
                    }, 
                    trainer
                )
            );
        }

        // POST: Trainers/Upsert
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(TrainersUpsertVM vm)
        {
            if(vm.IsCreate)
            {
                ModelState.Remove("Trainer.Id");
            }

            var files = HttpContext.Request.Form.Files; // nouvelle image récupérée
            string webRootPath = _webHostEnvironment.WebRootPath; //Chemin root des images de Trainers
            string upload = webRootPath + "\\" + AppConstants.ImageTrainerPath;
            string filename = Guid.NewGuid().ToString();
            string extension = null; 
            if (files.Count > 0 )
            {
                extension = Path.GetExtension(files[0].FileName);
            }
    
            if (ModelState.IsValid)
            {
              
               
               
                if (vm.IsCreate)
                {
                                   
                    using(var fileStream = new FileStream(Path.Combine(upload,filename+extension),FileMode.Create))
                    {
                        files[0].CopyTo(fileStream); 
                    }
                    vm.Trainer.Photo = filename + extension;
                    _db.Add(vm.Trainer);
                }
                else
                {
                    try
                    {
                        var objFromDb = _db.Trainers.AsNoTracking().FirstOrDefault(u => u.Id == vm.Trainer.Id);

                        if (files.Count > 0)
                        {
                            

                            if (objFromDb.Photo != null)
                            {
                                var oldFile = Path.Combine(upload, objFromDb.Photo);
                                if (System.IO.File.Exists(oldFile))
                                {
                                    System.IO.File.Delete(oldFile);
                                }
                            }

                            using (var fileStream = new FileStream(Path.Combine(upload, filename + extension), FileMode.Create))
                            {
                                files[0].CopyTo(fileStream);
                            }

                            vm.Trainer.Photo = filename + extension;
                        }
                        else
                        {
                            vm.Trainer.Photo = objFromDb.Photo;
                        }

                       _db.Update(vm.Trainer);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TrainerExists(vm.Trainer.Id))
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
                    GetTrainersUpsertVM(
                        vm.IsCreate, 
                        new Dictionary<string,SelectList­>(){
                        { "ListForSpeciality_Id", new SelectList(_db.Specialities, "Id", "Name") },
                        }, 
                        vm.Trainer
                    )
            );
        }

        // GET: Trainers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Trainer trainer = await _db.Trainers
                                                
.Include(t => t.Speciality)
                                                    .FirstOrDefaultAsync(e => e.Id == id);
            if (trainer == null)
            {
                return NotFound();
            }

            return View(
                    "Display",
                    new TrainersDisplayVM(
                        false,
                        "Trainer",
                        "Are you sure you want to delete this Trainer",
                        new List<PageLinks>() { PageLinks.BackToList },
                        trainer,
                        "Supprimer"
                    )
            );
        }

        // POST: Trainers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Trainer trainer = await _db.Trainers.FindAsync(id);
            _db.Trainers.Remove(trainer);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainerExists(int id)
        {
            return _db.Trainers.Any(e => e.Id == id);
        }

        private TrainersUpsertVM GetTrainersUpsertVM(bool isCreate, Dictionary<string,SelectList­> selectLists, Trainer trainer = null)
        {
            return new TrainersUpsertVM(
                        isCreate,
                        "Trainer",
                        "Trainer",
                        new List<PageLinks>() { PageLinks.BackToList },
                        isCreate ? "Ajouter" : "Modifier",
                        selectLists,
                        trainer
            );
        }
    }
}
