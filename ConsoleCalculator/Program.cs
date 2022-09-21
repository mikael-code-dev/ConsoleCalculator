using System;

namespace ConsoleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Start();
            RunCalculator();
            End();
        }

        private static void RunCalculator()
        {
            ConsoleKey userSelection;
            
            while (true)
            {
                userSelection = RunMenu();
                Console.Clear();
                switch (userSelection)
                {
                    case ConsoleKey.A: Addition(); break;
                    case ConsoleKey.D: Division();  break;
                    case ConsoleKey.M: Multiplication(); break;
                    case ConsoleKey.S: Subtraction(); break;
                    case ConsoleKey.E: return;
                    default: ErrorMessage(" Something went wrong, try again!"); break;
                }

                Console.WriteLine("\n Press any key to continue!");
                Console.ReadKey();
            }
        }

        private static void Subtraction()
        {
            var nums = GetUserInput(" Enter the numbers. Each number separated with a space");
            if (nums.Count <= 1)
            {
                Console.WriteLine(" You must enter at least two numbers. Try again!");
                Subtraction();
                return;
            }

            double result = 0;
            
            result += nums[0];
            for (int i = 1; i < nums.Count; i++)
            {
                result -= nums[i];
            }

            Console.Clear();

            for (int i = 0; i < nums.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write($" {nums[i]}");
                }
                else
                {
                    Console.Write(nums[i] < 0 ? $" - ({nums[i]})" : $" - {nums[i]}");
                }
            }

            Console.WriteLine($" = {result}");
        }

        private static void Multiplication()
        {
            var nums = GetUserInput(" Enter the numbers. Each number separated with a space");
            if (nums.Count <= 1)
            {
                ErrorMessage(" You must enter at least two numbers. Try again!");
                Multiplication();
                return;
            }

            double result = 0;

            result += nums[0];
            for (int i = 1; i < nums.Count; i++)
            {
                result *= nums[i];
            }

            Console.Clear();

            for (int i = 0; i < nums.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write($" {nums[i]}");
                }
                else
                {
                    Console.Write(nums[i] < 0 ? $" * ({nums[i]})" : $" * {nums[i]}");
                }
            }

            Console.WriteLine($" = {result}");
        }

        private static void Division()
        {
            var nums = GetUserInput(" Enter the number to divide, than the denominator. Separate the numbers with a space");
            if (nums.Count != 2)
            {
                ErrorMessage(" You must enter two numbers. Try again!");
                Division();
                return;
            }
            
            if (nums[1] == 0)
            {
                ErrorMessage(" You cant divide with zero. Try again!");
                Division();
                return;
            }

            double result = nums[0] / nums[1];

            Console.Clear();
            Console.WriteLine($" {nums[0]} / {nums[1]} = {result}");
        }

        private static void Addition()
        {
            var nums = GetUserInput(" Enter the numbers. Each number separated with a space");
            if(nums.Count <= 1)
            {
                ErrorMessage(" You must enter at least two numbers. Try again!");
                Addition();
                return;
            }

            double result = 0;

            foreach (var num in nums)
            {
                result += num;
            }

            Console.Clear();

            for (int i = 0; i < nums.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write($" {nums[i]}");
                }
                else
                {
                    Console.Write(nums[i] < 0 ? $" + ({nums[i]})" : $" + {nums[i]}");
                }
            }

            Console.WriteLine($" = {result}");
        }

        private static List<double> GetUserInput(string prompt)
        {
            var nums = new List<double>();

            Console.WriteLine(prompt);
            Console.Write(" :> ");

            while (true)
            {
                try
                {
                    nums = Console.ReadLine().Split(' ').Select(double.Parse).ToList();
                    break;
                }
                catch
                {
                    ErrorMessage(" You must enter numbers. Try again!");
                    Console.Write(" :> ");
                }
            }

            return nums;
        }

        private static void ErrorMessage(string prompt)
        {
            Console.WriteLine(prompt);
        }

        private static ConsoleKey RunMenu()
        {
            Console.Clear();

            Console.WriteLine(" A.  Addition");
            Console.WriteLine(" S.  Subtracton");
            Console.WriteLine(" M.  Multiplication");
            Console.WriteLine(" D.  Division");
            Console.WriteLine(" E.  End Program");

            Console.WriteLine("\n Select from menu");
            Console.Write(" :> ");
            return Console.ReadKey().Key;
        }


        // **********************************************************
        // **********************************************************

        private static void Start()
        {
            Console.WriteLine(" ********  CALCULATOR  ******** ");
            Console.WriteLine();
            Console.WriteLine(" **  +  **  -  **  x  **  /  ** ");
            Console.WriteLine("\n Use the menu and have fun");

            Thread.Sleep(4000);
            Console.Clear();
        }

        private static void End()
        {
            Console.WriteLine("\n\n Thanks for using the calculator! Hit any key to close the window\n\n");
        }
    }
}