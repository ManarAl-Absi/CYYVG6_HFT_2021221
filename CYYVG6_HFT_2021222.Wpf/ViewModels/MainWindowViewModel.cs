using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYYVG6_HFT_2021222.Wpf.ViewModels
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public RelayCommand ManageStudentsCommand { get; set; }
        public RelayCommand ManageEmployeesCommand { get; set; }
        public RelayCommand ManageFacultiesCommand { get; set; }

        public MainWindowViewModel()
        {
            ManageStudentsCommand = new RelayCommand(OpenStudentsWindow);
            ManageEmployeesCommand = new RelayCommand(OpenEmployeesWindow);
            ManageFacultiesCommand = new RelayCommand(OpenFacultiesWindow);
        }

        private void OpenStudentsWindow()
        {
            new StudentsWindow().Show();
        }
        private void OpenEmployeesWindow()
        {
            new EmployeesWindow().Show();
        }
        private void OpenFacultiesWindow()
        {
            new FacultiesWindow().Show();
        }
    }
}
