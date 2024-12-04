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

namespace up_wpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для RolePage.xaml
    /// </summary>
    public partial class RolePage : Page
    {
        public RolePage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (App.user.teacher != null)
            {
                NavigationService.Navigate(new ExamsPage());
            }
            else
            {
                MessageBox.Show("Этот пользователь не учитель");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (App.user.direction_director != null)
            {
                NavigationService.Navigate(new DirDirPage());
            }
            else
            {
                MessageBox.Show("Этот пользователь не заведующий кафедрой");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (App.user.engineer != null)
            {
                NavigationService.Navigate(new EngPage());
            }
            else
            {
                MessageBox.Show("Этот пользователь не инженер");
            }
        }
    }
}
