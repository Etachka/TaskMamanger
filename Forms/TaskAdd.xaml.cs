using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using TaskMamanger.Class;

namespace TaskMamanger.Forms
{
    /// <summary>
    /// Логика взаимодействия для TaskAdd.xaml
    /// </summary>
    public partial class TaskAdd : Window
    {
        private UserList UL;

        public TaskAdd()
        {
            InitializeComponent();
            UL = new UserList();
            DataContext = UL;

            // Инициализация данных выпадающего списка
            using (var context = new ApplicationContext())
            {
                UL.Users = new ObservableCollection<User>(context.Users.ToList());
            }
        }

        private void AddTaskBaton_Click(object sender, RoutedEventArgs e)
        {
            using (var con = new ApplicationContext())
            {
                string name = NameTask.Text;
                string description = DescripTask.Text;
                int priority = Int32.Parse(PrioTask.Text);
                DateTime endTime = DateTime.Parse(DateTask.Text);

                int userID = (int)UserComboBox.SelectedValue;
                int taskColumnID = 1;

                //TaskColumn taskColumn = con.TaskColumns.FirstOrDefault(a => a.Id == taskColumnID);
                //if (taskColumn == null)
                //{
                //    // Если колонка не найдена, создаем новую
                //    taskColumn = new TaskColumn { Name = "Не начали", ItemCount = 0 };
                //    con.TaskColumns.Add(taskColumn);
                //    con.SaveChanges(); // Сохранение изменений в базе данных
                //}

                //User user = con.Users.FirstOrDefault(a => a.ID == userID);
                //if (user == null)
                //{
                //    // Если пользователь не найден, создаем нового
                //    user = new User { Name = "Олежа", Email = "aboba@aboba.aboba", Password = "abobaaa" };
                //    con.Users.Add(user);
                //    con.SaveChanges(); // Сохранение изменений в базе данных
                //}

                Task task = new Task { Name = name, Description = description, Priority = priority, EndTime = endTime, UserID = userID, TaskColumnID = taskColumnID };

                con.Tasks.Add(task);
                con.SaveChanges();
            }
            this.Close();
        }


        private void NameTask_KeyDown(object sender, KeyEventArgs e)
        {
            if (NameTask.Text == "Введите название задания")
            {
                NameTask.Clear();
                NameTask.Foreground = Brushes.Black;
            }
        }

        private void DescripTask_KeyDown(object sender, KeyEventArgs e)
        {
            if (DescripTask.Text == "Введите описание задания")
            {
                DescripTask.Clear();
                DescripTask.Foreground = Brushes.Black;
            }
        }

        private void PrioTask_KeyDown(object sender, KeyEventArgs e)
        {
            if (PrioTask.Text == "Введите приоритет задания")
            {
                PrioTask.Clear();
                PrioTask.Foreground = Brushes.Black;
            }
        }

        private void NameTask_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void PrioTask_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!e.Text.All(char.IsDigit))
            {
                e.Handled = true;
            }
        }
    }
}
