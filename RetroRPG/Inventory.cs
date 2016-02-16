﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetroRPG.Objects;

namespace RetroRPG
{
    class Inventory
    {
         List<GameItem> items = new List<GameItem>();
        private static Inventory inventory;

        Inventory()
        {
    
        }

    public static Inventory getInstance
        {
            get
            {
                if (inventory == null)
                {
                    inventory = new Inventory();
                }

                return inventory;
            }
        }
        
     public void drawInventory()
        {
            int showItemsCount = 10;
            int itemMin = 0;

            bool choosing = true;
            int itemSelected = 1;
            int actualItem = itemMin;
            int length = 0;

            while (choosing)
            {
                int itemMax = Math.Min(itemMin + showItemsCount, items.Count);

                Render.getInstance.Buffer.Clear();
                Console.SetCursorPosition(0, 0);
                actualItem = itemMin;
                GameItem choosingItem = null;
                int horizontalIndex = 0;
                string[] equipedItems = {"","",""};
                ConsoleColor[] equipedItemsColors = {ConsoleColor.Gray,ConsoleColor.Gray,ConsoleColor.Gray};

                foreach (GameItem item in items)
                {
                    if (item.attributes[(int)GameItem.atr.equiped] == 1)
                    {
                        equipedItems[item.attributes[(int)GameItem.atr.type]] = item.itemName;
                        equipedItemsColors[item.attributes[(int)GameItem.atr.type]] = item.itemColor;
                    }

                }

                Render.getInstance.Buffer.Draw("Inventář", Console.CursorLeft, Console.CursorTop, ConsoleColor.Gray);
                Render.getInstance.Buffer.NewLine();
                Render.getInstance.Buffer.Draw(Strings.getInstance.horizontalLine, Console.CursorLeft, Console.CursorTop, ConsoleColor.Gray);
                Render.getInstance.Buffer.NewLine();
                Render.getInstance.Buffer.Draw("Používané věci", Console.CursorLeft, Console.CursorTop, ConsoleColor.Gray);
                Render.getInstance.Buffer.NewLine();
                Render.getInstance.Buffer.Draw(" • Zbraň: ", Console.CursorLeft, Console.CursorTop, ConsoleColor.Gray);

                if (equipedItems[(int)oPlayer.ItemsEquiped.Weapon] == "")
                {
                    Render.getInstance.Buffer.Draw("Holé ruce", Console.CursorLeft, Console.CursorTop, ConsoleColor.Gray);
                }
                else
                {
                    Render.getInstance.Buffer.Draw(equipedItems[(int)oPlayer.ItemsEquiped.Weapon], Console.CursorLeft, Console.CursorTop, equipedItemsColors[(int)oPlayer.ItemsEquiped.Weapon]);
                }
                Render.getInstance.Buffer.NewLine();

                Render.getInstance.Buffer.Draw(" • Brnění: ", Console.CursorLeft, Console.CursorTop, ConsoleColor.Gray);

                if (equipedItems[(int)oPlayer.ItemsEquiped.Armor] == "")
                {
                    Render.getInstance.Buffer.Draw("Nic", Console.CursorLeft, Console.CursorTop, ConsoleColor.Gray);
                }
                else
                {
                    Render.getInstance.Buffer.Draw(equipedItems[(int)oPlayer.ItemsEquiped.Armor], Console.CursorLeft, Console.CursorTop, equipedItemsColors[(int)oPlayer.ItemsEquiped.Armor]);
                }
                Render.getInstance.Buffer.NewLine();


                Render.getInstance.Buffer.Draw(Strings.getInstance.horizontalLine, Console.CursorLeft, Console.CursorTop, ConsoleColor.Gray);
                Render.getInstance.Buffer.NewLine();
                Render.getInstance.Buffer.NewLine();

                for (int i = itemMin; i < itemMax; i++ )
                {
                    actualItem++;
                    GameItem item = items[i];

                    if (itemSelected == actualItem) { choosingItem = item; }

                    if (item.attributes[(int)GameItem.atr.equiped] == 1)
                    {
                        Render.getInstance.Buffer.Draw("[Nasazeno]", Console.CursorLeft, Console.CursorTop, ConsoleColor.Green);
                    }

                    // Vykreslí info o hover předmětu
                    if (itemSelected == actualItem)
                    {
                        Render.getInstance.Buffer.Draw(" > ", Console.CursorLeft, Console.CursorTop, ConsoleColor.Green);
                        item.drawItemStats();
                        item.drawItemOptions();
                        Render.getInstance.Buffer.NewLine();
                        item.drawItemDescription();
                    }
                    else
                    {
                        Render.getInstance.Buffer.Draw("> ", Console.CursorLeft, Console.CursorTop, ConsoleColor.Gray);
                        item.drawItemStats();
                    }

                    Render.getInstance.Buffer.NewLine();

                }

                /*
                foreach (GameItem item in items)
                {
                    actualItem++;
                    if (itemSelected == actualItem) { choosingItem = item; }

                    if (item.attributes[(int)GameItem.atr.equiped] == 1)
                    {
                        Render.getInstance.Buffer.Draw("[Nasazeno]", Console.CursorLeft, Console.CursorTop, ConsoleColor.Green);
                    }

                    // Vykreslí info o hover předmětu
                    if (itemSelected == actualItem) 
                        { 
                        Render.getInstance.Buffer.Draw(" > ", Console.CursorLeft, Console.CursorTop, ConsoleColor.Green);
                        item.drawItemStats();
                        item.drawItemOptions();
                        Render.getInstance.Buffer.NewLine();
                        item.drawItemDescription();
                        }
                    else
                    {
                        Render.getInstance.Buffer.Draw("> ", Console.CursorLeft, Console.CursorTop, ConsoleColor.Gray);
                        item.drawItemStats();
                    }
                   
                    Render.getInstance.Buffer.NewLine();
                }*/


                // Vykreslí možnost "zpět"
                if (itemSelected == itemMax + 1)
                {                

                    Render.getInstance.Buffer.Draw(" > ", Console.CursorLeft, Console.CursorTop, ConsoleColor.Green);

                }    
                else
                {
                    Render.getInstance.Buffer.Draw("> ", Console.CursorLeft, Console.CursorTop, ConsoleColor.Gray);
                }

                Render.getInstance.Buffer.Draw("Zpět", Console.CursorLeft, Console.CursorTop, ConsoleColor.Gray);
                Render.getInstance.Buffer.NewLine();
                // **********

                Render.getInstance.Buffer.Print();


                ConsoleKey key = Console.ReadKey().Key;

                if (key == ConsoleKey.W)
                {
                    if (itemMin > 0 && (items.Count - itemSelected > 5)) 
                    {
                        itemMin--;
                    }

                    if (itemSelected > 0) { itemSelected--; }
                    else { itemSelected = items.Count + 1; itemMin = items.Count - showItemsCount; }
                    horizontalIndex = 0;
                }
                if (key == ConsoleKey.S)
                {
                    if (itemMin < items.Count - showItemsCount && itemSelected > 5)
                    {
                        itemMin++;
                    }

                    if (itemSelected < items.Count + 1) { itemSelected++; }
                    else { itemSelected = 1; itemMin = 0; }
                    horizontalIndex = 0;
                }

                if (key == ConsoleKey.Enter)
                {
                  
                        // Klasické předměty (zbraň, brnění...)

                        // Equip
                        if (choosingItem != null && choosingItem.attributes[(int)GameItem.atr.equiped] == 0 && (GameWorld.getInstance.player.equiped[choosingItem.attributes[(int)GameItem.atr.type]] == false))
                        {
                            choosingItem.Equip();
                            choosingItem.attributes[(int)GameItem.atr.equiped] = 1;
                            GameWorld.getInstance.player.equiped[choosingItem.attributes[(int)GameItem.atr.type]] = true;
                        }
                        // Unequip
                        else if (choosingItem != null && choosingItem.attributes[(int)GameItem.atr.equiped] == 1 && (GameWorld.getInstance.player.equiped[choosingItem.attributes[(int)GameItem.atr.type]] == true))
                        {
                            choosingItem.UnEquip();
                            choosingItem.attributes[(int)GameItem.atr.equiped] = 0;
                            GameWorld.getInstance.player.equiped[choosingItem.attributes[(int)GameItem.atr.type]] = false;
                        }
                    
                  

                    if (itemSelected == items.Count + 1) { choosing = false; } 
                }

               
            }
        }

        public void itemAdd(GameItem item)
           {
               items.Add(item);
           }

    }
}
