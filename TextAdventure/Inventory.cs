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
        private int quantity;

        public Inventory()
        {
            all = new List<Item>();
            numberOfItems = 0;
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public void AddItem(Item item)
        {
            all.Add(item);
            numberOfItems++;
        }

        public void RemoveItem(int index)
        {
            all.RemoveAt(index);
        }

        /*
        public void SortInventory()
        {

        }
        */

        //Receive user input to enter/exit inventory
        //Detect user keypress to traverse inventory
        public void TraverseInv()
        {
            bool leaveInventory = false;
            ConsoleKeyInfo key;
            int currentItem = 0;

            do
            {
                key = Console.ReadKey();
                Console.WriteLine("{0}-- {1}", currentItem, all[currentItem]);
                if (key.Key == ConsoleKey.DownArrow)
                {
                    if (currentItem < numberOfItems)
                    {
                        currentItem++;
                        Console.WriteLine("{0}-- {1}", currentItem, all[currentItem]);
                    }
                    else if(currentItem >= numberOfItems)
                    {
                        Console.WriteLine("You are at the maximum number of items. You cannot go down further.");
                    }
                }
                else if(key.Key == ConsoleKey.UpArrow)
                {
                    if (currentItem >= 0)
                    {
                        currentItem--;
                        Console.WriteLine("{0}-- {1}", currentItem, all[currentItem]);
                    }
                    else if (currentItem < 0)
                    {
                        Console.WriteLine("You are at the first item. You cannot go up further.");
                    }
                }
                else if(key.Key == ConsoleKey.Escape)
                {
                    leaveInventory = true;
                }
            } while (leaveInventory == false);

        }
    }
}
