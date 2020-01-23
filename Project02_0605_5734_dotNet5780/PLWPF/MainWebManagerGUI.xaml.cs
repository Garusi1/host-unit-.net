﻿using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MainWebManagerGUI.xaml
    /// </summary>
    public partial class MainWebManagerGUI : Window
    {
        BL.IBL bl;

        public MainWebManagerGUI()
        {
            InitializeComponent();
            bl = BL.Factory.GetInstance();
        }

        private void GuestsList_Click(object sender, RoutedEventArgs e)
        {
            UserControl.GuestsListUC GLUCObj = new UserControl.GuestsListUC();
            WMstackPannel.Children.Add(GLUCObj);
        }
    }
}
