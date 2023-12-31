﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskMamanger.Class
{
    public class Task
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public DateTime EndTime { get; set; }
        public User User { get; set; }
        public int UserID { get; set; }
        public TaskColumn TaskColumn { get; set; }
        public int TaskColumnID { get; set; }

        public bool EndTask
        {
            get
            {
                return TaskColumnID == 3;
            }
        }
    }
}
