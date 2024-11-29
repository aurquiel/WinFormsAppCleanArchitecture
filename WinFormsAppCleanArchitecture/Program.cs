using ApplicationBusiness;
using Data;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;

namespace WinFormsAppCleanArchitecture
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //ApplicationConfiguration.Initialize();
            //Application.Run(new FormMain());

            var mainForm = serviceProvider.GetRequiredService<FormMain>();
            Application.Run(mainForm);
        }
        public static void ConfigureServices(ServiceCollection services)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DB")));

            services.AddTransient<AddBrand>();
            services.AddTransient<EditBrand>();
            services.AddTransient<AddBeer>();
            services.AddTransient<EditBeer>();
            services.AddTransient<IRepository<Brand>, BrandRepository>();
            services.AddTransient<IRepository<Beer>, BeerRepository>();
            
            services.AddTransient<FormMain>();
            services.AddTransient<FormBrand>();
            services.AddTransient<FormNewEditBrand>();
            services.AddTransient<FormBeer>();
            services.AddTransient<FormNewEditBeer>();
        }

    }
}