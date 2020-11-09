using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Hangman.Core;


namespace Hangman.Core
{
    public class HangmanModel
    {
        private string hangmanWord;
        public void loadWord(string aWord)
        {
            hangmanWord = aWord;
        }

        public string maskedhangmanWord = "";
        public string Mask(string hangmanWord)
        {
            for (int i = 0; i < hangmanWord.Length; i++)
                maskedhangmanWord += "*";
            return maskedhangmanWord;
        }

        public bool ValidateChar(string hangmanWord, char letter)
        {
            if(hangmanWord.Contains(letter))
            {

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
