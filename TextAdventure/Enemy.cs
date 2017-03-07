using System;

namespace TextAdventure
{
    public class Enemy
    {
        /*
         * Set EnemyBase as an abstract class...
         * Include abstract methods such as attack, guard, dodge, run....
         * Use interfaces for multiple enemy types....
        */

        //Implement stab, slash and crush attacks as interfaces
        public interface IOffense
        {
            int Attack(int playerHP, int attack, int defence);
            //void Dodge(); Might consider placing this with specific enemy types.
            //void Run(); For certain enemies
        }

        //Implement parry and dodge interfaces later
        public interface IDefend
        {
            void Guard(); //For certain enemies
        }

        public abstract class EnemyBase
        {
            protected string enemyName;
            protected string enemyClass;
            protected string enemyRank;
            protected int hp;
            protected int attackStat;
            protected int defenceStat;
            protected int expDrop;
            protected int enemyLevel;


            public EnemyBase()
            {
                enemyName = "enemy";
                enemyClass = "class";
                enemyRank = "rank";
                hp = 0;
                attackStat = 0;
                defenceStat = 0;
                expDrop = 0;
            }

            /*
             * Setting mutators and accesssors
            */

            public abstract int EnemyHealth
            {
                get;
                set;
            }
            public abstract int EnemyAttackPower
            {
                get;
                set;
            }
            public abstract int EnemyDefencePower
            {
                get;
                set;
            }
            public abstract int EnemyLevel
            {
                get;
                set;
            }
            public abstract int EnemyXP
            {
                get;
                set;
            }
        }

        //Implement interfaces apart from base classes...
        public class GeneralEnemy : EnemyBase, IOffense, IDefend
        {
            public GeneralEnemy(string name, string type, string rank, int health, int attack, int defence, int exp) : base()
            {
                enemyName = name;
                enemyClass = type;
                enemyRank = rank;
                hp = health;
                attackStat = attack;
                defenceStat = defence;
                expDrop = exp;
            }

            public override int EnemyHealth
            {
                get
                {
                    return hp;
                }
                set
                {
                    hp = value;
                }
            }

            public override int EnemyAttackPower
            {
                get
                {
                    return attackStat;
                }

                set
                {
                    attackStat = value;
                }
            }

            public override int EnemyDefencePower
            {
                get
                {
                    return defenceStat;
                }

                set
                {
                    defenceStat = value;
                }
            }
            public override int EnemyLevel
            {
                get
                {
                    return enemyLevel;
                }

                set
                {
                    enemyLevel = value;
                }
            }
            public override int EnemyXP
            {
                get
                {
                    return expDrop;
                }
                set
                {
                    expDrop = value;
                }
            }

            public override string ToString()
            {
                return enemyName;
            }

            public int Attack(int playerHP, int enemyAttack, int playerDefence)
            {
                int damage = enemyAttack - playerDefence;
                playerHP = playerHP - damage;
                Console.WriteLine("You are damaged for {0} HP.", damage);
                return playerHP;
            }

            public void Guard()
            {
                Console.WriteLine("The {0} attempts to block your attack!", enemyName);
            }
        }
    }
}
