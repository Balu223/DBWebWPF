using BYLLQ0_HFT_2022232.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace WPF_Client
{
    public class AlbumWindowViewModel : ObservableRecipient
    {
        public RestCollection<Album> Albums { get; set; }
        private Album selectedAlbum;

        public Album SelectedAlbum
        {
            get { return selectedAlbum; }
            set
            {
                if (value != null)
                {
                    selectedAlbum = new Album()
                    {
                        AlbumId = value.AlbumId,
                        AlbumName = value.AlbumName,
                        ReleaseDate = value.ReleaseDate,
                        ArtistId = value.ArtistId,
                    };
                    OnPropertyChanged();
                    (DeleteAlbumCommand as RelayCommand).NotifyCanExecuteChanged();
                }

            }


        }


        public ICommand CreateAlbumCommand { get; set; }
        public ICommand DeleteAlbumCommand { get; set; }
        public ICommand UpdateAlbumCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public AlbumWindowViewModel()
        {

            if (!IsInDesignMode)
            {

                Albums = new RestCollection<Album>("http://localhost:5124/", "Album", "hub");
                CreateAlbumCommand = new RelayCommand(() =>
                {
                    Albums.Add(new Album()
                    {
                        AlbumName = SelectedAlbum.AlbumName, 
                        ReleaseDate = SelectedAlbum.ReleaseDate
                    });
                });

                UpdateAlbumCommand = new RelayCommand(() =>
                {
                    Albums.Update(SelectedAlbum);
                });

                DeleteAlbumCommand = new RelayCommand(() =>
                {
                    Albums.Delete(SelectedAlbum.AlbumId);

                },
                () =>
                {
                    return SelectedAlbum != null;
                });
                SelectedAlbum = new Album()
                {
                    AlbumName = "",
                    ReleaseDate = DateTime.Now
                };
            }
        }
    }
}
