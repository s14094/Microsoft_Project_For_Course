using System;

namespace mineText
{
    public class Menu
    {
        private int selectionKey;
        public int newSizeX { get; set; } = 10;
        public int newSizeY { get; set; } = 10;
        public int newMineNum { get; set; } = 10;
        private bool tooManyMines = false;
        private double percentMineNum;
        public int level;

        public enum Difficulty
        {
            Easy,
            Medium,
            Hard,
            Custom,
        }

        public void mainMenu()
        {
            Console.WriteLine("********** SAPER - Pawel Lakomiec **********\n\n");
            Console.WriteLine("--Keybindy-------------------------");
            Console.WriteLine("Spacja = Odkrywanie pola");
            Console.WriteLine("Enter = Polozenie flagi");
            Console.WriteLine("Backspace = Usuniecie flagi");
            Console.WriteLine("-----------------------------------\n\n");
            Console.WriteLine("--Poziom trudnosci-----------------");
            Console.WriteLine("1. Latwy - 9x9, 10 bomb"); //9X9 10 = 81/10 = 8.1
            Console.WriteLine("2. Sredni - 15x10, 25 bomb"); //16X16 40 = 256/40 = 6.1
            Console.WriteLine("3. Trudny - 25x12, 60 bomb"); //16X30 99 = 480/99 = 4.8
            Console.WriteLine("4. Custom"); // min 3x3, 2 bomby . max 12x25, 99 bomb
            Console.WriteLine("5. Ladder");
            Console.WriteLine("6. Wyjscie");
            Console.WriteLine("-----------------------------------\n");
            Console.WriteLine("Wybierz poziom / wyjscie [1-6]: ");

            bool loop2 = true;
            while (loop2)
            {
                Console.SetCursorPosition(31, 19);
                string strReadKey = Console.ReadKey().KeyChar.ToString();
                int.TryParse(strReadKey, out selectionKey);
                switch (selectionKey)
                {
                    case 1:
                        {
                            Console.Clear();
                            this.newMineNum = 10;
                            this.newSizeX = 9;
                            this.newSizeY = 9;
                            level = (int)Difficulty.Easy;
                            loop2 = false;
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            newMineNum = 25;
                            newSizeX = 15;
                            newSizeY = 10;
                            level = (int)Difficulty.Medium;
                            loop2 = false;
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            newMineNum = 60;
                            newSizeX = 25;
                            newSizeY = 12;
                            level = (int)Difficulty.Hard;
                            loop2 = false;
                            break;
                        }
                    case 4:
                        {
                            level = (int)Difficulty.Custom;
                            do
                            {
                                tooManyMines = false;
                                Console.Clear();
                                Console.WriteLine("CUSTOM");
                                Console.WriteLine("\nPodaj szerokosc tablicy(min: 3, max: 25): ");
                                newSizeX = Int32.Parse(Console.ReadLine());
                                Console.WriteLine("\nPodaj wysokosc tablicy(min: 3, max: 12): ");
                                newSizeY = Int32.Parse(Console.ReadLine());
                                percentMineNum = (newSizeX * newSizeY) * 0.8;
                                Console.WriteLine("\nPodaj liczbe min(min: 1, max: 80% pol(" + Math.Floor(percentMineNum) + ")): ");
                                newMineNum = Int32.Parse(Console.ReadLine());
                                if (newMineNum > (newSizeX * newSizeY) * 0.8)
                                {
                                    tooManyMines = true;
                                }
                            } while (!(newSizeX >= 3 && newSizeX <= 25 && newSizeY >= 3 && newSizeY <= 12 && newMineNum >= 1 && tooManyMines == false));
                            loop2 = false;
                            break;
                        }
                    case 5:
                        {
                            Console.Clear();
                            Console.WriteLine("--Ranking-----------------");
                            Ladder.loadLadderFile();
                            Console.WriteLine("--------------------------");
                            Console.SetCursorPosition(35, 0);
                            Console.WriteLine("--Poziom trudnosci-----------------");
                            Console.SetCursorPosition(35, 1);
                            Console.WriteLine("1. Latwy - 9x9, 10 bomb");
                            Console.SetCursorPosition(35, 2);
                            Console.WriteLine("2. Sredni - 15x10, 25 bomb");
                            Console.SetCursorPosition(35, 3);
                            Console.WriteLine("3. Trudny - 25x12, 60 bomb");
                            Console.SetCursorPosition(35, 4);
                            Console.WriteLine("4. Custom");
                            Console.SetCursorPosition(35, 5);
                            Console.WriteLine("6. Wyjscie");
                            Console.SetCursorPosition(35, 6);
                            Console.WriteLine("-----------------------------------");
                            Console.SetCursorPosition(0, 19);
                            Console.WriteLine("Wybierz poziom / wyjscie [1-6]: ");
                            break;
                        }
                    case 6:
                        {
                            Console.Clear();
                            Environment.Exit(0);
                            return;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }
    }
}
