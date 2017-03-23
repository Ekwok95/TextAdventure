using System;
using System.Threading;
using System.Windows.Forms;


namespace TextAdventure
{
    public class Menu
    {
        private string option;
        private int optionNumber;

        public Menu(string name, int number)
        {
            option = name;
            optionNumber = number;
        }

        public override string ToString()
        {
            return "[" + optionNumber + "]---   " + option;
        }
    }

    class MainMenu
    {

        public static void Main(string[] args)
        {
            //bool mainmenu = true;
            //int optionSelection = 0;
            Menu[] menu = new Menu[4];
            FileIO fileHandler = new FileIO();
            //string[] playerData;

            //Test testGame = new Test();

            RunGame.Test.RunGame();

            /*
        string[] options = { "New Game", "Load", "Credits", "Quit Game" };

        for (int i = 0; i < 4; i++)
        {
            menu[i] = new Menu(options[i], i + 1);
        }

        Console.WriteLine("TEXT ADVENTURE");
        Test.ClearLine();

        do
        {
            Console.WriteLine("MAIN MENU");
            Test.ClearLine();
            Console.WriteLine("Select an option by typing in a number");

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(menu[i]);
            }

            optionSelection = Int32.Parse(Console.ReadLine());


            //Set actual game to take in 
            switch (optionSelection)
            {
                case 1:
                    {
                        //Creating new user....
                        Console.WriteLine("Welcome to TextAdventure!!");
                        Console.WriteLine("Please enter a name");
                        string user = Console.ReadLine();
                        Player player = new Player(user);
                        //Set objects to clear when game is done. Create new objects and load data into them.
                        //Set Player object properties when player loads character.

                        string saveFileName = user + "savefile.txt";

                        //Create a text file to save player data....

                        fileHandler.CreateNewFile(saveFileName);
                        Test.ClearLine();
                        //Test.runGame(player);
                        break;
                    }

                case 2:
                    {
                        //Load character data....
                        //If none, ask player to create new character and save file.
                        //if (File.Exists(savefilename) && justLoggedIn == true)
                        //{
                        //    Console.WriteLine("Welcome back {0}.", player);
                        //    justLoggedIn = false;
                        //}

                        Console.WriteLine("Input a character name.");
                        string charactername = Console.ReadLine();
                        string savefilename = charactername + "savefile.txt";

                        //Check directory for save file....
                        //playerData = fileHandler.ReadLines(savefilename);
                        Test.ClearLine();
                        break;
                    }
                case 3:
                    {
                        //Credits....
                        Console.WriteLine("Everything- Bryan Kwok");
                        Test.ClearLine();
                        break;
                    }
                case 4:
                    {
                        //Quit Game
                        Console.WriteLine("Do you really want to quit?");
                        string finalDecision = Console.ReadLine();
                        bool decision = End(finalDecision);
                        if (decision)
                        {
                            Thread.Sleep(3000);
                            mainmenu = false;
                        }
                        Test.ClearLine();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("There is no such option");
                        break;
                    }
            }
            //Include option 2 later...
        } while (mainmenu == true);

        Environment.Exit();
    }

    private static bool End(string quit)
    {
        bool reallyQuit = true;
        if (quit.Equals("yes"))
        {
            Console.WriteLine("Thanks for playing!!");
        }
        else if (quit.Equals("no"))
        {
            reallyQuit = false;
        }
        else
        {
            Console.WriteLine("That is not a valid decision. Please enter again.");
            reallyQuit = false;
        }
        return reallyQuit;
        }
        */
        }
    }
}
