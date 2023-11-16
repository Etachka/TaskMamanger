using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

using TaskMamanger.Class;

namespace TaskMamanger.Converters
{
    public class TudaSuda : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int userId)
            {
                using (var con = new ApplicationContext())
                {
                    var user = con.Users.FirstOrDefault(u => u.ID == userId);
                    return user?.Name.FirstOrDefault(); ;
                }
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}