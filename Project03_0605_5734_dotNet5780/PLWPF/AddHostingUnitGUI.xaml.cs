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
    /// Interaction logic for AddHostingUnitGUI.xaml
    /// </summary>
    public partial class AddHostingUnitGUI : Window
    {


        BL.IBL bl;
        BE.HostingUnit HUshow ;
        //BE.GuestRequest GRShow =new BE.GuestRequest();//לבדוק 
        List<string> errorMessages = new List<string>(); // לממש 



        public AddHostingUnitGUI()
        {
            InitializeComponent();

            bl = BL.Factory.GetInstance();
            HUshow = new BE.HostingUnit() { Owner=new BE.Host() { BankBranchDetails=new BE.BankBranch() } };
            this.DataContext = HUshow;
            //this.GuestRequestGrid.DataContext =GRShow; //הקשר הדטה לפי GuestRequest


            this.typeComboBox.ItemsSource = Enum.GetValues(typeof(BE.TypeEnum));
            this.areaComboBox.ItemsSource = Enum.GetValues(typeof(BE.AreaEnum));

        }


          

        private void Button_Click_Save_HostingUnit(object sender, RoutedEventArgs e)
        {
            try
            {
                //GRShow.PrivateName = this.firstNameTextBox.Text;  //קישור על ידי binding 


                int id=bl.addHostingUnit(HUshow); // add copy of gr to the BL layer
                                           // GRShow = new BE.GuestRequest();
                                           //this.GuestRequestGrid.DataContext = GRShow; //הקשר הדטה לפי GuestRequest

                // אם אין זריקה 
                MessageBox.Show("יחידת אירוח נוספה בהצלחה .\n נא לשמור את מספר יחידת האירוח : "+ id);

                this.Close();
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
