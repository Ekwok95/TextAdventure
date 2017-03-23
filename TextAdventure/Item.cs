using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    public interface Condition
    {
        //void Condition(Item item);
        void Condition();
    }

    public abstract class Item
    {
        private string name;
        private int iValue;
        protected string itemType;
        private bool equippable;
        private int quantity;
        //public string description;
        //private int weight;

        public Item(string itemName, int itemValue, bool equippable, int iQuantity   /*, string itemDesc, int itemWeight*/)
        {
            name = itemName;
            iValue = itemValue;
            quantity = iQuantity;
            //description = itemDesc;
            //weight = itemWeight;
        }

        public string ItemName
        {
            get { return name; }
            set { name = value; }
        }
        
        public int ItemValue
        {
            get { return iValue; }
            set { iValue = value; }
        }

        public bool Equippable
        {
            get { return equippable; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public override string ToString()
        {
            return name;
        }
    }

    public class Weapons : Item, Condition
    {
        private string weaponType;
        private string arm;
        //private int[] attackPower;
        private int attackPower;
        private int weaponSpeed;
        private int condition;

        public Weapons(string itemName, int itemValue, string type, int speed, int weaponDamage, int quantity) : base(itemName, itemValue, true, quantity)
        {
            itemType = "Primary";
            weaponType = type;
            weaponSpeed = speed;
            arm = "Right";
            attackPower = weaponDamage;
            condition = 100;
        }

        public string ItemType
        {
            get { return itemType; }
            set { itemType = value; }
        }

        public string WeaponType
        {
            get { return weaponType; }
            set { weaponType = value; }
        }

        public int WeaponDamageRange
        {
            get { return attackPower; }
            set { attackPower = value; }
        }

        public int WeaponSpeed
        {
            get { return weaponSpeed; }
            set { weaponSpeed = value; }
        }

        public int WeaponCondition
        {
            get { return condition;}
            set { condition = value; }
        }

        public void Condition()
        {
            if ((condition <= 100) && (condition >= 76))
            {
                Console.WriteLine("Your weapon is in an excellent condition");
            }
            else if ((condition <= 75) && (condition >= 51))
            {
                Console.WriteLine("Your weapon is in a good condition");
            }
            else if ((condition <= 50) && (condition <= 26))
            {
                Console.WriteLine("Your weapon is starting to lose quality. Consider repairing it");
            }
            else if ((condition <= 25) && (condition >= 0))
            {
                Console.WriteLine("Your weapon looks like it is about to fall apart. Caution.");
            }
            else if ((condition == 0))
            {
                Console.WriteLine("Your weapon is now broken. Either fix it or toss it away.");
            }
        }

        /*
        public int[] WeaponDamageRange
        {
            get { return attackPower; }    
            set { attackPower = value; }
        }
        */

        /*
        public int[] setAttackPower(int lowNumber, int highNumber)
        {
            int[] attackPowerRange = new int[] { lowNumber, highNumber };
            return attackPowerRange;
        }
        */
    }

    //Consider dual wield and 2h classes also
    public class DefensiveArm : Item, Condition
    {
        private string armType;
        private int defence;
        private string arm;
        private int condition;

        public DefensiveArm(string itemName, int itemValue, string type, int armsDefence, int quantity) : base(itemName, itemValue, true, quantity)
        {
            itemType = "Secondary";
            armType = type;
            defence = armsDefence;
            arm = "Left";
            condition = 100;
        }

        public string ItemType
        {
            get { return itemType; }
            set { itemType = value; }
        }

        public string ArmsType
        {
            get { return armType; }
            set { armType = value; }
        }

        public int ArmsDefence
        {
            get { return defence; }
            set { defence = value; }
        }

        public int WeaponCondition
        {
            get { return condition; }
            set { condition = value; }
        }

        public void Condition()
        {
            if ((condition <= 100) && (condition >= 76))
            {
                Console.WriteLine("Your armament is in an excellent condition");
            }
            else if ((condition <= 75) && (condition >= 51))
            {
                Console.WriteLine("Your armament is in a good condition");
            }
            else if ((condition <= 50) && (condition <= 26))
            {
                Console.WriteLine("Your armament is starting to lose quality. Consider repairing it");
            }
            else if ((condition <= 25) && (condition >= 0))
            {
                Console.WriteLine("Your armament looks like it is about to fall apart. Caution.");
            }
            else if ((condition == 0))
            {
                Console.WriteLine("Your armament is now broken. Either fix it or toss it away.");
            }
        }
    }

    public class Armour : Item, Condition
    {
        private string armourType;
        private string armourPosition;
        private int armourDefence;
        //private int xResistance;
        private int condition;
        
        public Armour(string itemName, int itemValue, string type, int defence, string bodyPart, int quantity) : base(itemName, itemValue, true, quantity)
        {
            itemType = "Armour";
            armourType = type;
            armourPosition = bodyPart;
            armourDefence = defence;
            condition = 100;
        }
        
        public string ArmourType
        {
            get { return armourType; }
        } 

        public int ArmourDefence
        {
            get { return armourDefence; }
            //set { armourDefence = value; }
        }

        public string ArmourPosition
        {
            get { return armourPosition; }
        }


        public void Condition()
        {
            if ((condition <= 100) && (condition >= 76))
            {
                Console.WriteLine("This armour piece is in an excellent condition");
            }
            else if ((condition <= 75) && (condition >= 51))
            {
                Console.WriteLine("This armour piece is in a good condition");
            }
            else if ((condition <= 50) && (condition <= 26))
            {
                Console.WriteLine("This armour piece is starting to lose quality. Consider repairing it");
            }
            else if ((condition <= 25) && (condition >= 0))
            {
                Console.WriteLine("This piece of armour looks like it is about to fall apart. Caution.");
            }
            else if ((condition == 0))
            {
                Console.WriteLine("This piece of armour is now broken. Either fix it or toss it away.");
            }
        }
    }

    //add additional diversity class (statboost, healing, etc...)
    //Test item will be a potion (50 hp). Can adjust to heal percentages later...
    public class Aid : Item
    {
        private string aidType;
        private int recoveryAmount;

        public Aid(string itemName, int itemValue, int quantity, string type, int restoreVolume) : base(itemName, itemValue, false, quantity)
        {
            aidType = type;
            recoveryAmount = restoreVolume;
        }

        public string AidType
        {
            get { return aidType; }
        }

        public int RestorationVolume
        {
            get { return recoveryAmount; }
            set { recoveryAmount = value; }
        }
    }

    /*Attempt this when doing crafting system
    public class Materials : Item
    {

    }
    */

    /*Attempt this when making quests
    public class KeyItem : Item
    {

    }
    */
    public class ItemFunctions
    {
        /*
        public void Condition(Item item)
        {
            if ((condition <= 100) && (condition >= 76))
            {
                Console.WriteLine("Your armament is in an excellent condition");
            }
            else if ((condition <= 75) && (condition >= 51))
            {
                Console.WriteLine("Your armament is in a good condition");
            }
            else if ((condition <= 50) && (condition <= 26))
            {
                Console.WriteLine("Your armament is starting to lose quality. Consider repairing it");
            }
            else if ((condition <= 25) && (condition >= 0))
            {
                Console.WriteLine("Your armament looks like it is about to fall apart. Caution.");
            }
            else if ((condition == 0))
            {
                Console.WriteLine("Your armament is now broken. Either fix it or toss it away.");
            }
        }*/

        public void ThrowAway(Item item)
        {
            item = null;
        }

        public void Equip(Item item, CharacterBase character)
        {
            if (item.Equippable)
            {
                //character.PlayerAttack = item.
            }
        }
    }
    
}
