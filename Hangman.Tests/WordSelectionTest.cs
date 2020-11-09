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
        //new string[]{
      //  "boo", "hello", "goodbye", "name", "age", "white", "blue", "ready", "fred"
//    })
     
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

           Console.WriteLine(result1);
           Console.WriteLine(result2);

            //ASSERT
            // Check that the two words are random
            Assert.AreNotSame(result1,result2);
            
        }




        //[Test]
        //public void GIVEN_a_randomly_selected_masked_word_WHEN_a_character_is_not_guessed_THEN_reject_it()
        //{
        //    //PREPARE
        //    //Obtain a word list and randomly select a word, mask the characters in the word.  
        //    //Obtain a word from a word list in an array
        //    WordSelection newWord = new WordSelection();
        //    newWord.RandomlySelectWord();


        //    //Mask the randomly selected word
        //    WordSelection.Mask(null, '\0');

        //    //Choose a character and see whether it is in the selected word

        //    newWord.ValidateMask();

        //    //ACT
        //    // Check that you can match a given character to any character in the word if you can, then reveal it, if not reject it
        //    newWord.ValidateChar();



        //    //ASSERT
        //    //Expect the chosen character to be accepted because it is in the word

        //    //Expect chosen character to be revealed.




        //}


        // string result = aWordSelectedFromList.RandomlySelectWord();
        //  [Test]
        //public void GIVEN_a_randomly_selected_word_WHEN_new_game_starts_THEN_mask_out_the_characters_in_it()
        // {
        //PREPARE
        //choose a word from an array of words held by the text file
        //  WordSelection aNewWord = new WordSelection();

        //ACT
        //  bool result = aNewWord.RandomlySelectWord(wordList);


        //ASSERT
        // Check that the word is selected properly from the word list accessed from the Http site//Check that the word is selected properly
        // Assert.IsTrue(result);
        // }
    }
}
