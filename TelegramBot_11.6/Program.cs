﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text;
using Telegram.Bot;
using TelegramBot_11._6.Configuration;
using TelegramBot_11._6.Controllers;
using TelegramBot_11._6.Services;

namespace TelegramBot_11._6
{
    internal class Program
    {
        public static async Task Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            var host = new HostBuilder()
                 .ConfigureServices((hostContext, services) => ConfigureServices(services))
                 .UseConsoleLifetime()
                 .Build();

            Console.WriteLine("Сервис запущен!");
            await host.RunAsync();
            Console.WriteLine("Сервис остановлен!");


        }

        static void ConfigureServices(IServiceCollection services)
        {
            AppSettings appSettings = BuildAppSettings();
            services.AddSingleton(BuildAppSettings());

            services.AddSingleton<IStorage, MemoryStorage>();

            services.AddTransient<DefaultMessageController>();
            services.AddTransient<TextMessageController>();
            services.AddTransient<InlineKeyboardController>();

            services.AddSingleton<ITelegramBotClient>(provider => new TelegramBotClient(appSettings.BotToken));
            services.AddHostedService<Bot>();
        }

        static AppSettings BuildAppSettings()
        {
            return new AppSettings
            {
                BotToken = "",
            };
        }
    }
}
