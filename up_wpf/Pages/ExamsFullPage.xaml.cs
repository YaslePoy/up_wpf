using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using up_wpf.Model;

namespace up_wpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для ExamsFullPage.xaml
    /// </summary>
    public partial class ExamsFullPage : Page
    {
        public ExamsFullPage()
        {
            InitializeComponent();
            var userCode = App.user.code;
            ExamsDG.DataContext = App.db.exam.ToList();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var tb = (TextBox)sender;
                var exam = tb.DataContext as exam;
                if (exam == null)
                    return;
                exam.grade = int.Parse(tb.Text);
                App.db.SaveChanges();
            }
            catch
            {

            }
        }

        private void TextBox_TextChanged1(object sender, TextChangedEventArgs e)
        {
            var text = ((TextBox)sender).Text;
            var tb = ((TextBox)sender).DataContext as exam;
            if (tb == null)
                return;
            tb.auditorium = text;
            App.db.SaveChanges();
        }

        private void TextBox_TextChanged2(object sender, TextChangedEventArgs e)
        {
            try
            {
                var tb = (TextBox)sender;
                var exam = tb.DataContext as exam;
                if (exam == null)
                    return;
                exam.discipline_id = int.Parse(tb.Text);
                App.db.SaveChanges();
            }
            catch
            {

            }
        }

        private void TextBox_TextChanged3(object sender, TextChangedEventArgs e)
        {
            try
            {
                var tb = (TextBox)sender;
                var exam = tb.DataContext as exam; 
                if (exam == null)
                    return;
                exam.student_id = int.Parse(tb.Text);
                App.db.SaveChanges();
            }
            catch
            {

            }
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var tb = (DatePicker)sender;
            var exam = tb.DataContext as exam;
            if (tb.SelectedDate == null || exam.date == tb.SelectedDate)
                return;
            exam.date = tb.SelectedDate;
            App.db.SaveChanges();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var examNew = new exam() { date = DateTime.Today };
            App.db.exam.Add(examNew);
            App.db.SaveChanges();

            var userCode = App.user.code;
            ExamsDG.DataContext = null;
            ExamsDG.DataContext = App.db.exam.ToList();
            MessageBox.Show("Сдача добавлена");

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var current = ExamsDG.SelectedValue as exam;
            if (current == null)
                return;

            App.db.exam.Add(current);
            App.db.SaveChanges();
            var userCode = App.user.code;

            ExamsDG.DataContext = null;
            ExamsDG.DataContext = App.db.exam.ToList();
            MessageBox.Show("Сдача удалена");

        }
    }
}
