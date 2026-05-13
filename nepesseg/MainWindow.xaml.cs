using System.IO;
using System.Windows;

namespace adatbovites
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnKilepes_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMentes_Click(object sender, RoutedEventArgs e)
        {
            int nepesseg = int.Parse(txtNepesseg.Text);
            int fovarosNepesseg = int.Parse(txtFovarosNepesseg.Text);

            if (fovarosNepesseg > nepesseg)
            {
                MessageBox.Show("A főváros lakossága nem lehet több a népességnél!");
                txtFovarosNepesseg.Text = txtNepesseg.Text;
                return;
            }

            string sor = $"{txtOrszagnev.Text};{txtTerulet.Text};{txtNepesseg.Text};{txtFovaros.Text};{txtFovarosNepesseg.Text}";
            File.AppendAllText("ujadat.txt", sor + System.Environment.NewLine);
            MessageBox.Show("A mentés sikeres!");
        }
    }
}