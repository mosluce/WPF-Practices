using NestedListSample.Data;
using NestedListSample.Models;
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

namespace NestedListSample
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        private NestedListSampleDbContext db = new NestedListSampleDbContext();
        private Customer SelectedCustomer;

        public ObservableCollection<Customer> CustomerDataProvider { get; set; }
        public ObservableCollection<Record> RecordDataProvider { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CustomerDataProvider = new ObservableCollection<Customer>(db.Customers.ToList());
            CustomerListView.ItemsSource = CustomerDataProvider;
            CustomerDataProvider.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CustomerDataProvider_Changed);
        }

        private void AddCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerNameTextBox.Text != null && CustomerNameTextBox.Text != "")
            {
                CustomerDataProvider.Add(new Customer
                {
                    Name = CustomerNameTextBox.Text,
                    Birthday = DateTime.Now
                });
            }
        }

        private void AddRecordButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedCustomer != null)
            {
                RecordDataProvider.Add(new Record
                {
                    CreatedAt = DateTime.Now
                });
            }
        }

        private void CustomerListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                SelectedCustomer = e.AddedItems[0] as Customer;

                RecordDataProvider = new ObservableCollection<Record>(SelectedCustomer.Records.ToList());
                RecordListView.ItemsSource = RecordDataProvider;

                RecordDataProvider.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(RecordDataProvider_Changed);
            }
            else
            {
                SelectedCustomer = null;
                RecordDataProvider.Clear();
            }
        }

        private void CustomerDataProvider_Changed(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                foreach (Customer customer in e.NewItems)
                {
                    db.Customers.Add(customer);
                }

                db.SaveChanges();
            }
        }

        private void RecordDataProvider_Changed(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                foreach (Record record in e.NewItems)
                {
                    SelectedCustomer.Records.Add(record);
                }

                db.SaveChanges();
            }
        }

        
    }
}
