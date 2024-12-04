using System.Linq;
using System.Windows.Controls;
using up_wpf.Model;

namespace up_wpf.Pages
{
    public partial class ExamsPage : Page
    {
        public ExamsPage()
        {
            InitializeComponent();
            DataContext = App.db.exam.Where(i => i.teacher_id == App.user.id).ToList();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var tb = (TextBox)sender;
                var exam = tb.DataContext as exam;
                exam.grade = int.Parse(tb.Text);
                App.db.SaveChanges();
            }
            catch
            {

            }
            
        }
    }
}