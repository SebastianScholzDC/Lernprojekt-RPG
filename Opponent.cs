using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lernprojekt_RPG
{
    public class Opponent
    {
        int[,] values = { { 08, 2, 5, 1, 04, 2 },
                          { 12, 3, 6, 2, 07, 4 },
                          { 15, 4, 8, 5, 12, 8 },
                          { 30, 6, 9, 3, 20, 7 } };
        string[] names = { "Goblin", "Bandit", "Harpy", "Black Knight" };

        public int hp { get; set; }
        public int damage { get; set; }
        public int accuracy { get; set; }
        public int dodge { get; set; }
        public int xpgiv { get; set; }
        public int speed { get; set; }
        public string name { get; set; }

        public Opponent(int id)
        {
            hp = values[id, 0];
            damage = values[id, 1];
            accuracy = values[id, 2];
            dodge = values[id, 3];
            xpgiv = values[id, 4];
            speed = values[id, 5];
            name = names[id];
        }
    }
}
