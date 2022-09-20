using System;

namespace MyTextRPG
{
    class Program
    {
        static void Main(string[] arg)
        {
            Game game = new Game();

            while (true)
            {
                game.Process();
            }

        }
    }
}
