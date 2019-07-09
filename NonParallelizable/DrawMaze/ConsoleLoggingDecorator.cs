using System;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace DrawMaze
{
    public class ConsoleLoggingDecorator : IMazeGenerator
    {
        private readonly IMazeGenerator wrappedGenerator;

        public ConsoleLoggingDecorator(IMazeGenerator mazeGenerator)
        {
            wrappedGenerator = mazeGenerator;
        }

        public string GetTextMaze(bool includePath = false)
        {
            LogEnterMethod();
            var result = wrappedGenerator.GetTextMaze(includePath);
            LogExitMethod();
            return result;
        }

        public Bitmap GetGraphicalMaze(bool includeHeatMap = false)
        {
            LogEnterMethod();
            var result = wrappedGenerator.GetGraphicalMaze(includeHeatMap);
            LogExitMethod();
            return result;
        }

        private void LogEnterMethod([CallerMemberName] string methodName = null)
        {
            LogToConsole($"Entering '{methodName}'");
        }

        private void LogExitMethod([CallerMemberName] string methodName = null)
        {
            LogToConsole($"Exiting '{methodName}'");
        }

        private void LogToConsole(string message)
        {
            Console.WriteLine($"{DateTime.Now:s}: {message}");
        }
    }
}
