using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MobileAvailability.Models
{
    public class Market
    {
        public int Id { get; set; }
        [Required]
        public string Naziv { get; set; }
    }
}
