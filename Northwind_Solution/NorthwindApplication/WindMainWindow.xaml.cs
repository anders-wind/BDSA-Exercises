using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using Northwind;
using NorthwindApplication.ViewModels;

namespace NorthwindApplication
{
    /// <summary>
    /// Interaction logic for WindMainWindow.xaml
    /// </summary>
    public partial class WindMainWindow : Window
    {
        private OrdersViewModel ordersListViewModel = new OrdersViewModel();
        private OrderViewModel orderViewModel = new OrderViewModel();
        public WindMainWindow()
        {
            ordersListViewModel.GetOrders();

            InitializeComponent();

            OrdersDataGrid.ItemsSource = ordersListViewModel.ordersList;
            UpdateCurrentOrder();
        }

        public void UpdateCurrentOrder()
        {
            OrderObjectGrid.DataContext = ordersListViewModel.ordersList[OrdersDataGrid.SelectedIndex];
            OrderDetailsDataGrid.DataContext = ordersListViewModel.ordersList[OrdersDataGrid.SelectedIndex];
            //OrderDetailsDataGrid.ItemsSource = ordersListViewModel.ordersList[OrdersDataGrid.SelectedIndex].OrderDetailViews;
        }
    }


}
