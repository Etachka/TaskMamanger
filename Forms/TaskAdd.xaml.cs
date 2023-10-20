using System;
using System.Collections.Generic;
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
        public TaskAdd()
        {
            InitializeComponent();
        }

        private void AddTaskBaton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new ApplicationContext())
            {
                var task1 = new Task { Name = NameTask.Text, Description = DescripTask.Text, Priority = Int32.Parse(PrioTask.Text), EndTime = DateTime.Now.AddDays(7), Type = 1, Picture = "1", UserID = 1, TaskColumnID = 1 };
                var task2 = new Task { Name = "fds", Description = "", Priority = 1, EndTime = DateTime.Now.AddDays(17), Type = 1, Picture = "1", UserID = 1, TaskColumnID = 1 };
                context.Tasks.Add(task1);
                context.Tasks.Add(task2);
                context.SaveChanges();
            }
        }
    }
}
