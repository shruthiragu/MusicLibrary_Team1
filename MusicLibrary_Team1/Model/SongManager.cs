using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.FileProperties;

namespace MusicLibrary_Team1.Model
{
    internal class SongManager
    {
        internal static async Task GetAllSongs(ObservableCollection<Song> Songs,ObservableCollection<StorageFile> songFiles)
        {
            
            foreach (var song in songFiles)
            {
                MusicProperties musicProperties = await song.Properties.GetMusicPropertiesAsync();
                var thumbnail =await song.GetThumbnailAsync(ThumbnailMode.MusicView);

                Songs.Add(new Song(musicProperties.Title, musicProperties.Artist, musicProperties.Genre[0], musicProperties.Album, thumbnail, song));
            }
        }
    }
}
