using System;
using System.Collections.Generic;
using System.Linq;

namespace digit_console
{
    class Program
    {
        private class Prediction
        {
            public string prediction;
            public string actual;
            public int[] image;
            public int[] closestMatch;
        }

        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Loading training data...");

            var log = new List<Prediction>();

            string fileName = AppDomain.CurrentDomain.BaseDirectory + "train.csv";
            int offset = 9000;
            int recordCount = 100;

            string[] rawTrain = Loader.trainingReader(fileName, offset, recordCount);
            string[] rawValidation = Loader.validationReader(fileName, offset, recordCount);

            var classifier = Recognizers.manhattanClassifier(rawTrain);

            Console.Clear();
            var startTime = DateTime.Now;
            foreach (var imageString in rawValidation)
            {
                int actual = imageString.Split(',').Select(x => Convert.ToInt32(x)).First();
                int[] ints = imageString.Split(',').Select(x => Convert.ToInt32(x)).Skip(1).ToArray();

                // Call the CPU-intensive function
                var result = Recognizers.predict(ints, classifier);

                var prediction = new  Prediction { prediction = result.Label, actual = actual.ToString(),
                                                image = ints, closestMatch = result.Pixels };

                // Display the result
                Console.SetCursorPosition(0, 0);
                WriteOutput(prediction);

                if (prediction.prediction != prediction.actual.ToString())
                {
                    log = LogError(log, prediction);
                }
            }

            var endTime = DateTime.Now;

            Console.Clear();
            Console.WriteLine("Press ENTER to view errors");
            Console.ReadLine();

            foreach (var pred in log)
            {
                WriteOutput(pred);
                Console.WriteLine("-------------------------------------");
            }
            Console.WriteLine($"Total Errors: {log.Count}");
            Console.WriteLine($"Start Time: {startTime}");
            Console.WriteLine($"End Time: {endTime}");
            Console.WriteLine($"Elapsed: {endTime - startTime:ss}");
            Console.WriteLine("\n\nEND END END END END END END END END");
            Console.ReadLine();
        }

        private static List<Prediction> LogError(List<Prediction> log, Prediction prediction)
        {
            log.Add(prediction);
            return log;
        }

        private static void WriteOutput(Prediction prediction)
        {
            Console.WriteLine($"Actual: {prediction.actual} - Prediction: {prediction.prediction}");
            Display.OutputImages(prediction.image, prediction.closestMatch);
        }
    }
}
