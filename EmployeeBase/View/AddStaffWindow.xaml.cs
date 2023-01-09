using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using EmployeeBase.ViewModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EmployeeBase.View
{
    /// <summary>
    /// Логика взаимодействия для AddStaffWindow.xaml
    /// </summary>
    public partial class AddStaffWindow : Window
    {
        public AddStaffWindow()
        {
            InitializeComponent();
            DataContext = new DataManageVM();
        }
    }
}
