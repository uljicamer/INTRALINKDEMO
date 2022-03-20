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
    /// Interaction logic for EditUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow : Window
    {
        public EditUserWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();   
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {

            UserNameTextBoxEDIT.Clear();
            UserAddPasswordFieldEDIT.Clear();
            Name_User_Textbox.Clear();
            Surname_Textbox.Clear();
            Email_textbox.Clear();
            Position_Textbox.Clear();
            Salary_textbox.Clear();






        }

        private void UserIDEDIT_TextChanged(object sender, TextChangedEventArgs e)
        {
        


            OleDbConnection con_admin_edit = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users_final.mdb");
            con_admin_edit.Open();



            if(UserIDEDIT.Text != "") { 

            OleDbCommand cmd = new OleDbCommand("SELECT [Username],[Password],[Name_User],[Surname_User],[Email],[Position],[Pay] FROM tbl_users_final WHERE [ID]=" + int.Parse(UserIDEDIT.Text)+"", con_admin_edit);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {


                UserNameTextBoxEDIT.Text = reader.GetValue(0).ToString();
                UserAddPasswordFieldEDIT.Text = reader.GetValue(1).ToString();
                Name_User_Textbox.Text = reader.GetValue(2).ToString();
                Surname_Textbox.Text=reader.GetValue(3).ToString();
                Email_textbox.Text=reader.GetValue(4).ToString();
                Position_Textbox.Text=reader.GetValue(5).ToString();
                Salary_textbox.Text=reader.GetValue(6).ToString();
                




            }



            con_admin_edit.Close();

            }


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {


            OleDbConnection connection_admin_update1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users_final.mdb");
            OleDbCommand command_admin_update1 = new OleDbCommand();
            OleDbDataAdapter data_adapter_admin_update1 = new OleDbDataAdapter();

            try
            {



                connection_admin_update1.Open();
                string Query_update1 = "UPDATE tbl_users_final SET [Username]=   '" + this.UserNameTextBoxEDIT.Text + "', [Password]='" + this.UserAddPasswordFieldEDIT.Text + "', [Name_User]='" + this.Name_User_Textbox.Text + "',[Surname_User]='" + this.Surname_Textbox.Text + "', [Email]='" + this.Email_textbox.Text + "', [Position]='" + this.Position_Textbox.Text + "',[Pay]='" + this.Salary_textbox.Text + "'  where [ID]= " + this.UserIDEDIT.Text + "    ";
                OleDbCommand cmd_admin_update1 = new OleDbCommand(Query_update1, connection_admin_update1);
                cmd_admin_update1.ExecuteNonQuery();
                MessageBox.Show("Updated");


                connection_admin_update1.Close();

            }

            catch (Exception ex)
            {


                MessageBox.Show(ex.Message);

            }







        }

        private void Refresh_Button_Click(object sender, RoutedEventArgs e)
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
    }
}
