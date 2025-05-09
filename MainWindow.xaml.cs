using System.Collections.ObjectModel;
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

namespace Project_OOP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private List<Student> studenten = new List<Student>();
        List<Student> studenten = new List<Student>();
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void btnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            string voornaam = tbxVoornaam.Text;
            string achternaam = tbxAchternaam.Text;
            string nummer = tbxNummer.Text;

            if (!string.IsNullOrEmpty(voornaam) && !string.IsNullOrEmpty(achternaam) && !string.IsNullOrEmpty(nummer))
            {
                Student nieuweStudent = new Student(voornaam, achternaam, nummer);

                studenten.Add(nieuweStudent);
                
                tbxVoornaam.Clear();
                tbxAchternaam.Clear();
                tbxNummer.Clear();
            }
            else
            {
                MessageBox.Show("Gelieve voornaam, achternaam en nummer in te vullen.");
            }
        }

        private void btnVerwijder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnToonlijst_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}