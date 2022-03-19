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
    }
}
