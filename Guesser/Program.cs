using System;

namespace Guesser
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int secret = r.Next(1, 101);
            int tries = 0;
            Console.WriteLine("This version uses user input");
            string response = "";
            while (response != "Match!")
            {
                int num = GetUserGuess();

                response = Guess(num, secret);
                Console.WriteLine(response);
                Console.WriteLine();
                tries++;
            }

            Console.WriteLine($"it took you {tries} to guess {secret}");

            Console.WriteLine();
            // Brute force
            // Best case: 1 guess
            // Worst case: 100 guesses
            // Average case: 50 guesses would be the average number over many tries

            Console.WriteLine("This version guesses starting at one and ticks up to 100");
            int current = 1;
            response = "";
            while (response != "Match!")
            {
                response = Guess(current, secret);
                if (response != "Match!")
                {
                    current++;
                }
            }

            Console.WriteLine($"The linear Guesser took {current} times to guess the number {secret} ");

            Console.WriteLine();
            // Random 
            // Best case: 1 guess
            // Worst case: infinite guesses
            // Average case: 
            Console.WriteLine("This version guesses a random number between 1 and 100 every time.");
            current = 0;
            response = "";
            while (response != "Match!")
            {
                response = Guess(current, secret);
                if (response != "Match!")
                {

                }
            }
        }

        public static int GetUserGuess()
        {
            while (true)
            {
                Console.WriteLine("Please guess a number between 1 and 100 and I will tell how close you are");
                try
                {
                    int num = int.Parse(Console.ReadLine());
                    if (num < 1)
                    {
                        throw new Exception("That number is too small, please input a number between 1 and 100");
                    }
                    else if (num > 100)
                    {
                        throw new Exception("That number is too large, please inptu a number between 1 and 100");
                    }
                    return num;

                }
                catch (FormatException)
                {
                    Console.WriteLine("That was not a valid number please try again");
                    continue;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
        }

        public static string Guess(int guess, int secretNum)
        {
            if (guess == secretNum)
            {
                return "Match!";
            }
            int diff = guess - secretNum;
            diff = Math.Abs(diff);

            if (guess > secretNum)
            {
                if (diff > 10)
                {
                    return "Way too high!";
                }
                else
                {
                    return "too high!";
                }
            }
            else
            {
                if (diff > 10)
                {
                    return "Way too low!";
                }
                else
                {
                    return "too low!";
                }
            }
        }
    }
}
