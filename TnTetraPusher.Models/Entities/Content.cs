using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TnTetraPusher.Models.Entities
{
    /// <summary>
    /// Контент присылаемых данных
    /// </summary>
    public class Content
    {
        /// <summary>
        /// Версия кодирования данных
        /// </summary>
        public int Version { get; set; } = 1;

        /// <summary>
        /// Кодированные данные
        /// </summary>
        public string Body { get; set; } = String.Empty;
    }
}
