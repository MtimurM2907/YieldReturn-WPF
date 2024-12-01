using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace YieldReturn_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        private NumbersGenerate _generate;

        public MainWindow()
        {
            InitializeComponent();
            _generate = new NumbersGenerate();
        }

        private async void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            int initial = Convert.ToInt32(InitialValue.Text);
            int final = Convert.ToInt32(FinalValue.Text);
            if (initial < final)
            {
                ListBox.Items.Clear();
                ProgressBar.Value = 0;
                await GenerationProcess(initial, final);
                MessageBox.Show("Генерация завершена!");
            }
            else
            {
                MessageBox.Show("Неккоректный ввод");
            }
        }

        private async Task GenerationProcess(int initial, int final)
        {
            var numbers = _generate.GetNumbers(initial, final);
            int range = (final - initial) + 1;
            int count = 0;
            foreach (var number in numbers)
            {
                ListBox.Items.Add(number);
                count++;
                ProgressBar.Value = (count / (double)range) * 100;
                await Task.Delay(100);
            }
        }
    }
}
