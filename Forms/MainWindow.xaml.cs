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

            Users = new ObservableCollection<User>(con.Users.ToList());
            Tasks = new ObservableCollection<Task>(con.Tasks.ToList());
            TaskColumns = new ObservableCollection<TaskColumn>(con.TaskColumns.ToList());
            Users = new ObservableCollection<User>
            {
                new User { ID = 1, Name = "Igor", Email="Igor@mail.com", Password=""}
            };
            Tasks = new ObservableCollection<Task>
            {
                new Task {ID = 1, Name = "работа 1", Description = "сложная капец", EndTime = DateTime.Now, Priority = 1, UserID = 1, TaskColumnID = 3},
                new Task {ID = 2, Name = "работа 2", Description = "лёгкая капец", EndTime = DateTime.Now, Priority = 3, UserID = 1, TaskColumnID = 1},
                new Task {ID = 3, Name = "работа 3", Description = "лёгкая капец", EndTime = DateTime.Now, Priority = 3, UserID = 1, TaskColumnID = 2},
                new Task {ID = 4, Name = "работа 4", Description = "лёгкая капец", EndTime = DateTime.Now, Priority = 3, UserID = 1, TaskColumnID = 1},
                new Task {ID = 5, Name = "работа 5", Description = "лёгкая капец", EndTime = DateTime.Now, Priority = 3, UserID = 1, TaskColumnID = 3},
                new Task {ID = 6, Name = "работа 6", Description = "лёгкая капец", EndTime = DateTime.Now, Priority = 3, UserID = 1, TaskColumnID = 2},
                new Task {ID = 7, Name = "работа 7", Description = "лёгкая капец", EndTime = DateTime.Now, Priority = 3, UserID = 1, TaskColumnID = 3},
                new Task {ID = 8, Name = "работа 8", Description = "лёгкая капец", EndTime = DateTime.Now, Priority = 3, UserID = 1, TaskColumnID = 1},    
                new Task {ID = 9, Name = "работа 9", Description = "лёгкая капец", EndTime = DateTime.Now, Priority = 3, UserID = 1, TaskColumnID = 3},
                new Task {ID = 10, Name = "работа 10", Description = "лёгкая капец", EndTime = DateTime.Now, Priority = 3, UserID = 1, TaskColumnID = 2},
                new Task {ID = 11, Name = "работа 11", Description = "лёгкая капец", EndTime = DateTime.Now, Priority = 3, UserID = 1, TaskColumnID = 2},
                new Task {ID = 12, Name = "работа 12", Description = "лёгкая капец", EndTime = DateTime.Now, Priority = 3, UserID = 1, TaskColumnID = 2},
                new Task {ID = 13, Name = "работа 13", Description = "лёгкая капец", EndTime = DateTime.Now, Priority = 3, UserID = 1, TaskColumnID = 3},
                new Task {ID = 14, Name = "работа 14", Description = "лёгкая капец", EndTime = DateTime.Now, Priority = 3, UserID = 1, TaskColumnID = 1},
                new Task {ID = 15, Name = "работа 15", Description = "средняя капец", EndTime = DateTime.Now , Priority = 2, UserID = 1 , TaskColumnID =1}

            };
            TaskColumns = new ObservableCollection<TaskColumn>
            {
                new TaskColumn { Id = 1, Name = "Не начали", ItemCount= Tasks.Count, Tasks = Tasks.Where(n => n.TaskColumnID == 1)},
                new TaskColumn {Id = 2, Name = " Начали", ItemCount= Tasks.Count, Tasks = Tasks.Where(n => n.TaskColumnID == 2)},
                new TaskColumn {Id = 3, Name = " Закончили", ItemCount= Tasks.Count, Tasks = Tasks.Where(n => n.TaskColumnID == 3)},
            };
            icTodoList.ItemsSource = TaskColumns;

            //using (con)
            //{
            //    var User1 = new User { Name = "Igor", Email = "Igor@mail.com", Password = "Igor227" };
            //    var User2 = new User { Name = "Oleg", Email = "Oleg@mail.com", Password = "Oleg229" };
            //    con.Users.Add(User1);
            //    con.Users.Add(User2);
            //    con.SaveChanges();
            //    var TaskColumn1 = new TaskColumn { Name = "Не начали", ItemCount = 0 };
            //    var TaskColumn2 = new TaskColumn { Name = "Начали", ItemCount = 0 };
            //    var TaskColumn3 = new TaskColumn { Name = "Закончили", ItemCount = 0 };
            //    con.TaskColumns.Add(TaskColumn1);
            //    con.TaskColumns.Add(TaskColumn2);
            //    con.TaskColumns.Add(TaskColumn3);
            //    con.SaveChanges();
            //    var task1 = new Task { Name = "olega", Description = "", Priority = 1, EndTime = DateTime.Now.AddDays(7), Type = 1, Picture = "1", UserID = 1, TaskColumnID = 1 };
            //    var task2 = new Task { Name = "fds", Description = "", Priority = 1, EndTime = DateTime.Now.AddDays(17), Type = 1, Picture = "1", UserID = 1, TaskColumnID = 1 };
            //    con.Tasks.Add(task1);
            //    con.Tasks.Add(task2);
            //    con.SaveChanges();
            //}

            //int maxTaskColumnID = con.Tasks.Max(task => task.TaskColumnID);
            //for (int i = 0; i < maxTaskColumnID; i++)
            //{
            //    var taskColumn = new TaskColumn { Name = $"Столбец {i}" };
            //    var tasksInColumn = con.Tasks.Where(task => task.TaskColumnID == i).ToList();
            //    var taskList = new List<Task>();
            //    taskList.AddRange(tasksInColumn);
            //    taskColumn.Tasks = taskList;
            //    TaskColumns.Add(taskColumn);
            //}

            //icTodoList.ItemsSource = TaskColumns;
        }
        //переход на форму добавления
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            TaskAdd taskAdd = new TaskAdd();
            taskAdd.ShowDialog();
        }
        //для переноса задачи в другой столбец
        private void Pointer_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
