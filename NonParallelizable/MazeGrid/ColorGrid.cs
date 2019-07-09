using System;
using System.Drawing;
using System.Linq;

namespace MazeGrid
{
    public class ColorGrid : Grid
    {
        private int? maximum;

        public override Distances distances { get; set; }
        public override Distances path { get; set; }

        public ColorGrid(int rows, int columns)
            : base(rows, columns)
        {
            includeBackgrounds = true;
        }

        public override string ContentsOf(Cell cell)
        {
            if (path != null &&
                path.ContainsKey(cell))
            {
                return path[cell].ToString().Last().ToString();
            }
            {
                return " ";
            }
        }

        public override Color BackgroundColorFor(Cell cell)
        {
            maximum = distances?.Values.Max();
            if (distances != null &&
                distances.ContainsKey(cell))
            {
                int distance = distances[cell];
                float intensity = ((float)maximum - (float)distance) / (float)maximum;
                int dark = Convert.ToInt32(255 * intensity);
                int bright = 128 + Convert.ToInt32(127 * intensity);
                return Color.FromArgb(dark, dark, bright);
            }
            else
            {
                return Color.White;
            }
        }

    }
}
