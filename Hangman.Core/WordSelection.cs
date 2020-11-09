using System;
using System.Net;

namespace Hangman.Core
{
    public class WordSelection
    {
        public Random random = new Random();

        public string[] hangmanWords = {"hello", "goodbye", "name", "age", "white", "blue", "ready", "fred" };
        public string RandomlySelectWord()
        {
           string aWord = hangmanWords[random.Next(0, hangmanWords.Length)];

            return aWord;
        }

        public void ValidateChar()
        {

        }





    }
}
