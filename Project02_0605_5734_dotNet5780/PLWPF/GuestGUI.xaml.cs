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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for GuestGUI.xaml
    /// </summary>
    public partial class GuestGUI : Window
    {
        BL.IBL bl;
        BE.GuestRequest GRShow;
        //BE.GuestRequest GRShow =new BE.GuestRequest();//לבדוק 
        List<string> errorMessages = new List<string>(); // לממש 


        public GuestGUI()
        {
            InitializeComponent();
            bl = BL.Factory.GetInstance();
            GRShow = new BE.GuestRequest();
            this.GuestRequestGrid.DataContext =GRShow; //הקשר הדטה לפי GuestRequest

        }

        private void Button_Click_Save_GuestRequest(object sender, RoutedEventArgs e)
        {
            try
            {
                //GRShow.PrivateName = this.firstNameTextBox.Text;  //קישור על ידי binding 


                bl.addGuestRequest(GRShow); // add copy of gr to the BL layer
               // GRShow = new BE.GuestRequest();
                //this.GuestRequestGrid.DataContext = GRShow; //הקשר הדטה לפי GuestRequest

            }

            catch (DuplicateWaitObjectException ex)
            {
                MessageBox.Show(ex.Message);

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);

            }
            catch (System.IO.InvalidDataException ex)
            {
                MessageBox.Show(ex.Message);

            }










        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource guestRequestViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("guestRequestViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // guestRequestViewSource.Source = [generic data source]
        }
    }
}
