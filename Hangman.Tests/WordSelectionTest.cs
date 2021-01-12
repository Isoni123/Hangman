using System;
using System.ComponentModel.Design;
using System.Net;
using System.Reflection;
using Hangman.Core;
using NUnit.Framework;



namespace Hangman.Test
{
    public class WordSelectionTests
    {
        [Test]
        public void GIVEN_an_array_of_words_WHEN_game_starts_THEN_select_a_random_word_from_string_array_and_check_its_random()
        {
            //PREPARE
            //Obtain a word list 

            WordSelection wordSelection = new WordSelection();

            //ACT
            //Randomly select a word twice and see if the word selected is different
           string result1 = wordSelection.RandomlySelectWord();
           string result2 = wordSelection.RandomlySelectWord();

           wordSelection.Fetch(result1);
           wordSelection.Fetch(result2);

           Console.WriteLine(result1);
           Console.WriteLine(result2);

            //ASSERT
            // Check that the two words are random
            Assert.AreNotSame(result1,result2);
            
        }

    }
}
