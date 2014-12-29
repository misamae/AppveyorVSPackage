using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace memamjome.AppveyorVSPackage.Converters
{
    public class BuildStatusColourConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var status = value as string;

            if (status == Model.ProjectConstants.Failed)
            {
                return new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 252, 92, 60));
            }
            if (status == Model.ProjectConstants.Success)
            {
                return new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 95, 227, 94));
            }
            if (status == Model.ProjectConstants.Building)
            {
                return new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 192, 192, 192));
            }

            throw new NotSupportedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
