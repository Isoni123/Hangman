using System;
using System.Collections.Generic;
using System.Linq;
using Hangman.Core;

namespace Hangman.Tests
{
    public class TestConsole : IConsole
    {
        private List<string> testReadLineReturn;
       /// <summary>
       ///Stores what has been written using console.WriteLine
       /// </summary>
        private List<string> writtenLines;

        public TestConsole(List<string> readLineReturn = null)
        {
            testReadLineReturn = readLineReturn;
            writtenLines = new List<string>();
        }

        public void WriteLine(string s)
        {
            writtenLines.Add(s);
        }

        public void Write(string s)
        {
        }

        public string ReadLine()
        {
            string nextLine = testReadLineReturn.First();
            testReadLineReturn.RemoveAt(0);
            return nextLine;
        }

        

        public List<string> InspectWhatWasWritten()
        {
            return writtenLines;
        }
    }
}