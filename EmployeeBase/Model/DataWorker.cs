using EmployeeBase.Model.DataApplCont;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBase.Model
{
    public static class DataWorker
    {
        // получаем всех Сотрудников
        public static List<Subvision> GetAllSubvisions()
        {
            using(ApplicationContext db=new ApplicationContext())
            {
                var result = db.Subvisions.ToList();
                return result;
            }
        }

        // получаем все Подразделения
        public static List<Staff> GetAllStaffs()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Staffs.ToList();
                return result;
            }
        }

        // получаем все Заказы
        public static List<Order> GetAllOrders()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Orders.ToList();
                return result;
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------

        // создание Сотрудника
        public static string CreateSubvision(string surname, string name, string patronymic, DateTime dob, string gender, Staff staff)
        {
            string result = "Уже существует";
            using(ApplicationContext db=new ApplicationContext())
            {
                // проверяем существеут ли сотрудник
                bool checkIsExist = db.Subvisions.Any(el => el.Surname == surname && el.Name == name && el.Patronymic == patronymic);
                if (!checkIsExist)
                {
                    Subvision newSubvision = new Subvision
                    { Surname = surname, Name = name, 
                      Patronymic = patronymic, DOB=dob, Gender=gender, StaffId = staff.Id 
                    };
                   db.Subvisions.Add(newSubvision);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }
        }

        // создание Подразделения
        public static string CreateStaff(string staffName, string manager)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                // проверяем существеут ли подразделение
                bool checkIsExist = db.Staffs.Any(el => el.StaffName == staffName && el.Manager == manager);
                if (!checkIsExist)
                {
                    Staff newStaff = new Staff
                    {
                        StaffName = staffName,
                        Manager = manager
                    };
                    db.Staffs.Add(newStaff);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }
        }

        // создание Заказа
        public static string CreateOrder(int orderNumber, string productName, Subvision subvision)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                // проверяем существеут ли заказ
                bool checkIsExist = db.Orders.Any(el => el.OrderNumber == orderNumber && el.ProductName == productName);
                if (!checkIsExist)
                {
                    Order newOrder = new Order
                    {
                        OrderNumber = orderNumber,
                        ProductName = productName,
                        SubvisionId = subvision.Id
                    };
                    db.Orders.Add(newOrder);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------
        // удаление Сотрудника
        public static string DeleteSubvision(Subvision subvision)
        {
            string result = "Такого сотрудника не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Subvisions.Remove(subvision);
                db.SaveChanges();
                
            }
            return result;
        }

        // удаление Подразделения
        public static string DeleteStaff(Staff staff)
        {
            string result = "Такого подразделения не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Staffs.Remove(staff);
                db.SaveChanges();
                
            }
            return result;
        }

        // удаление Заказа
        public static string DeleteOrder(Order order)
        {
            string result = "Такого заказа не существует";
            using (ApplicationContext db = new ApplicationContext())
            {                
                db.Orders.Remove(order);                
                db.SaveChanges();               

            }
            return result;
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------

        // редактирование Сотрудника
        public static string EditSubvision(Subvision oldSubvision, string newSurname, string newName, string newPatronymic, DateTime newDOB, string newGender, Staff newStaff)
        {
            string result = "Такого сотрудника не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                Subvision subvision = db.Subvisions.FirstOrDefault(subv => subv.Id == oldSubvision.Id);
                if (subvision != null)
                {
                    subvision.Surname = newSurname;
                    subvision.Name = newName;
                    subvision.Patronymic = newPatronymic;
                    subvision.DOB = newDOB;
                    subvision.Gender = newGender;
                    subvision.StaffId = newStaff.Id;
                    db.SaveChanges();
                    result = "Сделано! Сотрудник " + subvision.Surname + " изменен";
                }
            }
            return result;
        }

        // редактирование Подразделения
        public static string EditStaff(Staff oldStaff, string newStaffName, string newManager)
        {
            string result = "Такого подразделения не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                Staff staff = db.Staffs.FirstOrDefault(st => st.Id == oldStaff.Id);
                if (staff != null)
                {
                    staff.StaffName = newStaffName;
                    staff.Manager = newManager;
                    db.SaveChanges();
                    result = "Сделано! Подразделение " + staff.StaffName + " изменено";
                }
            }
            return result;
        }

        // редактирование Заказа
        public static string EditOrder(Order oldOrder, int newOrderNumber, string newProductName, Subvision newSubvision)
        {
            string result = "Такого заказа не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                Order order = db.Orders.FirstOrDefault(ord => ord.Id == oldOrder.Id);
                if (order != null)
                {
                    order.OrderNumber = newOrderNumber;
                    order.ProductName = newProductName;
                    order.SubvisionId = newSubvision.Id;
                    db.SaveChanges();
                    result = "Сделано! Заказ " + order.OrderNumber + " изменен";
                }
            }
            return result;
        }

        // Получение подразделения по Id подразделения
        public static Staff GetStaffById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Staff stf = db.Staffs.FirstOrDefault(p => p.Id == id);
                return stf;
            }
        }

        // Получение Сотрудник по Id подразделения
        public static Subvision GetSubvisionById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Subvision sbv = db.Subvisions.FirstOrDefault(p => p.Id == id);
                return sbv;
            }
        }

        // получение сотрудников по id позиции
        public static List<Order> GetAllOrdersBySubvisionId(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<Order> orders = (from order in GetAllOrders() where order.SubvisionId == id select order).ToList();
                return orders;
            }
        }

        // получение подразделений по id подразделения
        public static List<Subvision> GetAllSubvisionsByStaffId(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<Subvision> subvisions= (from subvision in GetAllSubvisions() where subvision.StaffId == id select subvision).ToList();
                return subvisions;
            }
        }
    }
}
