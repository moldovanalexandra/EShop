using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Models
{
    public class Produs
    {
        public int Id { get; set; }
        [Required]
        public string Denumire { get; set; }
        public string Brand { get; set; }
        public string Image { get; set; }
        [Required]
        public int Pret { get; set; }
        //public int Stoc { get; set; }
        [Display(Name = "Disponibil")]
        public bool EsteDisponibil { get; set; }
        [Required]
        [Display(Name = "Tip Produs")]
        public int CategorieId { get; set; }
        [ForeignKey("CategorieId")]
        public CategorieProdus Categorie { get; set; }


    }
}
