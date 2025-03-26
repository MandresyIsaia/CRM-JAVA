using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonProjetMVC.Models
{
    public class Depense
    {
        public int depenseId { get; set; }
        public decimal valeurDepense { get; set; }
        public DateTime? dateDepense { get; set; }
        public int etat { get; set; }
        public Lead? lead { get; set; }
        public Ticket? ticket { get; set; }
    }
}