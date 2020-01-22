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
        List<BE.GuestRequest> nn = new List<BE.GuestRequest>();
        public OrdersForHostingUnitGUI(BE.HostingUnit HUshow1)
        {
            bl.GetGuestRequestList
            InitializeComponent();
            HUshow = HUshow1;
            List<BE.GuestRequest> hhg = new List<BE.GuestRequest>();
            Console.WriteLine(  HUshow.ToString());
            //hhg.Add(HUshow);
            
            BE.GuestRequest  gg = bl.getGuestRequestByID(20000000);

           // gg.FamilyName = "garusi";
           // gg.PrivateName = "Michael the king";
           // gg.Adults = 222;
           // gg.Children = 221;
            
           //// gg.Pool = true;
           // gg.RegistrationDate = DateTime.Now;

            //hhg.Add(gg);

            //IEnumerable<BE.GuestRequest> gg = bl.GetGuestRequestList();
            //foreach (var item in bl.GetGuestRequestList())
            //{
            //    item.ToString();
            //}
           // nn = bl.GetGuestRequestList().ToList();
           // IEnumerable<BE.GuestRequest> GRL = bl.GetGuestRequestList();
            list.ItemsSource = hhg;
            
            //}

            //{

            //}
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource guestRequestViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("guestRequestViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // guestRequestViewSource.Source = [generic data source]
        }
    }
}
