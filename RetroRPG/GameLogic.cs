﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroRPG.Objects
{
    // Třída pro herní smyčku
    class GameLogic
    {
        Random random = new Random();

        private static GameLogic gameLogic;
        private GameLogic()
        {
               
         }

        public static GameLogic getInstance
        {
            get
            {
                if (gameLogic == null)
                {
                    gameLogic = new GameLogic();
                }

                return gameLogic;
            }
        }
 

        public void Step()
        {
            Console.SetCursorPosition(0, 0);
            Render.getInstance.Buffer.Clear();
     

            //    Intro.getInstance.DisplayIntro();
            Parser.getInstance.parseImage("award.txt",true,ConsoleColor.Gray, Parser.Effects.typewriter);
            Console.SetCursorPosition(0, 0);
            Console.ReadKey();
            Render.getInstance.Buffer.Clear();

            // TEST INVENTÁŘE   
            GameItem item = new GameItem("Pirátská šavle", ConsoleColor.Yellow, "Stará šavle nějakého piráta.", oPlayer.ItemsEquiped.Weapon);
            GameItem item1 = new GameItem("Kožená vesta", ConsoleColor.Gray, "Zahřeje když je zima.", oPlayer.ItemsEquiped.Armor);

            item.attributes[(int)GameItem.atr.damage] = 10;
            item1.attributes[(int)GameItem.atr.damage] = 4;
            item.attributes[(int)GameItem.atr.hp] = 7;

            Inventory.getInstance.itemAdd(item);
            Inventory.getInstance.itemAdd(item1);
            
            Inventory.getInstance.drawInventory();

            // *****
            Render.getInstance.Buffer.NewLine();
            Render.getInstance.Buffer.DrawColored("#rDvojitý buffer#x teď umí parsovat #ycolorflagy!#x ", Console.CursorLeft, Console.CursorTop, ConsoleColor.Gray, false);
            Render.getInstance.Buffer.Print();
            Console.ReadKey();
            Parser.getInstance.ParseMap();

            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Render.getInstance.Buffer.Clear();
              //  Console.Clear();
              //  Render.getInstance.DrawHeader("Informace: ");
               // Render.getInstance.DrawMapInfo();
                oEnemy.addEnemy(random.Next(1,5),random.Next(1,5));
              //  GameWorld.getInstance.ShowInfo();
                Render.getInstance.drawWorld();             
                Render.getInstance.DrawPlayerStats();
                PreRender.getInstance.PlayerMove();
            }
        }
    }
}
