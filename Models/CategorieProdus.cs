using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Models
{
    public class CategorieProdus
    {
        [Key]
        public int CategorieId { set; get; }
        [Required]
        [Display (Name = "Categorie Produs")]
        public string DenumireCategorie{ set; get; }

    }
}
