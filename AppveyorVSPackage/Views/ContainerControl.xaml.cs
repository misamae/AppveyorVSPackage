﻿using System;
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

namespace memamjome.AppveyorVSPackage.Views
{
    /// <summary>
    /// Interaction logic for ContainerControl.xaml
    /// </summary>
    [Export(typeof(ContainerControl))]
    public partial class ContainerControl : UserControl
    {
        [ImportingConstructor]
        public ContainerControl(ProjectsControl projectsControl, SettingsControl settingsControl)
        //public ContainerControl(SettingsControl settingsControl)
        {
            InitializeComponent();

            this._containerStackPanel.Children.Add(settingsControl);
            this._containerStackPanel.Children.Add(projectsControl);
        }
    }
}
