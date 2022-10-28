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


    internal class Sound
    {
        public string TrackName { get; set; }
        public string AudioFile { get; set; }
        public string ImageFile { get; set; }
        public PlaylistCategory Category { get; set; }
    
        public Sound(string name, PlaylistCategory category)
        {

        }

        }
    }
