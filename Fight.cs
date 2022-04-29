using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lernprojekt_RPG
{
    public class Fight
    {
        int opponentID { get; set; }
        CV view { get; set; }
        Character chara { get; set; }
        Random rnd { get; set; }
        Opponent opponent { get; set; }
        public Fight(int opponentIDinput, CV viewinput, Character charainput)
        {
            opponentID = opponentIDinput;
            view = viewinput;
            chara = charainput;
            rnd = new Random();
        }


        public void Start()
        {
            opponent = new Opponent(opponentID);
            view.AnnounceFight(opponent.name);
            bool dodging = false;
            bool oppAlive = true;

            while (true)
            {

                int action = view.RequestInput();
                Console.WriteLine("");
                if (action == 0)
                {
                    oppAlive = this.Attack();
                }
                else if (action == 1)
                {
                    dodging = true;
                    chara.accuracy = chara.accuracy - 2;
                    oppAlive = this.Attack();
                    chara.accuracy = chara.accuracy + 2;
                }
                else if (action == 2)
                {
                    this.Retreat();
                }

                if (!oppAlive)
                {
                    break;
                }

                if (dodging)
                {
                    chara.dodge = chara.dodge + 2;
                }

                this.Attackopp();

                if (dodging)
                {
                    chara.dodge = chara.dodge - 2;
                    dodging = false;
                }
            }
        }


        public bool Attack()
        {
            if (rnd.Next(1, 10) <= chara.accuracy && rnd.Next(1, 10) > opponent.dodge)
            {
                Console.WriteLine($"You hit the {opponent.name} for {chara.damage} damage.");
                opponent.hp = opponent.hp - chara.damage;
                if (opponent.hp <= 0)
                {
                    view.Victory(opponent);
                    chara.xp = chara.xp + opponent.xpgiv;
                    if (chara.xp >= 20)
                    {
                        chara.xp = chara.xp - 20;
                        if (chara.level < 10)
                        {
                            chara.level = chara.level + 1;
                            chara.hp_max = chara.hp_max + 2;
                            chara.damage = chara.damage + 1;
                            Console.WriteLine($"Congratulations. You've reached level {chara.level}.");
                        }
                    }
                    Console.WriteLine("");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                Console.WriteLine($"You fail to hit the {opponent.name}");
                return true;
            }
        }


        public void Retreat()
        {
            if (rnd.Next(1, 10) > opponent.speed)
            {
                Console.WriteLine("You retreated successfully!");
                return;
            }
            else
            {
                Console.WriteLine("You did not retreat successfully! The fight continues.");
            }
        }


        public void Attackopp()
        {
            if (rnd.Next(1, 10) <= opponent.accuracy && rnd.Next(1, 10) > chara.dodge)
            {
                chara.hp_cur = chara.hp_cur - opponent.damage;
                view.GotHit(opponent, chara);
                if (chara.hp_cur <= 0)
                {
                    view.Defeated();
                }
            }
            else
            {
                Console.WriteLine($"The {opponent.name} fails to hit you.");
            }
        }
    }
}
