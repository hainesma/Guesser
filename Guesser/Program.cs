using System;

namespace Guesser
{
    class Program
    {
        static void Main(string[] args)
        {
            // Generate random number
            Random rand = new Random();
            int secretNumber = rand.Next(1, 101);
            Console.WriteLine(secretNumber);

            int guess = GetInteger();

        }

        public static int GetInteger()
        {
            int output = 0;
            
            try
            {
                string input = Console.ReadLine();
                output = int.Parse(input);
                if (output < 1 || output > 100)
                {
                    throw new Exception("Your guess must be between 1 and 100.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("That was not a number.");
                output = GetInteger();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                output = GetInteger();
            }
            return output;

        }

    }
}
