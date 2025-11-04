using Seminar3.Models;
using System;

namespace Seminar3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var processor = new Processor(5);

            processor.OnValueChanged += (bool increased, int value) =>
            {
                Console.WriteLine(increased ? $"Increased\t\t{value}" : $"Decreased\t\t{value}");
            };

            processor.OnProcessingStarted += (int value) =>
            {
                var originalColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Processing started from value {value}");
                Console.ForegroundColor = originalColor;
            };

            processor.OnProcessingFinished += (int steps) =>
            {
                var originalColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Processing finished after {steps} steps");
                Console.ForegroundColor = originalColor;
            };

            processor.Process();

            Console.ReadKey();
        }
    }
}
