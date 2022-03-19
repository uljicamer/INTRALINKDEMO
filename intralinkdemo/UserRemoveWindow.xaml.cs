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
    /// Interaction logic for UserRemoveWindow.xaml
    /// </summary>
    public partial class UserRemoveWindow : Window
    {
        public UserRemoveWindow()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {

            this.Close();



        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {


            OleDbConnection connection_admin_view = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users_final.mdb");
            OleDbCommand command_admin_view = new OleDbCommand();
            OleDbDataAdapter data_adapter_admin_view = new OleDbDataAdapter();

            try
            {

                connection_admin_view.Open();
                string Query_view = "SELECT [ID],[Username],[Password],[Name_User],[Surname_User],[Email],[Position],[Pay] FROM tbl_users_final";
                OleDbCommand cmd_admin_view = new OleDbCommand(Query_view, connection_admin_view);
                cmd_admin_view.ExecuteNonQuery();


                OleDbDataAdapter admin_data_adapter_view = new OleDbDataAdapter(cmd_admin_view);
                DataTable dt = new DataTable("tbl_users_final");
                admin_data_adapter_view.Fill(dt);
                data_grid_remove.ItemsSource = dt.DefaultView;
                admin_data_adapter_view.Update(dt);

                data_grid_remove.Visibility = Visibility.Visible;
                connection_admin_view.Close();


            }

            catch (Exception ex)
            {


                MessageBox.Show(ex.Message);

            }







        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            OleDbConnection connection_admin_delete = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users_final.mdb");
            OleDbCommand command_admin_delete = new OleDbCommand();
            OleDbDataAdapter data_adapter_admin_delete = new OleDbDataAdapter();


            try
            {



                connection_admin_delete.Open();
                string Query_delete = "  delete from  tbl_users_final where [ID]= " + this.UserIdBox.Text + "  ";
                OleDbCommand cmd_admin_delete = new OleDbCommand(Query_delete, connection_admin_delete);
                cmd_admin_delete.ExecuteNonQuery();
                MessageBox.Show("User Deleted");


                connection_admin_delete.Close();



      

            }

            catch (Exception ex)
            {


                MessageBox.Show(ex.Message);

            }





        }
    }
}
