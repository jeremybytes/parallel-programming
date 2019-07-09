using System.Drawing;

namespace DrawMaze
{
    public interface IMazeGenerator
    {
        Bitmap GetGraphicalMaze(bool includeHeatMap = false);
        string GetTextMaze(bool includePath = false);
    }
}