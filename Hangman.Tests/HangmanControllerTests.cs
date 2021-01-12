using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangman.Core;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Hangman.Tests
{
    class HangmanControllerTests
    {
        [TestCase("blue", 'c', 2)]
        [TestCase("purple", 'e', 3)]
        public void GIVEN_a_letter_is_not_in_a_word_WHEN_user_inputs_that_letter_reduce_number_of_lives(string hangmanWord, char letter, int numberOfLives)
        {
            //Prepare
            // Check game is running correctly with number of lives count
            //Show Masked words 
            //Show number of lives count total number of lives -3
            TestConsole testConsole = new TestConsole();
            HangmanModel hangmanModel = new HangmanModel();
            HangmanView hangmanView = new HangmanView(testConsole);
            HangmanController controller = new HangmanController(hangmanModel, hangmanView);

            //string _maskedHangmanWord = model.Mask(hangmanWord);
            hangmanModel.LoadWord(hangmanWord);
            //Act
            //number of lives are affected depending on whether a character
            //is guessed correctly                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
              hangmanModel.ValidateChar(letter);
              int result = controller.CharNotInWordReduceLives(letter);

            //Assert
            //Check the numbers change if the guess is incorrect or stay the same if they are
            //correct
            Assert.AreEqual(numberOfLives, result);
        }
    }
}

