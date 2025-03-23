using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonProjetMVC.Models
{
    public class Budget
    {
        public int Id { get; set; }
        public double Valeur { get; set; }
        public Customer? Customer { get; set; }  // Ici on garde Customer comme un objet
        public DateTime Date { get; set; }
    }
}