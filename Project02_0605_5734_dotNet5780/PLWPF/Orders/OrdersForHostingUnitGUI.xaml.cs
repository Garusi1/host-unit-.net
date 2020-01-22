using System;
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
        BL.IBL bl;
        BE.GuestRequest GRShow;
        BE.HostingUnit HUshow;
        
        public OrdersForHostingUnitGUI(BE.HostingUnit HUshow1)
        {
            InitializeComponent();
            HUshow = HUshow1;
            IEnumerable <BE.GuestRequest> GRL = bl.GetGuestRequestList();
            foreach (var item in GRL)
            {
                lvUsers.ItemsSource = items;

            }

            {

            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
