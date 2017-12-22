using System;
using System.Collections.Generic;
using Objects;
using TextAdventure;


namespace Character
{
    //Create one whole inventory first then branch out and have 6 lists
    //Add an array one main inventory and then more specific inventory lists
    public class Inventory
    {
        private List<Item> all;
        private int numberOfItems;
        //private CharacterBase mainCharacter;

        public Inventory()
        {
            all = new List<Item>();
            numberOfItems = 0;
            //mainCharacter = player;
        }
        
        //Modify later to manipulate quanity rather than have another object in List.- DONE
        //Ensure to watch AddItem function in future as there is possibility for ArgumentOutOfRange Exception
        public void AddItem(Objects.Item item)
        {
            bool itemInInventory = false;
            for(int i=0; i<numberOfItems; i++)
            {
                if (item.ItemNumber == all[i].ItemNumber)
                {
                    all[i].Quantity++;
                    itemInInventory = true;
                }
            }

            if(!itemInInventory)
            {
                all.Add(item);
                numberOfItems++;
            }          
        }

        public void RemoveItem(Item item, int index, int numberToRemove)
        {
            Console.WriteLine("You throw away {0} {1}", numberToRemove, all[index]);
            if (numberToRemove < item.Quantity)
            {
                item.Quantity = item.Quantity - numberToRemove;
            }
            else
            {
                all.RemoveAt(index);
                numberOfItems--;
            }            
        }

        //Start with single stat restore/boost before addding in multiple values at once
        //Specify item type and restore type to match with character stat.


        public void EquipItem(CharacterBase character, Item item)
        {
            if (item.Equippable)
            {
                if (item.ItemType.Equals("Primary"))
                {
                    
                }
                else if (item.ItemType.Equals("Secondary"))
                {

                }
                else if (item.ItemType.Equals("Armour"))
                {

                }
                //Set data structure to link body parts and equippable items
                //Concat equipment names to body parts ( Right Arm-- Longsword )
                //Show stat increases/decreases
            }
            else
            {
                Console.WriteLine("You cannot equip this item");
            }
        }

        /*
        public void SortInventory()
        {

        }
        */

        //Receive user input to enter/exit inventory-- DONE
        //Detect user keypress to traverse inventory-- DONE

