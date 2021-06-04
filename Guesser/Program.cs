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

            bool keepGuessing = true;
            while (keepGuessing == true)
            {

                
                int guess = GetInteger(secretNumber);
                Console.WriteLine($"Your guess is {guess}.");

                //if (TryGuess(secretNumber, guess) == true)
                //{
                //    Console.WriteLine("You guessed the correct number!");
                //    keepGuessing = false;
                //}
                //else
                //{
                //    Console.WriteLine("That number is not correct.");
                //    guess = GetInteger();
                //}
            }
        }

        public static int GetInteger(int target )
        {
            int output = 0;
            
            try
            {
                Console.WriteLine("Please enter a guess 1-100.");
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
                output = GetInteger(target);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                output = GetInteger(target);
            }

            if (output == target)
            {
                Console.WriteLine("You guessed the correct number!");
                keepGuessing = false;
            }
            else
            {
                Console.WriteLine("That number is not correct.");
                output = GetInteger(target);
            }
            return output;

        }

        //public static bool TryGuess(int target, int guess)
        //{
        //    if(guess == target)
        //    {
        //        return true;
        //    } else
        //    {
        //        return false;
        //    }
        //}

    }
}
