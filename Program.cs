namespace Dice_Rolling_Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program will roll dice for you.");
            Console.WriteLine("If you choose to roll 2d6, you can play craps.");

            GameStart(); // Here I'm invoking the method that prompts the user for guesses
        }

        static void GameStart()
        {
            Console.Write("How many sides on the first die? ");
            string firstDie = Console.ReadLine();
            int.TryParse(firstDie, out int firstDieNumber);

            Console.Write("How many sides on the second die? ");
            string secondDie = Console.ReadLine();
            int.TryParse(secondDie, out int secondDieNumber);

            RollTwoDice(firstDieNumber, secondDieNumber);

            PlayAgain(); // Here I'm invoking the method that will invoke GameStart() if the user wants to play again.
        }

        static int RollTwoDice(int firstDieNumber, int secondDieNumber)
        {
            Random dieRoll = new Random();
            int dieResult1 = dieRoll.Next(1, firstDieNumber + 1);
            int dieResult2 = dieRoll.Next(1, secondDieNumber + 1);
            int dieTotal = dieResult1 + dieResult2;

            Console.WriteLine($"You rolled {dieResult1} on the first die and {dieResult2} on the second die for a total of {dieTotal}!");

            if (firstDieNumber == 6 && secondDieNumber == 6) // If the user rolled 2d6...
            {
                DiceCombos(dieTotal); // This figures out if any of the rolls are special.
                WinOrLoseCraps(dieTotal); // Check to see if the user won.
            }
            else
            {
                // If the user rolled something other than 2d6, they just the results.
            }
            
            return dieTotal; // This is just here to end the method.
        }

        static int DiceCombos(int dieTotal) // This gives values to the special dice combinations.
        {
            if (dieTotal == 2)
            {
                Console.WriteLine($"Snake Eyes!");
                return dieTotal;
            }
            if (dieTotal == 3)
            {
                Console.WriteLine($"Ace Deuce!");
                return dieTotal;
            }
            if (dieTotal == 12)
            {
                Console.WriteLine($"Box Cars!");
                return dieTotal;
            }
            if (dieTotal == 7 || dieTotal == 11)
            {
                return dieTotal;
            }
            else
            {
                Console.WriteLine($"There's nothing special about this roll.");
                return dieTotal; // This repetition is to make sure the method ends after each roll is evaluated.
            }
        }

        static int WinOrLoseCraps(int dieTotal) // This declares a winner or loser after evaluaing the die total.
        {
            if (dieTotal == 7 || dieTotal == 11)
            {
                Console.WriteLine("Winner!");
                return dieTotal;
            }
            if (dieTotal == 2 || dieTotal == 3 || dieTotal == 12)
            {
                Console.WriteLine("Loser!");
                return dieTotal;
            }
            else
            {
                return dieTotal; // Again, this just ends the method.
            }
        }

        static void PlayAgain() // This is where I find out if the user wants to play again.
        {
            while (true)
            {
                Console.WriteLine("Would you like to play again?");
                string userResponse = Console.ReadLine();
                if (userResponse == "Y")
                {
                    GameStart(); // This runs the game again.
                }
                else if (userResponse == "N")
                {
                    break; // This ends the program (it's at the end of the code).
                }
                else
                {
                    Console.WriteLine($"Invalid input. Please enter Y or N this time:");
                    continue; // This prompts the user for a new input if they enter something other than Y or N.
                }
            }
        }
    }
}