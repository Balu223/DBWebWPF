using BYLLQ0_HFT_2022232.Models;
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

        public RestCollection<Artist> Artists { get; set; }
        private Artist selectedArtist;

        public Artist SelectedArtist
        {
            get { return selectedArtist; }
            set
            {
                SetProperty(ref selectedArtist, value);
                (DeleteArtistCommand as RelayCommand).NotifyCanExecuteChanged();
            }


        }


        public ICommand CreateArtistCommand { get; set; }
        public ICommand DeleteArtistCommand { get; set; }
        public ICommand UpdateArtistCommand { get; set; }

        public MainWindowViewModel()
        {
            Artists = new RestCollection<Artist>("http://localhost:5124/", "artist");
            CreateArtistCommand = new RelayCommand(() =>
            {
                Artists.Add(new Artist()
                {
                    StageName = "Lil Kubik A Creeper",
                    RealName = "Kubik Marcell"
                });
            });
            DeleteArtistCommand = new RelayCommand(() =>
            {
                Artists.Delete(SelectedArtist.ArtistId);
                
            },
            () =>
            {
                return SelectedArtist != null;
            });
        }
    }
}
