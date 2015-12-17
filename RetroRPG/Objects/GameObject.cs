﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroRPG.Objects
{
    // Třida pro vestavěné promměné, dědí z ní každý objekt
    class GameObject
    {
        public int x,y;
        public ConsoleColor color;
        public int hp;
        public int max_hp;
        public char symbol;
        public int value;
        public string accessName;

        int id;

        // Přetížení pro unikátní objekty
        public GameObject()
        {
            Render.getInstance.actualID++;
            id = Render.getInstance.actualID;
        }

        // Přetížení pro NPC based objekty
        public GameObject(char symbol, string accessName, ConsoleColor color, int x, int y, int hp)
        {

            Render.getInstance.actualID++;
            this.x = x;
            this.y = y;
            this.hp = hp;
            this.symbol = symbol;
            id = Render.getInstance.actualID;
            this.accessName = accessName;
            this.color = color;

            max_hp = hp;
        }

        public double distanceToPoint(int xx, int yy)
        {
             double distance = -1;

            distance = Math.Round(Math.Sqrt(Math.Pow(Math.Abs(x-xx),2) + Math.Pow(Math.Abs(y - yy), 2)));
            return distance;
        }

        public void showStats()
        {
            Console.WriteLine("--- {0} (id: {1}) ---", accessName, id);
            Console.WriteLine("Hp: " + hp);
            Console.WriteLine("Max hp: " + max_hp);

        }

    }
}
