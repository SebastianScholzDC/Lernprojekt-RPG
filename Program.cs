using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lernprojekt_RPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CV view = new CV();
            string name = view.Initialize();
            Character chara = new Character(name);
            while (true)
            {
                view.Idle();
                Exploration exp = new Exploration(view, chara);
                exp.Explore();
            }
        }
    }
}
