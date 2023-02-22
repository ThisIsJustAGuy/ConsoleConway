using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using ConwayBusinessLogic;

namespace ConwayConsolePresentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("----------========== Conway's Game of Life ==========----------");
            string colsString, rowsString, cellsString;
            Console.Write("Sorok száma: ");
            colsString = Console.ReadLine();
            Console.Write("Oszlopok száma: ");
            rowsString = Console.ReadLine();
            Console.Write("Elemek száma: ");
            cellsString = Console.ReadLine();

            if (Int32.TryParse(colsString, out int cols) && Int32.TryParse(rowsString, out int rows) && Int32.TryParse(cellsString, out int cells))
            {
                PlayArea playArea = new PlayArea(cols, rows, cells);
                bool shouldContinue = true;
                playArea.DrawMap();
                int gen = 0;
                Stopwatch sw = new Stopwatch();
                sw.Start();
                while (shouldContinue)
                {
                    playArea.ApplyRules();
                    playArea.DrawMap();
                    if (playArea.isAllFalse()) break;
                    gen++;
                    //var keyInfo = Console.ReadKey();
                    //if (keyInfo.KeyChar == 'x') shouldContinue = false;
                }
                sw.Stop();
                Console.WriteLine();
                Console.WriteLine($"Sim endend({(shouldContinue ? "Population died" : "")}). Elapsed time: {sw.Elapsed.TotalSeconds}\tGeneration count: {gen}");
            }
            else Console.WriteLine("Valami nem jó");

            Console.WriteLine("Done.");
            Console.ReadKey();
        }
    }
}