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
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Window
    {
        public AddStudent()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Students.ItemsSource = Singletone.DB.People.ToList();
            Group.ItemsSource = Singletone.DB.Group.ToList();
            Role.ItemsSource = Singletone.DB.ROLE.ToList();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Student student = new Student() { };
            Singletone.DB.SaveChanges();
            Close();
        }
    }
}
