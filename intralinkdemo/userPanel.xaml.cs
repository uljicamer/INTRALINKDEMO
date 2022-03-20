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

namespace intralinkdemo
{
    /// <summary>
    /// Interaction logic for userPanel.xaml
    /// </summary>
    public partial class userPanel : Window
    {
        public userPanel()
        {
            InitializeComponent();

            lbl_task.Content = Add_Task_Window.set_value_user_task;



        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
