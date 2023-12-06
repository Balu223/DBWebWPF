using BYLLQ0_HFT_2022232.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WPF_Client
{
    class NCWindowViewModel : ObservableRecipient
    {

        public ObservableCollection<NonCrud.ArtistInfo> artistWithMostSongsAtLabel { get; set; }
        public ObservableCollection<NonCrud.ArtistInfo> ArtistWithMostSongsAtLabel
        {
            get { return artistWithMostSongsAtLabel; }
            set
            {
                artistWithMostSongsAtLabel = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<NonCrud.AlbumInfo> albumsWithMostSongs { get; set; }
        public ObservableCollection<NonCrud.AlbumInfo> AlbumsWithMostSongs
        {
            get { return albumsWithMostSongs; }
            set
            {
                albumsWithMostSongs = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Artist> getArtistsByGenre { get; set; }
        public ObservableCollection<Artist> GetArtistsByGenre
        {
            get { return getArtistsByGenre; }
            set
            {
                getArtistsByGenre = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Song> getSongsByLabel { get; set; }
        public ObservableCollection<Song> GetSongsByLabel
        {
            get { return getSongsByLabel; }
            set
            {
                getSongsByLabel = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<NonCrud.LabelInfo> getLabelsWithMostAlbums { get; set; }
        public ObservableCollection<NonCrud.LabelInfo> GetLabelsWithMostAlbums
        {
            get { return getLabelsWithMostAlbums; }
            set
            {
                getLabelsWithMostAlbums = value;
                OnPropertyChanged();
            }
        }


        public RestService rest;
        private string tb_input;
        public string TB_input
        {
            get
            {
                return tb_input;
            }
            set
            {
                tb_input = value;
                OnPropertyChanged();
                (GetArtistWithMostSongsAtLabelCommand as RelayCommand).NotifyCanExecuteChanged();
                (GetAlbumsWithMostSongsCommand as RelayCommand).NotifyCanExecuteChanged();
                (GetArtistsByGenreCommand as RelayCommand).NotifyCanExecuteChanged();
                (GetSongsByLabelCommand as RelayCommand).NotifyCanExecuteChanged();
                (GetLabelsWithMostAlbumsCommand as RelayCommand).NotifyCanExecuteChanged();

            }
        }

        private string selectedMethod;
        public string SelectedMethod
        {
            get { return selectedMethod; }
            set
            {
                selectedMethod = value;
                OnPropertyChanged(nameof(SelectedMethod));
                OnPropertyChanged(nameof(SelectedObservableCollection));
            }
        }

        public IEnumerable SelectedObservableCollection
        {
            get
            {
                switch (SelectedMethod)
                {
                    case "ArtistWithMostSongsAtLabel":
                        return ArtistWithMostSongsAtLabel;
                    case "AlbumsWithMostSongs":
                        return AlbumsWithMostSongs;
                    case "GetArtistsByGenre":
                        return GetArtistsByGenre;
                    case "GetSongsByLabel":
                        return GetSongsByLabel;
                    case "GetLabelsWithMostAlbums":
                        return GetLabelsWithMostAlbums;
                    default:
                        return null;
                }
            }
        }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public ICommand GetArtistWithMostSongsAtLabelCommand { get; set; }
        public ICommand GetAlbumsWithMostSongsCommand { get; set; }
        public ICommand GetArtistsByGenreCommand { get; set; }
        public ICommand GetSongsByLabelCommand { get; set; }
        public ICommand GetLabelsWithMostAlbumsCommand { get; set; }


        public NCWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                rest = MainWindowViewModel.rest;
                GetArtistWithMostSongsAtLabelCommand = new RelayCommand(() =>
                {
                    //SelectedCollection = 1;
                    int id = int.Parse(TB_input);
                    var a = rest.Get<NonCrud.ArtistInfo>($"http://localhost:5124/NC/GetArtistWithMostSongsAtLabel/{id}");
                    ArtistWithMostSongsAtLabel = new ObservableCollection<NonCrud.ArtistInfo>(a);
                    SelectedMethod = "ArtistWithMostSongsAtLabel";
                });
                GetAlbumsWithMostSongsCommand = new RelayCommand(() =>
                {
                    // SelectedCollection = 2;

                    var a = rest.Get<NonCrud.AlbumInfo>($"http://localhost:5124/NC/GetAlbumsWithMostSongs/");
                    AlbumsWithMostSongs = new ObservableCollection<NonCrud.AlbumInfo>(a);
                    SelectedMethod = "AlbumsWithMostSongs";
                    
                    ;
                });
                GetArtistsByGenreCommand = new RelayCommand(() =>
                {
                   // SelectedCollection = 3;
                    string genre = TB_input;
                    var a = rest.Get<Artist>($"http://localhost:5124/NC/GetArtistsByGenre/{genre}/");
                    GetArtistsByGenre = new ObservableCollection<Artist>(a);
                    SelectedMethod = "GetArtistsByGenre";
                });
                GetSongsByLabelCommand = new RelayCommand(() =>
                {
                   // SelectedCollection = 4;
                    int id = int.Parse(TB_input);
                    var a = rest.Get<Song>($"NC/GetSongsByLabel/{id}");
                    GetSongsByLabel = new ObservableCollection<Song>(a);
                    SelectedMethod = "GetSongsByLabel";
                });
                
                GetLabelsWithMostAlbumsCommand = new RelayCommand(() =>
                {
                   // SelectedCollection = 5;
                    var a = rest.Get<NonCrud.LabelInfo>($"http://localhost:5124/NC/GetLabelsWithMostAlbums/");
                    GetLabelsWithMostAlbums = new ObservableCollection<NonCrud.LabelInfo>(a);
                    SelectedMethod = "GetLabelsWithMostAlbums";
                });
            }
        }
    }
}
