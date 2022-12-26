using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using WpfApp1.Model;
namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ObservableCollection<Product> products { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TablewareEntities bd = new TablewareEntities();
            products = new ObservableCollection<Product>(bd.Product.ToList());
            listViewProducts.ItemsSource = products;
        }

        private void buttonSort_Click(object sender, RoutedEventArgs e)
        {
            TablewareEntities bd = new TablewareEntities();
            products = new ObservableCollection<Product>(bd.Product.OrderBy(p => p.ProductCost).ToList());
            listViewProducts.ItemsSource = products;
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
           Product ds = (Product)listViewProducts.SelectedItem;
            MessageBox.Show(ds.ProductDescription);
        }
    }
}
