using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using SaleCakes.Command;
using SaleCakes.Model;

namespace SaleCakes.ViewModel;

public class EmployeeViewModel : BaseViewModel
{
    private Container _containers;

    private ObservableCollection<EmployeeModel> _employee = new()
    {
        new EmployeeModel(Guid.NewGuid(), Guid.NewGuid(), "Александр", "Шветцов", "Михайлович", "8-922-333-22-33", "mos@metro.рф", "пекарь"),
        new EmployeeModel(Guid.NewGuid(), Guid.NewGuid(), "Михаил", "Шветцов", "Михайлович", "8-922-333-22-33", "mos@metro.рф", "пекарь"),
        new EmployeeModel(Guid.NewGuid(), Guid.NewGuid(), "Максим", "Шветцов", "Михайлович", "8-922-333-22-33", "mos@metro.рф", "пекарь"),
        new EmployeeModel(Guid.NewGuid(), Guid.NewGuid(), "Екатерина", "Шветцов", "Михайлович", "8-922-333-22-33", "mos@metro.рф", "пекарь"),
        new EmployeeModel(Guid.NewGuid(), Guid.NewGuid(), "Вероника", "Шветцов", "Михайлович", "8-922-333-22-33", "mos@metro.рф", "администратор"),
        new EmployeeModel(Guid.NewGuid(), Guid.NewGuid(), "Алина", "Шветцов", "Михайлович", "8-922-333-22-33", "mos@metro.рф", "пекарь"),
        new EmployeeModel(Guid.NewGuid(), Guid.NewGuid(), "Ольга", "Мосвина", "Михайлович", "8-922-333-22-33", "mos@metro.рф", "пекарь")
    };

    private EmployeeModel _employeeModelNew;

    public EmployeeViewModel()
    {
        _employeeModelNew = new EmployeeModel();
        Containers = new Container { EmployeeModel = _employeeModelNew, Collection = _employee, ViewModel = this };
    }

    public ICommand AddEmployee { get; } = new RelayCommand(async obj =>
    {
        var container = obj as Container;

        container.Collection.Add(container.EmployeeModel);
        container.ViewModel.EmployeeModelNew = new EmployeeModel();
        container.ViewModel.UpdateAllProperty();

        container.ViewModel.Containers = new Container
        {
            Collection = container.ViewModel.Employee,
            EmployeeModel = container.ViewModel.EmployeeModelNew,
            ViewModel = container.ViewModel
        };
    });

    public EmployeeModel EmployeeModelNew
    {
        get
        {
            _employeeModelNew ??= new EmployeeModel();
            return _employeeModelNew;
        }
        set
        {
            _employeeModelNew = value;
            OnPropertyChanged(nameof(EmployeeModelNew));
        }
    }

    public ObservableCollection<EmployeeModel> Employee
    {
        get => _employee;
        set
        {
            _employee = value;
            OnPropertyChanged(nameof(Employee));
        }
    }

    public Container Containers
    {
        get => _containers;
        set
        {
            _containers = value;
            OnPropertyChanged(nameof(Containers));
        }
    }

    public override void UpdateAllProperty()
    {
        OnPropertyChanged(nameof(Employee));
        OnPropertyChanged(nameof(Containers));
        OnPropertyChanged(nameof(EmployeeModelNew));
    }

    public class Container
    {
        public EmployeeModel EmployeeModel { get; set; }
        public ObservableCollection<EmployeeModel> Collection { get; set; }
        public EmployeeViewModel ViewModel { get; set; }
    }
}