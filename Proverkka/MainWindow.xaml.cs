using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
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

namespace Proverkka
{

    public partial class MainWindow : Window
    {
        int idSelected;
        List<Note> notes;
        List<Note> selectedNotes = new List<Note>();
        List<string> types = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            notes = SaveLoad.Load();
            DatePicker.Text = DateTime.Now.ToString();
            Change_Price();
            UpDate();

        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime selectedDate = Convert.ToDateTime(DatePicker.Text);

            selectedNotes = notes.Where(note => note.date == selectedDate).ToList();

            List<string> noteNames = selectedNotes.Select(note => note.name).ToList();
            Menu.ItemsSource = noteNames;
        }



        private void Menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedName = Menu.SelectedItem as string;

            if (selectedName != null)
            {
                var selectedNote = notes.FirstOrDefault(note => note.name == selectedName);

                if (selectedNote != null)
                {
                    NameBox.Text = selectedNote.name;
                    comboBox.Text = selectedNote.type;
                    SumBox.Text = selectedNote.money.ToString();
                    idSelected = notes.IndexOf(selectedNote);
                }
            }
        }


        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            notes.RemoveAt(idSelected);
            UpDate();
            SaveLoad.Save(notes);
            Change_Price();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            notes.Add(new Note(NameBox.Text, comboBox.Text, Convert.ToDouble(SumBox.Text), Convert.ToDateTime(DatePicker.Text)));
            UpDate();
            SaveLoad.Save(notes);
            Change_Price();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            notes.RemoveAt(idSelected);
            notes.Add(new Note(NameBox.Text, comboBox.Text, Convert.ToDouble(SumBox.Text), Convert.ToDateTime(DatePicker.Text)));
            UpDate();
            SaveLoad.Save(notes);
        }

        private void UpDate()
        {
            DateTime selectedDate = Convert.ToDateTime(DatePicker.Text);

            selectedNotes = notes.Where(note => note.date == selectedDate).ToList();

            List<Note> noteNames = selectedNotes.Select(note =>
                new Note(note.name, note.type, note.money, note.date)).ToList();

            Menu.ItemsSource = noteNames;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Dialog dialog = new Dialog();
            if (dialog.ShowDialog() == true)
            {
                int c = 0;
                foreach (string type in types)
                {
                    if (type == dialog.textReturn) { c++; }
                }
                if (c == 0)
                {
                    types.Add(dialog.textReturn);
                }
                comboBox.ItemsSource = types;
            }
            else
            {
                MessageBox.Show("Тема не была добавлена");
            }
        }

        private void Change_Price()
        {
            try
            {
                double totalSum = notes.Sum(note => note.money);
                Price.Content = totalSum.ToString();
            }
            catch { }
        }

    }
}