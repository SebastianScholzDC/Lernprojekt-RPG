using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lernprojekt_RPG
{
    public class Exploration
    {
        int duration { get; set; }
        int opponentID { get; set; }
        Random rnd = new Random();
        CV view { get; set; }
        Character chara { get; set; }

        public Exploration(CV viewinput, Character charainput)
        {
            view = viewinput;
            chara = charainput;
        }



        public void Explore()
        {
            duration = 0;
            while (true)
            {
                if (duration < rnd.Next(3, 10)+chara.level-1)
                {
                    duration++;
                    this.StartFight();
                }
                else
                {
                    Console.WriteLine("You returned from your exploration! Your HP are fully restored.");
                    chara.hp_cur = chara.hp_max;
                    return;
                }
            }
        }



        private void StartFight()
        {
            int opponentValue = (rnd.Next(1, 100) - 5 * (10 - duration));
            if      (opponentValue <= 50)
            {
                opponentID = 0;
            }
            else if (opponentValue <= 80)
            {
                opponentID = 1;
            }
            else if (opponentValue <= 95)
            {
                opponentID = 2;
            }
            else
            {
                opponentID = 3;
            }
            Fight fight = new Fight(opponentID, view, chara);
            fight.Start();
        }

    }
}
