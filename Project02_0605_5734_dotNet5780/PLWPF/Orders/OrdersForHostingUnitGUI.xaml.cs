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

namespace PLWPF.Orders
{
  
    /// <summary>
    /// Interaction logic for OrdersForHostingUnitGUI.xaml
    /// </summary>
    public partial class OrdersForHostingUnitGUI : Window
    {
        BL.imp_BL bl;
        BE.HostingUnit HUshow;
        
        public OrdersForHostingUnitGUI(BE.HostingUnit HUshow)
        {
            InitializeComponent();
            IEnumerable <BE.GuestRequest> GRL = bl.GetGuestRequestList();
            int f = bl.GetGuestRequestList().Count();
            foreach (var item in GRL)
            {

            }

            {

            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
