using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMamanger.Class
{
    public class UserList
    {
        public ObservableCollection<User> Users { get; set; }
        public int SelectedUserID { get; set; }
    }
}
