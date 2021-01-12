using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Core
{
    public class HangmanController
    {
        private HangmanModel _theHangmanModel;
        private HangmanView _theHangmanView;
        private WordSelection wordSelection;

        public HangmanController(HangmanModel hangmanModel, HangmanView hangmanView)
        {
            _theHangmanModel = hangmanModel;
            _theHangmanView = hangmanView;
            wordSelection = new WordSelection();
            _numberOfLives = 3;
        }

        public int ResetNumberOfLives()
        {
            int startingLives = 3;
            return startingLives;
        }

        private int _numberOfLives = 3;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int LivesCount()
        {

            return _numberOfLives;
        }


        public int CharNotInWordReduceLives(char letter)
        {
            if (_theHangmanModel.ValidateChar(letter) == true)
            {
                return _numberOfLives;
            }
            else
            {
                _numberOfLives = _numberOfLives - 1;
                return _numberOfLives;
            }
        }


        public void Start()
        {
            var word = wordSelection.RandomlySelectWord();
            _theHangmanModel.LoadWord(word);
            _theHangmanModel.Mask();
            string _maskedHangmanWord = _theHangmanModel.FetchMaskedWord();
            _theHangmanView.ShowMaskedWord(_maskedHangmanWord);
            ResetNumberOfLives();
            _theHangmanView.ShowWelcome(_numberOfLives);

            while (_numberOfLives != 0 && _theHangmanModel.IsWordRevealed() == false)
            {
                char c = _theHangmanView.AskforChar();
                _theHangmanModel.ValidateChar(c);
                _theHangmanModel.IsWordRevealed();
                CharNotInWordReduceLives(c);
                _theHangmanModel.RevealLetterInMaskedHangmanWord(c);
                _maskedHangmanWord = _theHangmanModel.FetchMaskedWord();
                _theHangmanModel.IsWordRevealed();
                _theHangmanView.ShowMaskedWord(_maskedHangmanWord);
                _theHangmanView.ShowNumberOfLives(_numberOfLives);
            }

            if (_theHangmanModel.IsWordRevealed() == true)
            {
                _theHangmanView.YouWon();
            }
            else
            {
                _theHangmanView.YouLost();
            }
        }
    }
}


//was in LivesCount
/*
    if (_numberOfLives == 3)
    {
        return _numberOfLives;
    }

    if (_numberOfLives >= 1)
    {
        Console.WriteLine($"You have {_numberOfLives }lives left");
        return _numberOfLives;
    }
    else if (_numberOfLives == 0)
    {
        Console.WriteLine($"Game Over, you have {_numberOfLives }lives left");
        return _numberOfLives;
    }
    return _numberOfLives;
*/

