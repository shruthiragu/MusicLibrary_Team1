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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MusicLibrary_Team1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    
    public sealed partial class MainPage : Page
    {
        private Windows.Storage.StorageFile file;
        private String selectedPlaylist;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void CategoryTextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
             
        }

        private async void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            var picker = new FileOpenPicker();
            picker.ViewMode = PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = PickerLocationId.MusicLibrary;
            picker.FileTypeFilter.Add(".mp3");
            file = await picker.PickSingleFileAsync();
            if (file != null)
                this.FileNameTextBox.Text = file.Path;
            else
                this.FileNameTextBox.Text = "Operation Cancelled!";
            
        }

   

        private async void InsertFileButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the path to the app's Assets folder.
            string root = Directory.GetCurrentDirectory();
            string path = root + @"\Assets\" + this.selectedPlaylist;

            // Get the folder object that corresponds to this absolute path in the file system.
            StorageFolder assetsFolder = await StorageFolder.GetFolderFromPathAsync(path);


            StorageFile copiedFile = await file.CopyAsync(assetsFolder);

        }

        private void PlaylistComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {           
            ComboBoxItem cbi = (ComboBoxItem)PlaylistComboBox.SelectedItem;
            selectedPlaylist = cbi.Content.ToString();
           
        }
    }
}
