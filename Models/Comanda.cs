using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Models
{
    public class Comanda
    {
        public Comanda()
        {
            DetaliiComanda = new List<DetaliiComanda>();
        }
        public int Id { get; set; }
        [Required]
        public string Nume { get; set; }
        public string NrComanda { get; set; }
        [Required]
        public string NrTelefon { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Adresa { get; set; }
        public DateTime DataComanda { get; set; }
        public virtual List<DetaliiComanda> DetaliiComanda { get; set; }
    }
}
