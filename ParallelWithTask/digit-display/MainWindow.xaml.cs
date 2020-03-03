using System;
using System.Threading.Tasks;
using System.Windows;

namespace DigitDisplay
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Offset.Text = 8000.ToString();
            RecordCount.Text = 375.ToString();
        }

        private async void GoButton_Click(object sender, RoutedEventArgs e)
        {
            LeftPanel.Children.Clear();
            RightPanel.Children.Clear();

            string fileName = AppDomain.CurrentDomain.BaseDirectory + "train.csv";

            int offset = int.Parse(Offset.Text);
            int recordCount = int.Parse(RecordCount.Text);

            string[] rawTrain = await Task.Run(() => Loader.trainingReader(fileName, offset, recordCount));
            string[] rawValidation = await Task.Run(() => Loader.validationReader(fileName, offset, recordCount));

            var manhattanClassifier = Recognizers.manhattanClassifier(rawTrain);

            var manhattanRecognizer = new NonParallelRecognizerControl(
                "Single-Threaded Manhattan Classifier");
            LeftPanel.Children.Add(manhattanRecognizer);

            var parallelManhattanRecognizer = new ParallelRecognizerControl(
                "Parallel Manhattan Classifier");
            RightPanel.Children.Add(parallelManhattanRecognizer);

            MessageBox.Show("Ready to start non-parallel");
            await manhattanRecognizer.Start(rawValidation, manhattanClassifier);

            MessageBox.Show("Ready to start parallel");
            await parallelManhattanRecognizer.Start(rawValidation, manhattanClassifier);
        }
    }
}
