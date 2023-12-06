using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_Client
{
    public class MainWindowViewModel : ObservableRecipient
    {
        static public RestService rest;
        public ICommand OpenArtistsWindowCommand { get; set; }
        public ICommand OpenAlbumsWindowCommand { get; set; }
        public ICommand OpenLabelsWindowCommand { get; set; }
        public ICommand OpenSongsWindowCommand { get; set; }
        public ICommand OpenNCWindowCommand { get; set; }

        public MainWindowViewModel()
        {
            rest = new RestService("http://localhost:5124/", "swagger");
            OpenArtistsWindowCommand = new RelayCommand(() =>
            {
                ArtistWindow artistWindow = new ArtistWindow();
                artistWindow.Show();
            });
            OpenAlbumsWindowCommand = new RelayCommand(() =>
            {
                AlbumWindow albumWindow = new AlbumWindow();
                albumWindow.Show();
            });
            OpenLabelsWindowCommand = new RelayCommand(() =>
            {
                LabelWindow labelWindow = new LabelWindow();
                labelWindow.Show();
            });
            OpenSongsWindowCommand = new RelayCommand(() =>
            {
                SongWindow songWindow = new SongWindow();
                songWindow.Show();
            });
            OpenNCWindowCommand = new RelayCommand(() =>
            {
                NCWindow ncWindow = new NCWindow();
                ncWindow.Show();
            });
        }
    }
}
