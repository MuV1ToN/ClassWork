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
    /// Логика взаимодействия для DobavStudent.xaml
    /// </summary>
    public partial class DobavStudent : Window
    {
        public DobavStudent()
        {
            InitializeComponent();
        }
        private void Otmen_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Save_Click_1(object sender, RoutedEventArgs e)
        {
            Singletone.DB.SaveChanges();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            group.ItemsSource = Singletone.DB.Group.ToList();
        }
        public class PeopleView
        {
            public bool Check { get; set; }
            public People People { get; set; }
            public PeopleView(People people, bool check = false) 
            {
                People = people;
                Check = check;
            }
            static public List<PeopleView> Converter(List<People> peoples) 
            {
                List<PeopleView> peopleViews = new List<PeopleView>();
                foreach (People people in peoples)
                {
                    PeopleView peopleView = new PeopleView(people);
                    peopleViews.Add(peopleView);
                }
                return peopleViews;
            }
        }
    }
}
