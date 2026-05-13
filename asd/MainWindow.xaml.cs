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

namespace WpfApp4
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
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i <= 40; i++)
            {
                txtNapSzam.Items.Add(i);
            }
            txtNapSzam.SelectedIndex = 0;
        }

        private void hozzaadas(object sender, RoutedEventArgs e)
        {
            int.TryParse(txtEladott.Text, out int eladott);
            int.TryParse(txtElkeszitett.Text, out int elkeszitett);
            int.TryParse(txtNapSzam.SelectedItem.ToString(), out int napSzam);
            if (eladott < 0 || elkeszitett < 0)
            {
                MessageBox.Show("Nem lehet negatív szám!","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            };

            if (eladott > elkeszitett)
            {
                MessageBox.Show("Nem lehet több eladott, mint elkészített!","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }

            string sor = $"{napSzam}.nap:\t elkeszitett: {elkeszitett}\t eladott{eladott}";

            lstAdatok.Items.Add(sor);

            txtElkeszitett.Text = "";
            txtEladott.Text = "";
        }
    }
}