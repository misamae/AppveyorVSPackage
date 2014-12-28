using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace memamjome.AppveyorVSPackage
{
    /// <summary>
    /// Interaction logic for ProjectsControl.xaml
    /// </summary>
    public partial class ProjectsControl : UserControl
    {
        public IProjectsViewModel ViewModel 
        {
            get { return (IProjectsViewModel)this.DataContext; }
            set { this.DataContext = value; }
        }

        public ProjectsControl()
        {
            ViewModel = new ProjectsViewModel();

            InitializeComponent();
        }
    }
}