        public void TraverseInv()
        {
            bool leaveInventory = false;
            // sameKeyPressed = false;
            ConsoleKeyInfo key;
            int currentItem = 0;
            int sameKey = 0;

            Console.WriteLine("INVENTORY");
            Console.WriteLine("=========================================================================");
            Test.ClearLine();

            for (int i=0; i<numberOfItems; i++)
            {
                Console.WriteLine(" {0}-- {1}       x{2}", i, all[i], all[i].Quantity);
                
            }

            Console.WriteLine("=========================================================================");
            Console.WriteLine("=");
            Console.WriteLine("=");
            Console.WriteLine("=");
            Console.WriteLine("=========================================================================");

            Console.WriteLine("Current Item: {0}       x{1}", all[currentItem], all[currentItem].Quantity);

            do
            {
                //Console.WriteLine("Ready");
                if (currentItem < numberOfItems && currentItem >= 0)
                {
                    /*
                     * If a key is pressed, mark it with either 1 or 2. This mark will determine whether a key gets pressed again. If the key changes, the mark attached to the key will change as well.
                     * If a key is being spammed, no output will come out because the mark will determine whether output will be released or not.                   
                     */


                    key = Console.ReadKey();

                    if (key.Key == ConsoleKey.DownArrow)
                    {                      
                        if (currentItem == (numberOfItems - 1))
                        {
                            if (sameKey != 1)
                            {
                                //Console.WriteLine("You can't go down any further");
                                //Console.WriteLine("=========================================================================");
                                Test.ClearLine();
                                sameKey = 1;
                            }
                            else
                            {
                                //Console.WriteLine("");
                            }
                            
                        }
                        else
                        {
                            currentItem++;
                            Console.WriteLine("Current Item: {0}       x{1}", all[currentItem], all[currentItem].Quantity);
                            Console.WriteLine("=========================================================================");
                            Test.ClearLine();
                            //Console.WriteLine(" {0}-- {1}       x{2}", currentItem, all[currentItem], all[currentItem].Quantity);
                        }
                    }
                    else if (key.Key == ConsoleKey.UpArrow)
                    {                       
                        if (currentItem == 0)   
                        {
                            if (sameKey != 2)
                            {
                                //Console.WriteLine("You can't go up any further");
                                //Console.WriteLine("=========================================================================");
                                Test.ClearLine();
                                sameKey = 2;
                            }
                            else
                            {
                                //Console.WriteLine("");
                            }
                        }
                        else
                        {
                            currentItem--;
                            Console.WriteLine("Current Item: {0}       x{1}", all[currentItem], all[currentItem].Quantity);
                            Console.WriteLine("=========================================================================");
                            Test.ClearLine();
                            //Console.WriteLine("{0}-- {1}       x{2}", currentItem, all[currentItem], all[currentItem].Quantity);
                        }
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        int choice = 0;
                        //bool actedOnItem = false;
                        bool finishedWithItem = false;
                        int sameKeyPressed = 0;

                        Test.ClearLine();
                        Console.WriteLine("What would you like to do?");
                        Console.WriteLine("=========================================================================");
                        Console.WriteLine("=");
                        Console.WriteLine("=");
                        Console.WriteLine("=");
                        Console.WriteLine("=========================================================================");
                        Console.WriteLine("1. Use");
                        Console.WriteLine("2. Remove");
                        //Add in functions to delete or use items (2 element array)
                        //Consider moving Use to only be done by player.

                        do
                        {
                            //Console.WriteLine("Ready");
                            //Console.WriteLine("=========================================================================");
                            key = Console.ReadKey();

                            if (key.Key == ConsoleKey.DownArrow)
                            {
                                if (sameKeyPressed != 1)
                                {
                                    Console.WriteLine("Currently Selected: Use");
                                    Console.WriteLine("=========================================================================");
                                    Test.ClearLine();
                                    sameKeyPressed = 1;
                                }
                                else
                                {
                                    //Console.WriteLine("");
                                }                               
                                choice = 0;                               
                            }

                            else if (key.Key == ConsoleKey.UpArrow)
                            {
                                if (sameKeyPressed != 2)
                                {
                                    Console.WriteLine("Currently Selected: Remove");
                                    Console.WriteLine("=========================================================================");
                                    Test.ClearLine();
                                    sameKeyPressed = 2;
                                }
                                else
                                {
                                    //Console.WriteLine("");
                                }
                                choice = 1;
                            }

                            else if (key.Key == ConsoleKey.Enter)
                            {
                                //actedOnItem = true;
                                //Console.WriteLine("You pressed enter");
                                if (choice == 0)
                                {
                                    //Aid.UseItem(mainCharacter, all[currentItem]);

                                    /*
                                     * Change around dependencies so that character class will be one public class with other class as private additions (classes). In this case, move
                                     * UseItem function to character class. In fact, inventory class should be private class of character. 
                                    */

                                }
                                else if (choice == 1)
                                {
                                    int itemsToDelete;
                                    string yesOrNo = "";

                                    Console.WriteLine("Are you sure you want to throw away this item?");
                                    yesOrNo = Console.ReadLine();
                                    if (yesOrNo.Equals("yes") || yesOrNo.Equals("y"))
                                    {
                                        Console.WriteLine("How many items would you like to remove?");
                                        itemsToDelete = Convert.ToInt32(Console.ReadLine());
                                        //Console.WriteLine("Loading. Please wait a moment.");
                                        RemoveItem(all[currentItem], currentItem, itemsToDelete);
                                        
                                    }
                                    else
                                    {
                                        //do nothing
                                        Console.WriteLine("Cancelled.");
                                        Test.ClearLine();
                                        //Console.WriteLine("Loading. Please wait a moment.");
                                    }
                                }
                            }

                            else if (key.Key == ConsoleKey.Q)
                            {
                                finishedWithItem = true;
                                Console.WriteLine("You return the item to your inventory.");
                                //Console.WriteLine("Loading. Please wait a moment.");
                                //actedOnItem = true;
                                choice = 2;                               
                            }
                        } while (finishedWithItem == false);                      
                    }

                    else if (key.Key == ConsoleKey.Q)
                    {
                        string decision;
                        Console.WriteLine("Are you finished with your inventory?");
                        decision = Console.ReadLine();
                        if (decision.Equals("yes") || decision.Equals('y'))
                        {
                            leaveInventory = true;
                            Console.WriteLine("You leave your inventory.");
                            //Console.WriteLine("Loading. Please wait a moment");
                        }
                        else
                        {
                            leaveInventory = false;
                            Console.WriteLine("You continue looking at your inventory.");
                            //Console.WriteLine("Loading. Please wait a moment");
                        }
                    }
                }                
            } while (leaveInventory == false);

        }
    }
}
