using System;
using System.Collections.Generic;
using System.Text;
using EmployeeBase.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using EmployeeBase.Model;

namespace EmployeeBase.View
{
    /// <summary>
    /// Логика взаимодействия для EditStaffWindow.xaml
    /// </summary>
    public partial class EditStaffWindow : Window
    {
        public EditStaffWindow(Staff staffToEdit)
        {
            InitializeComponent();
            DataContext = new DataManageVM();
            DataManageVM.SelectedStaff = staffToEdit;
            DataManageVM.StaffName = staffToEdit.StaffName;
            DataManageVM.StaffManager = staffToEdit.Manager;
        }
    }
}
