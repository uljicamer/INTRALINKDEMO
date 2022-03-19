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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.OleDb;


namespace intralinkdemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();





        }

      
        





        private void Button_Click(object sender, RoutedEventArgs e)
        {


            OleDbConnection con_new = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = db_users_final.mdb");
            OleDbCommand cmd_new = new OleDbCommand();
            OleDbDataAdapter adapter_new = new OleDbDataAdapter();


            con_new.Open();
            string login = "SELECT * FROM tbl_users_final WHERE Username = '" + txt_box_username.Text + "' and Password = '" + txt_box_password.Password.ToString() + "'  ";
            cmd_new = new OleDbCommand(login,con_new);
            OleDbDataReader read_data = cmd_new.ExecuteReader();
              

            if (read_data.Read() == true)
            {

                if(txt_box_username.Text == "admin")
                {


                    new adminPanel().Show();
                    this.Close();





                }

                else
                {

                    new userPanel().Show();
                    this.Close();


                }




                




            }


            else
            {

                MessageBox.Show("Incorrect Username/Password.Try Again");



            }




            con_new.Close();




        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }






    }
}
