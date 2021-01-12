using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
        public void GIVEN_a_word_WHEN_masked_THEN_hide_characters(string hangmanWord, string expected_masked_word)
        {
            //PREPARE
            //Obtain a word list and randomly select a word, mask the characters in the word.  
            //Obtain a word from a word list in an array
            HangmanModel hangmanModel = new HangmanModel();
            hangmanModel.LoadWord(hangmanWord);
      

            //ACT
            //Mask the randomly selected word
            hangmanModel.Mask();
           string _maskedHangmanWord =hangmanModel.FetchMaskedWord();

            //ASSERT
            Assert.AreEqual(expected_masked_word, _maskedHangmanWord);
        }


        [TestCase("blue", 'e', true)]
        [TestCase("blue", 'z', false)]
        //[Test]
        public void GIVEN_a_randomly_selected_masked_word_WHEN_a_character_is_guessed_THEN_reveal_it
            (string hangmanWord, char letter, bool should_find_it)
        {
            //PREPARE
            //Obtain a word from the model to test and load it
            HangmanModel hangmanModel = new HangmanModel();
            hangmanModel.LoadWord(hangmanWord);

            //ACT
            //Mask the randomly selected word
            hangmanModel.Mask();
            string _maskedHangmanWord =hangmanModel.FetchMaskedWord();

            // Check that you can match a given character to any character in the word if you can, then reveal it
            bool result = hangmanModel.ValidateChar(letter);

            // ASSERT
            Assert.AreEqual(should_find_it, result);

            //Expect the chosen character to be accepted because it is in the word
        }

        [TestCase("blue", 'c', false)]
        [TestCase("blue", 'b', true)]
        //[TestCase]
        public void Given_an_input_letter_WHEN_it_matches_a_letter_in_the_word_return_yes_or_no(string hangmanWord, char letter, bool isLetterinWord)
        {
            //Prepare

            //Show Masked word
            //choose a letter for the test delivered from the test console.
            // need to check whether that letter is in the hangman word and reveal it in
            //the word but still mask out the other characters
            TestConsole testConsole = new TestConsole();
            HangmanModel hangmanModel = new HangmanModel();
            HangmanView hangmanView = new HangmanView(testConsole);
            HangmanController controller = new HangmanController(hangmanModel, hangmanView);

            // string _maskedHangmanWord = model.Mask(hangmanWord);
            hangmanModel.LoadWord(hangmanWord);

            //Act
            bool result = hangmanModel.ValidateChar(letter);

            //Assert
            Assert.AreEqual(isLetterinWord, result);
        }



        [TestCase("boob", "****", true, 'b')]
        [TestCase("boob", "b**b", true, 'o')]
        public void GIVEN_a_correctly_guessed_letter_WHEN_it_is_unmasked_reveal_all_the_instances_in_the_word(string hangmanWord, string maskedHangmanWord, bool isInWord, char letter)
        {
            //PREPARE
            //Obtain a word from the model to test and load it
            HangmanModel hangmanModel = new HangmanModel();
            hangmanModel.LoadWord(hangmanWord);


            //ACT
            //Mask the randomly selected word
            hangmanModel.Mask();
            hangmanModel.FetchMaskedWord();

            bool result = hangmanModel.RevealLetterInMaskedHangmanWord(letter);

            //Assert
            //Assert.AreNotEqual(revealedMaskedHangmanWord,updatedMaskedHangmanWord);
            Assert.AreEqual(isInWord, result);
        }


        [TestCase("boob", false, 'b')]
        [TestCase("I", true, 'I')]
        public void GIVEN_a_word_WHEN_all_the_letters_guessed_correctly_notify_the_player_they_won(string hangmanWord, bool hasStars, char letter)
        {
            //PREPARE
            //Obtain a word from the model to test and load it
            HangmanModel hangmanModel = new HangmanModel();
            hangmanModel.LoadWord(hangmanWord);

            //ACT
            //Mask the randomly selected word
            hangmanModel.Mask();
            hangmanModel.FetchMaskedWord();
            //ACT
            //Need to reveal all the characters in the word first
            bool result1 = hangmanModel.RevealLetterInMaskedHangmanWord(letter);

            //Check whether all of them have been found and then return you have won.
            bool result = hangmanModel.IsWordRevealed();

            //ASSERT
            Assert.AreEqual(hasStars, result);
        }


        [TestCase("boob", 'b', 'o', true)]
        public void 
            GIVEN_a_word_WHEN_user_enters_all_the_correct_letters_check_reveal_methods_work(string hangmanWord, char letter1, char letter2, bool expectedUnmaskedWord)
        {
            //PREPARE
            //Obtain a word from the model to test and load it
            HangmanModel hangmanModel = new HangmanModel();
            hangmanModel.LoadWord(hangmanWord);

            //ACT
            //Mask the randomly selected word
            hangmanModel.Mask();
            hangmanModel.FetchMaskedWord();
            //ACT
            //Need to reveal all the characters in the word first

            hangmanModel.RevealLetterInMaskedHangmanWord(letter1);
            hangmanModel.RevealLetterInMaskedHangmanWord(letter2);

            string unMaskedWord = hangmanModel.FetchMaskedWord();

            bool result = hangmanModel.IsWordRevealed();

            Assert.AreEqual(expectedUnmaskedWord, result);

        }
    }
}
