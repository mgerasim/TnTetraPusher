using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TnTetraPusher.Models.Entities
{
    public class Device
    {
        public string SerialNumber { get; set; }

        public string Title { get; set; }

        public string SenderEmail { get; set; }

        public DateTime ScanedAt { get; set; }

        public DateTime RecivedAt { get; set; }
            
    }
}
