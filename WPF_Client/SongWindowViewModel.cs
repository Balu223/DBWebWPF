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
    class SongWindowViewModel : ObservableRecipient
    {
        public RestCollection<Song> Songs { get; set; }
        private Song selectedSong;

        public Song SelectedSong
        {
            get { return selectedSong; }
            set
            {
                if (value != null)
                {
                    selectedSong = new Song()
                    {
                        SongId = value.SongId,
                        SongName = value.SongName,
                        ArtistId = value.ArtistId,
                        Genre = value.Genre
                    };
                    OnPropertyChanged();
                    (DeleteSongCommand as RelayCommand).NotifyCanExecuteChanged();
                }

            }


        }


        public ICommand CreateSongCommand { get; set; }
        public ICommand DeleteSongCommand { get; set; }
        public ICommand UpdateSongCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public SongWindowViewModel()
        {

            if (!IsInDesignMode)
            {

                Songs = new RestCollection<Song>("http://localhost:5124/", "Song", "hub");
                CreateSongCommand = new RelayCommand(() =>
                {
                    Songs.Add(new Song()
                    {
                        SongName = SelectedSong.SongName,
                        Genre = SelectedSong.Genre,
                        ArtistId = SelectedSong.ArtistId,
                    });
                });

                UpdateSongCommand = new RelayCommand(() =>
                {
                    Songs.Update(SelectedSong);
                });

                DeleteSongCommand = new RelayCommand(() =>
                {
                    Songs.Delete(SelectedSong.SongId);

                },
                () =>
                {
                    return SelectedSong != null;
                });
                SelectedSong = new Song()
                {
                    SongName = "",
                    Genre = "",
                    ArtistId = 1
                };
            }
        }
    }
}
