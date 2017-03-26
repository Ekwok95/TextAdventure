using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    //Create one whole inventory first then branch out and have 6 lists
    //Add an array one main inventory and then more specific inventory lists
    public class Inventory
    {
        private List<Item> all;
        private int numberOfItems;

        public Inventory()
        {
            all = new List<Item>();
            numberOfItems = 0;
        }
        
        //Modify later to manipulate quanity rather than have another object in List.- DONE
        //Ensure to watch AddItem function in future as there is possibility for ArgumentOutOfRange Exception
        public void AddItem(Item item)
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
        public void UseItem(CharacterBase character, Aid item)
        {
            int statRestore = item.RestorationVolume;
            character.PlayerHealth = character.PlayerHealth + statRestore;               
        }

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
            ConsoleKeyInfo key;
            int currentItem = 0;
            
            do
            {
                Console.WriteLine(" {0}-- {1}       x{2}", currentItem, all[currentItem], all[currentItem].Quantity);
                if (currentItem < numberOfItems && currentItem >= 0)
                {
                    key = Console.ReadKey();

                    if (key.Key == ConsoleKey.DownArrow)
                    {
                        if (currentItem == (numberOfItems - 1))
                        {
                            //Console.WriteLine("You can't go down any further");
                        }
                        else
                        {
                            currentItem++;
                            //Console.WriteLine(" {0}-- {1}       x{2}", currentItem, all[currentItem], all[currentItem].Quantity);
                        }
                    }
                    else if (key.Key == ConsoleKey.UpArrow)
                    {
                        if (currentItem == 0)
                        {
                            //Console.WriteLine("You can't go up any further");
                        }
                        else
                        {
                            currentItem--;
                           //Console.WriteLine("{0}-- {1}       x{2}", currentItem, all[currentItem], all[currentItem].Quantity);
                        }
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        Test.ClearLine();
                        Console.WriteLine("What would you like to do?");
                        //Add in functions to delete or use items (2 element array)

                        int choice = 0;
                        bool actedOnItem = false;

                        do
                        {
                            key = Console.ReadKey();

                            if (key.Key == ConsoleKey.DownArrow)
                            {
                                Console.WriteLine("Use");
                                choice = 0;                               
                            }

                            else if (key.Key == ConsoleKey.UpArrow)
                            {
                                Console.WriteLine("Remove");
                                choice = 1;
                            }

                            else if (key.Key == ConsoleKey.Enter)
                            {
                                actedOnItem = true;
                                //Console.WriteLine("You pressed enter");
                            }

                            else if (key.Key == ConsoleKey.Escape)
                            {
                                actedOnItem = true;
                            }
                        } while (actedOnItem == false);

                        if (choice == 0)
                        {
                            //UseItem();                            
                        }
                        else if (choice == 1)
                        {
                            int itemsToDelete;
                            Console.WriteLine("How many items would you like to remove?");
                            itemsToDelete = Convert.ToInt32(Console.ReadLine());
                            RemoveItem(all[currentItem], currentItem, itemsToDelete);
                        }                        
                    }
                    else if (key.Key == ConsoleKey.Escape)
                    {
                        string decision;
                        Console.WriteLine("Are you finished with your inventory?");
                        decision = Console.ReadLine();
                        if (decision.Equals("yes") || decision.Equals('y'))
                        {
                            leaveInventory = true;
                        }
                        else
                        {
                            leaveInventory = false;
                        }
                    }
                }                
            } while (leaveInventory == false);

        }
    }
}
