using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary_Team1.Model
{ 
    public enum PlayListCategory
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
        public Boolean Recommendable   { get; set; }
        public PlayListCategory Category { get; set; }
        public string ImageFile { get; set; }
        public string AudioFile { get;set; }
    
        public Track(string name, PlayListCategory category)
        Boolean Recommendable   { get; set; }
        public PlaylistCategory Category { get; set; }
    
        public Playlist(string name, PlaylistCategory category)
        {
            name = name;
            Category = category;

        }

        }
    }
