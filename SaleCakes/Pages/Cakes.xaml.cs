using SaleCakes.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using SaleCakes.View;

namespace SaleCakes.Pages
{
    /// <summary>
    /// Логика взаимодействия для Cakes.xaml
    /// </summary>
    public partial class Cakes : Page
    {
        private CakeViewModel _cakeViewModel = new CakeViewModel();

        public Cakes()
        {
            InitializeComponent();
            StartPage();
        }

        private void StartPage()
        {
            _cakeViewModel = DataContext as CakeViewModel;
            _cakeViewModel.LoadModes.Execute(_cakeViewModel.ModelCakes);
        }

        private void ButtonMainMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenu());
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_OpenAddCake_OnClick(object sender, RoutedEventArgs e)
        {
            var cakeAddView = new CakeAddView(){DataContext = new CakeAddViewModel(_cakeViewModel) };
            cakeAddView.Show();
        }
    }
}
