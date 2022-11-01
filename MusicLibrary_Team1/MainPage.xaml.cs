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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MusicLibrary_Team1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    
    public sealed partial class MainPage : Page
    {
        /*private Windows.Storage.StorageFile file;
        private String selectedPlaylist;
        private String selectedArtist;
        private Boolean isRecommended;*/

        internal ObservableCollection<Track> tracks;
        public MainPage()
        {
            this.InitializeComponent();
            this.tracks = new ObservableCollection<Track>();
            TrackManager.GetAllTracks(tracks);
            //BackButton.Visibility = Visibility.Collapsed;
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TracksGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var track = (Track)e.ClickedItem;
            TrackMedia.Source = new Uri(this.BaseUri, track.AudioFile);
        }

        /*private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
             
        }

        private async void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            var picker = new FileOpenPicker();
            picker.ViewMode = PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            picker.FileTypeFilter.Add(".mp3");
            file = await picker.PickSingleFileAsync();
            if (file != null)
                this.FileNameTextBox.Text = file.Path;
            else
                this.FileNameTextBox.Text = "Operation Cancelled!";
            
        }

   

        private async void InsertFileButton_Click(object sender, RoutedEventArgs e)
        {
            if (RecommendedTrue.IsChecked == true)
                isRecommended = true;
            else
                isRecommended = false;
            // Get the path to the app's Assets folder.
            //string root = Directory.GetCurrentDirectory();
            //string path = root + @"\Assets\" + this.selectedPlaylist;

            
            

            // Get the folder object that corresponds to this absolute path in the file system.
            //StorageFolder assetsFolder = await StorageFolder.GetFolderFromPathAsync(root);

            
            StorageFile copiedFile = await file.CopyAsync(KnownFolders.MusicLibrary);

        }

        private void PlaylistComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {           
            ComboBoxItem cbi = (ComboBoxItem)PlaylistComboBox.SelectedItem;
            selectedPlaylist = cbi.Content.ToString();
           
        }

        private void ArtistComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = (ComboBoxItem)ArtistComboBox.SelectedItem;
            selectedArtist = cbi.Content.ToString();
        }*/
    }
}
