using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonProjetMVC.Models
{
    public class Ticket
    {
        public int ticketId { get; set; }

        public string? subject { get; set; }

        public string? description { get; set; }

        public string? status { get; set; }

        public string? priority { get; set; }
        public DateTime createdAt { get; set; } = DateTime.UtcNow;
    }
}