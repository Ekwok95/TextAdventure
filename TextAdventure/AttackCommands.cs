using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace TextAdventure
{
    public interface Slash
    {
        int Slash(Enemy.GeneralEnemy enemy, CharacterBase character);
    }

    public interface Stab
    {
        int Stab(Enemy.GeneralEnemy enemy, CharacterBase character);
    }

    public interface Crush
    {
        int Crush(Enemy.GeneralEnemy enemy, CharacterBase character);
    }

    public interface ISwordsman //Sword and Shield
    {
        int DoubleSlash(Enemy.GeneralEnemy enemy, CharacterBase character);     //Swings sword in 2 opposite directions eg. Left -> Right, Right -> Left
        int PowerLunge(Enemy.GeneralEnemy enemy, CharacterBase character);      //Pulls sword back and then thrusts sword forward with a powered stab 
        //int ShieldBash(Enemy.GeneralEnemy enemy, CharacterBase character);   //Uses shield to stun/daze enemy
        int Bladespin(Enemy.GeneralEnemy enemy, CharacterBase character);       //Does a 360 degree spin with sword
    }

    public interface IBladeKnight  //2H Sword
    {
        int DownwardSlash(Enemy.GeneralEnemy enemy, CharacterBase character);   //Bring down sword on enemy with 1 strike
        int HorizontalSwing(Enemy.GeneralEnemy enemy, CharacterBase character); //Does one swipe horizontally
        int GuardBreak(Enemy.GeneralEnemy enemy, CharacterBase character);      //While enemy is guarding, this skill does 2x damage. Otherwise, it only does half damage
        int Zantetsuken(Enemy.GeneralEnemy enemy, CharacterBase character);     //Lunge forward with sword and body and break enemy guard. Takes time to charge up.
    }

    public interface ISharpshooter   //Bow
    {
        int SingleShot(Enemy.GeneralEnemy enemy, CharacterBase character);      //Fire one arrow at enemy
        int DoubleShot(Enemy.GeneralEnemy enemy, CharacterBase character);      //Fire 2 arrows at enemy
        int SeriesOfShots(Enemy.GeneralEnemy enemy, CharacterBase character);   //Fire multiple shots each one at a time
        int Snipe(Enemy.GeneralEnemy enemy, CharacterBase character);           //Targets enemy weakspot and fires at it. Takes time to charge up.
    }

    public class AttackCommands
    {

    }
}
