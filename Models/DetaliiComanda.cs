using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Models
{
    public class DetaliiComanda
    {
        public int Id { get; set; }
        [Display(Name ="Comanda")]
        public int ComandaId{ get; set; }
        [Display(Name = "Produs")]
        public int ProdusId { get; set; }
        [ForeignKey("ComandaId")]
        public Comanda Comanda { get; set; }
        [ForeignKey("ProdusId")]
        public Produs Produs { get; set; }
    }
}
