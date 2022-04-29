using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lernprojekt_RPG
{
    public class Character
    {
        public string name { get; set; }
        public int hp_max { get; set; }
        public int hp_cur { get; set; }
        public int damage { get; set; }
        public int accuracy { get; set; }
        public int dodge { get; set; }
        public int level { get; set; }
        public int xp { get; set; }

        public Character(string name_input)
        {
            name = name_input;
            hp_max = 20;
            hp_cur = hp_max;
            damage = 5;
            accuracy = 8;
            dodge = 3;
            level = 1;
            xp = 0;
        }
    }
}
