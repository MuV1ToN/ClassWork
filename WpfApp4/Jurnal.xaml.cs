using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для Jurnal.xaml
    /// </summary>
    public partial class Jurnal : Window
    {

        public Jurnal()
        {
            InitializeComponent();

        }

        private void Gr_jurnal_Loaded(object sender, RoutedEventArgs e)
        {
            Gr1.ItemsSource = Singletone.DB.Group.ToList();
           
            List<AcademicYear> academicYearsUnique = Singletone.DB.AcademicYear.ToList();
            int nowYear = DateTime.Now.Year;
            int nowMonth = DateTime.Now.Month;
            Gr2.ItemsSource = academicYearsUnique;
            AcademicYear year = academicYearsUnique.Find(n => ((n.StartYear == nowYear) && (nowMonth > 8)) || ((n.EndYear == nowYear) && (nowMonth < 7)));
            Gr2.SelectedItem = year;

            Gr3.ItemsSource = Singletone.DB.Discipline.ToList();
       

             


        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Singletone.DB.SaveChanges();
        }



        private void Gr1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Group chousegroup = Gr1.SelectedItem as Group;
            People people = Gr1.SelectedItem as People;
            if (chousegroup == null) return;

            PersonsDataGrid.ItemsSource = chousegroup.Student;
            
        }

        private void Gr2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        }

        private void Gr3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           

        }
    }
}
