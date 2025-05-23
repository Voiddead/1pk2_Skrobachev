using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace ShoppingList
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<string> products;
        private const string DefaultFileName = "shopping_list.txt";

        public MainWindow()
        {
            InitializeComponent();
            products = new ObservableCollection<string>();
            ProductsListBox.ItemsSource = products;
            LoadProducts();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ProductTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите название продукта!",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            products.Add(ProductTextBox.Text);
            ProductTextBox.Clear();
            ProductTextBox.Focus();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (products.Count == 0)
            {
                MessageBox.Show("Список покупок пуст!",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*",
                FileName = DefaultFileName,
                DefaultExt = ".txt"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    File.WriteAllLines(saveFileDialog.FileName, products);
                    MessageBox.Show("Список покупок успешно сохранен!",
                        "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}",
                        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            if (products.Count > 0)
            {
                var result = MessageBox.Show("Вы уверены, что хотите очистить список покупок?",
                    "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    products.Clear();
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (products.Count > 0)
            {
                var result = MessageBox.Show("Сохранить список покупок перед выходом?",
                    "Подтверждение", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    SaveButton_Click(sender, null);
                }
                else if (result == MessageBoxResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void LoadProducts()
        {
            try
            {
                if (File.Exists(DefaultFileName))
                {
                    var result = MessageBox.Show("Найден сохраненный список покупок. Загрузить его?",
                        "Загрузка", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        var loadedProducts = File.ReadAllLines(DefaultFileName);
                        foreach (var product in loadedProducts)
                        {
                            products.Add(product);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке файла: {ex.Message}",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}