﻿using System;
using System.Text;


namespace Hangman
{
    class Program
    {
        static String[] secretWords = new String[] {"banana", "star", "dough"};
        static int guessesLeft; 
        static bool keepAlive;
        static StringBuilder guessedLetters;

        static String secretWord;
        static char[] theWord;

        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Hangman!");
            StartGame();

            while (keepAlive)
            {
                Console.WriteLine("You have " + guessesLeft + " guesses left.");
                Console.WriteLine("you have guessed the following letters: " + guessedLetters);
                Console.WriteLine(theWord);
                Console.WriteLine("Press W to guess a word, L to guess a letter or Q to quit:");
                String choice = Console.ReadLine();
                String action = choice.ToUpper();
                switch (action)
                {
                    case "W":
                        Console.WriteLine("Which word do you think is right?");
                        String guessedWord = Console.ReadLine();
                        GuessWord(guessedWord.ToLower());
                        break;
                    case "L":
                        Console.WriteLine("Which letter would you like to guess for?");
                        String guessedLetter = Console.ReadLine();
                        char letter = guessedLetter[0];
                        GuessLetter(letter);
                        break;
                    case "Q":                      
                        Console.WriteLine("Thank you for playing!");
                        keepAlive = false;
                        break;
                    default:
                        Console.WriteLine("Not a valid option.");
                        break;
                }
                if (guessesLeft == 0)
                {
                    Console.WriteLine("You have no more guesses! Game over.");
                    EndOfGame();
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void StartGame()
        {
            keepAlive = true;
            guessesLeft = 10;
            guessedLetters = new StringBuilder();
            Random rand = new Random();
            int wordIndex = rand.Next(0, secretWords.Length);
            secretWord = secretWords[wordIndex];
            theWord = new char[secretWord.Length];
            for (int i = 0; i < theWord.Length; i++)
            {
                theWord[i] = '_';

            }
        }

            static void GuessWord(String word)
        {
            guessesLeft--;
            if (word.Equals(secretWord))
            {
                Console.WriteLine("Congratulations! You have guessed the right word.");
                EndOfGame();
            }
            else
            {
                Console.WriteLine("Wrong word!");
            }
        }

        static void GuessLetter(char letter)
      {
            bool isInWord = false;
            String letters = guessedLetters.ToString();
            if (letters.Contains(letter))
            {
                Console.WriteLine("You have already made that guess!");
            }
            else
            {
                guessesLeft--;
                guessedLetters.Append(letter);
                for (int i = 0; i < theWord.Length; i++)
                {
                    if (secretWord[i].Equals(letter))
                    {
                        theWord[i] = letter;
                        isInWord = true;

                    }
                }
            }
            if (isInWord)
            {
                Console.WriteLine("Yay! The letter " + letter + " is in the word.");
            }
            else
            {
                Console.WriteLine("Sorry, the letter " + letter + " is not in the word.");
            }
            if(StringEqualsCharArray(secretWord, theWord))
            {
                Console.Write("Congratualtions! You have guessed all the right characters.\n" +
                    "The word is " + secretWord + ".\n");
                EndOfGame();
            }
        }

        static bool StringEqualsCharArray(String str, char[] chars)
        {
            if(str.Length == chars.Length)
            {
                for(int i = 0; i < str.Length; i++)
                {
                    if (str[i] != chars[i]) return false;
                }
                return true;
            }
            return false;
        }

        static void EndOfGame()
        {
            Console.WriteLine("Would you like to play again? Y/N");
            String answer = Console.ReadLine();
            String ans = answer.ToUpper();
            if (ans.Equals("N"))
            {
                Console.WriteLine("Goodbye, see you later!");
                keepAlive = false;
            }
            else if (ans.Equals("Y"))
            {

                Console.WriteLine("Go ahead!");
                StartGame();
            }
            else
            {
                Console.WriteLine("Please choose Y or N");
                EndOfGame();
            }

        }

    }
}
