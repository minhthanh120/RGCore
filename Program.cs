// See https://aka.ms/new-console-template for more information
using Abstraction.Interfaces;
using Implementation.CoreServices;
using Microsoft.Extensions.DependencyInjection;

ServiceCollection services = new ServiceCollection();
services.AddScoped<ICoreService, ServiceA>();

var serviceProvider = services.BuildServiceProvider();
var currentService = serviceProvider.GetService<ICoreService>();

currentService.Run();
Console.WriteLine("Hello, World!");
