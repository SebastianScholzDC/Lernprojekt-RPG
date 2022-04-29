using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lernprojekt_RPG
{
    public class CV
    {
        public string Initialize()
        {
            Console.WriteLine("Welcome to your adventure. Please Enter your name. \n");
            string name = Console.ReadLine();
            Console.WriteLine($"\nWelcome {name}");
            return name;
        }

        public void Idle()
        {
            while (true)
            {
                Console.WriteLine("Do you want to explore? (y)es (q)uit");
                string response = Console.ReadLine();

                switch (response)
                {
                    case "y":
                        return;
                    case "q":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Wrong Input. Please repeat.");
                        break;
                }
            }
        }


        public void AnnounceFight(string opponentName)
        {
            Console.WriteLine($"You are being attacked by a {opponentName}!");
        }


        public int RequestInput()
        {
            Console.WriteLine("\nChoose an action.");
            Console.WriteLine("(a)ttack, (d)odge and attack, (r)etreat");
            while (true)
            {
                string response = Console.ReadLine();
                switch (response)
                {
                    case "a":
                        return 0;
                    case "d":
                        return 1;
                    case "r":
                        return 2;
                    default:
                        Console.WriteLine("Wrong Input. Please repeat.");
                        break;
                }
            }
        }


        public void Defeated()
        {
            Console.WriteLine("You got defeated!");
            Console.ReadKey();
            System.Environment.Exit(0);
        }


        public void Victory(Opponent opponent)
        {
            Console.WriteLine($"The {opponent.name} is defeated!");
            Console.WriteLine($"You gain {opponent.xpgiv} XP!");
        }


        public void GotHit(Opponent opponent, Character chara)
        {
            Console.WriteLine($"The {opponent.name} deals {opponent.damage} damage to you.");
            Console.WriteLine($"You have {chara.hp_cur} HP left.");
        }
    }
}
