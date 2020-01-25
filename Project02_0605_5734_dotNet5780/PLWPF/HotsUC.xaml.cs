using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for HotsUC.xaml
    /// </summary>
    public partial class HotsUC : UserControl
    {
        BL.IBL bl;

        BE.Host hostShow;
        IEnumerable<IGrouping<int, BE.Host>> IenumaIgroupHosts;

        IEnumerable<BE.Host> IenumaHosts;
        List<BE.Host> newList;

        public HotsUC()
        {
            InitializeComponent();
            bl = BL.Factory.GetInstance();

            IenumaIgroupHosts = bl.groupByNumberOfHosintgUnitForHost();// כנראה שצריך הגדרת משתנה מארח אנונימי שיש לו עוד שדה בשם כמות היחידות.  לא צריך מחיקת Host.

            //var IenumaNewHosts = from item in IenumaIgroupHosts
            //                     select 


            List<BE.Host> ls = new List<BE.Host>();
            //IEnumerable<IGrouping<int, BE.Host>> groups = list.GroupBy(x => x.id);
            
            IEnumerable<BE.Host> smths = IenumaIgroupHosts.SelectMany(IenumaIgroupHosts => IenumaIgroupHosts);
            List<BE.Host> newList = smths.ToList();

            list.ItemsSource = newList;



            //List<smth> list = new List<smth>();
            //IEnumerable<IGrouping<int, smth>> groups = list.GroupBy(x => x.id);
            //IEnumerable<smth> smths = groups.SelectMany(group => group);
            //List<smth> newList = smths.ToList();



            //newList = new List< BE.Host > ();
            ////IEnumerable<IGrouping<int, BE.Host>> groups = list.GroupBy(x => x.hos);

            //IenumaHosts = IenumaIgroupHosts.SelectMany(group => group);


            //newList = IenumaHosts.ToList();
            //newList.ItemsSource = IenumaHosts;




            //    void mouseClick(object sender, RoutedEventArgs e)
            //    {
            //        var btn = sender as System.Windows.Controls.Button;
            //        list.SelectedItem = btn.DataContext;
            //        hostShow = (BE.Host)list.SelectedItem;

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)//https://social.msdn.microsoft.com/Forums/vstudio/en-US/194ee5ad-a3cf-48ae-8c0e-1aab84a1df97/how-to-get-wpf-listview-click-event?forum=wpf
        {
            hostShow = (BE.Host)list.SelectedItem;

            if (hostShow != null)
            {

            }
        }






        private void OnMouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.ListView list = (System.Windows.Controls.ListView)sender;
            BE.Order selectedObject = (BE.Order)list.SelectedItem;
            selectedObject.ToString();
        }











        #region מיון 
        GridViewColumnHeader _lastHeaderClicked = null;
        ListSortDirection _lastDirection = ListSortDirection.Ascending;

        void GridViewColumnHeaderClickedHandler(object sender,
                                            RoutedEventArgs e)
        {
            var headerClicked = e.OriginalSource as GridViewColumnHeader;
            ListSortDirection direction;

            if (headerClicked != null)
            {
                if (headerClicked.Role != GridViewColumnHeaderRole.Padding)
                {
                    if (headerClicked != _lastHeaderClicked)
                    {
                        direction = ListSortDirection.Ascending;
                    }
                    else
                    {
                        if (_lastDirection == ListSortDirection.Ascending)
                        {
                            direction = ListSortDirection.Descending;
                        }
                        else
                        {
                            direction = ListSortDirection.Ascending;
                        }
                    }

                    var columnBinding = headerClicked.Column.DisplayMemberBinding as Binding;
                    var sortBy = columnBinding?.Path.Path ?? headerClicked.Column.Header as string;

                    Sort(sortBy, direction);

                    if (direction == ListSortDirection.Ascending)
                    {
                        headerClicked.Column.HeaderTemplate =
                          Resources["HeaderTemplateArrowUp"] as DataTemplate;
                    }
                    else
                    {
                        headerClicked.Column.HeaderTemplate =
                          Resources["HeaderTemplateArrowDown"] as DataTemplate;
                    }

                    // Remove arrow from previously sorted header
                    if (_lastHeaderClicked != null && _lastHeaderClicked != headerClicked)
                    {
                        _lastHeaderClicked.Column.HeaderTemplate = null;
                    }

                    _lastHeaderClicked = headerClicked;
                    _lastDirection = direction;
                }
            }
        }
        private void Sort(string sortBy, ListSortDirection direction)
        {
            ICollectionView dataView =
              CollectionViewSource.GetDefaultView(list.ItemsSource); //list is namespace of xaml

            dataView.SortDescriptions.Clear();
            SortDescription sd = new SortDescription(sortBy, direction);
            dataView.SortDescriptions.Add(sd);
            dataView.Refresh();
        }









        #endregion


    }









}



