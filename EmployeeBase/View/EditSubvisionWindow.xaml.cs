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
    /// Логика взаимодействия для EditSubvisionWindow.xaml
    /// </summary>
    public partial class EditSubvisionWindow : Window
    {
        public EditSubvisionWindow(Subvision subvisionToEdit)
        {
            InitializeComponent();
            DataContext = new DataManageVM();
            DataManageVM.SelectedSubvision = subvisionToEdit;
            DataManageVM.SubvisionSurname = subvisionToEdit.Surname;
            DataManageVM.SubvisionName = subvisionToEdit.Name;
            DataManageVM.SubvisionPatronymic = subvisionToEdit.Patronymic;
            DataManageVM.SubvisionDOB = subvisionToEdit.DOB;
            DataManageVM.SubvisionGender = subvisionToEdit.Gender;
        }
    }
}
