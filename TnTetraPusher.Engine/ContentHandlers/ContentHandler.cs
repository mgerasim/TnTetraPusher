using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TnTetraPusher.Core.Engine;

namespace TnTetraPusher.Engine.ContentHandlers
{
    public class ContentHandler : IContentHandler
    {
        public Task RunAsync(string subject, string content, string sender)
        {
            Console.WriteLine(content);

            return Task.CompletedTask;
        }
    }
}
