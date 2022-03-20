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
using System.Data.OleDb;
using System.Data;
using LiveCharts;
using LiveCharts.Wpf;

namespace intralinkdemo
{
    /// <summary>
    /// Interaction logic for adminPanel.xaml
    /// </summary>
    public partial class adminPanel : Window
    {
        public adminPanel()
        {
            InitializeComponent();


            //data_grid_view.Visibility = Visibility.Hidden;
            


        }

        


        private void exitButtonAdminPanel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


       

        private void ExpanderUserButton_Click(object sender, RoutedEventArgs e)
        {


            new UserListWindow().Show();
            
            

        }

        private void ExpanderAddUserButton_Click(object sender, RoutedEventArgs e)
        {
            
            
            
            
            new AddUsersWindow().Show();
        }

        private void ExpanderRemoveUsersButton_Click(object sender, RoutedEventArgs e)
        {
            new UserRemoveWindow().Show();  
        }

        private void ExpanderEditUsersButton_Click(object sender, RoutedEventArgs e)
        {


            new EditUserWindow().Show();



        }

        private void Add_Task_Click(object sender, RoutedEventArgs e)
        {
            new Add_Task_Window().Show();
        }

        private void w(object sender, RoutedEventArgs e)
        {

        }

        private void Chart_Stackpanel_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Create_Teams_Click(object sender, RoutedEventArgs e)
        {
            new Create_Teams_Window().Show();
        }

        private void Teams_Overview_Click(object sender, RoutedEventArgs e)
        {
            new Teams_Overview_Window().Show();
        }
    }
}
