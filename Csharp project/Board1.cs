using System;

namespace mineText
{
    class Board1 : Menu
    {
        private bool[,] shown, hasFlag;
        public bool[,] hasMine;
        private int[,] aroundMines;
        private int selX, selY;
        public int actX, actY;
        public int sizeX;
        public int sizeY;
        public int mineNum, flagNum = 0, oldflagNum = 0;
        public int reveledNum;
        public Board1(int newSizeX, int newSizeY, int newMineNum) //konstuktor
        {
            selX = 0;
            selY = 0;
            sizeX = newSizeX; 
            sizeY = newSizeY;
            mineNum = newMineNum;
            flagNum = mineNum;
            oldflagNum = mineNum;
            shown = new bool[sizeX, sizeY];
            hasMine = new bool[sizeX, sizeY];
            hasFlag = new bool[sizeX, sizeY];
            aroundMines = new int[sizeX, sizeY];
        }

        private void putFrame(int x, int y, bool del) // ramka poruszania sie
        {
            if (del)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.SetCursorPosition(x - 1, y);
                Console.Write("|");
                Console.SetCursorPosition(x + 1, y);
                Console.Write("|");
                Console.SetCursorPosition(x, y - 1);
                Console.Write("-");
                Console.SetCursorPosition(x, y + 1);
                Console.Write("-");
                Console.SetCursorPosition(x - 1, y - 1);
                Console.Write("+");
                Console.SetCursorPosition(x + 1, y + 1);
                Console.Write("+");
                Console.SetCursorPosition(x + 1, y - 1);
                Console.Write("+");
                Console.SetCursorPosition(x - 1, y + 1);
                Console.Write("+");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(x - 1, y);
                Console.Write("|");
                Console.SetCursorPosition(x + 1, y);
                Console.Write("|");
                Console.SetCursorPosition(x, y - 1);
                Console.Write("-");
                Console.SetCursorPosition(x, y + 1);
                Console.Write("-");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.SetCursorPosition(x - 1, y - 1);
                Console.Write("+");
                Console.SetCursorPosition(x + 1, y + 1);
                Console.Write("+");
                Console.SetCursorPosition(x + 1, y - 1);
                Console.Write("+");
                Console.SetCursorPosition(x - 1, y + 1);
                Console.Write("+");
                Console.ResetColor();
            }
        }

