using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
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
    /// Interaction logic for OrdersListForHostingUnit.xaml
    /// </summary>
    public partial class OrdersListForHostingUnit : Window
    {

        BL.IBL bl;
        BE.Order order;
        BE.Order orderTemp;
        IEnumerable<BE.Order> ieOrder;

        public OrdersListForHostingUnit()
        {
            InitializeComponent();
            bl = BL.Factory.GetInstance();

            ieOrder = bl.GetOrderList();

            list.ItemsSource = ieOrder;
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)//https://social.msdn.microsoft.com/Forums/vstudio/en-US/194ee5ad-a3cf-48ae-8c0e-1aab84a1df97/how-to-get-wpf-listview-click-event?forum=wpf
        {
           
            order = (BE.Order)list.SelectedItem;
            if (order != null)
            {
                //int id = int.Parse(selectedrow.Row.ItemArray[0].ToString());
                //Console.WriteLine(id);
                //Console.WriteLine(bl.getGuestRequestByID(40000000 + id));
                Console.WriteLine(order.ToString());
            }
        }


        private void Button_Click_confirm_order(object sender, RoutedEventArgs e)
        {
            orderTemp = order;
            order.Status = BE.StatusEnum.נסגר_בהיענות_הלקוח;

            try
            {
                bl.UpdateOrder(order);
                System.Windows.MessageBox.Show("ההזמנה נסגרה בהצלחה");

            }

            catch (ArgumentException ex)
            {
                order = orderTemp;
                MessageBox.Show(ex.Message);

            }
            catch (KeyNotFoundException ex)
            {
                order = orderTemp;
                MessageBox.Show(ex.Message);


            }
            catch (BE.Tools.UnLogicException ex)
            {
                order = orderTemp;
                MessageBox.Show(ex.Message);


            }




        }

        private void Button_Click_send_email(object sender, RoutedEventArgs e)
        {

            
            Thread thr = new Thread(sendAnEamil);
            thr.Start(789);

            Console.WriteLine("Main Thread Ends!!");




            orderTemp = order;
            order.Status = BE.StatusEnum.נשלח_מייל;

            try
            {
                bl.UpdateOrder(order);
              //  System.Windows.MessageBox.Show(" נסגרה בהצלחה");

            }

            catch (ArgumentException ex)
            {
                order = orderTemp;
                MessageBox.Show(ex.Message);

            }
            catch (KeyNotFoundException ex)
            {
                order = orderTemp;
                MessageBox.Show(ex.Message);


            }
            catch (BE.Tools.UnLogicException ex)
            {
                order = orderTemp;
                MessageBox.Show(ex.Message);


            }

        }
        public  void sendAnEamil()
        {
            
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("zimmerisrael123@gmail.com", "Aa12345678910"),
                EnableSsl = true
            };

            client.Send(bl.getGuestRequestByID(order.GuestRequestKey).MailAddress, bl.getGuestRequestByID(order.GuestRequestKey).MailAddress, order.ToString(), "love you :) \n Garusi zimmer ");
            Console.WriteLine("Sent");


            Console.ReadLine();
        }
    }

        
    }

