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
    /// Логика взаимодействия для DirectionsPage.xaml
    /// </summary>
    public partial class DirectionsPage : Page
    {
        public DirectionsPage()
        {
            InitializeComponent();
            TeachersDG.ItemsSource = App.db.department.ToList();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var text = ((TextBox)sender).Text;
                var tb = ((department)((TextBox)sender).DataContext);
                if (tb.code == text)
                    return;
                tb.code = text;
                App.db.SaveChanges();
            }
            catch
            {

            }

        }

        private void TextBox_TextChanged1(object sender, TextChangedEventArgs e)
        {
            try
            {
                var text = ((TextBox)sender).Text;
                var tb = ((department)((TextBox)sender).DataContext);
                if (tb.name == text)
                    return;
                tb.name = text;
                App.db.SaveChanges();
            }
            catch { }
        }

        private void TextBox_TextChanged2(object sender, TextChangedEventArgs e)
        {
            try
            {
                var text = ((TextBox)sender).Text;
                var tb = ((department)((TextBox)sender).DataContext);
                if (tb.faculty == text)
                    return;
                tb.faculty = text;
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
                App.db.department.Remove(selected as department);
                App.db.SaveChanges();
            }
            finally
            {
                TeachersDG.ItemsSource = App.db.department.ToList();
                MessageBox.Show("Кафедра удалена");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DirectionPage());
        }
    }
}