        public void display()
        {
            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    Console.SetCursorPosition(x * 2 + 1, y * 2 + 1);
                    if (shown[x, y])
                    {
                        if (hasMine[x, y])
                            Console.Write('*');
                        else
                        {
                            if (aroundMines[x, y] != 0)
                            {
                                if (aroundMines[x, y] == 1)
                                {
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.Write(aroundMines[x, y]);
                                    Console.ResetColor();
                                }
                                if (aroundMines[x, y] == 2)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write(aroundMines[x, y]);
                                    Console.ResetColor();
                                }
                                if (aroundMines[x, y] == 3)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write(aroundMines[x, y]);
                                    Console.ResetColor();
                                }
                                if (aroundMines[x, y] == 4)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write(aroundMines[x, y]);
                                    Console.ResetColor();
                                }
                                if (aroundMines[x, y] == 5)
                                {
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write(aroundMines[x, y]);
                                    Console.ResetColor();
                                }
                                if (aroundMines[x, y] == 6)
                                {
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.Write(aroundMines[x, y]);
                                    Console.ResetColor();
                                }
                                if (aroundMines[x, y] == 7)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    Console.Write(aroundMines[x, y]);
                                    Console.ResetColor();
                                }
                                if (aroundMines[x, y] == 8)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.Write(aroundMines[x, y]);
                                    Console.ResetColor();
                                }
                            }
                            else
                                Console.Write(' ');
                        }
                    }
                    else
                    {
                        if (hasFlag[x, y])
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write('F');
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write('#');
                            Console.ResetColor();
                        }
                    }
                }
            }
        }

        private Boolean isXYvalid(int x, int y) // ograniczenie konsoli
        {
            return ((x >= 0) && (y >= 0) && (x < sizeX) && (y < sizeY));
        }

        private Boolean placeMine(int x, int y)
        {
            if ((isXYvalid(x, y)) && (!hasMine[x, y]))
            {
                hasMine[x, y] = true;
                for (int xx = -1; xx <= 1; xx++)
                    for (int yy = -1; yy <= 1; yy++)
                    {
                        if (((xx != 0) || (yy != 0)) && isXYvalid(x + xx, y + yy))
                            aroundMines[x + xx, y + yy]++;
                    }
                return true;
            }
            else
                return false;

        }

        public void makeBoard()
        {
            reveledNum = 0;

            for (int x = 0; x < sizeX; x++)
                for (int y = 0; y < sizeY; y++)
                {
                    shown[x, y] = false; //true - debug - sprawdzenie generowania mapy
                    hasMine[x, y] = false;
                    hasFlag[x, y] = false;
                    aroundMines[x, y] = 0;
                }

            Random rnd = new Random();
            int count = 0;
            int i = 0;
            while (count < mineNum)
            {
                i++;
                if (placeMine(rnd.Next(sizeX), rnd.Next(sizeY)))
                    count++;
            }
        }

        public void putFlag(int x, int y)
        {
            if (!shown[x, y] && hasFlag[x, y] == false)
            {
                hasFlag[x, y] = true;
                if (flagNum >= -1000)
                {
                    flagNum = flagNum - 1;
                }
            }
        }

        public void removeFlag(int x, int y)
        {
            if (!shown[x, y] && hasFlag[x, y] == true)
            {
                hasFlag[x, y] = false;
                if (flagNum <= mineNum)
                {
                    flagNum = flagNum + 1;
                }
            }
            else if (!hasFlag[x, y])
                return;
        }

        public bool revelBlock(int x, int y) //odkrywanie pol
        {
            if (!hasFlag[x, y])
            {
                if (shown[x, y] == false)
                {
                    reveledNum++;
                }
                shown[x, y] = true;
                int newX, newY;
                if ((aroundMines[x, y] == 0) && (!hasMine[x, y]))
                {
                    for (int xx = -1; xx <= 1; xx++)
                        for (int yy = -1; yy <= 1; yy++)
                        {
                            newX = x + xx;
                            newY = y + yy;
                            if ((isXYvalid(newX, newY)) && (!shown[newX, newY]) && (!hasFlag[newX, newY]))
                                revelBlock(newX, newY);
                        }
                }
                return hasMine[x, y];
            }
            else
                return false;
        }

        public bool wonGame()
        {
            Console.SetCursorPosition((sizeX * 2) + 3, 1);
            Console.WriteLine("             ");
            Console.SetCursorPosition((sizeX * 2) + 3, 1);
            Console.WriteLine("Liczba pol = " + sizeX * sizeY);
            Console.SetCursorPosition((sizeX * 2) + 15, 2);
            Console.WriteLine("             ");
            Console.SetCursorPosition((sizeX * 2) + 3, 2);
            Console.WriteLine("Odkryte pola = " + reveledNum);
            Console.SetCursorPosition((sizeX * 2) + 15, 3);
            Console.WriteLine("             ");
            Console.SetCursorPosition((sizeX * 2) + 3, 3);
            Console.WriteLine("Zakryte pola = " + ((sizeX * sizeY) - reveledNum));
            Console.SetCursorPosition((sizeX * 2) + 15, 4);
            Console.WriteLine("             ");
            Console.SetCursorPosition((sizeX * 2) + 3, 4);
            Console.WriteLine("Bomby = " + mineNum);
            Console.SetCursorPosition((sizeX * 2) + 15, 5);
            Console.WriteLine("             "); //sluzy do tego by wyswietlalo liczby poprawnie (bez tego byloby 90 zamiast 9 itd)
            Console.SetCursorPosition((sizeX * 2) + 3, 5);
            Console.WriteLine("Pozostale flagi = " + flagNum);
            return (reveledNum + mineNum) == (sizeX * sizeY);
        }

        public bool control(ConsoleKeyInfo cki) //sterowanie i keybindy
        {
            putFrame(selX * 2 + 1, selY * 2 + 1, true);

            if ((selX < sizeX - 1) && (cki.Key == ConsoleKey.RightArrow))
                selX++;
            if ((selX > 0) && (cki.Key == ConsoleKey.LeftArrow))
                selX--;
            if ((selY < sizeY - 1) && (cki.Key == ConsoleKey.DownArrow))
                selY++;
            if ((selY > 0) && (cki.Key == ConsoleKey.UpArrow))
                selY--;
            putFrame(selX * 2 + 1, selY * 2 + 1, false);

            if (cki.Key == ConsoleKey.Enter)
                putFlag(selX, selY);
            if (cki.Key == ConsoleKey.Backspace)
                removeFlag(selX, selY);
            if (cki.Key == ConsoleKey.Spacebar)
            {
                actX = selX;
                actY = selY;
                return revelBlock(selX, selY);
            }
            else
                return false;
        }
    }
}