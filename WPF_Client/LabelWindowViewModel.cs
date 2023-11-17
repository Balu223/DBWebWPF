using BYLLQ0_HFT_2022232.Models;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace WPF_Client
{
    class LabelWindowViewModel : ObservableRecipient
    {
        public RestCollection<Label> Labels { get; set; }
        private Label selectedLabel;

        public Label SelectedLabel
        {
            get { return selectedLabel; }
            set
            {
                if (value != null)
                {
                    selectedLabel = new Label()
                    {
                        LabelId = value.LabelId,
                        LabelName = value.LabelName,
                        Address = value.Address
                    };
                    OnPropertyChanged();
                    (DeleteLabelCommand as RelayCommand).NotifyCanExecuteChanged();
                }

            }


        }


        public ICommand CreateLabelCommand { get; set; }
        public ICommand DeleteLabelCommand { get; set; }
        public ICommand UpdateLabelCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public LabelWindowViewModel()
        {

            if (!IsInDesignMode)
            {

                Labels = new RestCollection<Label>("http://localhost:5124/", "Label", "hub");
                CreateLabelCommand = new RelayCommand(() =>
                {
                    Labels.Add(new Label()
                    {
                        LabelName = SelectedLabel.LabelName,
                        Address = SelectedLabel.Address
                    });
                });

                UpdateLabelCommand = new RelayCommand(() =>
                {
                    Labels.Update(SelectedLabel);
                });

                DeleteLabelCommand = new RelayCommand(() =>
                {
                    Labels.Delete(SelectedLabel.LabelId);

                },
                () =>
                {
                    return SelectedLabel != null;
                });
                SelectedLabel = new Label()
                {
                    LabelName = "",
                    
                };
            }
        }
    }
}
