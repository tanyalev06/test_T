using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            using(HttpClient client = new HttpClient())
            {
                var respons = await client.GetAsync("https://localhost:7295/values");
                respons.EnsureSuccessStatusCode();
                if (respons.IsSuccessStatusCode)
                {
                    message.Content = await respons.Content.ReadAsStringAsync();
                }
                else
                {
                    message.Content = $"Server error code {respons.StatusCode}";
                }
            }
        }
    }
}
