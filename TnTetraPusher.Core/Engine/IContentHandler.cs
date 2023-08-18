using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TnTetraPusher.Core.Engine
{
    public interface IContentHandler
    {
        public Task RunAsync(string subject, string content, string sender);
    }
}
