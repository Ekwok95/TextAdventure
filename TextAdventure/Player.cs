﻿using System;
using System.Threading;
using System.Windows.Forms;

//Created by Bryan Kwok Zhe Jian on 1/3/2017.

/* Timestamp and completed features.
 * 1/3/2017- Created base command system, player class and basic functions and actions.
 * 2/3/2017- Added commands, toString for objects, file I/O systems and help menu.
 * 3/3/2017- Finished the save file and player profile feature
 * 5/3/2017- Finished implementing the base enemy class and interface methods for attack and defend.
 * 6/3/2017- Started on Enemy class. Implemented abstract base class and 2 interfaces for attack and defend abilities.
 * 7/3/2017- Adjusted classes. Moved IO methods to FileIO class. Accomplished basic combat. Accomplished simple leveling system (without xp algorithm). 
 *          Completed death system- Player needs to reload save game or create a new character. Can adjust settings later.
 * 
*/

/*
 * All action steps will involve creating commands for each action. Make commands no more than 20 characters unless this length is too short.
 *
 * * To do:
 * - Player save file and list- Done; Included a main menu.
 * - Enemy class- Can possibly split between evil NPCs and wild monsters.... - Basic enemy class done
 * - Enemy types- Normal enemies first. Add in bosses and boss room scenarios later....
 * - Set player stats also.... - Attack and Defence stats tested and works. Attempt to use generics later.
 * - Combat actions - Attack and Defend commands done.
 * - Death system - Complete. Needs tweaking however.
 * - Level and experience system- Set enemies to be within suitable level range (not too high or low unless player stumbles into a high level area)- 
 *         - Basic levelling system complete.
 *         - Need to figure out xp algorithm soon. Will attempt this at a later time.
 *      - NO LEVEL CAP :D
 * - Create character classes (No magic characters. Physical weapons only. Can add enchant feature for weapons to reduce player disadvantage)
 *      - Have classes share SOME abilities, not all.
 *      - Create all abilities in advance.
 *      - Use binary tree to allow skill/advanced class tiers
 * - Armor and weapon types (Tiers and linked lists)- Set weapon stats to have a reasonable range(So that weapons don't become OP or UP).
 * - Weapon combos and abilities- Add in energy/MP field to be adjusted according to abilities as they are done.
 * - Item Lists/Items- Gradually add to base list as game is being developed.
 * - Finishing moves- Will consider this after 
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
 * - Difficulty Levels :P (Will consider it. No promises though.)
 * - Boss mechanics 0_0
 * - Playtime- Use Stopwatch class methods and Stopwatch.Elapsed method then write this timestamp to file.
 *      - Retrive timestamp and add onto new elapsed time.
 * - Achievements
*/

namespace TextAdventure
{
    public class Player : Enemy.IDefend
    {
        private string name;
        private int hp;
        private int attack;
        private int defence;
        private int currentXP;
        private int requiredXP;
        private int currentLevel;
        //public string characterClass;

        public Player(string nm)
        {
            name = nm;
            hp = 50;
            attack = 10;
            defence = 10;
            currentXP = 0;
            requiredXP = 100;
            currentLevel = 1;
        }

        public int PlayerHealth
        {
            get { return hp; }
            set { hp = value; }
        }

        public int PlayerAttack
        {
            get { return attack; }
            set { attack = value; }
        }

        public int PlayerDefence
        {
            get { return defence; }
            set { defence = value; }
        }

        public int PlayerCurrentXP
        {
            get { return currentXP; }
            set { currentXP = value; }
        }

        public int PlayerNextLevelXP
        {
            get { return requiredXP; }
            set { requiredXP = value; }
        }

        public int PlayerLevel
        {
            get { return currentLevel; }
            set { currentLevel = value; }
        }
        public override string ToString()
        {
            return name;
        }

        public void Fight(Enemy.GeneralEnemy enemy, int enemyHP, int attack, int defence)
        {
            int damage = attack - defence;
            enemyHP = enemyHP - damage;
            Console.WriteLine("You damage {0} for {1} damage.", enemy, damage);
            enemy.EnemyHealth  = enemyHP;
            Console.WriteLine("{0} now has {1} HP.", enemy, enemy.EnemyHealth);
        }

        public void Guard()
        {
            Console.WriteLine("You block {0}'s attack!");
        }

