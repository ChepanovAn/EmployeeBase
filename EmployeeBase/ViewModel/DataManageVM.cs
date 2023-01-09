using EmployeeBase.Model;
using EmployeeBase.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace EmployeeBase.ViewModel
{
    public class DataManageVM : INotifyPropertyChanged
    {
        // Свойства по умолчанию
        // все сотрудники
        private List<Subvision> allSubvisions = DataWorker.GetAllSubvisions();
        public List<Subvision> AllSubvisions
        {
            get { return allSubvisions; }
            set
            {
                allSubvisions = value;
                NotifyPropertyChanged("AllSubvisions");
            }
        }

        // все Подразделение
        private List<Staff> allStaffs = DataWorker.GetAllStaffs();
        public List<Staff> AllStaffs
        {
            get { return allStaffs; }
            set
            {
                allStaffs = value;
                NotifyPropertyChanged("AllStaffs");
            }
        }

        // все Заказы
        private List<Order> allOrders = DataWorker.GetAllOrders();
        public List<Order> AllOrders
        {
            get { return allOrders; }
            set
            {
                allOrders = value;
                NotifyPropertyChanged("AllOrders");
            }
        }
        //------------------------------------------------------------------------------------------------------------

        // Свойства для сотрудника
        public static string SubvisionSurname { get; set; }
        public static string SubvisionName { get; set; }
        public static string SubvisionPatronymic { get; set; }
        public static DateTime SubvisionDOB { get; set; }
        public static string SubvisionGender { get; set; }
        public static Staff SubvisionStaff { get; set; }

        // Свойства для подразделения
        public static string StaffName { get; set; }
        public static string StaffManager { get; set; }

        // Свойства для заказа
        public static int OrderNumber { get; set; }
        public static string OrderProductName { get; set; }
        public Subvision OrderSubvision { get; set; }

        // Свойства для выделенных элементов
        public TabItem SelectedTabItem { get; set; }
        public static Subvision SelectedSubvision { get; set; }
        public static Staff SelectedStaff { get; set; }
        public static Order SelectedOrder { get; set; }

        #region Команды создать
        private RelayCommand addNewSubvision;
        public RelayCommand AddNewSubvision
        {
            get
            {
                return addNewSubvision ?? new RelayCommand(obj =>
               {
                   Window wind = obj as Window;
                   string resultStr = "";
                   if (SubvisionSurname==null || SubvisionSurname.Replace(" ", "").Length==0)
                   {
                       SetRedBlockControll(wind, "SurnameBlock");
                   }
                   if (SubvisionName == null || SubvisionName.Replace(" ", "").Length == 0)
                   {
                       SetRedBlockControll(wind, "NameBlock");
                   }
                   if (SubvisionPatronymic == null || SubvisionPatronymic.Replace(" ", "").Length == 0)
                   {
                       SetRedBlockControll(wind, "PatronymicBlock");
                   }
                   if (SubvisionDOB == null)
                   {
                       SetRedBlockControll(wind, "DOBBlock");
                   }
                   if (SubvisionGender == null || SubvisionGender.Replace(" ", "").Length == 0)
                   {
                       SetRedBlockControll(wind, "GenderBlock");   
                   }
                   if (SubvisionStaff == null)
                   {
                       MessageBox.Show("Укажите подразделение");
                   }
                   else
                   {
                       resultStr = DataWorker. CreateSubvision(SubvisionSurname, SubvisionName, SubvisionPatronymic, SubvisionDOB, SubvisionGender, SubvisionStaff);
                       UpdateAllSubvisionView();
                       ShowMessageToSubvision(resultStr);
                       SetNullValluesToProperties();
                   }
                   wind.Close();
               }
               );
    
             }
        }
        private RelayCommand addNewStaff;
        public RelayCommand AddNewStaff
        {
            get
            {
                return addNewStaff ?? new RelayCommand(obj =>
                {
                    Window wind = obj as Window;
                    string resultStr = "";
                    if (StaffName == null || StaffName.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControll(wind, "NameBlock");
                    }
                    if (StaffManager == null)
                    {
                        SetRedBlockControll(wind, "ManagerBlock");
                    }
                    else
                    {
                        resultStr = DataWorker.CreateStaff(StaffName, StaffManager);
                        UpdateAllStaffView();
                        ShowMessageToSubvision(resultStr);
                        SetNullValluesToProperties();
                    }
                    wind.Close();
                }
                );
            }
        }


        private RelayCommand addNewOrder;
        public RelayCommand AddNewOrder
        {
            get
            {
                return addNewOrder ?? new RelayCommand(obj =>
                {
                    Window wind = obj as Window;
                    string resultStr = "";
                    if (OrderNumber == 0)
                    {
                        SetRedBlockControll(wind, "NumberBlock");
                    }
                    if (OrderProductName == null)
                    {
                        SetRedBlockControll(wind, "ProductNameBlock");
                    }
                    if (OrderSubvision == null)
                    {
                        MessageBox.Show("Укажите сотрудника");
                    }
                
                    else
                    {
                        resultStr = DataWorker.CreateOrder(OrderNumber, OrderProductName, OrderSubvision);
                        UpdateAllOrderView();
                        ShowMessageToSubvision(resultStr);
                        SetNullValluesToProperties();
                        
                        
                    }
                    wind.Close();
                }
                );
            }
        }
        #endregion

        private RelayCommand deleteItem;
        public RelayCommand DeleteItem
        {
            get
            {
                return deleteItem ?? new RelayCommand(obj =>
                {
                    string resultStr = "Ничего не выбрано";
                    // если сотрудник 
                    if(SelectedTabItem.Name== "SubivisionTab" && SelectedSubvision !=null)
                    {
                        resultStr = DataWorker.DeleteSubvision(SelectedSubvision);
                        UpdateAllDataView();
                    }
                    // если подразделение
                    if (SelectedTabItem.Name == "StaffTab" && SelectedStaff != null)
                    {
                        resultStr = DataWorker.DeleteStaff(SelectedStaff);
                        UpdateAllDataView();
                    }
                    // если заказ
                    if (SelectedTabItem.Name == "OrderTab" && SelectedOrder != null)
                    {
                        resultStr = DataWorker.DeleteOrder(SelectedOrder);
                        UpdateAllDataView();
                    }
                    // обновление
                    SetNullValluesToProperties();
                   // ShowMessageToSubvision(resultStr);

                });
            }
        }

        #region Редактировать команда

        // редактировать пользователя
        private RelayCommand editSubvision;
        public RelayCommand EditSubvision
        {
            get
            {
                return editSubvision ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string resultStr = "Не выбран сотрудник";
                    string noStaffStr = "Не выбрано подразделение";
                    if(SelectedSubvision != null && SubvisionStaff != null)
                    {
                        if (SubvisionStaff != null)
                        {
                            resultStr = DataWorker.EditSubvision(SelectedSubvision, SubvisionSurname, SubvisionName, SubvisionPatronymic, SubvisionDOB, SubvisionGender, SubvisionStaff);
                            UpdateAllDataView();
                            SetNullValluesToProperties();
                            ShowMessageToSubvision(resultStr);
                            window.Close();
                        }
                        else ShowMessageToSubvision(noStaffStr);                     

                    }
                   else ShowMessageToSubvision(resultStr);
                });
            }    
        }

        // редактировать подразделение
        private RelayCommand editStaff;
        public RelayCommand EditStaff
        {
            get
            {
                return editStaff ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string resultStr = "Не выбрано подразделение";
                   
                    if (SelectedStaff != null)
                    {
                         resultStr = DataWorker.EditStaff(SelectedStaff, StaffName, StaffManager);
                         UpdateAllDataView();
                         SetNullValluesToProperties();
                         ShowMessageToSubvision(resultStr);
                         window.Close();                     
                                           
                    }
                       else ShowMessageToSubvision(resultStr);
                });
            }
        }

        // редактировать ордер
        private RelayCommand editOrder;
        public RelayCommand EditOrder
        {
            get
            {
                return editOrder ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string resultStr = "Не выбран заказ";
                    string noSubvisionStr = "Не выбран сотрудник";
                    if (SelectedOrder != null && OrderSubvision != null)
                    {
                        if (OrderSubvision != null)
                        {
                            resultStr = DataWorker.EditOrder(SelectedOrder, OrderNumber, OrderProductName, OrderSubvision);
                            UpdateAllDataView();
                            SetNullValluesToProperties();
                            ShowMessageToSubvision(resultStr);
                            window.Close();
                        }
                           else ShowMessageToSubvision(noSubvisionStr);                     

                    }
                       else ShowMessageToSubvision(resultStr);
                });
            }
        }
        #endregion

        #region Команды создания окон
        //команды создания окон Subvision
        private RelayCommand openAddNewSubvisionWind;
        public RelayCommand OpenAddNewSubvisionWind
        {
            get
            {
                return openAddNewSubvisionWind ?? new RelayCommand(obj =>
                {
                    OpenAddSubvisionWindowMethod();
                }
                );
            }
        }
        //команды создания окон Staff
        private RelayCommand openAddNewStaffWind;
        public RelayCommand OpenAddNewStaffWind
        {
            get
            {
                return openAddNewStaffWind ?? new RelayCommand(obj =>
                {
                    OpenAddStaffWindowMethod();
                }
                );
            }
        }
        //команды создания окон Order
        private RelayCommand openAddNewOrderWind;
        public RelayCommand OpenAddNewOrderWind
        {
            get
            {
                return openAddNewOrderWind ?? new RelayCommand(obj =>
                {
                    OpenAddOrderWindowMethod();
                }
                );
            }
        }
        private RelayCommand OpeneditItemWind;
        public RelayCommand OpenEditItemWind
        {
            get
            {
                return OpeneditItemWind ?? new RelayCommand(obj =>
                {
                    string resultStr = "Ничего не выбрано";
                    // если сотрудник 
                    if (SelectedTabItem.Name == "SubvisionTab" && SelectedSubvision != null)
                    {
                        OpenEditSubvisionWindowMethod(SelectedSubvision);
                    }
                    // если подразделение
                    if (SelectedTabItem.Name == "StaffTab" && SelectedStaff != null)
                    {
                        OpenEditStaffWindowMethod(SelectedStaff);
                    }
                    // если заказ
                    if (SelectedTabItem.Name == "OrderTab" && SelectedOrder != null)
                    {
                        OpenEditOrderWindowMethod(SelectedOrder);
                    }                 
                });
            }
        }


        #endregion

        #region Методы открытия окон
        // методы открытия окон
        private void OpenAddSubvisionWindowMethod()
        {
            AddSubvisionWindow newSubvisionWindow = new AddSubvisionWindow();
            SetCenterSubvisionAndOpen(newSubvisionWindow);
        }
        private void OpenAddStaffWindowMethod()
        {
            AddStaffWindow newStaffWindow = new AddStaffWindow();
            SetCenterSubvisionAndOpen(newStaffWindow);
        }
        private void OpenAddOrderWindowMethod()
        {
            AddOrdersWindow newOrdersWindow = new AddOrdersWindow();
            SetCenterSubvisionAndOpen(newOrdersWindow);
        }
        // методы редактирования окон
        private void OpenEditSubvisionWindowMethod(Subvision subvision)
        {
            EditSubvisionWindow editSubvisionWindow = new EditSubvisionWindow(subvision);
            SetCenterSubvisionAndOpen(editSubvisionWindow);
        }
        private void OpenEditStaffWindowMethod(Staff staff)
        {
            EditStaffWindow editStaffWindow = new EditStaffWindow(staff);
            SetCenterSubvisionAndOpen(editStaffWindow);
        }
        private void OpenEditOrderWindowMethod(Order order)
        {
            EditOrdersWindow editOrdersWindow = new EditOrdersWindow(order);
            SetCenterSubvisionAndOpen(editOrdersWindow);
        }
        #endregion

        private void SetRedBlockControll(Window wind, string NameBlock)
        {
            Control block=wind.FindName(NameBlock) as Control;
            block.BorderBrush = Brushes.Red;
        }

        private void ShowMessageToSubvision(string message)
        {
            MessageView messageView = new MessageView(message);
            SetCenterSubvisionAndOpen(messageView);
        }

        #region Обновить окно

        private void SetNullValluesToProperties()
        {
            // для сотрудника
            SubvisionSurname = null;
            SubvisionName = null;
            SubvisionPatronymic = null;
          //  SubvisionDOB = null;
            SubvisionGender = null;
            SubvisionStaff = null;

            // для подразделения
            StaffName = null;
            StaffManager = null;
            // для заказа 
            OrderNumber = 0;
            OrderProductName = null;
            OrderSubvision = null;

        }

        private void UpdateAllDataView()
        {
            UpdateAllSubvisionView();
            UpdateAllStaffView();
            UpdateAllOrderView();

        }
        // Сотрудник
          private void UpdateAllSubvisionView()
        {
            AllSubvisions = DataWorker.GetAllSubvisions();
            MainWindow.AllSubvisionsView.ItemsSource = null;
            MainWindow.AllSubvisionsView.Items.Clear();
            MainWindow.AllSubvisionsView.ItemsSource = AllSubvisions;
            MainWindow.AllSubvisionsView.Items.Refresh();
        }
        // Подразделение
        private void UpdateAllStaffView()
        {
            AllStaffs = DataWorker.GetAllStaffs();
            MainWindow.AllStaffsView.ItemsSource = null;
            MainWindow.AllStaffsView.Items.Clear();
            MainWindow.AllStaffsView.ItemsSource = AllStaffs;
            MainWindow.AllStaffsView.Items.Refresh();
        }
        // Заказ
        private void UpdateAllOrderView()
        {
            AllOrders = DataWorker.GetAllOrders();
            MainWindow.AllOrdersView.ItemsSource = null;
            MainWindow.AllOrdersView.Items.Clear();
            MainWindow.AllOrdersView.ItemsSource = AllOrders;
            MainWindow.AllOrdersView.Items.Refresh();
        }

        #endregion

        private void SetCenterSubvisionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }        
    }
}
 