using SaleCakes.ViewModel;
using System.Windows;

namespace SaleCakes.View
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow(RegistrationViewModel vm)
        {
            DataContext = vm;
            InitializeComponent();
        }

        private void Close_OnClick(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.WindowState = WindowState.Normal;
            this.Close();
        }
    }
}
