using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace _02_ConsoleApp_DI
{
    class Program
    {
        static readonly IServiceProvider _serviceProvider = ConfigureServices();

        static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(cfg =>
            {
                cfg.AddConsole();
                cfg.AddDebug();
            });

            serviceCollection.AddTransient<Calculadora>();
            return serviceCollection.BuildServiceProvider();
        }

        static void Main(string[] args)
        {
            var logger = _serviceProvider.GetRequiredService<ILogger<Program>>();
            logger.LogInformation("Hello World - Calculadora");
            DisplayInfo();

            string lineArgument = Console.ReadLine();
            do
            {
                args = lineArgument.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (args.Length > 0)
                {
                    string operacao = GetArgumento(args, "operacao");
                    switch (operacao)
                    {
                        case "soma":
                            Soma(args);
                            break;
                        case "subtracao":
                            Substracao(args);
                            break;
                    }
                }
                else
                    DisplayInfo();

                lineArgument = Console.ReadLine();
            }
            while (lineArgument != "q");
        }

        static void Soma(string[] args)
        {
            string arg1 = GetArgumento(args, "operador1");
            decimal valor = decimal.Parse(arg1);

            string arg2 = GetArgumento(args, "operador2");
            decimal valor2 = decimal.Parse(arg2);

            
            var calc = _serviceProvider.GetRequiredService<Calculadora>();
            var resultado = calc.Somar(valor, valor2);

            var logger = _serviceProvider.GetRequiredService<ILogger<Program>>();
            logger.LogInformation("Resultado soma {RESULTADO}", resultado);
        }

        static void Substracao(string[] args)
        {
            string arg1 = GetArgumento(args, "operador1");
            decimal valor = decimal.Parse(arg1);

            string arg2 = GetArgumento(args, "operador2");
            decimal valor2 = decimal.Parse(arg2);

            var calc = _serviceProvider.GetRequiredService<Calculadora>();
            var resultado = calc.Subtrair(valor, valor2);

            var logger = _serviceProvider.GetRequiredService<ILogger<Program>>();
            logger.LogInformation("Resultado subtração {RESULTADO}", resultado);
        }

        static string GetArgumento(string[] args, string nome)
        {
            string nomeArg = $"--{nome}";
            for (int i = 0; i < args.Length; i++)
            {
                if (string.Compare(args[i], nomeArg, true) == 0)
                    return args[i + 1];
            }
            return string.Empty;
        }

        static void DisplayInfo()
        {
            var logger = _serviceProvider.GetRequiredService<ILogger<Program>>();

            logger.LogInformation("Escolha um dos operações.");

            logger.LogInformation("Operacoes disponiveis -");
            logger.LogInformation("1. -> soma");
            logger.LogInformation("1. -> subtracao");

            logger.LogInformation("exemplo");
            logger.LogInformation("--operacao soma --operador1 1.3 --operador2 1.3");
            
            logger.LogInformation("Digite q para sair");
        }
    }
}
