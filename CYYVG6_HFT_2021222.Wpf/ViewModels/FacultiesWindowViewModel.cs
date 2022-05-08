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
    public class FacultiesWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }


        public RestCollection<Faculty> Faculties { get; set; }

        private Faculty selectedFaculty;

        public Faculty SelectedFaculty
        {
            get { return selectedFaculty; }
            set
            {
                if (value != null)
                {
                    selectedFaculty = new Faculty()
                    {
                        FacultyName = value.FacultyName,
                        FacultyId = value.FacultyId
                    };
                    OnPropertyChanged();
                    (DeleteFacultyCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand CreateFacultyCommand { get; set; }

        public ICommand DeleteFacultyCommand { get; set; }

        public ICommand UpdateFacultyCommand { get; set; }
        public ICommand GetFacultyCommand { get; set; }
        public ICommand GetAllFacultyCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }


        public FacultiesWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Faculties = new RestCollection<Faculty>("http://localhost:47153/", "faculty", "hub");
                CreateFacultyCommand = new RelayCommand(() =>
                {
                    Faculties.Add(new Faculty()
                    {
                        FacultyName = SelectedFaculty.FacultyName
                    });
                });

                UpdateFacultyCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Faculties.Update(SelectedFaculty);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteFacultyCommand = new RelayCommand(() =>
                {
                    Faculties.Delete(SelectedFaculty.FacultyId);
                },
                () =>
                {
                    return SelectedFaculty != null;
                });

            }

        }
    }
}
