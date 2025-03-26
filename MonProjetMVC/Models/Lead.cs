using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonProjetMVC.Models
{
    public class Lead
    {
        public int leadId { get; set; }
        public string? name { get; set; }
        public string? status { get; set; }
        public string? phone { get; set; }
        public string? meetingId { get; set; }
        public bool? googleDrive { get; set; }
        public string? googleDriveFolderId { get; set; }
        public DateTime? createdAt { get; set; } = DateTime.UtcNow;
    }
}