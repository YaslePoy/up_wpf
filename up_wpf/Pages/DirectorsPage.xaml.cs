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
    /// Логика взаимодействия для DirectorsPage.xaml
    /// </summary>
    public partial class DirectorsPage : Page
    {
        public DirectorsPage()
        {
            InitializeComponent();
            TeachersDG.ItemsSource = App.db.direction_director.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate( new DirectorPage());
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var text = ((TextBox)sender).Text;
                var tb = ((direction_director)((TextBox)sender).DataContext);
                if (tb.experience.ToString() == text)
                    return;
                tb.experience = int.Parse(text);
                App.db.SaveChanges();

            }
            catch { }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selected = TeachersDG.SelectedValue;
            if (selected == null)
                return;

            try
            {
                App.db.direction_director.Remove(selected as direction_director);
                App.db.SaveChanges();
            }
            finally
            {
                TeachersDG.ItemsSource = null;
                TeachersDG.ItemsSource = App.db.direction_director.ToList();
                MessageBox.Show("Зав. удален");

            }
        }
    }
}
