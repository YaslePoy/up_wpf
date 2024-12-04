using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using up_wpf.Model;

namespace up_wpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для EmployeesPage.xaml
    /// </summary>
    public partial class EmployeesPage : Page
    {
        private List<teacher> teacherList;
        public EmployeesPage()
        {
            InitializeComponent();
            var departmentId = App.user.department.code;
            teacherList = App.db.teacher.Where(i => i.employee.department.code == departmentId).OrderBy(i => i.employee.name).ToList();
            TeachersDG.ItemsSource = teacherList;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var text = ((TextBox)sender).Text;
            TeachersDG.ItemsSource = null;

            if (string.IsNullOrWhiteSpace(text))
                TeachersDG.ItemsSource = teacherList;
            else
                TeachersDG.ItemsSource = teacherList.Where(i => i.employee.name.ToLower().Contains(text));

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TeachersDG == null) return;
            var comboBox = sender as ComboBox;
            if (comboBox.SelectedIndex == -1)
                return;
            TeachersDG.ItemsSource = null;
            switch (comboBox.SelectedIndex)
            {
                case 0:
                    TeachersDG.ItemsSource = teacherList;
                    break;
                case 1:
                    TeachersDG.ItemsSource = teacherList.OrderBy(i => i.employee.salary);
                    break;
                case 2:
                    TeachersDG.ItemsSource = teacherList.OrderBy(i => i.degree);
                    break;


            }
        }

        private void TextBox_TextChanged1(object sender, TextChangedEventArgs e)
        {
            var text = ((TextBox)sender).Text;
            var tb = ((teacher)((TextBox)sender).DataContext);

            tb.employee.name = text;
            App.db.SaveChanges();

        }
        private void TextBox_TextChanged2(object sender, TextChangedEventArgs e)
        {
            var text = ((TextBox)sender).Text;
            var tb = ((teacher)((TextBox)sender).DataContext);

            tb.employee.position = text;
            App.db.SaveChanges();

        }
        private void TextBox_TextChanged3(object sender, TextChangedEventArgs e)
        {
            var text = ((TextBox)sender).Text;
            var tb = ((teacher)((TextBox)sender).DataContext);

            try
            {
                tb.employee.salary = decimal.Parse(text);
                App.db.SaveChanges();
            }
            catch
            {

            }

        }
        private void TextBox_TextChanged4(object sender, TextChangedEventArgs e)
        {
            var text = ((TextBox)sender).Text;
            var tb = ((teacher)((TextBox)sender).DataContext);

            tb.title = text;
            App.db.SaveChanges();

        }
        private void TextBox_TextChanged5(object sender, TextChangedEventArgs e)
        {
            var text = ((TextBox)sender).Text;
            var tb = ((teacher)((TextBox)sender).DataContext);

            tb.degree = text;
            App.db.SaveChanges();

        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var selected = (TeachersDG.SelectedItem as teacher);

            if (selected != null)
            {
                App.db.teacher.Remove(selected);
                App.db.SaveChanges();
                TeachersDG.ItemsSource = null;
                var departmentId = App.user.department.code;

                teacherList = App.db.teacher.Where(i => i.employee.department.code == departmentId).OrderBy(i => i.employee.name).ToList();
                TeachersDG.ItemsSource = teacherList;
                MessageBox.Show("Работник удален");

            }
        }

        private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            var user = new up_wpf.Model.employee();
            user.code = App.user.code;

            App.db.employee.Add(user);
            App.db.SaveChanges();

            var teacher = new teacher() { id = user.id };

            App.db.teacher.Add(teacher);
            App.db.SaveChanges();

            teacherList.Add(teacher);
            TeachersDG.ItemsSource = null;

            TeachersDG.ItemsSource = teacherList;
            MessageBox.Show("Работник добавлен");



        }
    }
}
