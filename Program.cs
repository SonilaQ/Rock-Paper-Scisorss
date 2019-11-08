using System;

namespace RPC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the game! "
                        + "The Rules of Rock Paper Scissor game will be follows: \n"
                        + "Rock vs Paper --> Paper wins \n"
                        + "Rock vs scissor --> Rock wins \n"
                        + "Paper vs Scissor --> Scissor wins \n");

            while (true) // per sa kohe perdoruesi do qe te qendroje ne loje
            {
                Console.WriteLine("If you want to play with the computer enter 1 , "
                            + "to proceed with the computer game enter 2 "
                            + " or enter any other key to exit the game");

                Game game = new Game();

                String input = Console.ReadLine();

                if (input == "1") game.playUser();

                else if (input == "2") game.playComputer();

                else break;
            }

            Console.WriteLine("Goodbye");

            Console.ReadKey();
        }

    }
}
