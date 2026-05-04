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

namespace toto
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Ellenorzes();
        }

        private void TxtInput_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            Ellenorzes();
        }

        private void Ellenorzes()
        {
            string szoveg = txtInput.Text;

           
            chkHossz.Content = $"Hibás hossz ({szoveg.Length})";
            chkHossz.IsChecked = szoveg.Length != 14;

        
            var hibas = szoveg.Where(c => c != '1' && c != '2' && c != 'X').Distinct();

            string hibasStr = new string(hibas.ToArray());

            chkKarakter.Content = $"Hibás karakterek ({hibasStr})";
            chkKarakter.IsChecked = hibasStr.Length > 0;

        
            btnSave.IsEnabled = szoveg.Length == 14 && hibasStr.Length == 0;
        }
    }
}