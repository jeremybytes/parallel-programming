using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using conway_library;

namespace conway_consoleui
{
    class Program
    {
        static async Task Main(string[] args)
        {
            bool auto = false;

            if (args.Length > 0)
            {
                auto = args.Contains("-auto");
            }

            int rows = 30;
            int columns = 79;

            var grid = new LifeGrid(rows, columns);
            grid.Randomize();

            Console.Clear();
            ShowGrid(grid.CurrentState);

            if (auto)
                await RunAutoAdvance(grid);
            else
                await RunManualAdvance(grid);
        }

        public static async Task RunAutoAdvance(LifeGrid grid)
        {
            while (true)
            {
                await Task.Delay(100);
                await grid.UpdateState();
                ShowGrid(grid.CurrentState);
            }
        }

        public static async Task RunManualAdvance(LifeGrid grid)
        {
            while (Console.ReadKey().Key != ConsoleKey.Q)
            {
                await grid.ParallelForUpdateState();
                ShowGrid(grid.CurrentState);
            }
        }

        private static void ShowGrid(CellState[,] currentState)
        {
            int x = 0;
            int rowLength = currentState.GetUpperBound(1) + 1;

            var output = new StringBuilder();

            foreach(var state in currentState)
            {
                output.Append(state == CellState.Alive ? "O" : "·");
                x++;
                if (x >= rowLength)
                {
                    x = 0;
                    output.AppendLine();
                }
            }

            Console.SetCursorPosition(0, 0);
            Console.Write(output.ToString());
        }
    }
}
