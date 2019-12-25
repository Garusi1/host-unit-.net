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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dotNet5780_03_0605_5923
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
    {
        public List<Host> hostsList;

        private Host currentHost;
        public MainWindow()
        {
            InitializeComponent();

            hostsList = new List<Host>()
            {
                 new Host()
                {
                     HostName ="צימרים ווילות בצפון",
                     Units=new List<HostingUnit>()
                    {
                          new HostingUnit()
                        {
                              UnitName="גל בנוף",
                              Rooms = 3,
                              IsSwimmimgPool = true,
                              AllOrders = new List<DateTime>(),
                               Uris=new List<string>()
                               {
                             "https://my.weekend.co.il/Templates/customerimages/21478/gallery/image_21478_16.jpeg?w=1028&h=510&mode=crop&quality=70",
                             "https://my.weekend.co.il/Templates/customerimages/21478/gallery/image_21478_4.jpg?w=1028&h=510&mode=crop&quality=70",
                             "https://my.weekend.co.il/Templates/customerimages/21478/gallery/image_21478_39.jpg?w=1028&h=510&mode=crop&quality=70"
                               }

                         },
                          new HostingUnit()
                        {
                              UnitName="בסוף הדרך",
                              Rooms = 3,
                              IsSwimmimgPool = false,
                              AllOrders = new List<DateTime>(),
                               Uris=new List<string>()
                               {
                             "https://my.weekend.co.il/Templates/customerimages/26033/gallery/image_26033_1f25c8b1e8e04bcb8f22a54d17722b3e.jpg?w=1028&h=510&mode=crop&quality=70",
                             "https://my.weekend.co.il/Templates/customerimages/26033/gallery/image_26033_93506c5c94bd4301b3d5ab7381be0b0c.jpg?w=1028&h=510&mode=crop&quality=70",
                             "https://my.weekend.co.il/Templates/customerimages/26033/gallery/image_26033_07af4fff1fcd467d968d1b2cf92ca52e.jpg?w=1028&h=510&mode=crop&quality=70"
                               }

                         },
                          new HostingUnit()
                        {
                              UnitName="וילה בת גליל",
                              Rooms = 3,
                              IsSwimmimgPool = true,
                              AllOrders = new List<DateTime>(),
                               Uris=new List<string>()
                               {
                            "https://my.weekend.co.il/Templates/customerimages/17850/gallery/image_17850_55.jpg?w=1028&h=510&mode=crop&quality=70",
                             "https://my.weekend.co.il/Templates/customerimages/17850/gallery/image_17850_44.jpg?w=1028&h=510&mode=crop&quality=70",
                             "https://my.weekend.co.il/Templates/customerimages/17850/gallery/image_17850_49.jpg?w=1028&h=510&mode=crop&quality=70"
                               }

                         }
                    }
                 },
                  new Host()
                {
            HostName = "צימרים בדרום",
                Units = new List<HostingUnit>()
                {
                    new HostingUnit ()
                    {
                        UnitName="מדבר פארן",
                      Rooms=2,
                      IsSwimmimgPool=true,
                      AllOrders=new List<DateTime>(),
                      Uris=new List<string>(){"https://pic.rrr.co.il/images/breha/16%20(Big).jpg",
                          "https://pic.rrr.co.il/images/breha/9%20(Big).jpg" }
                    },
                    new HostingUnit()
                    {
                        UnitName="ירוק במדבר",
                        Rooms=3,
                        IsSwimmimgPool=false,
                        AllOrders=new List<DateTime>(),
                        Uris= new List<string>(){ "https://pic.rrr.co.il/images/henriyeta/96%20(Big).jpg",
                            "https://pic.rrr.co.il/images/henriyeta/98%20(Big).jpg" }
                    }
                }
                },
                                 new Host()
                {
                     HostName ="צימרים בגלבוע ובכנרת",
                     Units=new List<HostingUnit>()
                    {
                          new HostingUnit()
                        {
                              UnitName="נופש דביר",
                              Rooms = 3,
                              IsSwimmimgPool = true,
                              AllOrders = new List<DateTime>(),
                               Uris=new List<string>()
                               {
                             "https://pic.aaa.co.il/images/dvir/254.jpg",
                             "https://pic.aaa.co.il/images/dvir/310.jpg",
                             "https://pic.aaa.co.il/images/dvir/273.jpg"
                               }

                         },
                          new HostingUnit()
                        {
                              UnitName="אחוזת ברש",
                              Rooms = 3,
                              IsSwimmimgPool = true,
                              AllOrders = new List<DateTime>(),
                               Uris=new List<string>()
                               {
                             "https://pic.aaa.co.il/images/barash/256.jpg",
                             "https://pic.aaa.co.il/images/barash/199.jpg",
                             "https://pic.aaa.co.il/images/barash/265.jpg"
                               }

                         },
                          new HostingUnit()
                        {
                              UnitName="במורד הארבל",
                              Rooms = 3,
                              IsSwimmimgPool = true,
                              AllOrders = new List<DateTime>(),
                               Uris=new List<string>()
                               {
                            "https://pic.aaa.co.il/images/arbel/97.jpg",
                             "https://pic.aaa.co.il/images/arbel/98.jpg",
                             "https://pic.aaa.co.il/images/arbel/99.jpg"
                               }

                         }
                    }
                 },
            };

            cbHostList.ItemsSource = hostsList;
            cbHostList.DisplayMemberPath = "HostName";
            cbHostList.SelectedIndex = 0;


        }

        private void cbHostList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InitializeHost(cbHostList.SelectedIndex);
        }

        private void InitializeHost(int index)
        {
            MainGrid.Children.RemoveRange(1, 3);
            currentHost = hostsList[index];
            UpGrid.DataContext = currentHost;
            for (int i = 0; i < currentHost.Units.Count; i++)
            {
                HostingUnitUserControl a = new HostingUnitUserControl(currentHost.Units[i]);
                MainGrid.Children.Add(a);
                Grid.SetRow(a, i + 1);
            }
        }

  
    }
}

