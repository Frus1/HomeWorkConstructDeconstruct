using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using HomeWorkConstructDeconstruct.Classes;

namespace HomeWorkConstructDeconstruct
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Product> _products = new ObservableCollection<Product>();
        public MainWindow()
        {
            InitializeComponent();
            ProductListBox.ItemsSource = _products;
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            string name = ProductNameTextBox.Text;
            double.TryParse(ProductPriceTextBox.Text, out double price);
            int.TryParse(ProductQuantityTextBox.Text, out int quantity);
            if (string.IsNullOrEmpty(ProductQuantityTextBox.Text))
            {
                _products.Add(new Product(name, price));
            }
            else
            {
                _products.Add(new Product(name, price, quantity));
            }
            ProductNameTextBox.Clear();
            ProductPriceTextBox.Clear();
            ProductQuantityTextBox.Clear();
        }

        private void OutputProductInfoButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductListBox.SelectedItem is Product product)
            {
                product.Deconstruct(out string name, out double price, out int quantity);
                MessageBox.Show($"Название: {name}\nЦена: {price:C2}\nКоличество: {quantity}", "Информация о товаре");
            }
        }

        private void ProductNameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ProductNameTextBox.Clear();
        }

        private void ProductPriceTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ProductPriceTextBox.Clear();
        }

        private void ProductQuantityTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ProductQuantityTextBox.Clear();
        }
    }
}
