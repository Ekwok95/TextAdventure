using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    class Menu
    {
        static void Main(string[] args)
        {
            bool mainmenu = true;
            int optionSelection = 0;
            Menu[] menu = new Menu[4];

            string[] options = { "New Game", "Load", "Credits", "Quit Game" };

            for (int i = 0; i < 4; i++)
            {
                menu[i] = new Menu(options[i], i + 1);
            }

            Console.WriteLine("TEXT ADVENTURE");
            Player.ClearLine();


            do
            {
                Console.WriteLine("MAIN MENU");
                ClearLine();
                Console.WriteLine("Select an option by typing in a number");

                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine(menu[i]);
                }

                optionSelection = Int32.Parse(Console.ReadLine());

                switch (optionSelection)
                {
                    case 1:
                        {
                            //Creating new user....
                            Console.WriteLine("Welcome to TextAdventure!!");
                            Console.WriteLine("Please enter a name");
                            string user = Console.ReadLine();
                            Player player1 = new Player(user);

                            string saveFileName = user + "savefile.txt";
                            CreateNewFile(saveFileName);
                            break;
                        }

                    case 2:
                        {
                            //Load character data....
                            Console.WriteLine("Input a character name.");
                            string charactername = Console.ReadLine();
                            string savefilename = charactername + "savefile.txt";
                            ReadLines(savefilename);
                            break;
                        }
                    case 3:
                        {
                            //Credits....
                            Console.WriteLine("Everything- Bryan Kwok");
                            ClearLine();
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
                                //mainmenu == false;
                            }
                            break;

                        }
                    default:
                        {
                            Console.WriteLine("There is no such option");
                            break;
                        }
                }

            } while (mainmenu == true);

            Application.Exit();

        }

    }
}
