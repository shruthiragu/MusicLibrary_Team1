using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;

namespace MusicLibrary_Team1.Model
{
    public class Song
    {
        
        public string Name { get; set; }
        public int SongId { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public string Album { get; set; }
        public StorageFile songFile { get; set; }
        public BitmapImage albumCover { get; set; }
        

        internal Song (string name, string artist, string genre, string album, Windows.Storage.FileProperties.StorageItemThumbnail thumbnail, StorageFile songFile)
        {
            Name = name;
            
            Artist = artist;
            Genre = genre;
            Album = album;
            this.songFile = songFile;

            albumCover = new BitmapImage();
            albumCover.SetSource(thumbnail);
            
        }
    }
}
