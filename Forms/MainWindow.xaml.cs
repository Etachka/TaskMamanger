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
                new Task { ID = 3, Name = "работа 3", Description = "средняя капец", EndTime = DateTime.Now , Priority = 2, Type = 1, Picture = "тут могла быть ваша картинка", UserID = 1 }

            };
            TaskColumns = new ObservableCollection<TaskColumn>
            {
                new TaskColumn { Id = 1, Name = "Не начали", ItemCount= Tasks.Count, Tasks = Tasks},
                new TaskColumn {Id = 2, Name = " Начали", ItemCount= Tasks.Count, Tasks = Tasks},
                new TaskColumn {Id = 3, Name = " Закончили", ItemCount= Tasks.Count, Tasks = Tasks},
            };
            icTodoList.ItemsSource = TaskColumns;
        }
    }
}
