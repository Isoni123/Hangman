using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangman.Core;

namespace Hangman.App
{
    class HangmanViewConsole : IConsole
    {
        private string testReadLineReturn;

        public HangmanViewConsole()
        {
        }

        public void WriteLine(string s)
        {
            Console.WriteLine(s);
        }

        public void Write(string s)
        {
            Console.Write(s);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void Clear()
        {
            Console.Clear();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create actors
            HangmanModel model  = new HangmanModel();

            HangmanViewConsole viewConsole = new HangmanViewConsole();
            HangmanView view = new HangmanView(viewConsole);

            HangmanController controller = new HangmanController(model, view);

            controller.Start();
           
            view.GameFinished();
            

        }
    }
}
