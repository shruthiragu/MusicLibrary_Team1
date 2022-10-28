using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Perception.People;

namespace MusicLibrary_Team1.Model
{
    internal enum PlaylistCategory
    {
        Chill,
        Classics,
        Dance,
        Upbeat

    }
    internal class Playlist
    {
        public string TrackName { get; set; }   
        public string ArtistName { get; set; }
        Boolean Recommendable { get; set; } = true;
        public PlaylistCategory Category { get; set; }

        public Playlist(string name, PlaylistCategory category)
        {
            TrackName = name;
            Category = category;
            Recommendable = false;  


        }
    }
}
