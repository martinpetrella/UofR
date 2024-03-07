using System;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Threading.Tasks;
using System.Windows;

namespace SimpleCounterUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.CountTextBox.Text = "50";
            this.NursingFactorTextBox.Text = "3";
            this.MelioraFactorTextBox.Text = "7";
            this.CountRateTextBox.Text = "1";
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                Dispatcher.Invoke(new Action(() =>
                {
                    this.StartButton.IsEnabled = false;
                    this.CountTextBox.IsEnabled = false;
                    this.NursingFactorTextBox.IsEnabled = false;
                    this.MelioraFactorTextBox.IsEnabled = false;
                    this.CountRateTextBox.IsEnabled = false;
                }));

                string? message;
                Process cmd = new Process();
                cmd.StartInfo.FileName = "SimpleCounter.exe";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.UseShellExecute = false;

                Dispatcher.Invoke(new Action(() =>
                {
                    cmd.StartInfo.Arguments = string.Format("{0} {1} {2} {3}",
                                              this.NursingFactorTextBox.Text,
                                              this.MelioraFactorTextBox.Text,
                                              this.CountTextBox.Text,
                                              this.CountRateTextBox.Text);
                }));

                cmd.Start();

                do
                {
                    message = cmd.StandardOutput.ReadLine();

                    Dispatcher.Invoke(new Action(() =>
                    {
                        this.MessageLabel.Content = message == null ? "---" : message;
                    }));
                } while (message != null);

                cmd.WaitForExit();

                Dispatcher.Invoke(new Action(() =>
                {
                    this.StartButton.IsEnabled = true;
                    this.CountTextBox.IsEnabled = true;
                    this.NursingFactorTextBox.IsEnabled = true;
                    this.MelioraFactorTextBox.IsEnabled = true;
                    this.CountRateTextBox.IsEnabled = true;
                }));
            });
        }

        private void FactorTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            this.DescriptionLabel.Content = string.Format("A simple counter displaying a message when count is a multiple of {0} or {1}.",
                this.NursingFactorTextBox.Text, this.MelioraFactorTextBox.Text);
        }
    }
}
