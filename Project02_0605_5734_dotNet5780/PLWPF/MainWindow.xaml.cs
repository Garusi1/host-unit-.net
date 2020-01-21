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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            /// טעינת שפה עברית לחלונות  ---
            Uri dictUri = new Uri(@"/res/languages/AppStrings_HE.xaml", UriKind.Relative); 
            ResourceDictionary resourceDict = Application.LoadComponent(dictUri) as ResourceDictionary;
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            // ---- עד כאן שפה
        }


        private void openGuestGui(object sender, RoutedEventArgs e) //1.0
        {
            GuestGUI GuestGUIShow = new GuestGUI();
            GuestGUIShow.ShowDialog();//פתיחה באופן זה במחייב התייחסות לחלון זה ולא מאפשר להשתמש בחלון שקרא לו.

        }

        private void openMainHostingUnitGUI(object sender, RoutedEventArgs e)//2.0
        {

            MainHostingUnitGUI HostingUnitGUIShow = new MainHostingUnitGUI();
            HostingUnitGUIShow.ShowDialog();//פתיחה באופן זה במחייב התייחסות לחלון זה ולא מאפשר להשתמש בחלון שקרא לו.


            //add hosing unit gui //2.1
            //enter to personal area gui - need to recive int id for hosing unit key//2.2

        }
        private void openMainWebManagerGUI(object sender, RoutedEventArgs e)//4.0
        {

            MainWebManagerGUI MainWebManagerGUIShow = new MainWebManagerGUI();
            MainWebManagerGUIShow.Show();


            // add 
            /*
             * שאילתות רשימת לקוחות 4.1
7. 4.2 שאילתות יחידת אירוח
8. 4.3 שאילתות רשימת הזמנות
4.4 שאילתות נוספות
             */

        }

    }
}
