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
    /// Логика взаимодействия для HelloPage.xaml
    /// </summary>
    public partial class HelloPage : Page
    {
        public HelloPage()
        {
            InitializeComponent();
        }

        private void OnEnter(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(PassTB.Text, out int pass))
            {
                App.user = App.db.employee.FirstOrDefault(i => i.id == pass);
                if (App.user == null)
                {
                    MessageBox.Show("Нет учителя с таким кодом");
                }
                else
                {
                    MessageBox.Show("Вы успешно вошли");

                    NavigationService.Navigate(new RolePage());
                }
            }
        }
    }
}
