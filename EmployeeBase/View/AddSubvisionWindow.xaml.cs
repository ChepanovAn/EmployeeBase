using EmployeeBase.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
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
    /// Логика взаимодействия для AddSubvisionWindow.xaml
    /// </summary>
    public partial class AddSubvisionWindow : Window
    {
        public AddSubvisionWindow()
        {
            InitializeComponent();
            DataContext = new DataManageVM();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
