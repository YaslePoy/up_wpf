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
using up_wpf.Model;

namespace up_wpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для DirectionPage.xaml
    /// </summary>
    public partial class DirectionPage : Page
    {
        public DirectionPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTB.Text))
                return;

            if (string.IsNullOrWhiteSpace(CodeTB.Text))
                return;
            var dir = new department { code = CodeTB.Text, name = NameTB.Text, faculty1 = App.db.faculty.FirstOrDefault(i => i.@short == FacTB.Text) };
            if (dir.faculty1 == null)
                return;

            App.db.department.Add(dir);
            try
            {
                App.db.SaveChanges();
            }
            finally
            {
                NavigationService.Navigate(new DirectionsPage());
            }
        }
    }
}
