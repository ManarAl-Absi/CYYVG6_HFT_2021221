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
    public class StudentsWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }


        public RestCollection<Student> Students { get; set; }

        private Student selectedStudent;

        public Student SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                if (value != null)
                {
                    selectedStudent = new Student()
                    {
                        FulName = value.FulName,
                        StudentId = value.StudentId
                    };
                    OnPropertyChanged();
                    (DeleteStudentCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand CreateStudentCommand { get; set; }

        public ICommand DeleteStudentCommand { get; set; }

        public ICommand UpdateStudentCommand { get; set; }
        public ICommand GetStudentCommand { get; set; }
        public ICommand GetAllStudentCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }


        public StudentsWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Students = new RestCollection<Student>("http://localhost:47153/", "student", "hub");
                CreateStudentCommand = new RelayCommand(() =>
                {
                    Students.Add(new Student()
                    {
                        FulName = SelectedStudent.FulName
                    });
                });

                UpdateStudentCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Students.Update(SelectedStudent);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteStudentCommand = new RelayCommand(() =>
                {
                    Students.Delete(SelectedStudent.StudentId);
                },
                () =>
                {
                    return SelectedStudent != null;
                });
                
            }

        }
    }
}
