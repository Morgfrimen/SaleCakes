using System;
using System.Windows;
using SaleCakes.Model;
using SaleCakes.ViewModel;

namespace SaleCakes.View;

/// <summary>
///     Логика взаимодействия для CakeAddView.xaml
/// </summary>
public partial class CakeAddView : Window
{
    private readonly CakeViewModel _cakeViewModel;

    public CakeAddView(CakeViewModel cakeViewModel)
    {
        _cakeViewModel = cakeViewModel;
        InitializeComponent();
    }

    private void Exit(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void CakeAddView_OnFocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        if (e.NewValue is false)
        {
            Close();
        }
    }

    private void AddCakeOnClick(object sender, RoutedEventArgs e)
    {
        var random = new Random().Next(1, 4);
        _cakeViewModel.ModelCakes.Add(new CakeModel { Number = (uint)random, Title = $"Новый торт {random}", Weight = 100 * random });
        _cakeViewModel.UpdateAllProperty();
    }
}