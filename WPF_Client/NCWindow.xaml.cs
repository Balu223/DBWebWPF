using BYLLQ0_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_Client
{
    /// <summary>
    /// Interaction logic for NCWindow.xaml
    /// </summary>
    public partial class NCWindow : Window
    {

        public NCWindow()
        {
            InitializeComponent();
        }
    }
    public class MyItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ArtistWithMostSongsTemplate { get; set; }
        public DataTemplate AlbumsWithMostSongsTemplate { get; set; }
        public DataTemplate GetArtistsByGenreTemplate { get; set; }
        public DataTemplate GetSongsByLabelTemplate { get; set; }
        public DataTemplate GetLabelsWithMostAlbumsTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is NonCrud.ArtistInfo)
                return ArtistWithMostSongsTemplate;

            if (item is NonCrud.AlbumInfo)
                return AlbumsWithMostSongsTemplate;
            if (item is Artist)
                return GetArtistsByGenreTemplate;
            if (item is Song)
                return GetSongsByLabelTemplate;
            if (item is NonCrud.LabelInfo)
                return GetLabelsWithMostAlbumsTemplate;

            return base.SelectTemplate(item, container);
        }
    }

}
