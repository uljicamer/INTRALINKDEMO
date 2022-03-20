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
    /// Interaction logic for Add_Task_Window.xaml
    /// </summary>
    public partial class Add_Task_Window : Window
    {


        public static string set_value_user_task;



        public Add_Task_Window()
        {
            InitializeComponent();
        }

        private void exit_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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

        private void clear_button_Click(object sender, RoutedEventArgs e)
        {


            userid_task.Clear();
            team_task.Clear();
            task_name.Clear();
            task_description.Clear();





        }

        private void Confirm_Task_Click(object sender, RoutedEventArgs e)
        {


            OleDbConnection connection_admin_send_task = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users_final.mdb");
            OleDbCommand command_admin_send_task = new OleDbCommand();
            OleDbDataAdapter data_adapter_admin_send_task = new OleDbDataAdapter();



            try
            {



                connection_admin_send_task.Open();
                string Query_send_task = "update tbl_users_final set [Task]=   '" + this.task_name.Text + "' where [ID]= " + this.userid_task.Text + "    ";
                OleDbCommand cmd_admin_task_send = new OleDbCommand(Query_send_task, connection_admin_send_task);
                cmd_admin_task_send.ExecuteNonQuery();
                MessageBox.Show("Sent");


                connection_admin_send_task.Close();

               

            }

            catch (Exception ex)
            {


                MessageBox.Show(ex.Message);

            }



            set_value_user_task = task_name.Text;

            var userform = new userPanel();
            userform.Show();



        }
    }
}
