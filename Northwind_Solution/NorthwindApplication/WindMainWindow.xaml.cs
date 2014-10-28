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
using NorthwindApplication.ViewModels;

namespace NorthwindApplication
{
    /// <summary>
    /// Interaction logic for WindMainWindow.xaml
    /// </summary>
    public partial class WindMainWindow : Window
    {
        public WindMainWindow()
        {
            InitializeComponent();
            var OVM = new OrderViewModel().GetOrder(10248);
            LabelOrderID.Content = OVM.OrderID;
        }
    }
}
