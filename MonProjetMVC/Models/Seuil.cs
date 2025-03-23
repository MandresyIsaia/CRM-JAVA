using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonProjetMVC.Models
{
    public class Seuil
    {
        public int seuilId { get; set; }
        public decimal taux { get; set; }
        public DateTime? dateSeuil { get; set; }
    }
}