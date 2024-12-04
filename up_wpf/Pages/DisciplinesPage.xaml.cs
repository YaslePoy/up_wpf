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
    /// Логика взаимодействия для DisciplinesPage.xaml
    /// </summary>
    public partial class DisciplinesPage : Page
    {
        public DisciplinesPage()
        {
            InitializeComponent();
            TeachersDG.ItemsSource = App.db.discipline.ToList();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var text = ((TextBox)sender).Text;
            var tb = ((discipline)((TextBox)sender).DataContext);
            if (tb.name == text)
                return;
            tb.name = text;
            App.db.SaveChanges();
        }

        private void TextBox_TextChanged1(object sender, TextChangedEventArgs e)
        {
            var text = ((TextBox)sender).Text;
            var tb = ((discipline)((TextBox)sender).DataContext);
            if (tb.volume.ToString() == text)
                return;
            try
            {
                tb.volume = int.Parse(text);
                App.db.SaveChanges();
            }
            catch { }

        }

        private void TextBox_TextChanged2(object sender, TextChangedEventArgs e)
        {
            var text = ((TextBox)sender).Text;
            var tb = ((discipline)((TextBox)sender).DataContext);
            if (tb.department != null && tb.department.code == text)
                return;
            tb.department = App.db.department.FirstOrDefault(i => i.code == text);
            if (tb.department != null)
                try
                {
                    App.db.SaveChanges();

                }
                catch { }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var disc = new discipline();
            App.db.discipline.Add(disc);
            App.db.SaveChanges();
            TeachersDG.ItemsSource = null;

            TeachersDG.ItemsSource = App.db.discipline.ToList();
            MessageBox.Show("Дисциплина создана");


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (TeachersDG.SelectedValue is null)
                return;

            App.db.discipline.Remove(TeachersDG.SelectedValue as discipline);
            App.db.SaveChanges();
            TeachersDG.ItemsSource = null;

            TeachersDG.ItemsSource = App.db.discipline.ToList();

            MessageBox.Show("Дисциплина удалена");


        }
    }
}
