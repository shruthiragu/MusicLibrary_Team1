using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string Artist { get; set; }
        Boolean Recommendable   { get; set; }
        public PlaylistCategory Category { get; set; }
    
        public Playlist(string name, PlaylistCategory category)
        {
            name = name;
            Category = category;
        }

        }
    }
