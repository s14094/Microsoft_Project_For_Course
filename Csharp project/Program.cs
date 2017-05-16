using System;
using System.Diagnostics;

namespace mineText
{
    class Program
    {
        public TimeSpan Elapsed { get; }
        static void Main(string[] args)
        {
            Console.Title = "Saper - Pawel Lakomiec";
            bool exit = false;
            bool exit2 = false;
            bool exit3 = false;
            ConsoleKeyInfo ch;
            Ladder ladder = new Ladder(); //test
            ladder.creatingLadderFile(); //test
            //ladder.loadLadderFile(); //test
            //ladder.readLadderFile();
            //Console.ReadKey(); //debug

            REasy REasy = new REasy();
            RMedium RMedium = new RMedium();
            RHard RHard = new RHard();
            //ladder.saveLadderFile();

            Console.Clear();
            Menu menu = new Menu();
            menu.mainMenu();
            do
            {
                Console.Clear();
                Board1 game = new Board1(menu.newSizeX, menu.newSizeY, menu.newMineNum);
                game.makeBoard();
                game.display();
                game.wonGame();
                Table1 table = new Table1(game.sizeX, game.sizeY);
                table.displayTable();
                Stopwatch stopWatch = new Stopwatch();
                do
                {
                    stopWatch.Start();
                    ch = Console.ReadKey(true);
                    if (game.control(ch))
                    {
                        while (game.reveledNum == 1 && game.hasMine[game.actX, game.actY])
                        {
                            //sprawdzanie czy przegralo sie w 1st ruchu
                            {
                                Console.Clear();
                                game.makeBoard();
                                game.display();
                                table.displayTable();
                                game.reveledNum = 0;
                                Console.SetCursorPosition(game.actX, game.actY);
                                game.control(ch);
                                game.revelBlock(game.actX, game.actY);
                            }
                        }

                        if (game.reveledNum > 1)
                        {
                            Console.Clear();
                            Console.SetCursorPosition(0, 1);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("**********PRZEGRALES!**********");
                            Console.ResetColor();

                            stopWatch.Stop();
                            TimeSpan ts = stopWatch.Elapsed;
                            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                ts.Hours, ts.Minutes, ts.Seconds,
                                ts.Milliseconds / 10);
                            Console.WriteLine("Twoj czas: " + elapsedTime);
                            //nowy elapsedTime do wsylania i sprawdzania?
                            stopWatch.Reset();


                            /* //Debug - sprawdzanie czy zapisywanie dziala
                            if (menu.level == 0)
                            {
                                REasy.AddRanking(elapsedTime);
                            }
                            else if (menu.level == 1)
                            {
                                RMedium.AddRanking(elapsedTime);
                            }
                            else if (menu.level == 2)
                            {
                                RHard.AddRanking(elapsedTime);
                            }
                            */

                            Console.WriteLine("Nowa gra / Menu glowne (nacisnij y/n)?");
                            bool loop = true;
                            while (loop)
                            {
                                Console.SetCursorPosition(0, 4);
                                var input = Console.ReadKey();
                                switch (input.Key)
                                {
                                    case ConsoleKey.Y:
                                        {
                                            Console.Clear();
                                            game.makeBoard();
                                            game.display();
                                            table.displayTable();
                                            game.flagNum = game.mineNum;
                                            loop = false;
                                            break;
                                        }
                                    case ConsoleKey.N:
                                        {
                                            Console.Clear();
                                            game.flagNum = game.mineNum;
                                            exit3 = true;
                                            loop = false;
                                            break;
                                        }
                                    default:
                                        {
                                            break;
                                        }
                                }
                            }
                        }
                    }
                    if (game.wonGame())
                    {
                        Console.Clear();
                        Console.SetCursorPosition(0, 1);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("**********WYGRALES!**********");
                        Console.ResetColor();

                        stopWatch.Stop();
                        TimeSpan ts = stopWatch.Elapsed;
                        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                            ts.Hours, ts.Minutes, ts.Seconds,
                            ts.Milliseconds / 10);
                        Console.WriteLine("Twoj czas: " + elapsedTime);
                        stopWatch.Reset();

                        // ZAPISYWANIEE
                        if (menu.level == 0)
                        {
                            REasy.AddRanking(elapsedTime);
                        }
                        else if (menu.level == 1)
                        {
                            RMedium.AddRanking(elapsedTime);
                        }
                        else if (menu.level == 2)
                        {
                            RHard.AddRanking(elapsedTime);
                        }

                        Console.WriteLine("Nowa gra / Menu glowne (nacisnij y/n)?");
                        bool loop = true;
                        while (loop)
                        {
                            Console.SetCursorPosition(0, 4);
                            var input = Console.ReadKey();
                            {
                                switch (input.Key)
                                {
                                    case ConsoleKey.Y:
                                        {
                                            Console.Clear();
                                            game.makeBoard();
                                            game.display();
                                            table.displayTable();
                                            game.flagNum = game.mineNum;
                                            loop = false;
                                            break;
                                        }
                                    case ConsoleKey.N:
                                        {
                                            Console.Clear();
                                            game.flagNum = game.mineNum;
                                            loop = false;
                                            exit3 = true;
                                            break;
                                        }
                                    default:
                                        {
                                            break;
                                        }
                                }
                            }
                        }
                    }
                    game.display();
                    exit = ch.Key == ConsoleKey.Escape;
                }
                while (!exit && !exit3);
                Console.Clear();
                menu.mainMenu();
                exit3 = false;
            } while (!exit2);
        }
    }
}