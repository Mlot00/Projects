using System;

namespace TicTacToe
{
    internal class main
    {
        public static bool Draw(string[,] board)
        {
            int amountOfArray = 0;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == "O" || board[i, j] == "X")
                        amountOfArray++;
                }
            if (amountOfArray == 9)
                return true;
            else 
                return false;

        }
        public static bool Checker(string[,] board)
        {
                for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                    return true; 
                if (board[0, i] == board[1, i] && board[1, i] == board[2, i])
                    return true; 
            }
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
                return true;
            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
                return true;
            return false;
        }

        public static void DrawTicTacToe(string[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                if (i == 0)
                    Console.WriteLine("     |     |     ");
                if (i > 0)
                    Console.Write("\n_____|_____|_____\n     |     |     \n");

                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write("  " + array[i, j] + "  ");

                    if (j < 2)
                        Console.Write("|");
                    if (j == 2 && i == 2)
                        Console.Write("\n     |     |     ");

                }
            }
        }

        public static void Game(string[,] array)
        {
            int counterPlayer = 0;
            int playerNumber = 1;
            string input = "";
            int inputNumber = 0;
            bool isInputCorrect = false;
            bool isCorrectNumber;
            string x_or_o;
            bool isDraw = Draw(array);

            do
            {
                
                Console.WriteLine("if you want end the game please enter letter 'E' or 'e'\n");

                if (counterPlayer % 2 == 1) playerNumber = 2;
                else playerNumber = 1;
                if (playerNumber == 1) x_or_o = "O";
                else x_or_o = "X";
                isCorrectNumber = false;
                DrawTicTacToe(array);
                Console.WriteLine($"\n\nPlayer {playerNumber}: Choose your field!\n");

                do
                { 
                    input = Console.ReadLine();
                    if (input == "E" || input == "e") break;
                    isInputCorrect = int.TryParse(input, out inputNumber);
                    if (!isInputCorrect)
                    {
                        Console.WriteLine("\nPlease enter a number\n");
                    }
                    else
                    {
                        for (int i = 0; i < array.GetLength(0); i++)
                        {
                            for (int j = 0; j < array.GetLength(1); j++)
                            {
                                if (array[i, j] == input)
                                {
                                    array[i, j] = x_or_o;
                                    isCorrectNumber = true;
                                }
                            }
                        }
                        if (!isCorrectNumber)
                        {
                            Console.WriteLine("\nWrong number!\n");
                        }
                    }
                    isDraw = Draw(array);
                } while (!isCorrectNumber);
                if (input == "E" || input == "e") break;
                counterPlayer++;
                Console.Clear();
            } while (!Checker(array) && isDraw == false);
            if (input != "e" && input != "E")
            {
                if (isDraw == true)
                {
                    Console.WriteLine("DRAW!");
                }
                else
                {
                    Console.WriteLine($"Winner is Player {playerNumber}!!!\n");
                    DrawTicTacToe(array);
                }
            }
        }

        static void Main(string[] args)
        {
            string playAgain;
            do
            {
                string[,] array = new string[3, 3]
                {
                    {"1","2","3" },
                    {"4","5","6" },
                    {"7","8","9" }
                };
                Game(array);
                Console.WriteLine("\nEnter letter 'Y' or 'y' to play again \nor anything else to quit");
                playAgain = Console.ReadLine();
                
            } while (playAgain == "Y" || playAgain == "y");
        }
    }
}