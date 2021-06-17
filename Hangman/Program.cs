using System;
using System.Text;


namespace Hangman
{
    public class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Hangman!");
            HangmanGame newGame = new HangmanGame();
            newGame.InitGame();
            newGame.PlayGame();
        }

    }
}
