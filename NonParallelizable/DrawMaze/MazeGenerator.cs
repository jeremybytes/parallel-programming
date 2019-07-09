using Algorithms;
using MazeGrid;
using System;
using System.Drawing;

namespace DrawMaze
{
    public class MazeGenerator : IMazeGenerator
    {
        private readonly Grid maze;
        private readonly IMazeAlgorithm algorithm;
        private bool isGenerated = false;

        public MazeGenerator(Grid grid, IMazeAlgorithm algorithm)
        {
            if (grid == null)
                throw new ArgumentNullException(nameof(grid), $"The '{nameof(grid)}' cannot be null");
            this.maze = grid;
            this.algorithm = algorithm;
        }

        private void GenerateMaze()
        {
            algorithm?.CreateMaze(maze);
            isGenerated = true;
        }

        public string GetTextMaze(bool includePath = false)
        {
            if (!isGenerated)
                GenerateMaze();

            if (includePath)
            {
                Cell start = maze.GetCell(maze.Rows / 2, maze.Columns / 2);
                maze.path = start.GetDistances().PathTo(maze.GetCell(maze.Rows - 1, 0));
            }

            return maze.ToString();
        }

        public Bitmap GetGraphicalMaze(bool includeHeatMap = false)
        {
            if (!isGenerated)
                GenerateMaze();

            if (includeHeatMap)
            {
                Cell start = maze.GetCell(maze.Rows / 2, maze.Columns / 2);
                maze.distances = start.GetDistances();
            }
            return maze.ToPng(30);
        }
    }
}
