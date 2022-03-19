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

            OleDbCommand cmd = new OleDbCommand("SELECT [Username],[Password],[Name_User] FROM tbl_users_final WHERE [ID]="+int.Parse(UserIDEDIT.Text)+"", con_admin_edit);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {


                UserNameTextBoxEDIT.Text = reader.GetValue(0).ToString();
                UserAddPasswordFieldEDIT.Text = reader.GetValue(1).ToString();
                Name_User_Textbox.Text = reader.GetValue(2).ToString();




            }



            con_admin_edit.Close();

            }


        }
    }
}
