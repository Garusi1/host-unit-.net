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
            this.DataContext = GRShow;
            //this.GuestRequestGrid.DataContext =GRShow; //הקשר הדטה לפי GuestRequest

            this.typeComboBox.ItemsSource = Enum.GetValues(typeof(BE.TypeEnum));
            this.areaComboBox.ItemsSource = Enum.GetValues(typeof(BE.AreaEnum));
            this.poolComboBox.ItemsSource = Enum.GetValues(typeof(BE.AttractionsEnum));
            this.jacuzziComboBox.ItemsSource = Enum.GetValues(typeof(BE.AttractionsEnum));
            this.gardenComboBox.ItemsSource = Enum.GetValues(typeof(BE.AttractionsEnum));
            this.childrensAttractionsComboBox.ItemsSource = Enum.GetValues(typeof(BE.AttractionsEnum));

        }

        private void Button_Click_Save_GuestRequest(object sender, RoutedEventArgs e)
        {
            try
            {
                //GRShow.PrivateName = this.firstNameTextBox.Text;  //קישור על ידי binding 


                bl.addGuestRequest(GRShow); // add copy of gr to the BL layer
               // GRShow = new BE.GuestRequest();
                //this.GuestRequestGrid.DataContext = GRShow; //הקשר הדטה לפי GuestRequest
                
                // אם אין זריקה 
                MessageBox.Show("דרישת אירוח נוספה בהצלחה");
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

    }
}
