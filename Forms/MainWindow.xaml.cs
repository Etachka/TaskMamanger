using Microsoft.EntityFrameworkCore.Storage;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public ObservableCollection<Task> Tasks {  get; set; }
        public ObservableCollection<TaskColumn> TaskColumns {  get; set; }
        public ObservableCollection<User> Users { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            ApplicationContext con = new ApplicationContext();
            Users = new ObservableCollection<User>
            {
                new User { ID = 1, Name = "Igor", Email="Igor@mail.com", Password=""}
                
            };
            Tasks = new ObservableCollection<Task>
            {
                new Task { ID = 1, Name = "работа 1", Description = "сложная капец", EndTime = DateTime.Now , Priority = 1, Type = 1, Picture = "тут могла быть ваша картинка", UserID = 1 },
                new Task { ID = 2, Name = "работа 2", Description = "лёгкая капец", EndTime = DateTime.Now , Priority = 3, Type = 1, Picture = "тут могла быть ваша картинка", UserID = 1 },
                new Task { ID = 2, Name = "работа 2", Description = "лёгкая капец", EndTime = DateTime.Now , Priority = 3, Type = 1, Picture = "тут могла быть ваша картинка", UserID = 1 },
                new Task { ID = 2, Name = "работа 2", Description = "лёгкая капец", EndTime = DateTime.Now , Priority = 3, Type = 1, Picture = "тут могла быть ваша картинка", UserID = 1 },
                new Task { ID = 2, Name = "работа 2", Description = "лёгкая капец", EndTime = DateTime.Now , Priority = 3, Type = 1, Picture = "тут могла быть ваша картинка", UserID = 1 },
                new Task { ID = 2, Name = "работа 2", Description = "лёгкая капец", EndTime = DateTime.Now , Priority = 3, Type = 1, Picture = "тут могла быть ваша картинка", UserID = 1 },
                new Task { ID = 2, Name = "работа 2", Description = "лёгкая капец", EndTime = DateTime.Now , Priority = 3, Type = 1, Picture = "тут могла быть ваша картинка", UserID = 1 },
                new Task { ID = 2, Name = "работа 2", Description = "лёгкая капец", EndTime = DateTime.Now , Priority = 3, Type = 1, Picture = "тут могла быть ваша картинка", UserID = 1 },
                new Task { ID = 2, Name = "работа 2", Description = "лёгкая капец", EndTime = DateTime.Now , Priority = 3, Type = 1, Picture = "тут могла быть ваша картинка", UserID = 1 },
                new Task { ID = 2, Name = "работа 2", Description = "лёгкая капец", EndTime = DateTime.Now , Priority = 3, Type = 1, Picture = "тут могла быть ваша картинка", UserID = 1 },
                new Task { ID = 2, Name = "работа 2", Description = "лёгкая капец", EndTime = DateTime.Now , Priority = 3, Type = 1, Picture = "тут могла быть ваша картинка", UserID = 1 },
                new Task { ID = 2, Name = "работа 2", Description = "лёгкая капец", EndTime = DateTime.Now , Priority = 3, Type = 1, Picture = "тут могла быть ваша картинка", UserID = 1 },
                new Task { ID = 2, Name = "работа 2", Description = "лёгкая капец", EndTime = DateTime.Now , Priority = 3, Type = 1, Picture = "тут могла быть ваша картинка", UserID = 1 },
                new Task { ID = 2, Name = "работа 2", Description = "лёгкая капец", EndTime = DateTime.Now , Priority = 3, Type = 1, Picture = "тут могла быть ваша картинка", UserID = 1 },
                new Task { ID = 3, Name = "работа 3", Description = "средняя капец", EndTime = DateTime.Now , Priority = 2, Type = 1, Picture = "тут могла быть ваша картинка", UserID = 1 }

            };
            TaskColumns = new ObservableCollection<TaskColumn>
            {
                new TaskColumn { Id = 1, Name = "Не начали", ItemCount= Tasks.Count, Tasks = Tasks},
                new TaskColumn {Id = 2, Name = " Начали", ItemCount= Tasks.Count, Tasks = Tasks},
                new TaskColumn {Id = 3, Name = " Закончили", ItemCount= Tasks.Count, Tasks = Tasks},
            };
            icTodoList.ItemsSource = TaskColumns;

            using (var context = new ApplicationContext())
            {
                var User1 = new User { Name = "Igor", Email = "Igor@mail.com", Password = "Igor227" };
                var User2 = new User { Name = "Oleg", Email = "Oleg@mail.com", Password = "Oleg229" };
                context.Users.Add(User1);
                context.Users.Add(User2);
                context.SaveChanges();
                var TaskColumn1 = new TaskColumn { Name = "Не начали", ItemCount = 0 };
                var TaskColumn2 = new TaskColumn { Name = "Начали", ItemCount = 0 };
                var TaskColumn3 = new TaskColumn { Name = "Закончили", ItemCount = 0 };
                context.TaskColumns.Add(TaskColumn1);
                context.TaskColumns.Add(TaskColumn2);
                context.TaskColumns.Add(TaskColumn3);
                context.SaveChanges();
                var task1 = new Task { Name = "olega", Description = "", Priority = 1, EndTime = DateTime.Now.AddDays(7), Type = 1, Picture = "1", UserID = 1, TaskColumnID = 1 };
                var task2 = new Task { Name = "fds", Description = "", Priority = 1, EndTime = DateTime.Now.AddDays(17), Type = 1, Picture = "1", UserID = 1, TaskColumnID = 1 };
                context.Tasks.Add(task1);
                context.Tasks.Add(task2);
                context.SaveChanges();
            }
        }
    }
}
