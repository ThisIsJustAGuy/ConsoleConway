using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwayBusinessLogic
{
    public class PlayArea //internal = namespace-en belül látható
    {
        public int Cols { get; private set; }
        public int Rows { get; private set; }
        public int Cells { get; private set; }
        bool[,] Map;
        public PlayArea(int cols, int rows, int cells)
        {
            Cols = cols;
            Rows = rows;
            Cells = cells;
            Map = new bool[cols, rows];
            Randomize();
        }

        private void Clear()
        {
            for (int i = 0; i < Cols - 1; i++)
            {
                for (int j = 0; j < Rows - 1; j++)
                {
                    Map[i, j] = false;
                }
            }
        }

        private void Randomize()
        {
            Clear();
            Random rnd = new Random();
            var elements = Enumerable.Range(0, Cols * Rows).ToHashSet();
            for (int i = 0; i < Cells; i++)
            {
                int item = rnd.Next(0, elements.Count());
                elements.Remove(item);
                int itemRow = item / Cols;
                int itemCol = item % Cols;
                Map[itemCol, itemRow] = true;
            }
        }
        public void DrawMap()
        {
            Console.Clear();
            for (int i = 0; i < Cols - 1; i++)
            {
                for (int j = 0; j < Rows - 1; j++)
                {
                    Console.SetCursorPosition(i, j);

                    if (Map[i, j])
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                    }
                    Console.Write(' ');
                }
            }
            ApplyRules();
            Console.BackgroundColor = ConsoleColor.Black;
        }

        private int getNeighbourCount(int col, int row)
        {
            int result = 0;
            if (col >= 1 && row >= 1 && Map[col - 1, row - 1]) result++;
            if (row >= 1 && Map[col, row - 1]) result++;
            if (col <= Cols - 2 && row >= 1 && Map[col + 1, row - 1]) result++;
            if (col <= Cols - 2 && Map[col + 1, row]) result++;
            if (col <= Cols - 2 && row <= Rows - 2 && Map[col + 1, row + 1]) result++;
            if (row <= Rows - 2 && Map[col, row + 1]) result++;
            if (col >= 1 && row <= Rows - 2 && Map[col - 1, row + 1]) result++;
            if (col >= 1 && Map[col - 1, row]) result++;

            return result;
        }
        public void ApplyRules()
        {
            bool[,] tempMap = new bool[Cols, Rows];
            for (int i = 0; i < Cols - 1; i++)
            {
                for (int j = 0; j < Rows - 1; j++)
                {
                    var neighbours = getNeighbourCount(i, j);
                    if (neighbours < 2 || neighbours > 3)
                        tempMap[i, j] = false;
                    else if (Map[i, j] && (neighbours == 2 || neighbours == 3))
                        tempMap[i, j] = true;
                    else if (!Map[i, j] && neighbours == 3)
                        tempMap[i, j] = true;
                }
            }
            Map = tempMap;
        }
    }
}
