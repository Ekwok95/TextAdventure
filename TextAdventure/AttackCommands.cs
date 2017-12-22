using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Character
{
    public interface Slash
    {
        int Slash(Opponent.Enemy.GeneralEnemy enemy, Character.CharacterBase character);
    }

    public interface Stab
    {
        int Stab(Opponent.Enemy.GeneralEnemy enemy, Character.CharacterBase character);
    }

    public interface Crush
    {
        int Crush(Opponent.Enemy.GeneralEnemy enemy, Character.CharacterBase character);
    }

    public interface ISwordsman //Sword and Shield
    {
        int DoubleSlash(Opponent.Enemy.GeneralEnemy enemy, Character.CharacterBase character);     //Swings sword in 2 opposite directions eg. Left -> Right, Right -> Left
        int PowerLunge(Opponent.Enemy.GeneralEnemy enemy, Character.CharacterBase character);      //Pulls sword back and then thrusts sword forward with a powered stab 
        //int ShieldBash(Enemy.GeneralEnemy enemy, CharacterBase character);   //Uses shield to stun/daze enemy
        int Bladespin(Opponent.Enemy.GeneralEnemy enemy, Character.CharacterBase character);       //Does a 360 degree spin with sword
    }

    public interface IBladeKnight  //2H Sword
    {
        int DownwardSlash(Opponent.Enemy.GeneralEnemy enemy, Character.CharacterBase character);   //Bring down sword on enemy with 1 strike
        int HorizontalSwing(Opponent.Enemy.GeneralEnemy enemy, Character.CharacterBase character); //Does one swipe horizontally
        int GuardBreak(Opponent.Enemy.GeneralEnemy enemy, Character.CharacterBase character);      //While enemy is guarding, this skill does 2x damage. Otherwise, it only does half damage
        int Zantetsuken(Opponent.Enemy.GeneralEnemy enemy, Character.CharacterBase character);     //Lunge forward with sword and body and break enemy guard. Takes time to charge up.
    }

    public interface ISharpshooter   //Bow
    {
        int SingleShot(Opponent.Enemy.GeneralEnemy enemy, Character.CharacterBase character);      //Fire one arrow at enemy
        int DoubleShot(Opponent.Enemy.GeneralEnemy enemy, Character.CharacterBase character);      //Fire 2 arrows at enemy
        int SeriesOfShots(Opponent.Enemy.GeneralEnemy enemy, Character.CharacterBase character);   //Fire multiple shots each one at a time
        int Snipe(Opponent.Enemy.GeneralEnemy enemy, Character.CharacterBase character);           //Targets enemy weakspot and fires at it. Takes time to charge up.
    }

    public class AttackCommands
    {

    }
}
