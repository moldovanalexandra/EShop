using EShop.Data;
using EShop.Models;
using EShop.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class OrderController : Controller
    {
        private ApplicationDbContext _db;

        public OrderController(ApplicationDbContext db)
        {
            _db = db;
        }

        //GET Checkout action method
        public IActionResult Checkout()
        {
            return View();
        }

        //POST Checkout actio method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult>Checkout(Comanda comanda)
        {
            List<Produs> produse =HttpContext.Session.Get<List<Produs>>("produse");
            if (produse != null)
            {
                foreach (var produs in produse)
                {
                    DetaliiComanda detalii = new DetaliiComanda();
                    detalii.ProdusId= produs.Id; 
                    detalii.ComandaId = comanda.Id;
                    comanda.DetaliiComanda.Add(detalii);
                }
            }

            comanda.NrComanda = GetOrderNo();
            comanda.DataComanda = DateTime.Now.Date;
            
            _db.Comenzi.Add(comanda);
            await _db.SaveChangesAsync();
            HttpContext.Session.Set("produse", new List<Produs>());
            //return View();
            return RedirectToAction("Index", "Home"); 
        }

        public string GetOrderNo()
        {
            int rowCount = _db.Comenzi.ToList().Count() + 1;
            return rowCount.ToString("000");
        }

    }
}
