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
    /// Interaction logic for HandlingOrders.xaml
    /// </summary>
    public partial class HandlingOrders : Window
    {
        BL.IBL bl;


        public HandlingOrders(BE.HostingUnit HU)
        {
            InitializeComponent();
            bl = BL.Factory.GetInstance();
            setActiveUserControl(GuestUC);
        }

        public void setActiveUserControl(UserControl control)
        {
            //הסתר ממשקי עזר
            GuestUC.Visibility = Visibility.Collapsed;
            orderUC.Visibility = Visibility.Collapsed;
            //HostingUC.Visibility = Visibility.Collapsed;
            //HostsUC.Visibility = Visibility.Collapsed;

            //גילוי ממשק שנשלח.
            control.Visibility = Visibility.Visible;
        }

        private void GuestsList_Button_Click(object sender, RoutedEventArgs e)
        {

            setActiveUserControl(GuestUC);
        }

        private void orderLists_Button_Click(object sender, RoutedEventArgs e)
        {
            setActiveUserControl(orderUC);
        }

        //private void hostingUnitLists_Button_Click(object sender, RoutedEventArgs e)
        //{
        //    setActiveUserControl(HostingUC);
        //}

        //private void hostLists_Button_Click(object sender, RoutedEventArgs e)
        //{
        //    setActiveUserControl(HostsUC);
        //}


    }
    public partial class MainWebManagerGUI : Window
    {

       
    }
}
