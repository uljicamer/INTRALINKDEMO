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
    /// Interaction logic for Add_Task_Window.xaml
    /// </summary>
    public partial class Add_Task_Window : Window
    {
        public Add_Task_Window()
        {
            InitializeComponent();
        }

        private void exit_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
