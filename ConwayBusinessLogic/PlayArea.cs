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
            Map = new bool[rows, cols];
        }

        private void Randomize()
        {
            Random rnd = new Random();
            var elements = Enumerable.Range(0, Cols*Rows);
            rnd.Next(0, elements.Count());
            element
        }
        public void DrawMap()
        {
            for (int i = 0; i < Cols; i++){

            }
        }
    }
}
