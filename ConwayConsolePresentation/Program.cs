using System;
using System.IO;
using ConwayBusinessLogic;

namespace ConwayConsolePresentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------========== Conway's Game of Life ==========----------");
            string colsString, rowsString, cellsString;
            //do
            //{
            Console.Write("Sorok száma: ");
            colsString = Console.ReadLine();
            //} while (!Int32.TryParse(colsString, out int cols));
            //do
            //{
            Console.Write("Oszlopok száma: ");
            rowsString = Console.ReadLine();
            //} while (!Int32.TryParse(rowsString, out int rows));
            //do
            //{
            Console.Write("Elemek száma: ");
            cellsString = Console.ReadLine();
            //} while (!Int32.TryParse(elementsString, out int elements));

            if (Int32.TryParse(colsString, out int cols) && Int32.TryParse(rowsString, out int rows) && Int32.TryParse(cellsString, out int cells))
            {
                PlayArea playArea = new PlayArea(cols, rows, cells);
            }
            else
            {
                Console.WriteLine("Valami nem jó");
            }

            //try //lassú az Exception obj. miatt
            //{
            //    var cols = Convert.ToInt32(colsString);
            //    var rows = Convert.ToInt32(rowsString);
            //    var elements = Convert.ToInt32(elementsString);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Nem megfelelő értékek!");
            //    return;
            //}

            Console.WriteLine("Done.");
            Console.ReadKey();
        }
    }
}