using StripsClientWPFReeksView.Model;
using StripsClientWPFReeksView.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
using static System.Net.WebRequestMethods;

namespace StripsClientWPFReeksView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StripServiceClient stripService;
        private string path = "http://localhost:5044";
        static HttpClient client = new HttpClient();
        private ObservableCollection<StripWPF> stripsCollection =
            new ObservableCollection<StripWPF>();

        public MainWindow()
        {
            InitializeComponent();
            stripService = new StripServiceClient();
            StripsDataGrid.ItemsSource = stripsCollection;
        }

        private async void GetReeksButton_Click(object sender, RoutedEventArgs e)
        {
            client.BaseAddress = new Uri(path);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
            string reeksIdText = ReeksIdTextBox.Text;
            try
            {
                if (int.TryParse(reeksIdText, out int reeksId))
                {
                    ReeksWPF reeks = await GetReeksAsync($"api/Strips/GetReeks/{reeksId}");
                    if (reeks != null)
                    {
                        NaamTextBox.Text = reeks.Naam;
                        AantalTextBox.Text = reeks.Aantal;
                        foreach (StripWPF s in reeks.Strips)
                        {
                            StripWPF newStrip = new StripWPF(s.nr, s.titel, s.url);
                            stripsCollection.Add(newStrip);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid input. Please enter a valid integer.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong: " + ex.Message);
            }
        }

        static async Task<ReeksWPF> GetReeksAsync(string path)
        {
            try
            {
                ReeksWPF r = null;
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    r = await response.Content.ReadAsAsync<ReeksWPF>();
                }
                return r;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
