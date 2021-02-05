using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Character;
using Objects;
using Opponent;


/* Timestamp and completed features.
 * 1/3/2017- Created base command system, player class and basic functions and actions.
 * 2/3/2017- Added commands, toString for objects, file I/O systems and help menu.
 * 3/3/2017- Finished the save file and player profile feature
 * 5/3/2017- Finished implementing the base enemy class and interface methods for attack and defend.
 * 6/3/2017- Started on Enemy class. Implemented abstract base class and 2 interfaces for attack and defend abilities.
 * 7/3/2017- Adjusted classes. Moved IO methods to FileIO class. Accomplished basic combat. Accomplished simple leveling system (without xp algorithm). 
 *          Completed death system- Player needs to reload save game or create a new character. Can adjust settings later.
 * 14/3/2017- Added interface functions for attack commands         
 * 15/3/2017- Moved actual game operation into RunGame class. Changing CharacterDiscipline class to inherit from Player class. Moved character classes around
 * 21/3/2017- Created Swordsman class over CharacterBase abstract class. Started creating Item class. Mostly completed now. Tested XP algorithm.
 * 24/3/2017- Made Inventory class and Item class. Going to test tomorrow since I'm pretty tired tonight...
 * 25/3/2017- Inventory class has been a success. Can add items to inventory now. Next thing to do is use and remove functions.
 * 26/3/2017- Inventory class almost complete. Only lacking a sorting function. Started Equipment class for equipping weapons & armour.
 * 17/12/2017 - Inventory class now has spam lock. Changed around some if statements so that only what is important will show.
 * 18/12/2017 - Changed some class names. Will most likely restructure dependencies for player class by combining inventory and equipment. Will add some more after considering in future.
 * 21/12/2017 - Changed Namespace names. Now classes that have close relationships will be within the same namespace. 
 *             - Will change classes so that they return object references instead of create dependencies between each class.
 *              This is to reduce tethering to a minimum between any number of classes so that the only errors messages that will come up are the
 *              ones created by me. Recommended not to use exceptions in this case.
*/

/*
 * All action steps will involve creating commands for each action. Make commands no more than 20 characters unless this length is too short.
 *
 * * To do:
 * - Player save file and list- Done; Included a main menu.
 * - Enemy class- Can possibly split between evil NPCs and wild monsters.... - Basic enemy class done
 * - Enemy types- Normal enemies first. Add in bosses and boss room scenarios later....
 * - Set player stats also.... - Attack and Defence stats tested and works. Attempt to use generics later.
 * - Combat actions - Completed some other ability commands.
 * - Death system - Complete. Needs tweaking however.
 * - Level and experience system- Set enemies to be within suitable level range (not too high or low unless player stumbles into a high level area)- 
 *         - Basic levelling system complete.
 *         - Need to figure out xp algorithm soon. Will attempt this at a later time.
 *      - NO LEVEL CAP :D
 * - Create character classes (No magic characters. Physical weapons only. Can add enchant feature for weapons to reduce player disadvantage)
 *      - Have classes share SOME abilities, not all.
 *      - Create all abilities in advance.- Need some inspiration
 *      - Use binary tree to allow skill/advanced class tiers. - Will get to it soon.
 *      - build interfaces for same class abilities - Will attempt in future.
 *      - Adjust stat values for speed, special attack and special defence. - Can add this in later.
 * - Create a responses class for responses to commands and choices being made.
 * - Armor and weapon types (Tiers and linked lists)- Set weapon stats to have a reasonable range(So that weapons don't become OP or UP). - Can adjust this after items have been complete.
 * - Weapon combos and abilities- Add in energy/MP field to be adjusted according to abilities as they are done.- Configure attack functions to accept references from other functions to 
 *      chain combos.
 * - Item Lists/Items- Gradually add to base list as game is being developed.
 * - Item database- To refer to item stats and detailed descriptions.- Use hash table.
 * - Finishing moves- Will consider this after combat system has been developed.
 * - Timed combat (If I can pull it off...)- Can adjust for other options; Can consider doing elapsed time instead of countdown.
 * - Inventory- Create inventory with item details/stats. Also add inventory functions (Sorting functions, discard, etc..)
 * - NPCs- Friendly NPCs only. Enemies are already a class of their own.
 *      - Can add personalities to NPCs when game is complete (or more like adjusted properly).
 *      - Add conversation feature.
 * - Day and Night system- Set normal actions to take up approx normal time. Combat actions will take up a bit more time. 
 * Time will come in the form of turns/minutes in assumption of real life time....
 * - Status Effects (Maybe)
 * - Damage types (Maybe)
 * - Hunting system (Could allow linked lists also)- Hunting level in honour of Slayer skill on RS. :P
 * - Non-combat skills and actions
 * - Currency system (When most functions are in)
 * - Companions- If there is a need for additional support.
 * - Mounts (Not necessary but nice addition)
 * - Daily Challenges
 * - Dungeons
 * - Maps and location details
 * - Quests (Would love to have randomly generated quests; bounty hunting or otherwise) :D
 *      - Add level description to quests
 *      - Quest lines with linked lists/some other data structure.
 *      - Set quest ID for easy reference
 *      - If setting quest lines, use linked lists.
 * - Difficulty Levels :P (Will consider it. No promises though.)
 * - Boss mechanics 0_0
 * - Playtime- Use Stopwatch class methods and Stopwatch.Elapsed method then write this timestamp to file.
 *      - Retrive timestamp and add onto new elapsed time.
 * - Achievements
 * - Change namespace names - DONE. Format for all object declarations from now on is [Namespace].[Class].[Interface]
*/

