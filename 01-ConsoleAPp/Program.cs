using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace _01_ConsoleAPp
{
    class Program
    {
        static readonly Calculadora _calculadora = new Calculadora();

        static void ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(cfg => cfg.AddConsole());
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World - Calculadora");
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

            var resultado = _calculadora.Somar(valor, valor2);
            Console.WriteLine($"Resultado soma {resultado}");
        }

        static void Substracao(string[] args)
        {
            string arg1 = GetArgumento(args, "operador1");
            decimal valor = decimal.Parse(arg1);

            string arg2 = GetArgumento(args, "operador2");
            decimal valor2 = decimal.Parse(arg2);

            var resultado = _calculadora.Subtrair(valor, valor2);
            Console.WriteLine($"Resultado subtração {resultado}");
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
            Console.WriteLine("Escolha um dos operações.");

            Console.WriteLine("Operacoes disponiveis -");
            Console.WriteLine("1. -> soma");
            Console.WriteLine("1. -> subtracao");

            Console.WriteLine("exemplo");
            Console.WriteLine("--operacao soma --operador1 1.3 --operador2 1.3");
            Console.WriteLine();
            Console.WriteLine("Digite q para sair");
        }
    }

    class Calculadora
    {
        public Calculadora()
        {
        }

        public decimal Somar(decimal valor, decimal valor2)
        {
            return valor + valor2;
        }

        public decimal Subtrair(decimal valor, decimal valor2)
        {
            return valor + valor2;
        }
    }
}
