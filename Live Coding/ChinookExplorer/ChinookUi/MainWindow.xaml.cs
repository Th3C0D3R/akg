using ChinookDal;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChinookUi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ChinookContext context = new ChinookContext();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var genres = context.Genres.OrderBy(g => g.Name).ToList();

            foreach (Genre genre in genres)
            {
                TreeViewItem tvi = new TreeViewItem() { Header = genre.Name, Tag=genre.GenreId };
                tvi.Items.Add(new TreeViewItem());
                tvi.Expanded += Genre_Expanded;

                trvArtists.Items.Add(tvi);
            }
        }

        private void Genre_Expanded(object sender, RoutedEventArgs e)
        {
            // Alle Artists, die mindestens einen Track haben, dessen Genre dem gewählten Genre entspricht
            if (sender is TreeViewItem tviGenre)
            {
                string genreName = tviGenre.Header.ToString();
                int genreId = (int)tviGenre.Tag;

                tviGenre.Items.Clear();

                var qArtists = context.Tracks.Where(tr => tr.GenreId == genreId)
                                                .Select(tr => tr.Album)
                                                .Select(al => al.Artist)
                                                .Distinct();

                var qArtists2 = this.context.Artists.Where(art => art.Albums.Any(alb => alb.Tracks.Any(tr => tr.Genre.Name == genreName))).Distinct();

                foreach (Artist artist in qArtists)
                {
                    TreeViewItem tvi = new TreeViewItem() { Header = artist.Name, Tag = artist.ArtistId };
                    tvi.Selected += Artist_Selected;
                    tviGenre.Items.Add(tvi);
                }
            }
        }

        private void Artist_Selected(object sender, RoutedEventArgs e)
        {
            // Combobox mit den ALben des Artists füllen
            if (sender is TreeViewItem tviArtist)
            {
                int artistId = (int)tviArtist.Tag;

                Artist artist = context.Artists.Find(artistId);
                cbxAlbums.ItemsSource = artist.Albums;
            }
        }
    }
}
