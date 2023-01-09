using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using EmployeeBase.ViewModel;

namespace EmployeeBase.View
{
    /// <summary>
    /// Логика взаимодействия для AddOrdersWindow.xaml
    /// </summary>
    public partial class AddOrdersWindow : Window
    {
        public AddOrdersWindow()
        {
            InitializeComponent();
            DataContext = new DataManageVM();
        }
    }
}
