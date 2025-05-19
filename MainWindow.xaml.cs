﻿using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Text.Json;
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
        public ObservableCollection<string> studenten = new ObservableCollection<string>();
        
        public MainWindow()
        {
            InitializeComponent();
            cbxStudenten.ItemsSource = studenten;
            // Json file linken bij opstart
            string JsonPad = "Studenten.json";
            if (File.Exists(JsonPad) && new FileInfo(JsonPad).Length > 0)
            {
                try
                {
                    string json = File.ReadAllText(JsonPad);
                    List<Student> opgeslagenStudenten = JsonSerializer.Deserialize<List<Student>>(json);

                    if (opgeslagenStudenten != null)
                    {
                        foreach (Student s in opgeslagenStudenten.OrderBy(s => s.Achternaam))
                        {
                            studenten.Add(s.Beschrijf());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fout bij het inlezen van studenten: " + ex.Message);
                }
            }
        }

        private void btnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string voornaam = tbxVoornaam.Text;
                string achternaam = tbxAchternaam.Text;
                string stringnummer = tbxNummer.Text;
                string stringscore = tbxScore.Text;
                int nummer = Convert.ToInt32(stringnummer);
                int score = Convert.ToInt32(stringscore);

                if (!string.IsNullOrEmpty(voornaam) && !string.IsNullOrEmpty(achternaam) && !string.IsNullOrEmpty(stringnummer) && !string.IsNullOrEmpty(stringscore))
                {
                    Student nieuweStudent = new Student(voornaam, achternaam, nummer, score);
                    studenten.Add(nieuweStudent.Beschrijf());

                    //Studenten toevoegen aan de Json file
                    string JsonPad = "Studenten.json";
                    List<Student> bestaandeStudenten = new List<Student>();

                    if (File.Exists(JsonPad) && new FileInfo(JsonPad).Length > 0)
                    {
                        string bestaandeJson = File.ReadAllText(JsonPad);
                        bestaandeStudenten = JsonSerializer.Deserialize<List<Student>>(bestaandeJson) ?? new List<Student>();
                    }

                    bestaandeStudenten.Add(nieuweStudent);

                    // Serialize lijst naar bestand
                    string nieuweJson = JsonSerializer.Serialize(bestaandeStudenten, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(JsonPad, nieuweJson);

                    // Herlaad gesorteerde beschrijvingen
                    studenten.Clear();
                    foreach (Student s in bestaandeStudenten.OrderBy(s => s.Achternaam))
                    {
                        studenten.Add(s.Beschrijf());
                    }

                    tbxVoornaam.Clear();
                    tbxAchternaam.Clear();
                    tbxNummer.Clear();
                    tbxScore.Clear();
                    tbxScoreAanpassen.Clear();
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Geef een Voornaam, Achternaam, Nummer en Score in");
            }
        }

        private void btnVerwijder_Click(object sender, RoutedEventArgs e)
        {
            if (cbxStudenten.SelectedItem != null)
            {
                string geselecteerdeBeschrijving = cbxStudenten.SelectedItem.ToString();
                studenten.Remove(geselecteerdeBeschrijving);

               
                string JsonPad = "Studenten.json";
                if (File.Exists(JsonPad))
                {
                    string json = File.ReadAllText(JsonPad);
                    List<Student> bestaandeStudenten = JsonSerializer.Deserialize<List<Student>>(json);

                    if (bestaandeStudenten != null)
                    {
                        Student teVerwijderen = bestaandeStudenten.FirstOrDefault(s => s.Beschrijf() == geselecteerdeBeschrijving);

                        if (teVerwijderen != null)
                        {
                            bestaandeStudenten.Remove(teVerwijderen);
                            string nieuweJson = JsonSerializer.Serialize(bestaandeStudenten, new JsonSerializerOptions { WriteIndented = true });
                            File.WriteAllText(JsonPad, nieuweJson);
                            
                        }
                    }
                }
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            studenten.Clear();

            // Leeg de JSON-file
            string JsonPad = "Studenten.json";
            File.WriteAllText(JsonPad, "[]");
        }

        private void btnScoreAanpassen_Click(object sender, RoutedEventArgs e)
        {
            if (cbxStudenten.SelectedItem != null && int.TryParse(tbxScoreAanpassen.Text, out int nieuweScore))
            {

                string geselecteerdeBeschrijving = cbxStudenten.SelectedItem.ToString();
                string jsonPad = "Studenten.json";

                if (File.Exists(jsonPad))
                {
                    string json = File.ReadAllText(jsonPad);
                    List<Student> studentenUitJson = JsonSerializer.Deserialize<List<Student>>(json);

                    if (studentenUitJson != null)
                    {
                        Student geselecteerde = studentenUitJson.FirstOrDefault(s => s.Beschrijf() == geselecteerdeBeschrijving);

                        if (geselecteerde != null)
                        {
                            geselecteerde.Score = nieuweScore;

                            // Schrijf terug naar JSON
                            string nieuwJson = JsonSerializer.Serialize(studentenUitJson, new JsonSerializerOptions { WriteIndented = true });
                            File.WriteAllText(jsonPad, nieuwJson);

                            // Update ComboBox (herbouw beschrijving)
                            studenten[cbxStudenten.SelectedIndex] = geselecteerde.Beschrijf();
                            tbxScoreAanpassen.Clear();
                        }
                    }
                }
            }
        }

        private void cbxStudenten_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxStudenten.SelectedItem != null)
            {
                string geselecteerdeBeschrijving = cbxStudenten.SelectedItem.ToString();
                string jsonPad = "Studenten.json";

                if (File.Exists(jsonPad))
                {
                    string json = File.ReadAllText(jsonPad);
                    List<Student> studentenUitJson = JsonSerializer.Deserialize<List<Student>>(json);

                    if (studentenUitJson != null)
                    {
                        Student geselecteerde = studentenUitJson.FirstOrDefault(s => s.Beschrijf() == geselecteerdeBeschrijving);

                        if (geselecteerde != null)
                        {
                            tbxScoreAanpassen.Text = geselecteerde.Score.ToString();
                        }
                    }
                }
            }
        }
    }
}