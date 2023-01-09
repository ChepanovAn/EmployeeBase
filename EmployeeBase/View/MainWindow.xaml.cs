using EmployeeBase.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EmployeeBase.View
{ 
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ListView AllSubvisionsView;
        public static ListView AllStaffsView;
        public static ListView AllOrdersView;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new DataManageVM(); // теперь можем использовать конструкцию Bind
            AllSubvisionsView = ViewAllSubvisions;
            AllStaffsView = ViewAllStaffs;
            AllOrdersView = ViewAllOrders;
        }

        private void ViewAllSubvisions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ViewAllSubvisions_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
