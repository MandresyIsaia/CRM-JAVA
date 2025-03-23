using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonProjetMVC.Models
{
    public class Customer
    {
        public int customerId { get; set; }

        public string? name { get; set; }

        public string? email { get; set; }

        public string? position { get; set; }

        public string? phone { get; set; }

        public string? address { get; set; }

        public string? city { get; set; }

        public string? state { get; set; }

        public string? country { get; set; }

        public string? description { get; set; }

        public string? twitter { get; set; }

        public string? facebook { get; set; }

        public string? youtube { get; set; }
        public DateTime createdAt { get; set; }
    }
}