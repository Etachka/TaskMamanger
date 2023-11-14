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
                var task1 = new Task
                {
                    Name = NameTask.Text,
                    Description = DescripTask.Text,
                    Priority = Int32.Parse(PrioTask.Text),
                    EndTime = DateTime.Parse(DateTask.Text),
                    TaskColumnID = 1
                };
                context.Tasks.Add(task1);
                context.SaveChanges();
            }
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
    }
}
