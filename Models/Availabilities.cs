using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MobileAvailability.Models
{
    public class Availabilities
    {
        public int Id { get; set; }

        public int ProizvodjacId { get; set; }
        public Producer Proizvodjac { get; set; }

        [Required]
        public string Tip { get; set; }

        public int TrgovinaId { get; set; }
        public Market Trgovina { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PredajaOglasa { get; set; }

        [Required]
        public float Cijena { get; set; }

        [Required]
        public bool Dostupnost { get; set; }

        [Required]
        public String Kontakt { get; set; }
    }
}
