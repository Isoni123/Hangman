using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using Hangman.Core;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Hangman.Tests
{
    class HangmanViewTests
    {
        [TestCase("Welcome number of lives 3", 3)]
        [TestCase("Welcome number of lives 1", 1)]

        public void GIVEN_a_new_game_WHEN_it_starts_THEN_show_welcome_AND_number_of_Lives(string message, int numberOfLives)
        {
            //Prepare
            //Show the welcome Message
            //reset number of lives to 3
            TestConsole testConsole = new TestConsole();
            HangmanView hangmanView = new HangmanView(testConsole);
            HangmanModel hangmanModel = new HangmanModel();
            HangmanController controller = new HangmanController(hangmanModel, hangmanView);

            //Act
            int lifeCount = controller.LivesCount();
            hangmanView.ShowWelcome(lifeCount);
            controller.ResetNumberOfLives();

            //Assert
            Assert.AreEqual(2, testConsole.InspectWhatWasWritten().Count());
            Assert.AreEqual("You have 3 lives", testConsole.InspectWhatWasWritten()[1]);
        }


        [TestCase("red", "***", 2)]
        // [TestCase("blue", "****", 1)]
        public void GIVEN_a_game_WHEN_a_user_enters_an_incorrect_guess_THEN_show_decrease_number_of_Lives(string hangmanWord, string maskedHangmanWord, int numberOfLives)
        {

            //Prepare
            //reset number of lives to either 2 or 0
            List<string> testReadLineStrings = new List<string>();
            testReadLineStrings.Add("w");

            TestConsole testConsole = new TestConsole(testReadLineStrings);
            HangmanView hangmanView = new HangmanView(testConsole);
            HangmanModel hangmanModel = new HangmanModel();
            HangmanController controller = new HangmanController(hangmanModel, hangmanView);

            //Act
            hangmanModel.LoadWord(hangmanWord);
            hangmanModel.Mask();
            hangmanModel.FetchMaskedWord();
            char c = hangmanView.AskforChar();
            //  hangmanModel.ValidateChar(c);
            controller.CharNotInWordReduceLives(c);
            int lifeCount = controller.LivesCount();

            //Assert
            Assert.AreEqual(2, lifeCount);
            // Assert.AreEqual(0, lifeCount);
        }

        //[TestCase("red", "***", 2)]
        [TestCase("blue", "****", 0)]
        public void GIVEN_a_game_WHEN_a_user_enters_3_incorrect_guesses_THEN_show_decrease_number_of_Lives(string hangmanWord, string maskedHangmanWord, int numberOfLives)
        {
            //Prepare
            //reset number of lives to either 2 or 0
            List<string> testReadLineStrings = new List<string>();
            testReadLineStrings.Add("w");
            testReadLineStrings.Add("w");
            testReadLineStrings.Add("w");

            TestConsole testConsole = new TestConsole(testReadLineStrings);
            HangmanView hangmanView = new HangmanView(testConsole);
            HangmanModel hangmanModel = new HangmanModel();
            HangmanController controller = new HangmanController(hangmanModel, hangmanView);

            //Act
            controller.ResetNumberOfLives();
            int _numberOfLives = controller.LivesCount();
            hangmanView.ShowWelcome(_numberOfLives);
            hangmanModel.LoadWord(hangmanWord);
            hangmanModel.Mask();
            hangmanModel.FetchMaskedWord();
            controller.ResetNumberOfLives();
            char c = hangmanView.AskforChar();
            hangmanModel.ValidateChar(c);
            controller.CharNotInWordReduceLives(c);
            hangmanView.ShowLossOfLifeIncorrectGuess(_numberOfLives);

            char b = hangmanView.AskforChar();
            hangmanModel.ValidateChar(b);
            controller.CharNotInWordReduceLives(b);
            hangmanView.ShowLossOfLifeIncorrectGuess(_numberOfLives);

            char d = hangmanView.AskforChar();
            hangmanModel.ValidateChar(d);
            controller.CharNotInWordReduceLives(d);
            int lifeCount = controller.LivesCount();
            hangmanView.ShowLossOfLifeIncorrectGuess(_numberOfLives);

            //Assert
            // Assert.AreEqual(2, lifeCount);
            Assert.AreEqual(0, lifeCount);
        }


        // [TestCase("blue", "****", true, 3, true)]
        [TestCase("red", "***", 3)]
        public void GIVEN_a_new_game_WHEN_started_THEN_show_masked_word_AND_number_of_Lives(string hangmanWord, string maskedHangmanWord, int areLivesShown)
        {
            //Prepare
            TestConsole testConsole = new TestConsole();
            HangmanView hangmanView = new HangmanView(testConsole);
            HangmanModel hangmanModel = new HangmanModel();
            HangmanController controller = new HangmanController(hangmanModel, hangmanView);


            hangmanModel.LoadWord(hangmanWord);
            hangmanModel.Mask();
            string _maskedHangmanWord = hangmanModel.FetchMaskedWord();
            int startingLives = controller.ResetNumberOfLives();

            //Act
            hangmanView.ShowMaskedWord(_maskedHangmanWord);
            hangmanView.ShowNumberOfLives(startingLives);

            // Assert
            Assert.AreEqual(2, testConsole.InspectWhatWasWritten().Count());
            Assert.AreEqual("You have 3 lives", testConsole.InspectWhatWasWritten()[1]);

            //Assert
            //Assert.AreEqual(result, maskedHangmanWord);
            // Assert.AreEqual(revealedLivesCount, areLivesShown);
        }

        [TestCase("red", "***", 3)]
        public void GIVEN_a_game_WHEN_a_user_enters_3_correct_guess_THEN_show_3_number_of_Lives_AND_Game_Won(string hangmanWord, string maskedHangmanWord, int numberOfLives)
        {
            //Prepare
            //reset number of lives to either 2 or 0
            List<string> testReadLineStrings = new List<string>();
            testReadLineStrings.Add("r");
            testReadLineStrings.Add("e");
            testReadLineStrings.Add("d");

            TestConsole testConsole = new TestConsole(testReadLineStrings);
            HangmanView hangmanView = new HangmanView(testConsole);
            HangmanModel hangmanModel = new HangmanModel();
            HangmanController controller = new HangmanController(hangmanModel, hangmanView);

            //Act

            hangmanModel.LoadWord(hangmanWord);
            hangmanModel.Mask();
            hangmanModel.FetchMaskedWord();

            char c = hangmanView.AskforChar();
            hangmanModel.ValidateChar(c);
            controller.CharNotInWordReduceLives(c);
            hangmanModel.RevealLetterInMaskedHangmanWord(c);

            char e = hangmanView.AskforChar();
            hangmanModel.ValidateChar(c);
            controller.CharNotInWordReduceLives(c);

            int lifeCount = controller.LivesCount();
            hangmanView.YouWon();

            //Assert
            Assert.AreEqual(3, lifeCount);
            // Assert.AreEqual(0, lifeCount);
        }


        [TestCase("Welcome number of lives", 3, "blue", 'e')]
        [TestCase("Welcome number of lives", 3, "blue", 'w')]
        public void GIVEN_a_masked_word_WHEN_it_is_displayed_ask_user_to_enter_a_letter_AND_wait_for_the_user(string message, int numberOfLives, string hangmanWord, char c)
        {
            //Prepare
            //Show the welcome Message
            //reset number of lives to 3
            List<string> testReadLineStrings = new List<string>();
            testReadLineStrings.Add("r");
            testReadLineStrings.Add("e");
            testReadLineStrings.Add("d");

            TestConsole testConsole = new TestConsole(testReadLineStrings);
            HangmanView hangmanView = new HangmanView(testConsole);
            HangmanModel hangmanModel = new HangmanModel();
            HangmanController controller = new HangmanController(hangmanModel, hangmanView);
            //IConsole testConsole = new TestConsole("e");

            hangmanModel.LoadWord(hangmanWord);
            hangmanModel.Mask();
            hangmanModel.FetchMaskedWord();

            //Act
            int lifeCount = controller.LivesCount();
            hangmanView.ShowWelcome(lifeCount);

            char charInput = hangmanView.AskforChar();

            //ASSERT
            Assert.AreEqual('e', testConsole.ReadLine()[0]);
            Assert.AreNotEqual('w', testConsole.ReadLine()[0]);
        }
    }
}
