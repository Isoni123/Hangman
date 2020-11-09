using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangman.Core;
using NUnit.Framework;

namespace Hangman.Tests
{
    public class HangmanModelTests
    {

        [TestCase("ready", "*****")]
        [TestCase("fred", "****")]
        [Test]
        public void GIVEN_a_word_WHEN_masked_THEN_hide_characters(string word, string expected_masked_word)
        {
            //PREPARE
            //Obtain a word list and randomly select a word, mask the characters in the word.  
            //Obtain a word from a word list in an array
            HangmanModel selectedWord = new HangmanModel();


            //ACT
            //Mask the randomly selected word
            string maskedWord = selectedWord.Mask(word);

            //ASSERT
            Assert.AreEqual(expected_masked_word, maskedWord);
        }

        [TestCase("blue", 'e',true)]
        [TestCase("blue", 'z', false)]
        //[Test]
        public void GIVEN_a_randomly_selected_masked_word_WHEN_a_character_is_guessed_THEN_reveal_it
            (string hangmanWord, char letter, bool should_find_it)
        { 
            //PREPARE
            //Obtain a word list and randomly select a word, mask the characters in the word.  //Obtain a word from a word list in an array
            //WordSelection wordSelection = new WordSelection();
           // wordSelection.RandomlySelectWord();


             //ACT
            //Mask the randomly selected word
            HangmanModel selectedModel = new HangmanModel();

            string maskedWord = selectedModel.Mask(hangmanWord); 
            
            // Check that you can match a given character to any character in the word if you can, then reveal it
            bool result = selectedModel.ValidateChar(hangmanWord,letter);

            // ASSERT
              Assert.AreEqual(should_find_it, result);
           

            //    //Expect the chosen character to be accepted because it is in the word

        }

    }
}
