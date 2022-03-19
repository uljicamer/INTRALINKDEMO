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
    /// Interaction logic for AddUsersWindow.xaml
    /// </summary>
    public partial class AddUsersWindow : Window
    {
        public AddUsersWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {

            UserNameTextBox.Clear();
            UserAddPasswordField.Clear();
            Name_User_Textbox.Clear();
            Surname_Textbox.Clear();
            Email_textbox.Clear();
            Position_Textbox.Clear();
            Salary_textbox.Clear();





        }

        private void UserAddConfirmButton_Click(object sender, RoutedEventArgs e)
        {

            OleDbConnection connection_admin_insert = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users_final.mdb");
            OleDbCommand command_admin_insert = new OleDbCommand();
            OleDbDataAdapter data_adapter_admin_insert = new OleDbDataAdapter();

            try
            {


                connection_admin_insert.Open();
                string Query_insert = "insert into tbl_users_final ([Username],[Password],[Name_User],[Surname_User],[Email],[Position],[Pay]) values ('" + this.UserNameTextBox.Text + "','" + this.UserAddPasswordField.Text + "','" + this.Name_User_Textbox.Text + "','"+this.Surname_Textbox.Text+"','"+this.Email_textbox.Text+ "','" + this.Position_Textbox.Text + "','" + this.Salary_textbox.Text + "')";
                OleDbCommand cmd_admin_insert = new OleDbCommand(Query_insert, connection_admin_insert);
                cmd_admin_insert.ExecuteNonQuery();
                MessageBox.Show("Saved");


                connection_admin_insert.Close();

            }

            catch (Exception ex)
            {


                MessageBox.Show(ex.Message);

            }







        }
    }
}
