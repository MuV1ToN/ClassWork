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
            Groups.ItemsSource = Singletone.DB.Group.ToList();
           
            List<AcademicYear> academicYearsUnique = Singletone.DB.AcademicYear.ToList();
            int nowYear = DateTime.Now.Year;
            int nowMonth = DateTime.Now.Month;
            Years.ItemsSource = academicYearsUnique;
            AcademicYear year = academicYearsUnique.Find(n => ((n.StartYear == nowYear) && (nowMonth >= 8)) || ((n.EndYear == nowYear) && (nowMonth <= 7)));
            Years.SelectedItem = year;

            Discipline.ItemsSource = Singletone.DB.Discipline.ToList();


        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Singletone.DB.SaveChanges();
        }



        private void Groups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Logic();
            Group chousegroup = Groups.SelectedItem as Group;
            People people = Discipline.SelectedItem as People;
            if (chousegroup == null) return;
            PersonsDataGrid.ItemsSource = chousegroup.Student.ToList();           
        }

        private void Years_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Discipline.SelectedItem = null;
            PersonsDataGrid.SelectedItem = null;
            Groups.SelectedItem = null;
            Logic();

        }

        private void Discipline_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            Logic();
        }

        public void Logic()
        {
            if (Years.SelectedItem != null)
            {
                AcademicYear Year = Years.SelectedItem as AcademicYear;

                if (Groups.SelectedItem != null)
                {
                    Group group = Groups.SelectedItem as Group;
                    //Discipline discipline = Discipline.SelectedItem as Discipline;

                    Discipline.ItemsSource = Singletone.DB.AcademicLoad.Where(n => n.AcademicYearID == Year.ID && n.GroupID == group.ID).Select(n => n.Discipline).Distinct().ToList();
                    
                }
                if(Discipline.SelectedItem != null)
                {
                    Discipline discipline = Discipline.SelectedItem as Discipline;
                    Groups.ItemsSource = Singletone.DB.AcademicLoad.Where(n => n.AcademicYearID == Year.ID && n.DisciplinID == discipline.ID).Select(n => n.Group).Distinct().ToList();
                }
            }
        }
    }
}
