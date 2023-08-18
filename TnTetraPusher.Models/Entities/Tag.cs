using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TnTetraPusher.Models.Entities
{
    public class Tag
    {
        public string SerialNumber { get; set; }

        public DateTime DateTime { get; set; } = DateTime.UtcNow;
    }
}
