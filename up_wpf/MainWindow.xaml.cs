using System.Windows;
using System.Windows.Navigation;
using up_wpf.Pages;

namespace up_wpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BaseFrame.Navigate(new HelloPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BaseFrame.GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            BaseFrame.Navigate(new QRPage());
        }
    }
}
