using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using memamjome.AppveyorVSPackage.ViewModels;

namespace memamjome.AppveyorVSPackage.Views
{
    /// <summary>
    /// Interaction logic for SettingsControl.xaml
    /// </summary>
    [Export(typeof(SettingsControl))]
    public partial class SettingsControl : UserControl
    {
        private ISettingsViewModel ViewModel
        {
            get { return this.DataContext as ISettingsViewModel; }
            set { this.DataContext = value; }
        }

        [ImportingConstructor]
        public SettingsControl(ISettingsViewModel settingsViewModel)
        {
            ViewModel = settingsViewModel;
            InitializeComponent();
        }
    }
}
