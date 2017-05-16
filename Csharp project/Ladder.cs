using System;
using System.Collections.Generic;
using System.IO;

namespace mineText
{

    public interface IAddRanking
    {
        void AddRanking(string newTime);
    }

    //ponizej 3 klasy sa prawie takie same ale zrobilem to w ten sposob by uzycie interfejsu mialo jakikolwiek sens.

    public class REasy : IAddRanking
    {
        public void AddRanking(string newTime)
        {
            {
                List<string> listRanking = new List<string>();
                string[] stringArray = new string[6];
                try
                {
                    using (StreamReader sr2 = new StreamReader(@"C:\SaperProject\PawelLakomiec\Ladder.txt"))
                    {
                        string line;
                        while ((line = sr2.ReadLine()) != null)
                        {
                            listRanking.Add(line);
                        }
                    }
                    List<string> rangeRanking = listRanking.GetRange(1, 5);
                    int i = 0;
                    foreach (string top5 in rangeRanking)
                    {
                        stringArray[i] = top5;
                        i++;
                    }
                    stringArray[5] = newTime;
                    Array.Sort(stringArray);
                    rangeRanking.Clear();
                    for (int j = 0; j <= 5; j++)
                    {
                        rangeRanking.Add(stringArray[j]);
                    }
                    int yy = 0;
                    for (int xx = 1; xx <= 5; xx++, yy++)
                    {
                        string[] arrLine = File.ReadAllLines(@"C:\SaperProject\PawelLakomiec\Ladder.txt");
                        arrLine[xx] = stringArray[yy];
                        File.WriteAllLines(@"C:\SaperProject\PawelLakomiec\Ladder.txt", arrLine);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
    public class RMedium : IAddRanking
    {
        public void AddRanking(string newTime)
        {
            {
                List<string> listRanking = new List<string>();
                string[] stringArray = new string[6];
                try
                {
                    using (StreamReader sr2 = new StreamReader(@"C:\SaperProject\PawelLakomiec\Ladder.txt"))
                    {
                        string line;
                        while ((line = sr2.ReadLine()) != null)
                        {
                            listRanking.Add(line);
                        }
                    }
                    List<string> rangeRanking = listRanking.GetRange(7, 5);
                    int i = 0;
                    foreach (string top5 in rangeRanking)
                    {
                        stringArray[i] = top5;
                        i++;
                    }
                    stringArray[5] = newTime;
                    Array.Sort(stringArray);
                    rangeRanking.Clear();
                    for (int j = 0; j <= 5; j++)
                    {
                        rangeRanking.Add(stringArray[j]);
                    }
                    int yy = 0;
                    for (int xx = 7; xx <= 11; xx++, yy++)
                    {
                        string[] arrLine = File.ReadAllLines(@"C:\SaperProject\PawelLakomiec\Ladder.txt");
                        arrLine[xx] = stringArray[yy];
                        File.WriteAllLines(@"C:\SaperProject\PawelLakomiec\Ladder.txt", arrLine);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
    public class RHard : IAddRanking
    {
        public void AddRanking(string newTime)
        {
            {
                List<string> listRanking = new List<string>();
                string[] stringArray = new string[6];
                try
                {
                    using (StreamReader sr2 = new StreamReader(@"C:\SaperProject\PawelLakomiec\Ladder.txt"))
                    {
                        string line;
                        while ((line = sr2.ReadLine()) != null)
                        {
                            listRanking.Add(line);
                        }
                    }
                    List<string> rangeRanking = listRanking.GetRange(13, 5);
                    int i = 0;
                    foreach (string top5 in rangeRanking)
                    {
                        stringArray[i] = top5;
                        i++;
                    }
                    stringArray[5] = newTime;
                    Array.Sort(stringArray);
                    rangeRanking.Clear();
                    for (int j = 0; j <= 5; j++)
                    {
                        rangeRanking.Add(stringArray[j]);
                    }
                    int yy = 0;
                    for (int xx = 13; xx <= 17; xx++, yy++)
                    {
                        string[] arrLine = File.ReadAllLines(@"C:\SaperProject\PawelLakomiec\Ladder.txt");
                        arrLine[xx] = stringArray[yy];
                        File.WriteAllLines(@"C:\SaperProject\PawelLakomiec\Ladder.txt", arrLine);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
    public class Ladder
    {

        public void creatingLadderFile()
        {
            string folderName = @"c:\SaperProject";
            string pathString = System.IO.Path.Combine(folderName, "PawelLakomiec");
            System.IO.Directory.CreateDirectory(pathString);
            string fileName = "Ladder.txt";
            pathString = System.IO.Path.Combine(pathString, fileName);
            Console.WriteLine("UWAGA! Program tworzy folder i w nim plik na dysku C:");
            Console.WriteLine("Droga do pliku: {0}\n", pathString);
            Console.WriteLine("Najbardziej optymalny font: Raster Fonts - 12 x 16\n");
            if (!System.IO.File.Exists(pathString))
            {
                using (System.IO.FileStream xfs = System.IO.File.Create(pathString))
                {
                    Console.WriteLine("Utworzono plik: \"{0}\" ", fileName);
                }
            }
            else
            {
                Console.WriteLine("Plik \"{0}\" juz istnieje.", fileName);
                Console.WriteLine("Nacisnij dowolny klawisz by przejsc dalej.");
                Console.ReadKey();
                return;
            }
            try  // wyjatek!
            {
                byte[] readBuffer = System.IO.File.ReadAllBytes(pathString);
                foreach (byte b in readBuffer)
                {
                    Console.Write(b + " ");
                }
                Console.WriteLine();
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Nacisnij dowolny klawisz by przejsc dalej.");
            Console.ReadKey();
            saveLadderFile();  //tworzenie podstawowej tabeli do ladder.txt gdy jest na nowo tworzona
        }

        public void saveLadderFile()
        {
            // tworzenie podstawowych wartosci w ladder.txt
            string[] lines = { "Easy:", "XX:XX:XX.XX", "XX:XX:XX.XX", "XX:XX:XX.XX", "XX:XX:XX.XX", "XX:XX:XX.XX",
                    "Medium:", "XX:XX:XX.XX", "XX:XX:XX.XX", "XX:XX:XX.XX", "XX:XX:XX.XX", "XX:XX:XX.XX",
                    "Hard:", "XX:XX:XX.XX", "XX:XX:XX.XX", "XX:XX:XX.XX", "XX:XX:XX.XX", "XX:XX:XX.XX" };
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\SaperProject\PawelLakomiec\Ladder.txt"))
            {
                //debug
                foreach (string line in lines)
                {
                    if (!line.Contains("DELETE"))
                    {
                        file.WriteLine(line);
                    }
                }
            }
        }

        public static void loadLadderFile()
        {
            List<string> listLevel = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(@"C:\SaperProject\PawelLakomiec\Ladder.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        listLevel.Add(line);
                    }
                }
                foreach (string s in listLevel)
                {
                    Console.WriteLine(s);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

        }
    }
}