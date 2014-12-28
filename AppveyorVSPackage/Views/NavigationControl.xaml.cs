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
    /// Interaction logic for NavigationControl.xaml
    /// </summary>
    [Export(typeof(NavigationControl))]
    public partial class NavigationControl : UserControl
    {
        public INavigationViewModel ViewModel
        {
            get { return this.DataContext as INavigationViewModel; }
            set { this.DataContext = value; }
        }

        [ImportingConstructor]
        public NavigationControl(INavigationViewModel viewModel)
        {
            InitializeComponent();

            ViewModel = viewModel;
        }
    }
}
