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

namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = Login.Text;
            string password = Password.Password;  
            List<User> users = Singletone.DB.User.Where(user=>user.Login == login &&  user.Password == password).ToList();
            if (users.Count > 0)
            {
                string roles = "";
                string seporator = ", ";
                bool addSeporator = false;
                User user = users.First();
                List<string> rolelist = new List<string>();
                foreach (ROLE role in user.ROLE)
                {
                    rolelist.Add(role.NAME);
                    if (addSeporator)
                        roles += seporator;
                    roles += role.NAME;
                    addSeporator = true;
                }
                if (rolelist.Contains("Зав.отделения"))
                {
                    MessageBox.Show($"Здравствуйте,{user.Login}.Ваши роли :{roles} ");
                    Window1 window = new Window1();
                    Hide();
                    window.ShowDialog();
                    Show();
                }
                else
                {
                    //MessageBox.Show($"Здравствуйте,{user.Login}.Ваши роли :{roles} ");
                    Window1 window = new Window1();
                    Hide();
                    window.ShowDialog();
                    Show();
                }
                
            }
            else{ MessageBox.Show("Введённый логин или пароль не совпадают");}
        }
    }
}
