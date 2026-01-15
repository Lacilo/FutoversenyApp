using FutoversenyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


//TESZTELÉSHEZ:

//Display display = new Display();

//List<Futas> futasok = new List<Futas>();

//for (int i = 0; i < 10; i++)
//{
//    futasok.Add(new Futas());
//}

////foreach (var item in futasok)
////{
////    Console.WriteLine(item);
////}

//display.UpdateFutasok(futasok);

//display.DisplayFutasok();
//display.GetDisplayInput();

namespace FutoversenyApp.Models
{
    internal class Display
    {
        private List<Futas> futasok;

        int cursor;

        internal List<Futas> Futasok { get => futasok; set => futasok = value; }
        public int Cursor { get => cursor; set => cursor = value; }

        public Display(List<Futas> futasok, int cursor, int runSelected)
        {
            Futasok = futasok;
            Cursor = cursor;
        }

        public Display() 
        { 
            
        }

        public void UpdateFutasok(List<Futas> ujFutasok)
        {
            Futasok = ujFutasok;
        }

        public void GetDisplayInput()
        {
            ConsoleKeyInfo key = Console.ReadKey();
            bool exit = false;

            while (true)
            {
                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        cursor++;
                        break;

                    case ConsoleKey.UpArrow:
                        cursor--;
                        break;

                    case ConsoleKey.Q:
                        exit = true;
                        break;
                }

                if (exit) break;

                Console.Clear();
                DisplayFutasok();
                key = Console.ReadKey();
            }
        }

        public void DisplayFutasok()
        {
            foreach (Futas futas in Futasok)
            {
                if (cursor == Futasok.IndexOf(futas)) 
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("-> ");                    
                }
                else
                {
                    Console.Write("   ");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine($"{futas.Datum} | {futas.Tavolsag} | {futas.Idotartam} | {futas.Maxpulzus} ");
            }
        }
    }
}
