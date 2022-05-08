using CYYVG6_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CYYVG6_HFT_2021222.Wpf.ViewModels
{
    public class EmployeesWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }


        public RestCollection<Employee> Employees { get; set; }

        private Employee selectedEmployee;

        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set
            {
                if (value != null)
                {
                    selectedEmployee = new Employee()
                    {
                        FulName = value.FulName,
                        EmployeeId = value.EmployeeId
                    };
                    OnPropertyChanged();
                    (DeleteEmployeeCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand CreateEmployeeCommand { get; set; }

        public ICommand DeleteEmployeeCommand { get; set; }

        public ICommand UpdateEmployeeCommand { get; set; }
        public ICommand GetEmployeeCommand { get; set; }
        public ICommand GetAllEmployeeCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }


        public EmployeesWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Employees = new RestCollection<Employee>("http://localhost:47153/", "employee", "hub");
                CreateEmployeeCommand = new RelayCommand(() =>
                {
                    Employees.Add(new Employee()
                    {
                        FulName = SelectedEmployee.FulName
                    });
                });

                UpdateEmployeeCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Employees.Update(SelectedEmployee);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteEmployeeCommand = new RelayCommand(() =>
                {
                    Employees.Delete(SelectedEmployee.EmployeeId);
                },
                () =>
                {
                    return SelectedEmployee != null;
                });

            }

        }
    }
}
