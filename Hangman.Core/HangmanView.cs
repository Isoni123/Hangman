using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Core
{
    public class HangmanView
    {
        private IConsole theConsole;

        public HangmanView(IConsole c)
        //        public HangmanView(HangmanModel hangmanModel, HangmanController controller, IConsole c)
        {
            //_hangmanModel = hangmanModel;
            //_theController = controller;
            theConsole = c;
        }

        public void ShowWelcome(int _numberOfLives)
        {
            theConsole.WriteLine("Welcome to Hangman you have to guess my word! You can guess one letter of the alphabet at a time. Be careful, you only have 3 incorrect guesses and you loose!");
            ShowNumberOfLives(_numberOfLives);
        }

        public void ShowMaskedWord(string _maskedHangmanWord)
        {
            theConsole.WriteLine($"Here is the Masked Word: {_maskedHangmanWord}");
        }

        public void ShowNumberOfLives(int _numberOfLives)
        {
            theConsole.WriteLine($"You have {_numberOfLives} lives");
        }

        public void ShowLossOfLifeIncorrectGuess(int _numberOfLives)
        {
            theConsole.Write($"Sorry you have guessed incorrectly you loose a life");
            ShowNumberOfLives(_numberOfLives);
        }

        public void YouWon()
        {
            theConsole.WriteLine("Congratulations, you have won!");
        }

        public void YouLost()
        {
            theConsole.WriteLine("Sorry, you lost the game!");
        }


        public char AskforChar()
        {
            bool isInputEmpty = false;
            bool isInputAValidLetter = false;
            char firstCharOfInput = '\0';

            string input;
            do
            {
                theConsole.Write("Enter your Letter here:");
                input = theConsole.ReadLine().ToLower();
               
                isInputEmpty = (input.Length == 0);

                if (isInputEmpty)

                {
                    theConsole.Write("Sorry, try again Enter your Letter here:");
                }
                else
                {
                    firstCharOfInput = input[0];
                    isInputAValidLetter = (firstCharOfInput >= 'a' && firstCharOfInput <= 'z');
                    if (!isInputAValidLetter)
                    {
                        theConsole.Write("Sorry, I need a letter");
                    }
                }
            } while (!isInputAValidLetter);

            return firstCharOfInput;
            

        }


        public void GameFinished()
        {
            theConsole.WriteLine("Game finished, press ENTER to exit");
            theConsole.ReadLine();
        }

    }
}
//char ch;
//theConsole.Write("Enter your Letter here:");
//ch = theConsole.ReadLine()[0];

//if (ch.Equals(null))
//{
//    theConsole.Write("Sorry, try again Enter your Letter here:");
//}
//return ch;