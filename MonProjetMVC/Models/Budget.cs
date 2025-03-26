using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonProjetMVC.Models
{
    public class Budget
    {
        public int id { get; set; }
        public double valeur { get; set; }
        public Customer? customer { get; set; }  // Ici on garde Customer comme un objet
        public DateTime? date { get; set; }
    }
}