﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroRPG.Objects
{
    class oPlayer : GameObject
    {
        public oPlayer(char symbol, string accessName, ConsoleColor color, int x, int y, int hp) : base(symbol, accessName, color, x, y, hp) {  }

         int gold = 0;
        public string name = "LordOfFlies";
        public int stamina = 20;
        public int max_stamina = 20;


        public int Gold
            {
            get { return gold; }
            set { gold = value; }
            }
        
      

        
    }
}