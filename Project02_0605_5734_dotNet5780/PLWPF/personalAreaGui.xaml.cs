﻿using System;
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
    /// Interaction logic for personalAreaGui.xaml
    /// </summary>
    public partial class personalAreaGui : Window
    {
        BL.IBL bl;
        BE.HostingUnit HUshow; // מקבל את ההוסטינג יוניט מהטריגר
        //BE.GuestRequest GRShow =new BE.GuestRequest();//לבדוק 

        public personalAreaGui()
        {
            InitializeComponent();
            //בדיקה
            HUshow=bl.getHostingUnitByID(20000000);
            this.typeComboBox.ItemsSource = Enum.GetValues(typeof(BE.TypeEnum));
            this.areaComboBox.ItemsSource = Enum.GetValues(typeof(BE.AreaEnum));
        }

       
        private void Button_Click_edit_hostingUnit(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.updateHostingUnit(HUshow);
            }
            catch (System.IO.InvalidDataException ex)
            {

                MessageBox.Show(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {

                MessageBox.Show(ex.Message);
            }
            catch (ArgumentException ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_Delete_HostingUint(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.delHostingUnit(HUshow.HostingUnitKey);
            }
            catch (KeyNotFoundException ex)
            {

                MessageBox.Show(ex.Message);
            }
            catch (BE.Tools.UnLogicException ex)
            {

                MessageBox.Show(ex.Message);
            }


            this.Close();
        }

        private void Button_Click_order(object sender, RoutedEventArgs e)
        {
            //פותח חלון הוסף הזמנה לפי מספר יחידת אירוח
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource hostingUnitViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hostingUnitViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // hostingUnitViewSource.Source = [generic data source]
        }
    }
}
