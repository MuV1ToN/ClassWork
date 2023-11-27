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

namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для ZavOtd.xaml
    /// </summary>
    public partial class ZavOtd : Window
    {
        public ZavOtd()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            table.ItemsSource = Singletone.DB.Group.Local;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            Singletone.DB.SaveChanges();

        }
    }
}
