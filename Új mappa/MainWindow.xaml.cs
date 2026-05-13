using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
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

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (YearTextBox.Text == ""|| NameTextBox.Text == "" || CountryTextBox.Text == "" || ország.Text == "")
            {
                MessageBox.Show("Tolts ki minden mezot.","Figyelmeztetes",MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            int ev = int.Parse(YearTextBox.Text);

            if (ev <= 1988)
            {
                MessageBox.Show("A  megadott datum nem megfelelo.", "Figyelmzetetes", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string sor = $"{NameTextBox.Text};{CountryTextBox.Text};{YearTextBox.Text};{ország.Text}";
            File.AppendAllText("uj_dijazasok.txt", sor + Environment.NewLine, Encoding.UTF8);

            MessageBox.Show("Az adatok sikeresen elmentve!","Siker",MessageBoxButton.OK,MessageBoxImage.Information);

            YearTextBox.Text = "";
            NameTextBox.Text = "";
            CountryTextBox.Text = "";
            ország.Text = "";
        }
    }
}