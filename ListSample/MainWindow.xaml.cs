using ListSample.Data;
using ListSample.Models;
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

namespace ListSample
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        private ListSampleDbContext _dbContext { get; set; }
        public ObservableCollection<Product> ProductItems { get; set; }
        public MainWindow()
        {
            _dbContext = new ListSampleDbContext();
            
            InitializeComponent();
        }

        private void ListSampleWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ProductItems = new ObservableCollection<Product>(_dbContext.Products.ToList());
            ProductListView.ItemsSource = ProductItems;
        }
    }
}
