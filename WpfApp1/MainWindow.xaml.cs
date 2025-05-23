using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace StudentApp
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Student> students;
        private const string SaveFileName = "students.xml";

        public MainWindow()
        {
            InitializeComponent();
            students = new ObservableCollection<Student>();
            StudentsListBox.ItemsSource = students;
            LoadStudents();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LastNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(FirstNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(MiddleNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(GroupTextBox.Text) ||
                DateOfBirthPicker.SelectedDate == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var student = new Student
            {
                LastName = LastNameTextBox.Text,
                FirstName = FirstNameTextBox.Text,
                MiddleName = MiddleNameTextBox.Text,
                Group = GroupTextBox.Text,
                Gender = GenderComboBox.SelectedIndex == 0 ? Gender.Male : Gender.Female,
                DateOfBirth = DateOfBirthPicker.SelectedDate.Value
            };

            students.Add(student);
            ClearInputs();
        }

        private void ClearInputs()
        {
            LastNameTextBox.Clear();
            FirstNameTextBox.Clear();
            MiddleNameTextBox.Clear();
            GroupTextBox.Clear();
            GenderComboBox.SelectedIndex = -1;
            DateOfBirthPicker.SelectedDate = null;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveStudents();
        }

        private void SaveStudents()
        {
            try
            {
                var serializer = new XmlSerializer(typeof(ObservableCollection<Student>));
                using (var writer = new StreamWriter(SaveFileName))
                {
                    serializer.Serialize(writer, students);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadStudents()
        {
            try
            {
                if (File.Exists(SaveFileName))
                {
                    var serializer = new XmlSerializer(typeof(ObservableCollection<Student>));
                    using (var reader = new StreamReader(SaveFileName))
                    {
                        var loadedStudents = (ObservableCollection<Student>)serializer.Deserialize(reader);
                        students.Clear();
                        foreach (var student in loadedStudents)
                        {
                            students.Add(student);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}