using EShop.Data;
using EShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategorieProdusController : Controller
    {
        private ApplicationDbContext _db;

        public CategorieProdusController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            //var data = _db.CategorieProdus.ToList();
            return View(_db.CategorieProdus.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }


        //CREATE POST METHOD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategorieProdus categorieProdus)
        {
            if(ModelState.IsValid)
            {
                _db.CategorieProdus.Add(categorieProdus);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(categorieProdus);
        }

        //GET EDIT ACTION METHOD
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var categorie = _db.CategorieProdus.Find(id);
            if (categorie == null)
            {
                return NotFound();
            }
            return View(categorie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CategorieProdus categorieProdus)
        {
            if (ModelState.IsValid)
            {
                _db.Update(categorieProdus);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(categorieProdus);
        }

        //GET Details ACTION METHOD
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var categorie = _db.CategorieProdus.Find(id);
            if (categorie == null)
            {
                return NotFound();
            }
            return View(categorie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(CategorieProdus categorieProdus)
        {   
                return RedirectToAction(nameof(Index));
        }

        // GET Delete ACTION METHOD

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var categorie = _db.CategorieProdus.Find(id);
            if (categorie == null)
            {
                return NotFound();
            }
            return View(categorie);
        }

        //POST Delete Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, CategorieProdus categorieProdus)
        {
            if(id == null)
            {
                return NotFound();
            }
            if(id!=categorieProdus.CategorieId)
            {
                return NotFound();
            }
            var categorie = _db.CategorieProdus.Find(id);
            if(categorieProdus == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Remove(categorie);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(categorieProdus);
        }
    }
}
