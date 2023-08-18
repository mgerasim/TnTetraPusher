using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TnTetraPusher.Core.Engine;
using TnTetraPusher.Engine.ContentHandlers;
using TnTetraPusher.Engine.EmailReaders;

namespace TnTetraPusher.Engine
{
    /// <summary>
    /// Расширение для конфигурации издателей и подписчиков.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Регистрирует издателя и подписчиков.
        /// </summary>
        /// <param name="services">Колекция сервисов.</param>
        public static IServiceCollection AddEngine(this IServiceCollection services)
        {
            services.AddScoped<IEmailReader, ExchangeEmailReader>();

            services.AddScoped<IContentHandler, ContentHandler>();

            return services;
        }
    }
}
