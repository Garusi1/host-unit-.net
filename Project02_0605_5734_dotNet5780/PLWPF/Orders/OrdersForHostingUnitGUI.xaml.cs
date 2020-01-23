using FastMember;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
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
       // BE.Order order = new BE.Order;


        //private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)//https://social.msdn.microsoft.com/Forums/vstudio/en-US/194ee5ad-a3cf-48ae-8c0e-1aab84a1df97/how-to-get-wpf-listview-click-event?forum=wpf
        //  {
        //      GRShow =(BE.GuestRequest)list.SelectedItem;

        //      if (GRShow != null)
        //      {
        //          //int id = int.Parse(selectedrow.Row.ItemArray[0].ToString());
        //          //Console.WriteLine(id);
        //          //Console.WriteLine(bl.getGuestRequestByID(40000000 + id));
        //          ///////////////////////////////////////////Console.WriteLine(GRShow.ToString());
        //      }
        //  }


        public OrdersForHostingUnitGUI(BE.HostingUnit HUshow1)
        {
            //   bl.GetGuestRequestList
            InitializeComponent();
            HUshow = HUshow1;
            List<BE.GuestRequest> hhg = new List<BE.GuestRequest>();

            BE.GuestRequest gg = new BE.GuestRequest();
            gg.PrivateName = "Michael";
            gg.FamilyName = "garusi";
            gg.MailAddress = "mgarusi101@gmail.com";
            gg.Adults = 222;
            gg.Children = 221;
            gg.Pool = (BE.AttractionsEnum)1;
            gg.Jacuzzi = (BE.AttractionsEnum)1;
            gg.RegistrationDate = DateTime.Now;
            gg.EntryDate = DateTime.Parse("30 1");
            gg.ReleaseDate = DateTime.Parse("2 2");
            gg.GuestRequestKey = BE.Configuration.geustReqID;
           
            
            
            BE.GuestRequest gg1 = new BE.GuestRequest();
            gg1.PrivateName = "king";
            gg1.FamilyName = "garusi";
            gg1.MailAddress = "mgarusi101@gmail.com";
            gg1.Adults = 222;
            gg1.Children = 221;
            gg1.Pool = (BE.AttractionsEnum)1;
            gg1.Jacuzzi = (BE.AttractionsEnum)1;
            gg1.RegistrationDate = DateTime.Now;
            gg1.EntryDate = DateTime.Parse("30 1");
            gg1.ReleaseDate = DateTime.Parse("2 2");
            gg1.Type = (BE.TypeEnum)2;
            gg1.GuestRequestKey = BE.Configuration.geustReqID;

            BE.GuestRequest gg2 = gg;
            
            hhg.Add(gg);
            hhg.Add(gg1);
            hhg.Add(gg2);
            

            list.ItemsSource = hhg;

        }
        private void OnMouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            //var btn = sender as System.Windows.Controls.Button;
            //list.SelectedItem = btn.DataContext;
            //GRShow = (BE.GuestRequest)list.SelectedItem;
            //Console.WriteLine(GRShow.ToString());
            System.Windows.Controls.ListView list = (System.Windows.Controls.ListView)sender;
            BE.GuestRequest selectedObject = (BE.GuestRequest)list.SelectedItem;
            selectedObject.ToString();
            try
            {
                BE.Order order = new BE.Order();

                order.GuestRequestKey = (selectedObject.GuestRequestKey);
                order.HostingUnitKey = (HUshow.HostingUnitKey);
                order.OrderDate = DateTime.Now;
                order.OrderKey = BE.Configuration.orderID;
            }
            catch (Exception)
            {
                throw new System.IO.InvalidDataException(/*"כתובת המייל לא תקינה."*/"Email address incorrect");
            }
           
            
            

            Console.WriteLine("fdsfdsfdsfsd");



        }

        //private void Window_Loaded_1(object sender, RoutedEventArgs e)
        //{

        //    System.Windows.Data.CollectionViewSource guestRequestViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("guestRequestViewSource")));
        //    // Load data by setting the CollectionViewSource.Source property:
        //    // guestRequestViewSource.Source = [generic data source]
        //}


        //  BE.GuestRequest item = (BE.GuestRequest)(sender as Button).DataContext;

        //EventManager.RegisterClassHandler(typeof(ListBoxItem),
        // ListBoxItem.MouseDoubleClickEvent,
        // new RoutedEventHandler(this.MouseDoubleClick));


        //void mouseClick(object sender, RoutedEventArgs e)
        //{
        //    var btn = sender as System.Windows.Controls.Button;
        //    list.SelectedItem = btn.DataContext;
        //    GRShow = (BE.GuestRequest)list.SelectedItem;

        //    Console.WriteLine(GRShow.ToString());

        //}


        //DataGridView dataGridView1 = new DataGridView();

        //DataTable dataTable1 = new DataTable();  //https://stackoverflow.com/questions/564366/convert-generic-list-enumerable-to-datatable
        //using (var reader = ObjectReader.Create(hhg))
        //{
        //    dataTable1.Load(reader);
        //}
        //dataGridView1.DataSource = dataTable1;
        //dataGridView1.Visible = true;

        //FruitDataGrid.DataContext = fruitList;



        //IEnumerable<BE.GuestRequest> gg = bl.GetGuestRequestList();
        //foreach (var item in bl.GetGuestRequestList())
        //{
        //    item.ToString();
        //}
        // nn = bl.GetGuestRequestList().ToList();
        // IEnumerable<BE.GuestRequest> GRL = bl.GetGuestRequestList();

        //}

        //{

    }
}
