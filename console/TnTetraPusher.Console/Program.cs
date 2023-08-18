// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using TnTetraPusher.Configuration;
using TnTetraPusher.Core.Engine;

var serviceProvider = new ServiceCollection().ConfigureServiceCollection()
    .BuildServiceProvider();

await serviceProvider.GetRequiredService<IEmailReader>()
            .RunAsync();

Console.WriteLine("Hello, World!");
