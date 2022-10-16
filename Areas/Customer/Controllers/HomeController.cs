using EShop.Data;
using EShop.Models;
using EShop.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace EShop.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index(int? page)
        {
            return View(_db.Produs.Include(c => c.Categorie).ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //GET product Detail action
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var produs = _db.Produs.Include(c => c.Categorie).FirstOrDefault(c => c.Id == id);

            if (produs == null)
            {
                return NotFound();
            }
            return View(produs);
        }

        // POST product detail action method
        [HttpPost]
        [ActionName("Detail")]
        public ActionResult ProductDetail(int? id)
        {
            List<Produs> produse = new List<Produs>();
            if (id == null)
            {
                return NotFound();
            }
            var produs = _db.Produs.Include(c => c.Categorie).FirstOrDefault(c => c.Id == id);

            if (produs == null)
            {
                return NotFound();
            }
            produse = HttpContext.Session.Get<List<Produs>>("produse");
            if (produse == null)
            {
                produse = new List<Produs>();
            }
            produse.Add(produs);
            HttpContext.Session.Set("produse", produse);
            return RedirectToAction(nameof(Index));
        }


        ////POST product detail acation method
        //[HttpPost]
        //[ActionName("Detail")]
        //public ActionResult ProdusDetail(int? id)
        //{
        //    List<Produs> products = new List<Produs>();
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var product = _db.Produs.Include(c => c.Categorie).FirstOrDefault(c => c.Id == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    products = HttpContext.Session.Get<List<Produs>>("produse");
        //    if (products == null)
        //    {
        //        products = new List<Produs>();
        //    }
        //    products.Add(product);
        //    HttpContext.Session.Set("products", products);
        //    return RedirectToAction(nameof(Index));
        //}

        //GET Remove action method
        [ActionName("Remove")]
        public IActionResult RemoveToCart(int? id)
        {
            List<Produs> produse = HttpContext.Session.Get<List<Produs>>("produse");
            if (produse != null)
            {
                var produs = produse.FirstOrDefault(c => c.Id == id);
                if (produs != null)
                {
                    produse.Remove(produs);
                    HttpContext.Session.Set("produse", produse);
                }
            }
            return RedirectToAction(nameof(Cos));
        }

        [HttpPost]
        public IActionResult Remove(int? id)
        {
            List<Produs> produse = HttpContext.Session.Get<List<Produs>>("produse");
            if (produse != null)
            {
                var produs = produse.FirstOrDefault(c => c.Id == id);
                if (produs != null)
                {
                    produse.Remove(produs);
                    HttpContext.Session.Set("produse", produse);
                }
            }
            return RedirectToAction(nameof(Cos));
        }


        public IActionResult Cos()
        {
            List<Produs> produse = HttpContext.Session.Get<List<Produs>>("produse");
            if (produse == null)
            {
                produse = new List<Produs>();
            }
            return View(produse);
        }

    }
}
