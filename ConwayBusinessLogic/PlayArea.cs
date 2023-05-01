using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwayBusinessLogic
{
    public class PlayArea //internal = namespace-en belül látható
    {
        //ez egy teszt commit
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
            for (int i = 0; i < Cols; i++)
            {
                for (int j = 0; j < Rows; j++)
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
                int itemIndex = rnd.Next(0, elements.Count());
                int item = elements.ElementAt(itemIndex);
                elements.Remove(item);
                int itemRow = item / Cols;
                int itemCol = item % Cols;
                Map[itemCol, itemRow] = true;
            }
        }
        public void DrawMap()
        {
            for (int i = 0; i < Cols; i++)
            {
                for (int j = 0; j < Rows; j++)
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
            Console.BackgroundColor = ConsoleColor.Black;
        }

        private int getNeighbourCount(int c, int r)
        {
            var result = 0;
            if (c >= 1 && r >= 1 && Map[c - 1, r - 1])
                result++;
            if (r >= 1 && Map[c, r - 1])
                result++;
            if (c <= Cols - 2 && r >= 1 && Map[c + 1, r - 1])
                result++;
            if (c <= Cols - 2 && Map[c + 1, r])
                result++;
            if (c <= Cols - 2 && r <= Rows - 2 && Map[c + 1, r + 1])
                result++;
            if (r <= Rows - 2 && Map[c, r + 1])
                result++;
            if (c >= 1 && r <= Rows - 2 && Map[c - 1, r + 1])
                result++;
            if (c >= 1 && Map[c - 1, r])
                result++;

            return result;
        }
        public void ApplyRules()
        {
            bool[,] tempArea = new bool[Cols, Rows];

            for (int c = 0; c < Cols; c++)
            {
                for (int r = 0; r < Rows; r++)
                {
                    var neighbors = getNeighbourCount(c, r);
                    if (Map[c, r] && neighbors < 2)
                        tempArea[c, r] = false;
                    else if (Map[c, r] && (neighbors == 2 || neighbors == 3))
                        tempArea[c, r] = true;
                    else if (Map[c, r] && neighbors > 3)
                        tempArea[c, r] = false;
                    else if (Map[c, r] == false && neighbors == 3)
                        tempArea[c, r] = true;
                }
            }

            Map = tempArea;
        }

        public bool isAllFalse()
        {
            return !Map.Cast<bool>().Contains(true);
        }
    }
}
