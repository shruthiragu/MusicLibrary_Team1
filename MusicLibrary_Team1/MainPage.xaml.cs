using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.Win32;
using System.Windows;
using Windows.Storage.Pickers;
using Windows.Storage;
using System.IO;
using Windows.ApplicationModel;
using Windows.Storage.AccessCache;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MusicLibrary_Team1.Model;
using System.Collections.Generic;
using Windows.Media.Core;
using Windows.Devices.Bluetooth;
using Windows.UI.Xaml.Media;
using System.Linq;
using Windows.UI.ViewManagement;
using Windows.Foundation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MusicLibrary_Team1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    
    public sealed partial class MainPage : Page
    {
        internal ObservableCollection<Track> tracks;
        internal List<PlayListMenuItem> playListItems;
        public List<Track> recommendedTracks;
        public List<Track> searchAllSongsList;
        public List<string> allTrackNames;
        public List<string> recommendedTrackNames;

        public MainPage()
        {
            this.InitializeComponent();
            ApplicationView.PreferredLaunchViewSize = new Size(1000, 800);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;

            this.tracks = new ObservableCollection<Track>();
            this.searchAllSongsList = TrackManager.GetAllTracks(tracks);
            this.allTrackNames = TrackManager.GetAllTrackNames();
            this.playListItems = new List<PlayListMenuItem>();
            playListItems = PlayListManager.getPlayListIcons();
            BackButton.Visibility = Visibility.Collapsed;
            this.recommendedTracks = new List<Track>();
            this.recommendedTrackNames = new List<string>();
            
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            ContentSplitView.IsPaneOpen = !ContentSplitView.IsPaneOpen;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            GoToHomePage();
        }

        private void GoToHomePage()
        {
            BackButton.Visibility = Visibility.Collapsed;
            TrackManager.GetAllTracks(tracks);
            PlayListTextBlock.Text = "All Songs";
            PlayListMenuItemListView.SelectedItem = null;

        }

        private void TracksGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var track = (Track)e.ClickedItem;            
            TrackPlayerElement.Visibility = Visibility.Visible;
            TrackPlayerElement.Source = MediaSource.CreateFromUri(new Uri(this.BaseUri, track.AudioFile));
        }

        private void PlayListMenuItemListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var clickedItem = (PlayListMenuItem)e.ClickedItem;
            TrackManager.GetAllTracksbyPlayList(tracks, clickedItem.Category);
            PlayListTextBlock.Text = clickedItem.Category.ToString();
            BackButton.Visibility = Visibility.Visible;
            ContentSplitView.IsPaneOpen = false;
        }

        private void RecommendedButton_Click(object sender, RoutedEventArgs e)
        {            
            var favoriteTrack = (sender as Button).DataContext as Track;
            if (!recommendedTrackNames.Contains(favoriteTrack.TrackName))
            {
                recommendedTrackNames.Add(favoriteTrack.TrackName);
                
            }
            else
            {
                recommendedTrackNames.Remove(favoriteTrack.TrackName);               
            }
        }

        private void FavoritesButton_Click(object sender, RoutedEventArgs e)
        {
            TrackManager.GetAllRecommendedTracks(tracks, recommendedTracks, recommendedTrackNames);
            PlayListTextBlock.Text = "Recommended";
            BackButton.Visibility = Visibility.Visible;
        }

        private void SearchAllSongsAutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (String.IsNullOrEmpty(sender.Text))
            {
                GoToHomePage();
            }
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                List<string> trackSuggestion = allTrackNames.Where(x => x.Contains(sender.Text)).ToList();
                sender.ItemsSource = trackSuggestion;
            }
            
        }

        private void SearchAllSongsAutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            var selectedItem = args.SelectedItem.ToString();
            sender.Text = selectedItem;
        }

        private void SearchAllSongsAutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion != null)
            {
                string chosenTrackName = args.ChosenSuggestion.ToString();
                TrackManager.GetTrackbySearchName(tracks, chosenTrackName);
                BackButton.Visibility = Visibility.Visible;
                PlayListTextBlock.Text = "Search Results";                
            }
        }       
    }
}
