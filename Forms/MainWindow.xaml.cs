﻿using Microsoft.EntityFrameworkCore;
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
        List<Task> TaskList = new List<Task>();
        List<TaskColumn> TaskColumnList = new List<TaskColumn>();
        List<User> UserList = new List<User>();
        public MainWindow()
        {
            InitializeComponent();


            //con.Users.AddRange(new[]
            //{
            //    new User { Name = "Igor", Email = "Igor@mail.com", Password = "Igor227" },
            //    new User { Name = "Oleg", Email = "Oleg@mail.com", Password = "Oleg229" }
            //});

            //con.TaskColumns.AddRange(new[]
            //{
            ////    new TaskColumn { Name = "Не начали", ItemCount = 0 },
            ////    new TaskColumn { Name = "Начали", ItemCount = 0 },
            ////    new TaskColumn { Name = "Закончили", ItemCount = 0 },
            //    new TaskColumn { Name = "просто так", ItemCount = 0 },
            //    new TaskColumn { Name = "чтобы был", ItemCount = 0 }
            //});

            //con.Tasks.AddRange(new[]
            //{
            //new Task {Name = "работа 1", Description = "сложная капец", EndTime = DateTime.Now, Priority = 1, UserID = 1, TaskColumnID = 3},
            //    new Task {Name = "работа 2", Description = "лёгкая капец", EndTime = DateTime.Now, Priority = 3, UserID = 1, TaskColumnID = 1},
            //    new Task {Name = "работа 3", Description = "лёгкая капец", EndTime = DateTime.Now, Priority = 3, UserID = 1, TaskColumnID = 2},
            //    new Task {Name = "работа 4", Description = "лёгкая капец", EndTime = DateTime.Now, Priority = 3, UserID = 1, TaskColumnID = 1},
            //    new Task {Name = "работа 5", Description = "лёгкая капец", EndTime = DateTime.Now, Priority = 3, UserID = 1, TaskColumnID = 3},
            //    new Task {Name = "работа 6", Description = "лёгкая капец", EndTime = DateTime.Now, Priority = 3, UserID = 1, TaskColumnID = 2},
            //    new Task {Name = "работа 7", Description = "лёгкая капец", EndTime = DateTime.Now, Priority = 3, UserID = 1, TaskColumnID = 3},
            //    new Task {Name = "работа 8", Description = "лёгкая капец", EndTime = DateTime.Now, Priority = 3, UserID = 1, TaskColumnID = 1},
            //    new Task {Name = "работа 9", Description = "лёгкая капец", EndTime = DateTime.Now, Priority = 3, UserID = 1, TaskColumnID = 3},
            //    new Task {Name = "работа 10", Description = "лёгкая капец", EndTime = DateTime.Now, Priority = 3, UserID = 1, TaskColumnID = 2},
            //    new Task {Name = "работа 11", Description = "лёгкая капец", EndTime = DateTime.Now, Priority = 3, UserID = 1, TaskColumnID = 2},
            //    new Task {Name = "работа 12", Description = "лёгкая капец", EndTime = DateTime.Now, Priority = 3, UserID = 1, TaskColumnID = 2},
            //    new Task {Name = "работа 13", Description = "лёгкая капец", EndTime = DateTime.Now, Priority = 3, UserID = 1, TaskColumnID = 3},
            //    new Task {Name = "работа 14", Description = "лёгкая капец", EndTime = DateTime.Now, Priority = 3, UserID = 1, TaskColumnID = 1},
            //    new Task {Name = "работа 15", Description = "средняя капец", EndTime = DateTime.Now , Priority = 2, UserID = 1 , TaskColumnID =2},
            //    new Task {Name = "работа 16", Description = "ну такая капец", EndTime = DateTime.Now , Priority = 3, UserID = 1 , TaskColumnID =2},
            //    new Task {Name = "работа 17", Description = "дефолт капец", EndTime = DateTime.Now , Priority = 3, UserID = 1 , TaskColumnID =2},
            //    new Task {Name = "работа 18", Description = "средняя капец", EndTime = DateTime.Now , Priority = 2, UserID = 1 , TaskColumnID =2},
            //    new Task {Name = "работа 19", Description = "лютая капец", EndTime = DateTime.Now , Priority = 1, UserID = 1 , TaskColumnID =2},
            //new Task {Name = "работа 20", Description = "лютая капец", EndTime = DateTime.Now , Priority = 1, UserID = 1 , TaskColumnID =2}
            //});
            //con.SaveChanges();

            using (var con = new ApplicationContext())
            {
                TaskColumnList = con.TaskColumns.ToList();
                icTodoList.ItemsSource = TaskColumnList;
                TaskList = con.Tasks.ToList();
            }
            
        }
        //переход на форму добавления
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            TaskAdd taskAdd = new TaskAdd();
            taskAdd.Closed += TaskAdd_Closed;
            taskAdd.Show();
        }

        private void TaskAdd_Closed(object sender, EventArgs e)
        {
            using (var con = new ApplicationContext())
            {
                TaskColumnList = null;
                TaskColumnList = con.TaskColumns.ToList();
                icTodoList.ItemsSource = TaskColumnList;
                TaskList = null;
                TaskList = con.Tasks.ToList();
            }

        }
        //для переноса задачи в другой столбец
        private void Pointer_Click(object sender, RoutedEventArgs e)
        {
            using (var con = new ApplicationContext())
            {
                if (sender is FrameworkElement element && element.DataContext is Task task)
                {
                    if (task.TaskColumnID > 0 && task.TaskColumnID < con.TaskColumns.Max(tc => tc.Id))
                    {
                        task.TaskColumnID += 1;
                        con.Entry(task).State = EntityState.Modified;

                        con.SaveChanges();
                        con.UpdateColumnItemCounts();
                        TaskColumnList = null;
                        TaskColumnList = con.TaskColumns.ToList();
                        icTodoList.ItemsSource = TaskColumnList;

                        TaskList = null;
                        TaskList = con.Tasks.ToList();
                    }
                    else
                    {
                        MessageBox.Show("Превышено количество Столбцов", "Не делай так", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
        }

        private void Pointer2_Click(object sender, RoutedEventArgs e)
        {
            using (var con = new ApplicationContext())
            {
                if (sender is FrameworkElement element && element.DataContext is Task task)
                {
                    if (task.TaskColumnID > 1 && task.TaskColumnID <= con.TaskColumns.Max(tc => tc.Id))
                    {
                        task.TaskColumnID -= 1;
                        con.Entry(task).State = EntityState.Modified;
                        con.SaveChanges();
                        con.UpdateColumnItemCounts();
                        TaskColumnList = null;
                        TaskColumnList = con.TaskColumns.ToList();
                        icTodoList.ItemsSource = TaskColumnList;

                        TaskList = null;
                        TaskList = con.Tasks.ToList();
                    }
                    else
                    {
                        MessageBox.Show("Невозможно уменьшить значение TaskColumnID", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
        }
        public string UserName
        {
            
            get
            {
                using (var con = new ApplicationContext())
                {
                    var task = con.Tasks.FirstOrDefault(x => x.UserID != null);
                    var user = task != null ? task.User : null;
                    return user?.Name;
                }
            }
        }

        private void Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (Search.Text == "Введите название задания")
            {
                Search.Clear();
                Search.Foreground = Brushes.Black;
            }
            

        }
        private void PerformSearch(string searchText)
        {
            using (var con = new ApplicationContext())
            {
                var filteredTasks = con.Tasks.Where(task => task.Name.Contains(searchText)).ToList();

                TaskColumnList = null;
                TaskColumnList = con.TaskColumns.ToList();
                icTodoList.ItemsSource = TaskColumnList;
                TaskList = null;
                
                TaskList = filteredTasks;
                
            }
        }

        private void Search_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(Search.Text != "Введите название задания")
            {
                PerformSearch(Search.Text);
            }
            
        }


        private void Drop_database_Click(object sender, RoutedEventArgs e)
        {
            using (var con = new ApplicationContext())
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить эту задачу?", "Подтверждение удаления", MessageBoxButton.OKCancel);

                if (result == MessageBoxResult.OK)
                {
                Button dropButton = (Button)sender;
                Task task = (Task)dropButton.DataContext;

                    if (task != null && con.Tasks.Contains(task))
                    {

                    
                        con.RemoveTask(task);
                        TaskColumnList = null;
                        TaskColumnList = con.TaskColumns.ToList();
                        icTodoList.ItemsSource = TaskColumnList;
                        TaskList = null;
                        TaskList = con.Tasks.ToList();
                        
                    


                    }
                }
            }
        }

        private void Drop_database_Drop(object sender, DragEventArgs e)
        {
            using (var con = new ApplicationContext())
            {
                TaskColumnList = null;
                TaskColumnList = con.TaskColumns.ToList();
                icTodoList.ItemsSource = TaskColumnList;
                TaskList = null;
                TaskList = con.Tasks.ToList();
            }
        }

        private void ALARM_Click(object sender, RoutedEventArgs e)
        {
            using (var con = new ApplicationContext())
            {
                TaskColumnList = null;
                TaskColumnList = con.TaskColumns.ToList();
                con.UpdateColumnItemCounts();
                icTodoList.ItemsSource = TaskColumnList;
                con.UpdateColumnItemCounts();
                TaskList = null;
                TaskList = con.Tasks.ToList();
            }
        }
    }
}
