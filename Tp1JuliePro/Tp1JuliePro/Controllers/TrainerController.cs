using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tp1JuliePro_DataAccess.Data;
using Tp1JuliePro_Models;

namespace Tp1JuliePro.Controllers
{
    public class TrainerController : Controller
    {

        private readonly JulieProDbContext _db;
        public TrainerController(JulieProDbContext db)
        {
            _db = db;
        }

        // GET: TrainerController
        public ActionResult Index()
        {
            IEnumerable<Trainer> objListe = _db.Trainer;
            return View(objListe);
        }

        // GET: TrainerController/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var trainer = _db.Trainer.FirstOrDefault(m => m.Id == id);
            if (trainer == null)
            {
                return NotFound();
            }

            return View(trainer);
        }

        // GET: TrainerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrainerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Trainer collection)
        {
            if (ModelState.IsValid)
            {
                _db.Add(collection);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(collection);
        }

        // GET: TrainerController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainer = _db.Trainer.Find(id);
            if (trainer == null)
            {
                return NotFound();
            }

            return View(trainer);
        }

        // POST: TrainerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Trainer collection)
        {
            if (id != collection.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Update(collection);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(collection);
        }

        // GET: TrainerController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainer = _db.Trainer.Find(id);
            if (trainer == null)
            {
                return NotFound();
            }

            return View(trainer);
        }

        // POST: TrainerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Trainer collection)
        {
            _db.Remove(collection);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
