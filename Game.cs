using System;
using System.Collections.Generic;

namespace RPC
{
    public class Game
    {
        static String[] game = new String[3] { "rock", "paper", "scissor" };
        static Random rand = new Random();
        String player;
        String computer;
        int fitues;
        int piket_computer;
        int piket_player;
        List<String> arr;


        public Game() { }


        // inicializimi i variablave te instances
        public void initilazeGame() 
        {
            piket_computer = 0;
            piket_player = 0;
            arr = new List<String>();
            player = "";
            fitues = 0;
            computer = "";

        }

        //behen krahasimet e te gjitha kombinimeve te mundshme 
        public static int result(String choice1, String choice2) 
        {
            if ((choice1 == "rock" && choice2 == "scissor") || (choice1 == "scissor" && choice2 == "paper") || (choice1 == "paper" && choice2 == "rock"))
                return 1;

            if ((choice1 == "scissor" && choice2 == "rock") || (choice1 == "paper" && choice2 == "scissor") || (choice1 == "rock" && choice2 == "paper"))
                return 2;

            else return 0;
        }


        // loja e Kompjuterit
        public void playComputer()  
        {
            int inc = 1;

            initilazeGame();

            player = "rock";


            Console.WriteLine("Player choice is Rock");
            int index = 0;

            while (inc <= 100) //loja behet me 100 raunde
            {
                index = rand.Next(0, game.Length); 
                computer = game[index];             // zgjedhja e kompjuterit behet random

                fitues = result("rock", computer);  // merret rezultati

                if (fitues == 1)                    //testohet kush eshte fituesi i lojes
                {

                    piket_player++;
                    arr.Add("Computer choice: " + computer +
                        ". Player is the winner! Computer score = " + piket_computer +
                        ". Player score = " + piket_player);

                }
                else if (fitues == 2)
                {
                    piket_computer++;
                    arr.Add("Computer choice: " + computer +
                        " Computer is the winner! Computer score = " + piket_computer +
                        ". Player score = " + piket_player);

                }

                else arr.Add("Computer choice: " + computer + " Equal");

                inc++;
            }

            Console.WriteLine("Computer won " + piket_computer + " rounds. Player won " + piket_player + " rounds.");
            Console.WriteLine("\nClick 1 to see the aggregated results or any tab to exit the game: ");

            var inp = Console.ReadLine();
            if (inp == "1") // nese perdoruesi do te shikoje rezultatet
            {
                printResults();
            }

        }

        //loja e user-it me kompjuterin
        public void playUser() 
        {
            String input;
            int i = 1;
            bool ok;

            while (true)
            {
                initilazeGame(); //inicializimi i lojes

                while (i <= 5) //luhen 5 raunde te lojes
                {
                    ok = true;
                    int indx = rand.Next(game.Length);
                    computer = game[indx];

                    Console.WriteLine("\nNow please enter your choice number." +
                                    "\n 1. Rock \n 2. Paper \n 3. ScissorsS \n");
                    input = Console.ReadLine();

                    if (input == "1" || input == "2" || input == "3") //nese user ka bere zgjedhjen e sakte merret rezultati
                    {
                        player = game[Int32.Parse(input) - 1];

                        fitues = result(computer, player);
                    }

                    else                                            // ne te kundert i jepet mundesi per te zgjedhur prape
                    {
                        Console.WriteLine("\n Your choice is a wrong number enter 0 to exit the game or any tab to stay in the game");
                        input = Console.ReadLine();

                        if (input == "0")
                            break;

                        else
                            ok = false;

                    }

                    if (ok)                                          //nese zgjedhja eshte e sakte kotrolllohet kush ka fituar
                    {
                        Console.WriteLine("\nComputer Played now it is your turn");

                        if (fitues == 1)
                        {
                            piket_computer++;
                            arr.Add("\nComputer choice: " + computer +
                                ". Your choice " + player + ". Computer is the winner! Computer score = " + piket_computer +
                                ". Your score = " + piket_player);
                        }

                        else if (fitues == 2)
                        {
                            piket_player++;
                            arr.Add("\nComputer choice: " + computer +
                                ". Your choice " + player + ". You are the winner! Computer score = " + piket_computer +
                                ". Your score = " + piket_player);

                        }

                        else arr.Add("Computer choice: " + computer + ". Your choice " + player + ". Same choice.");

                        i++;
                    }
                }

                Console.WriteLine("\n Game finished! Your score " + piket_player + ".\nComputer score " + piket_computer);

                if (piket_computer > piket_player)
                    Console.WriteLine("\nComputer is the winner!");

                else if (piket_computer < piket_player)
                    Console.WriteLine("\nYou are the winner!");

                else Console.WriteLine("\nThe score is equal!");

                printResults();

                Console.WriteLine("\nIf you want to start a new game enter 1, or any other key to exit the game");

                input = Console.ReadLine();
                if (input == "1") i = 1;

                else break;

            }
        }

        // printimi i rezultateve
        public void printResults() 
        {
            int c = 1;
            foreach (String item in arr)
            {
                Console.WriteLine("\nRound " + (c++) + ": " + item);
            }
        }
    }
}