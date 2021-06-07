using System;
using System.Collections.Generic;

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
            // Best case: 1 guess (actually got it on the first guess one time)
            // Worst case: infinite guesses (highest I got was 365)
            // Average case: 
            Console.WriteLine("This version guesses a random number between 1 and 100 every time.");
            tries = 1;
            current = r.Next(1, 101);
            response = "";
            while (response != "Match!")
            {
                response = Guess(current, secret);
                if (response != "Match!")
                {
                    current = r.Next(1, 101);
                    tries++;
                }
            }
            Console.WriteLine($"The random guesser took {tries} tries to guess the number {secret}.");

            Console.WriteLine();
            // Elimination 
            // This is similar to the linear search
            // Best case: 1 guess (actually got it on the first guess one time)
            // Worst case: 100 guesses
            // Average case: 50 guesses
            Console.WriteLine("This version guesses a random number between 1 and 100 and doesn't guess numbers more than once.");
            List<int> unguessedNums = new List<int>();
            for (int i = 1; i <= 100; i++)
            {
                unguessedNums.Add(i);
            }

            tries = 1;
            current = r.Next(1, 101);
            
            response = "";
            while (response != "Match!")
            {
                response = Guess(current, secret);
                if (response != "Match!")
                {
                    unguessedNums.Remove(current);
                    int randomIndex = r.Next(1, unguessedNums.Count);
                    current = unguessedNums[randomIndex];
                    tries++;
                }
            }
            Console.WriteLine($"The elimination guesser took {tries} tries to guess the number {secret}.");
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
