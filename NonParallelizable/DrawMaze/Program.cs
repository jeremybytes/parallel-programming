using Algorithms;
using MazeGrid;
using Ninject;
using System;
using System.Diagnostics;

namespace DrawMaze
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ninject DI Container
            IKernel Container = new StandardKernel();
            Container.Bind<Grid>().ToMethod(c => new ColorGrid(15, 15));
            Container.Bind<IMazeAlgorithm>().To<Sidewinder>();
            Container.Bind<IMazeGenerator>().To<ConsoleLoggingDecorator>()
                .WithConstructorArgument<IMazeGenerator>(Container.Get<MazeGenerator>());

            IMazeGenerator generator = Container.Get<IMazeGenerator>();

            //// Manual object wiring
            //IMazeGenerator generator = 
            //    new ConsoleLoggingDecorator(
            //        new MazeGenerator(
            //            new ColoredGrid(15, 15),
            //            new Sidewinder()));

            CreateAndShowMaze(generator);

            Console.ReadLine();
        }

        private static void CreateAndShowMaze(IMazeGenerator generator)
        {
            var textMaze = generator.GetTextMaze(true);
            Console.WriteLine(textMaze);

            var graphicMaze = generator.GetGraphicalMaze(true);
            graphicMaze.Save("maze.png");
            Process p = new Process();
            p.StartInfo.FileName = "maze.png";
            p.Start();
        }
    }
}