        public void CheckCondition()
        {
            Console.WriteLine("Your current HP is {0}.", hp);
        }

        public void addXP(int xpDrop)
        {
            int attackUp = 5;
            int defenceUp = 2;
            currentXP = currentXP + xpDrop;
            if(currentXP >= requiredXP)
            {
                currentLevel++;
                attack = attack + attackUp;
                defence = defence + defenceUp;
                Console.WriteLine("You have leveled up! Congratulations!");
                Console.WriteLine("Attack +{0}", attackUp);
                Console.WriteLine("Defence +{0}", defenceUp);
            }
        }
    }

    public class Test //: IDisposable
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
            string intention, direction = "", temp = "", name = "";
            int steps = 0;
            bool justLoggedIn = true;

            ClearLine();
            
            Console.WriteLine("Enter name pls");
            name = Console.ReadLine();
            Player character = new Player(name);
            

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
                }

                /*
                if (intention.Equals("lookaround"))
                {
                    //Set random number depending on area and situation

                    //After further development, change this line to include multiple situations of similar scenarios.
                    Console.WriteLine("You look around and spot {0}.");
                }*/

                //Consider making sight/perception class....

                //Combat actions....

                //

                if (intention.Equals("walk"))
                {
                    temp = AskPlayer(1);
                    steps = Int32.Parse(temp);//use try keyword here just in case someone uses word instead of number.
                    Console.WriteLine("Which direction would you like to walk towards?");
                    direction = Console.ReadLine();
                    setOfActions.Walk(steps, direction);
                }
                /*
                if (intention.Equals("run"))
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

                randomEncounter = randomizer(dice);


                switch (randomEncounter)
                {
                    case 1:
                        {
                            string response = "";
                            Console.WriteLine("You encounter an enemy!");

                            Enemy.GeneralEnemy NormalEnemy = new Enemy.GeneralEnemy("Enemy", "Grunt", "Easy", 50, 5, 5, 50);
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
                                if(enemyChoice > 50 && enemyChoice < 101 )
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
                                else
                                { 
                                        //{
                                            NormalEnemy.Guard();
                                            isDefending = true;
                                            //break;
                                        //}
                                }

                                ClearLine();

                            } while (character.PlayerHealth > 0 && NormalEnemy.EnemyHealth > 0);

                            if (NormalEnemy.EnemyHealth == 0)
                            {
                                Console.WriteLine("You have slain {0}!", NormalEnemy);
                                character.addXP(NormalEnemy.EnemyXP);
                                Console.WriteLine("You have gained {0} xp from slaying {1}.", NormalEnemy.EnemyXP, NormalEnemy);

                                NormalEnemy = null;

                                Console.WriteLine("Your current xp is {0}", character.PlayerCurrentXP);

                                Console.WriteLine("You need {0} xp in order to level up.", (character.PlayerNextLevelXP-character.PlayerCurrentXP));
                                //Consider removing this line in future...
                            }
                            else if(character.PlayerHealth == 0)
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

                if(isDead == true)
                {
                    Console.WriteLine("You are now dead. Please reload the game or create a new character.");
                    Thread.Sleep(5000);
                    Environment.Exit(1);
                }

                ClearLine();
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

        private static void ShowCommands()
        {
            string commandFile = "commands.txt";
            FileIO fileHandler = new FileIO();

            string[] commands = fileHandler.ReadLines(commandFile);
                
            Commands[] listOfCommands = new Commands[NUMBER_OF_COMMANDS];
            for(int i = 0; i < NUMBER_OF_COMMANDS; i++)
            {
                int number = i;
                listOfCommands[i] = new Commands(commands[i], number);
            }

            Console.WriteLine("In order to perform an action, you must type in a command.");
            Console.WriteLine("The available actions are as follows: ");

            for (int i=0;i<NUMBER_OF_COMMANDS;i++)
            {
                Console.WriteLine("{0}", listOfCommands[i]);
            }

            Console.WriteLine("Make sure to type commands all in lowercase with no spaces.");
            //Console.ReadKey();
        }

        public static int randomizer(Random dice)
        {
            int outcome;       
            outcome = dice.Next(1, 1);
            return outcome;
        }

        /*
        public void Dispose()
        {
            throw new NotImplementedException();
        }*/
    }  
}