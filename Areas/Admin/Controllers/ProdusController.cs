using EShop.Data;
using EShop.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProdusController : Controller
    {
        private ApplicationDbContext _db;
        private IHostingEnvironment _he;

        public ProdusController(ApplicationDbContext db, IHostingEnvironment he)
        {
            _db = db;
            _he = he;
        }

        public IActionResult Index()
        {
            return View(_db.Produs.Include(c => c.Categorie).ToList());
        }

        // POST Index action method
        [HttpPost]
        public IActionResult Index(int minim, int maxim)
        {
            var produs = _db.Produs.Include(c => c.Categorie).Where(c => c.Pret >= minim && c.Pret <= maxim).ToList();
            if(minim == null || maxim == null)
            {
                produs = _db.Produs.Include(c => c.Categorie).ToList();
            }
            return View(produs);
        }

        // Get Create method
        public IActionResult Create()
        {
            ViewData["CategorieId"] = new SelectList(_db.CategorieProdus.ToList(),"CategorieId", "DenumireCategorie");
            return View();
        }

        // Post Create method

        [HttpPost]
        public async Task<IActionResult> Create(Produs produs, IFormFile image)
        {
            if(ModelState.IsValid)
            {
                var searchProdus = _db.Produs.FirstOrDefault(c => c.Denumire==produs.Denumire);
                if(searchProdus != null)
                {
                    ViewBag.message = "Exista deja un produs cu aceasta denumire!";
                    ViewData["CategorieId"] = new SelectList(_db.CategorieProdus.ToList(), "CategorieId", "DenumireCategorie");
                    return View(produs);
                }

                if (image != null)
                {
                    var name = Path.Combine(_he.WebRootPath + "/Images", Path.GetFileName(image.FileName));
                    await image.CopyToAsync(new FileStream(name, FileMode.Create));
                    produs.Image = "Images/" + image.FileName;
                }
                if(image==null)
                {
                    produs.Image = "Images/image-not-found.jpg";
                }
                _db.Produs.Add(produs);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produs);
        }
           
        public ActionResult Edit(int? id)
        {
            ViewData["CategorieId"] = new SelectList(_db.CategorieProdus.ToList(), "CategorieId", "DenumireCategorie");
            if(id == null)
            {
                return NotFound();
            }
            var product = _db.Produs.Include(c => c.Categorie).FirstOrDefault(c=>c.Id == id);
            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        //POST Edit Action Method
        [HttpPost]
        public async Task<IActionResult> Edit(Produs produs, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    var name = Path.Combine(_he.WebRootPath + "/Images", Path.GetFileName(image.FileName));
                    await image.CopyToAsync(new FileStream(name, FileMode.Create));
                    produs.Image = "Images/" + image.FileName;
                }
                if (image == null)
                {
                    produs.Image = "Images/image-not-found.jpg";
                }
                _db.Produs.Update(produs);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produs);
        }

        //GET Details Action Method
        public ActionResult Details(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var produs = _db.Produs.Include(c=>c.Categorie).FirstOrDefault(c=>c.Id==id);
            if(produs == null)
            {
                return NotFound();
            }
            return View(produs);
        }

        //GET Delete Action Method

        public ActionResult Delete(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var produs = _db.Produs.Include(c=>c.Categorie).Where(c => c.Id == id).FirstOrDefault(c => c.Id == id);
            if(produs == null)
            {
                return NotFound();
            }
            return View(produs);

        }
        
        // POST Delete Action Method
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var produs = _db.Produs.FirstOrDefault(c => c.Id == id);
            if(produs == null)
            {
                return NotFound();
            }
            _db.Produs.Remove(produs);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
