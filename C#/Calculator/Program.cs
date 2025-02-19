using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool keepRunning = true;

            Console.WriteLine("Basic C# Calculator");
            Console.WriteLine("Choose an operation:");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Subtract");
            Console.WriteLine("3. Multiply");
            Console.WriteLine("4. Divide");
            Console.WriteLine("5. Exit");

            while (keepRunning)
            {
                Console.Write("\nSelect an option (1/2/3/4/5): ");
                string userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        PerformOperation("Add");
                        break;

                    case "2":
                        PerformOperation("Subtract");
                        break;

                    case "3":
                        PerformOperation("Multiply");
                        break;

                    case "4":
                        PerformOperation("Divide");
                        break;

                    case "5":
                        Console.WriteLine("Exiting calculator...");
                        keepRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option, please choose a valid operation.");
                        break;
                }
            }
        }

        static void PerformOperation(string operation)
        {
            double num1, num2, result = 0;
            bool validInput;

            Console.Write("\nEnter the first number: ");
            validInput = double.TryParse(Console.ReadLine(), out num1);

            if (!validInput)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }

            Console.Write("Enter the second number: ");
            validInput = double.TryParse(Console.ReadLine(), out num2);

            if (!validInput)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }

            switch (operation)
            {
                case "Add":
                    result = num1 + num2;
                    break;

                case "Subtract":
                    result = num1 - num2;
                    break;

                case "Multiply":
                    result = num1 * num2;
                    break;

                case "Divide":
                    if (num2 == 0)
                    {
                        Console.WriteLine("Error: Cannot divide by zero.");
                        return;
                    }
                    result = num1 / num2;
                    break;
            }

            Console.WriteLine($"\nResult: {result}\n");
        }
    }
}
