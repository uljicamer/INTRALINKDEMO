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
    /// Interaction logic for Create_Teams_Window.xaml
    /// </summary>
    public partial class Create_Teams_Window : Window
    {
        public Create_Teams_Window()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();




        }

        private void Refresh_Button_Click(object sender, RoutedEventArgs e)
        {



            OleDbConnection connection_admin_view = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users_final.mdb");
            OleDbCommand command_admin_view = new OleDbCommand();
            OleDbDataAdapter data_adapter_admin_view = new OleDbDataAdapter();

            try
            {

                connection_admin_view.Open();
                string Query_view = "SELECT [ID],[Username],[Password],[Name_User],[Surname_User],[Email],[Position],[Pay],[Team] FROM tbl_users_final";
                OleDbCommand cmd_admin_view = new OleDbCommand(Query_view, connection_admin_view);
                cmd_admin_view.ExecuteNonQuery();


                OleDbDataAdapter admin_data_adapter_view = new OleDbDataAdapter(cmd_admin_view);
                DataTable dt = new DataTable("tbl_users_final");
                admin_data_adapter_view.Fill(dt);
                data_grid_view.ItemsSource = dt.DefaultView;
                admin_data_adapter_view.Update(dt);

                data_grid_view.Visibility = Visibility.Visible;
                connection_admin_view.Close();




            }

            catch (Exception ex)
            {


                MessageBox.Show(ex.Message);

            }








        }

        private void AddToTeamButton_Click(object sender, RoutedEventArgs e)
        {



            OleDbConnection connection_admin_send_task = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users_final.mdb");
            OleDbCommand command_admin_send_task = new OleDbCommand();
            OleDbDataAdapter data_adapter_admin_send_task = new OleDbDataAdapter();

            try
            {



                connection_admin_send_task.Open();
                string Query_send_task = "update tbl_users_final set [Team]=   '" + this.txtbox_teamname.Text + "' where [ID]= " + this.txtbox_userid.Text + "    ";
                OleDbCommand cmd_admin_task_send = new OleDbCommand(Query_send_task, connection_admin_send_task);
                cmd_admin_task_send.ExecuteNonQuery();
                MessageBox.Show("Created");


                connection_admin_send_task.Close();



            }

            catch (Exception ex)
            {


                MessageBox.Show(ex.Message);

            }






        }
    }
}
