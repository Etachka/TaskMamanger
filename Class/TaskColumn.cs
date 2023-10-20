using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMamanger.Class
{
    public class TaskColumn
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ItemCount { get; set; }

        public IEnumerable<Task> Tasks { get; set; } = new HashSet<Task>();

        public bool ShowButton
        {
            get
            {
                return Name == "Не начали";
            }
        }
    }
}
