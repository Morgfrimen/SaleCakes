using System.Windows;
using System.Windows.Controls;

namespace SaleCakes.View.Components
{
    /// <summary>
    /// Логика взаимодействия для AppButtonTopComponents.xaml
    /// </summary>
    public partial class AppButtonTopComponents : UserControl
    {
        public AppButtonTopComponents()
        {
            InitializeComponent();
        }

        private void ExitClick(object sender, RoutedEventArgs e) => App.Current.Shutdown(0);

        private void HideClick(object sender, RoutedEventArgs e)
        {
            foreach (Window currentWindow in Application.Current.Windows)
            {
                currentWindow.WindowState = WindowState.Minimized;
            }
            //App.Current.MainWindow.Hide();
        }
    }
}
