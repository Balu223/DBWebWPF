using BYLLQ0_HFT_2022232.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPF_Client
{
    public class ArtistWindowViewModel : ObservableRecipient
    {

        public RestCollection<Artist> Artists { get; set; }
        private Artist selectedArtist;

        public Artist SelectedArtist
        {
            get { return selectedArtist; }
            set
            {
                if (value != null)
                {
                    selectedArtist = new Artist()
                    { 
                        ArtistId = value.ArtistId, 
                        DateOfBirth = value.DateOfBirth,
                        RealName = value.RealName,
                        StageName = value.StageName,
                        LabelId = value.LabelId
                    };
                    OnPropertyChanged();
                    (DeleteArtistCommand as RelayCommand).NotifyCanExecuteChanged();
                }

            }


        }


        public ICommand CreateArtistCommand { get; set; }
        public ICommand DeleteArtistCommand { get; set; }
        public ICommand UpdateArtistCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public ArtistWindowViewModel()
        {

            if (!IsInDesignMode)
            {

                Artists = new RestCollection<Artist>("http://localhost:5124/", "artist", "hub");
                CreateArtistCommand = new RelayCommand(() =>
                {
                    Artists.Add(new Artist()
                    {
                        StageName = SelectedArtist.StageName,
                        RealName = SelectedArtist.StageName
                    });
                });

                UpdateArtistCommand = new RelayCommand(() =>
                {
                    Artists.Update(SelectedArtist);
                });

                DeleteArtistCommand = new RelayCommand(() =>
                {
                    Artists.Delete(SelectedArtist.ArtistId);

                },
                () =>
                {
                    return SelectedArtist != null;
                });
                SelectedArtist = new Artist()
                {
                    RealName = "",
                    StageName = ""
                };
            }
        }
    }
}
