using System;

namespace Hw1.Exercise3
{
    /// <summary>
    /// 'Rock-Paper-Scissors' game application core.
    /// </summary>
    public class GameApplication
    {
        /// <summary>
        /// Runs game application.
        /// Prints game results.
        /// </summary>
        /// <param name="args">
        /// Arguments - player's shape.
        /// args[0] - shape [Rock, Paper, Scissors].
        /// </param>
        /// <returns>Returns : 
        /// <c>0</c> in case of success; 
        /// <c>-1</c> in case of invalid <paramref name="args"/>.
        /// </returns>
        public int Run(string[] args)
        {

            if (args is not null)
            {
                var shape = args[0].ToLower();
                string[] arrayComputerShape = { "Rock", "Paper", "Scissors" };
                var indexOfShape = new Random().Next(arrayComputerShape.Length);
                var computerShape = arrayComputerShape[indexOfShape];
                switch (shape)
                {
                    case "rock":
                        switch (computerShape)
                        {
                            case "Rock":
                                Console.WriteLine($" Player = Rock:Draw");
                                Console.WriteLine($" Computer = {computerShape}:Draw");
                                break;
                            case "Paper":
                                Console.WriteLine($" Player = Rock:Lose");
                                Console.WriteLine($" Computer = {computerShape}:Win");
                                break;
                            case "Scissors":
                                Console.WriteLine($" Player = Rock:Win");
                                Console.WriteLine($" Computer = {computerShape}:Lose");
                                break;
                        }
                        return 0;

                    case "paper":
                        switch (computerShape)
                        {
                            case "Rock":
                                Console.WriteLine($" Player = Paper:Win");
                                Console.WriteLine($" Computer = {computerShape}:Lose");
                                break;
                            case "Paper":
                                Console.WriteLine($" Player = Paper:Draw");
                                Console.WriteLine($" Computer = {computerShape}:Draw");
                                break;
                            case "Scissors":
                                Console.WriteLine($" Player = Paper:Lose");
                                Console.WriteLine($" Computer = {computerShape}:Win");
                                break;

                        }
                        return 0;

                    case "scissors":
                        switch (computerShape)
                        {
                            case "Rock":
                                Console.WriteLine($" Player = Scissors:Lose");
                                Console.WriteLine($" Computer = {computerShape}:Win");
                                break;
                            case "Paper":
                                Console.WriteLine($" Player = Scissors:Win");
                                Console.WriteLine($" Computer = {computerShape}:Lose");
                                break;
                            case "Scissors":
                                Console.WriteLine($" Player = Scissors:Draw");
                                Console.WriteLine($" Computer = {computerShape}:Draw");
                                break;

                        }
                        return 0;
                }
            }
            return -1;
        }
    }
}