namespace TextAdventure
{   
    public class Test
    {
        private class Commands
        {
            private string command;
            private int commandNumber;

            public Commands(string name, int number)
            {
                command = name;
                commandNumber = number;
            }

            public override string ToString()
            {
                return "[" + commandNumber + "]---   " + command;
            }
        }

        private const int NUMBER_OF_COMMANDS = 4;

        public static void RunGame()
        {
            ///*Player character*/
            string intention = "", direction = "", temp = "";
            int steps = 0;
            bool justLoggedIn = true;
            //string name = "";

            ClearLine();
/*
            Console.WriteLine("Enter name pls");
            name = Console.ReadLine();
            */
            //Swordsman character = new Swordsman(name);
            Swordsman character = new Swordsman("Ekwok", null, null);

            ClearLine();
            //Change code for object creation.... 
            //Current code is placeholder....
            /*
            if (character == null)
            {
                Console.WriteLine("Welcome to TextAdventure!!");
                Console.WriteLine("Please enter a name");
                string user = Console.ReadLine();
                Player player1 = new Player(user);
            }
            */

            Actions setOfActions = new Actions();
            Random dice = new Random();
            Item[] items = createTestItems();


            //Inventory inventory = new Inventory(character);
            bool menuAction = false;
            bool releaseEnemy = false;

            /*
            for(int i=0; i<7; i++)
            {
                inventory.AddItem(items[i]);
            }

            */

            //Place all movement, combat and misc actions into actions class....
            //Make individual action types/classes and then combine into final Action class....

            if (justLoggedIn == true)
            {
                Console.WriteLine("Welcome back {0}.", character);
                justLoggedIn = false;
            }

            do
            {
                //Check for user in file.

                /* if(Player == null)
                    {
                    Console.WriteLine("Welcome to ...");
                    Console.WriteLine("Please enter a name");
                    string user = Console.ReadLine();
                    Player player1 = new Player(user);
                    }
                    */

                intention = AskPlayer(0);

                /*if(Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    Debug.WriteLine("Escape Key was pressed.");
                }*/

                //Search semaphores and mutex processes online

                ClearLine();

                if (intention.Equals("help"))
                {
                    ShowCommands();
                    menuAction = true;
                    releaseEnemy = false;
                }

                /*
                else if (intention.Equals("inv"))
                {
                    inventory.TraverseInv();
                    menuAction = true;
                    releaseEnemy = false;
                }
                */

                /*
                if (intention.Equals("lookaround"))
                {
                    //Set random number depending on area and situation

                    //After further development, change this line to include multiple situations of similar scenarios.
                    Console.WriteLine("You look around and spot {0}.");
                }*/

                //Consider making sight/perception class....

                //Combat actions....

                //Modify function to only accept specific strings as input for direction.
                else if (intention.Equals("walk"))
                {
                    temp = AskPlayer(1);
                    steps = Int32.Parse(temp);//use try keyword here just in case someone uses word instead of number.
                    Console.WriteLine("Which direction would you like to walk towards?");
                    direction = Console.ReadLine();
                    setOfActions.Walk(steps, direction);
                    releaseEnemy = true;
                }
                /*
                if (intent/ion.Equals("run"))
                {
                    temp = AskPlayer(1);
                    steps = Int32.Parse(temp);
                    Console.WriteLine("Which direction would you like to run towards?");
                    direction = Console.ReadLine();
                    setOfActions.Walk(steps * 2, direction);
                    //Consider making movement class...
                }
                */

                else
                {
                    Console.WriteLine("Command invalid. Please try again.");
                    Console.WriteLine("If you need help, type in 'help' in the next line.");
                    releaseEnemy = false;
                }

                ClearLine();

                /*
                else if (intention.Equals("quit"))
                {
                    Console.WriteLine("Do you really want to quit?");
                    string finalDecision = Console.ReadLine();
                    bool decision = End(finalDecision);
                    if (decision)
                    {
                        Thread.Sleep(3000);
                        break;
                    }
                }
                */

                //Set enemy objects to only form when battle begins for randomizer to choose enemy type.

                int randomEncounter = 0, enemyChoice = 0;
                bool isDead = false, isDefending = false;

                randomEncounter = randomizer(dice, menuAction);

                if (releaseEnemy == true)
                {
                    switch (randomEncounter)
                    {
                        case 1:
                            {
                                string response = "";
                                Console.WriteLine("You encounter an enemy!");

                                Enemy.GeneralEnemy NormalEnemy = new Enemy.GeneralEnemy("Grunt", "Grunt", "Easy", 50, 5, 5, 50);
                                NormalEnemy.EnemyLevel = character.PlayerLevel;

                                Console.WriteLine("A {0} attempts to attack you.", NormalEnemy);
                                do
                                {
                                    Console.WriteLine("What will you do?");
                                    response = Console.ReadLine();
                                    if (response.Equals("attack"))
                                    {
                                        int enemyHP = NormalEnemy.EnemyHealth;
                                        if (isDefending != true)
                                        {
                                            character.Fight(NormalEnemy, enemyHP, character.PlayerAttack, NormalEnemy.EnemyDefencePower);
                                        }
                                        else
                                        {
                                            Console.WriteLine("The {0} is guarding itself! Your attack does no damage!", NormalEnemy, NormalEnemy);
                                        }
                                    }
                                    else if (response.Equals("slash"))
                                    {
                                        int enemyHP = NormalEnemy.EnemyHealth;
                                        if (isDefending != true)
                                        {
                                            //int damage;
                                            int damageTaken = character.Slash(NormalEnemy, character);
                                            NormalEnemy.EnemyHealth = NormalEnemy.EnemyHealth - damageTaken;
                                            if (NormalEnemy.EnemyHealth >= 0)
                                            {
                                                Console.WriteLine("{0} now has {1} HP.", NormalEnemy, NormalEnemy.EnemyHealth);
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("The {0} is guarding itself! Your attack does no damage!", NormalEnemy);
                                        }
                                    }
                                    else if (response.Equals("defend"))
                                    {
                                        character.Guard();
                                        Console.WriteLine("You guard yourself against {0}.", NormalEnemy);
                                        character.CheckCondition();
                                    }
                                    else
                                    {
                                        Console.WriteLine("You cannot do {0} as it does not work in battle.", response);
                                    }

                                    ClearLine();

                                    enemyChoice = dice.Next(1, 100);
                                    //switch (enemyChoice)
                                    if (enemyChoice > 50 && enemyChoice < 101)
                                    {
                                        //case 1:
                                        //{
                                        isDefending = false;
                                        if (!response.Equals("defend"))
                                        {
                                            character.PlayerHealth = NormalEnemy.Attack(character.PlayerHealth, NormalEnemy.EnemyAttackPower, NormalEnemy.EnemyDefencePower);
                                            character.CheckCondition();
                                        }
                                        // break;
                                    }
                                    // case 2:
                                    /*else
                                    {
                                        //{
                                        NormalEnemy.Guard();
                                        isDefending = true;
                                        //break;
                                        //}
                                    }
                                    */
                                    ClearLine();

                                } while (character.PlayerHealth > 0 && NormalEnemy.EnemyHealth > 0);

                                if (NormalEnemy.EnemyHealth <= 0)
                                {
                                    Item potion = new Aid("Potion", 10, "potion", 10, 1001);
                                    Console.WriteLine("You have slain {0}!", NormalEnemy);
                                    Console.WriteLine("You have gained {0} xp from slaying {1}.", NormalEnemy.EnemyXP, NormalEnemy);
                                    Console.WriteLine("You pick up a {0} from slaying {1}.", potion, NormalEnemy);
                                    //inventory.AddItem(potion);

                                    character.addXP(NormalEnemy.EnemyXP);

                                    NormalEnemy = null;

                                    Console.WriteLine("Your current xp is {0}", character.PlayerCurrentXP);

                                    Console.WriteLine("You need {0} xp in order to level up.", (character.PlayerNextLevelXP - character.PlayerCurrentXP));
                                    //Consider removing this line in future...
                                }
                                else if (character.PlayerHealth == 0)
                                {
                                    Console.WriteLine("You have died...");
                                    isDead = true;
                                }

                                break;
                            }

                        default:
                            {
                                Console.WriteLine("Nothing has happened");
                                break;
                            }
                        }

                    if (isDead == true)
                    {
                        Console.WriteLine("You are now dead. Please reload the game or create a new character.");
                        Thread.Sleep(5000);
                        Environment.Exit(1);
                    }

                    ClearLine();
                }
            } while (true);           
        }

        public static void ClearLine()
        {
            Console.WriteLine("");
        }

        private static string AskPlayer(int decision)
        {
            string action = "";
            string response = "";
            string actions = "";

            if (decision == 0)
            {
                Console.WriteLine("Please perform an action.");
                ClearLine();
                action = Console.ReadLine();
                response = action;
            }
            else if (decision == 1)
            {
                Console.WriteLine("How many actions would you like to perform?");
                ClearLine();
                actions = Console.ReadLine();
                response = actions;
            }

            return response;
        }

        //Commands to add to list: inventory(inv), attack commands list(combat), 
        //Place attack commands list in another list.
        /*
         * If a file is not present, make sure to check the bin/Debug directory for the text file commands.txt. This must be present or an exception will be thrown.
         * There should be a number at the top to represent the number of lines below it.
         * For example,
         *  4
         *  abc
         *  def
         *  g
         *  hijklkmanafjdijfdij
        */
        private static void ShowCommands()
        {
            string commandFile = "commands.txt";
            FileIO fileHandler = new FileIO();

            string[] commands = fileHandler.ReadLines(commandFile);

            Commands[] listOfCommands = new Commands[NUMBER_OF_COMMANDS];
            for (int i = 0; i < NUMBER_OF_COMMANDS; i++)
            {
                int number = i;
                listOfCommands[i] = new Commands(commands[i], number);
            }

            Console.WriteLine("In order to perform an action, you must type in a command.");
            Console.WriteLine("The available actions are as follows: ");

            for (int i = 0; i < NUMBER_OF_COMMANDS; i++)
            {
                Console.WriteLine("{0}", listOfCommands[i]);
            }

            Console.WriteLine("Make sure to type commands all in lowercase with no spaces.");
            //Console.ReadKey();
        }

        public static int randomizer(Random dice, bool menuAction)
        {
            int outcome = 0;

            if(menuAction == false)
            {
                outcome = dice.Next(1, 1);
            }
                        
            return outcome;
        }

        public static Objects.Item[] createTestItems()
        {            
            Item potion = new Aid("Potion", 10, "potion", 10, 1001);
            Item longsword = new Weapons("Longsword", 100, "sword", 1, 10, 2001);
            Item shield = new DefensiveArm("Shield", 50, "shield", 10, 3001);
            Item chestplate = new Armour("Chestplate", 500, "chestplate", 50, "torso", 4001);
            Item platelegs = new Armour("Platelegs", 350, "platelegs", 35, "legs", 4002);
            Item pauldrons = new Armour("Pauldrons", 350, "gloves", 35, "arms", 4003);
            Item helmet = new Armour("Helmet", 250, "helmet", 25, "head", 4004);
            Item[] listOfItems = new Item[] { potion, longsword, shield, chestplate, platelegs, pauldrons, helmet};
            return listOfItems;
        }

        /*
        public void Dispose()
        {
            throw new NotImplementedException();
        }*/
    }
    
}
