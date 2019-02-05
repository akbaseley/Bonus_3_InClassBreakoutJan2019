using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonus_3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool userContinue = true;
            while (userContinue)
            {
                int computerNumber = GetNumber(0, 100);

                string message = "Give me a number between 0 and 100!";
                int count = 1;

                int userNumber = GetNumber(message, 0, 100);
                int difference = DoSubtraction(userNumber, computerNumber);

                while (difference != 0)
                {
                    count++;
                    message = EvaluteNumber(userNumber);
                    userNumber = GetNumber(message, 0, 100);
                    difference = DoSubtraction(userNumber, computerNumber);
                }

                ReturnFinalMessage(count);
                userContinue = ContinueProgram("Would you like to play again? y/n");
            }
        }

        public static void ReturnFinalMessage(int number)
        {
            if (number == 1)
            {
                Console.WriteLine("Wow! Yay! You did it! You guessed it in 1 try!");
            }
            else
            {
                Console.WriteLine($"Good job! You guessed the number in {number} tries!");
            }
        }
        public static string EvaluteNumber(int number)
        {
            string message;
            if (number > 0)
            {
                if (number >= 10)
                {
                    message = "Oh, bless your heart. That's too high.";
                }
                else
                {
                    message = "Too high.";
                }
            }
            else
            {
                if (number <= -10)
                {
                    message = "Oh, bless your heart. That's too low.";
                }
                else
                {
                    message = "Too low";
                }
            }
            return message;
        }

        public static int DoSubtraction(int number1, int number2)
        {
            return number1 - number2;
        }

        public static int GetNumber(int min, int max)
        {
            Random r = new Random();
            return r.Next(min, max);
        }

        public static int GetNumber(string message, int min, int max)
        {
            int userNumber = min - 1;

            if (userNumber < min || userNumber > max)
            {
                Console.WriteLine(message);
                while (!int.TryParse(Console.ReadLine(), out userNumber)) ;
            }

            return userNumber;
        }

        public static bool ContinueProgram(string message)
        {
            Console.WriteLine(message);
            string userInput = Console.ReadLine().ToLower();

            if (userInput == "y")
            {
                return true;
            }
            else if (userInput == "n")
            {
                return false;
            }
            else
            {
                return ContinueProgram("Not a valid response! " + message);
            }
        }
    }
}
