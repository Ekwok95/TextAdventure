using System;
using Opponent;
using Objects;

namespace Character
{   
    /*
     * Merge Player class with Equipment and Inventory Classes to prevent dependency requirement
    */


    public abstract class CharacterBase
    {          
        protected string name;                 
        protected int currentXP; //Create function to set algorithm for required xp
        protected int requiredXP;
        protected int currentLevel;
        protected int hp;
        protected int attack;
        protected int defence;
        protected int[] primaryWeaponDamage;
        protected Inventory inventory;
        protected Equipment equipment;


        //Can probably adjust to hold any weapon but give advantages if weapon matches class specification...       

        public CharacterBase(string user, Inventory playerItems, Equipment playerEquips)
        {
            name = user;
            currentXP = 0;
            requiredXP = 100;
            currentLevel = 1;
            inventory = playerItems;
            equipment = playerEquips;
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

        public Inventory PlayerInventory
        {
            get { return inventory; }
            //set { inventory = value; }
        }

        public Equipment PlayerEquips
        {
            get { return equipment; }
            //set { equipment = value; }
        }

        public override string ToString()
        {
            return name;
        }

        public void CheckCondition()
        {
            Console.WriteLine("Your current HP is {0}.", hp);
        }

        public void UseItem(Item item)
        {
            if(item.ItemType.Equals("Aid"))
            {
                restoreHP((Objects.Aid)item);
            }
        }

        public void ShowStats()
        {
            Console.WriteLine("HP-- {0}", PlayerHealth);
            Console.WriteLine("Attack-- {0}", PlayerAttack);
            Console.WriteLine("Defence-- {0}", PlayerDefence);
            Console.WriteLine("Level-- {0}", PlayerLevel);
            Console.WriteLine("Current XP-- {0}", PlayerCurrentXP);
            Console.WriteLine("Required XP-- {0}", PlayerNextLevelXP);
        }

        public void addXP(int xpDrop)
        {
            int attackUp = 5;
            int defenceUp = 2;
            currentXP = currentXP + xpDrop;

            if (currentXP >= requiredXP)
            {
                currentLevel++;
                attack = attack + attackUp;
                defence = defence + defenceUp;
                Console.WriteLine("You have leveled up! Congratulations!");
                Console.WriteLine("Attack +{0}", attackUp);
                Console.WriteLine("Defence +{0}", defenceUp);
                requiredXPIncr();
                PlayerCurrentXP = 0;
            }
        }

        //Function OK..
        public void requiredXPIncr()
        {
            int requiredXP = 0;
            double nextLevelXP = 0.0;

            nextLevelXP = Convert.ToDouble(PlayerNextLevelXP);
            nextLevelXP = (nextLevelXP + (nextLevelXP * 1.5));
            requiredXP = Convert.ToInt32(nextLevelXP);
            PlayerNextLevelXP = requiredXP;
            Console.WriteLine("Required xp: {0}", PlayerNextLevelXP);
        }

        public int primaryWeapDamage()
        {
            Random dice = new Random();
            int actualDamage = dice.Next(primaryWeaponDamage[0], primaryWeaponDamage[1]);
            return actualDamage;
        }

        public int damageConvert(double multiplier)
        {
            int primaryDamage = primaryWeapDamage();    //Include a primaryDamage field in object 
            int damage = primaryDamage + attack;
            double temp = Convert.ToDouble(damage);
            temp = temp * multiplier;
            damage = Convert.ToInt32(temp);
            return damage;
        }

        private void restoreHP(Aid healing)
        {
            int statRestore = healing.RestorationVolume;
            PlayerHealth = PlayerHealth + statRestore;
            Console.WriteLine("You have recovered {0} HP.", statRestore);
            Console.WriteLine("Your HP is now {0}.", PlayerHealth);
        }


    }















    public class Swordsman : CharacterBase, Slash, ISwordsman
    {
        protected string className;
        protected string weaponType;
        protected string armorType;

        public Swordsman(string user, Inventory inv, Equipment equips) : base(user, inv, equips)
        {
            className = "Swordsman";
            weaponType = "Long Sword";
            armorType = "Heavy Armour";
            hp = 100;
            attack = 10;
            defence = 15;
            primaryWeaponDamage = new int[] { 10, 15 };
        }

        //Swordsman accessors

        public int[] PrimaryWeapon
        {
            get { return primaryWeaponDamage; }
            set { primaryWeaponDamage = value; }
        }

        //Defence

        public void Guard()
        {
            Console.WriteLine("You block {0}'s attack!");
        }

        //Attack

        //Change this function to attack or remove it.
        public void Fight(Enemy.GeneralEnemy enemy, int enemyHP, int attack, int defence)
        {

            int damage = attack - defence;

            enemyHP = enemyHP - damage;

            Console.WriteLine("You damage {0} for {1} damage.", enemy, damage);

            enemy.EnemyHealth = enemyHP;

            Console.WriteLine("{0} now has {1} HP.", enemy, enemy.EnemyHealth);

        }

        public int Slash(Enemy.GeneralEnemy enemy, CharacterBase character)
        {
            int damage = damageConvert(1.5);
            damage = damage - enemy.EnemyDefencePower;
            Console.WriteLine("You slash the {0} for {1} damage!", enemy, damage);
            return damage;
        }

        public int DoubleSlash(Enemy.GeneralEnemy enemy, CharacterBase character)     //Swings sword in 2 opposite directions eg. Left -> Right, Right -> Left
        {
            int damage = damageConvert(1.5);
            damage = damage*2;
            damage = damage - enemy.EnemyDefencePower;
            Console.WriteLine("You perform a double slash on {0} for {1} damage.", enemy, damage);
            return damage;
        }

        public int PowerLunge(Enemy.GeneralEnemy enemy, CharacterBase character)      //Pulls sword back and then thrusts sword forward with a powered stab 
        {
            int damage = damageConvert(2.0);
            damage = damage - enemy.EnemyDefencePower;
            Console.WriteLine("You perform a powered lunge on {0} for {1} damage.", enemy, damage);
            return damage;
        }

        /*
        public int ShieldBash(Enemy.GeneralEnemy enemy, CharacterBase character)   //Uses shield to stun/daze enemy
        {
            int damage = damag
        }
        */

        public int Bladespin(Enemy.GeneralEnemy enemy, CharacterBase character)     //Does a 360 degree spin with sword
        {
            int damage = damageConvert(0.75);
            damage = damage * 3;
            damage = damage - enemy.EnemyDefencePower;
            Console.WriteLine("You perform a spin attack on {0} for {1} damage.", enemy, damage);
            return damage;
        }


    }           
}
