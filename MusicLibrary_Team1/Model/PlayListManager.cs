using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary_Team1.Model
{    internal static class PlayListManager
    {     
        public static List<PlayListMenuItem> getPlayListIcons()
        {
            var PlayListMenuItem = new List<PlayListMenuItem>();
            PlayListMenuItem.Add(new PlayListMenuItem("chillIcon", PlayListCategory.Chill));
            PlayListMenuItem.Add(new PlayListMenuItem("classicsIcon", PlayListCategory.Classics));
            PlayListMenuItem.Add(new PlayListMenuItem("danceIcon", PlayListCategory.Dance));
            PlayListMenuItem.Add(new PlayListMenuItem("upbeatIcon", PlayListCategory.Upbeat));
            return PlayListMenuItem;
        }
    }
}
