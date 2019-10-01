using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPF.Calculadora.ViewModels;

namespace WPF.Calculadora
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //inversao de controle
        internal static IServiceProvider ServiceProvider { get; private set; }


        internal static IConfiguration Configuration { get; private set; }


        public App()
        {
            Configuration = LoadConfiguration();

            var services = new ServiceCollection();
            ConfigureServices(services);

            ServiceProvider = services.BuildServiceProvider();
        }

        IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .AddUserSecrets(typeof(App).Assembly);

            return builder.Build();
        }

        void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<MainViewModel>();
        }
    }
}
