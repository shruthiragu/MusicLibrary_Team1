using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary_Team1.Model
{
 
    internal class PlayListMenuItem
    {
        public string PlayListMenuItemIconFile { get; set; }
        public PlayListCategory Category { get; set; }
        //public string Name;

        public PlayListMenuItem(string name, PlayListCategory category)
        {
            //Name = name;
            PlayListMenuItemIconFile = $"Assets/Icons/{category}/{name}.png";
            Category = category;
        }
    }
}
