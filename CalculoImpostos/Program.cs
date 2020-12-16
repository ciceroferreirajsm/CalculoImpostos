using System;
using System.Globalization;
using System.Collections.Generic;
using CalculoImpostos.Entities;
namespace CalculoImpostos
{
    class Program
    {
        static void Main(string[] args)
        {

            List<TaxPayer> controller = new List<TaxPayer>();

            Console.Write("Enter the number of tax payers: ");
            int payers = int.Parse(Console.ReadLine());

            for (int i = 1; i <= payers; i++)
            {
                Console.WriteLine("Tax payer #" + i + "data: ");
                Console.Write("Individual or company? (c/i) ");
                char IndOrComp = char.Parse(Console.ReadLine());
                if (IndOrComp == 'i')
                {
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Anual income: ");
                    double anualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    Console.Write("Health expenditures: ");
                    double healthExpenditures = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    controller.Add(new Individual(name, anualIncome,healthExpenditures));
                }
                else if (IndOrComp == 'c')
                {
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Anual income: ");
                    double anualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    Console.Write("Number of employees: ");
                    int employees = int.Parse(Console.ReadLine());
                    controller.Add(new Company(name, anualIncome, employees));
                }
                else
                    Console.WriteLine("Invalid answer! ");
            }
            double sum = 0.0;
            Console.WriteLine();
            Console.WriteLine("TAXES PAID: ");
            foreach (TaxPayer taxPayer in controller)
            {
                Console.WriteLine(taxPayer.Tax().ToString("F2",CultureInfo.InvariantCulture));
            }
            foreach(TaxPayer taxPayer in controller)
            {
                sum += taxPayer.Tax();
            }
            Console.WriteLine("TOTAL TAXES: " + sum);
        }
    }
}
