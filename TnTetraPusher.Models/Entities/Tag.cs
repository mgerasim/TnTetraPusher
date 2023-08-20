using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace TnTetraPusher.Models.Entities
{
    public class Tag
    {
        public static Tag FromBase64(string s)
        {
            var tagJson = Content.Base64Decode(s);

            var tag = Newtonsoft.Json.JsonConvert.DeserializeObject<Tag>(tagJson);

            return tag;
        }

        public string SerialNumber { get; set; }

        public DateTime DateTime { get; set; } = DateTime.UtcNow;
    }
}
