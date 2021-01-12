using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Hangman.Core;
using static System.Console;

namespace Hangman.Core
{
    public class HangmanModel
    {
        private string _hangmanWord;
        private string _maskedHangmanWord = "";

        public void LoadWord(string aWord)
        {
            _hangmanWord = aWord;
        }

      
        public void Mask()
        {
            _maskedHangmanWord = "";
         
            for (int i = 0; i < _hangmanWord.Length; i++)
            {
                _maskedHangmanWord += "*";
            }
        }

        public string FetchMaskedWord()
        {
            return _maskedHangmanWord;
        }

        public bool ValidateChar(char letter)
        {
            if (_hangmanWord.Contains(letter))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
       

        public bool RevealLetterInMaskedHangmanWord(char letter)
        {
            if (_hangmanWord.Contains(letter))
            {
                //Given the hangman word,when a letter is entered see if it has the letter in it
                char[] maskedHangmanWordChars = _maskedHangmanWord.ToCharArray();
                int index = 0;
                foreach (char letterInHangmanWord in _hangmanWord)
                {
                    if (letterInHangmanWord == letter)
                    {
                        maskedHangmanWordChars[index] = letter;
                    }
                    index++;
                }
                _maskedHangmanWord = new string(maskedHangmanWordChars);
                return true;
            }

            return false;
        }

        public string GetMaskedHangmanWord()
        {
            return _maskedHangmanWord;
        }

        public bool IsWordRevealed()
        {
            GetMaskedHangmanWord();
            //have to check whether the maskedhangmanword is completely revealed
            if (_maskedHangmanWord.Contains('*'))
            {
                return false;
            }
            return true;
        }
    }
}


//public bool AllCharactersAreRevealed()
//{

//    if (unMaskedWord =="boob")
// {
//     return true;
// }
// else return false;

//}

/*  public string RevealLetterInMaskedHangmanWord1(string hangmanWord, string maskedHangmanWord, char letter)
  {
      char[] maskedHangmanWordChars = maskedHangmanWord.ToCharArray();

      // Find all occurrences of the letter until there aren't any
      int searchFromIndex = 0; // Always start searching from beginning
      bool finished = false;
      // - While I am not finished keep looping
      while (finished == false)
      {
          // Search for the letter in the original word
          // - if you don't put a second arg in IndexOf it will always
          // start from beginning of the string
          // - So we tell IndexOf where to start searching from
          int positionOfLetter = hangmanWord.IndexOf(letter, searchFromIndex);
          bool didFindAMatch = (positionOfLetter != -1); // -1 means no match found

          // If there is no occurrence then we get -1
          if (didFindAMatch)
          {
              // Replace the letter in the mask at the position
              // we found the letter in the original word
              maskedHangmanWordChars[positionOfLetter] = letter;

              // Since we found a match and there may be others, we have
              // to start search from the next letter
              searchFromIndex = positionOfLetter + 1;
          }
          // We are finished if there wasn't any more matches
          finished = (didFindAMatch == false);
      }

      // Since we replaced the mask in char form, recreate the mask string with
      // any replaced masked letters
      _maskedHangmanWord = new string(maskedHangmanWordChars);

      // Return the masked word (this saves he controller calling the model again)
      return _maskedHangmanWord;
  }

  */

