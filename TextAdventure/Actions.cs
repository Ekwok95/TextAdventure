using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    public class Actions
    {
        public void Walk(int numberOfSteps, string direction)
        {
            Console.WriteLine("You walk {0} steps {1}.", numberOfSteps, direction);
        }

        public void PickUp(string item)
        {
            Console.WriteLine("You pick up a {0} and place it in your inventory.");
        }

        public void PickUp(string item, int number)
        {
            Console.WriteLine("You pick up {0} {1}s and place them in your inventory.");
        }

        
    }
}
