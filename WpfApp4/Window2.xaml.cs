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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            user.ItemsSource = Singletone.DB.User.ToList();
            role.ItemsSource = Singletone.DB.ROLE.ToList();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (user.SelectedItem == null)
            {
                MessageBox.Show("Пользователь не выбран, сохранение не произведено");
                return;
            }
            if (role.SelectedItem == null)
            {
                MessageBox.Show("Все роли данного пользователя сняты");
                User Selectuser = user.SelectedItem as User;
                Selectuser.ROLE.Clear();
                Singletone.DB.SaveChanges();
                return;
            }
            else
            {
                User Selectuser = user.SelectedItem as User;
                Selectuser.ROLE.Clear();
                Selectuser.ROLE.Add(role.SelectedItem as ROLE);
                Singletone.DB.SaveChanges();
            }
        }

        private void User_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            User Selectuser = user.SelectedItem as User;
            List<ROLE> QWE = Selectuser.ROLE.ToList();
            if (QWE.Count < 1)
            {
                role.Text = "";
            }
            else
            role.SelectedItem = QWE[0];
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            role.Text = "";
        }

    }
}
