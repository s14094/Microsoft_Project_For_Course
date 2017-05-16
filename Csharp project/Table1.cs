using System;

namespace mineText
{
    class Table1
    {
        private int sizeX;
        private int sizeY;
        public Table1(int x, int y)
        {
            sizeX = x;
            sizeY = y;
        }
        public void displayTable()  //wyswietlanie ramki gry
        {
            for (int y = 0; y < sizeY * 2 + 1; y = y + 2)
            {
                for (int x = 0; x < sizeX * 2 + 1; x = x + 2)
                {
                    Console.SetCursorPosition(x, y);
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("+");
                    Console.ResetColor();
                }
            }
            for (int y = 0; y < sizeY * 2 + 1; y = y + 2)
            {
                for (int x = 1; x < sizeX * 2 + 1; x = x + 2)
                {
                    Console.SetCursorPosition(x, y);
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("-");
                    Console.ResetColor();
                }
            }
            for (int y = 1; y < sizeY * 2 + 1; y = y + 2)
            {
                for (int x = 0; x < sizeX * 2 + 1; x = x + 2)
                {
                    Console.SetCursorPosition(x, y);
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("|");
                    Console.ResetColor();
                }
            }
        }
    }
}