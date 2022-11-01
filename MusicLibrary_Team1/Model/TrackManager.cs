using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace MusicLibrary_Team1.Model
{
    internal static class TrackManager
    {
        public static void GetAllTracks(ObservableCollection<Track> tracks)
        {
            var allTracks = getTracks();
            tracks.Clear();
            allTracks.ForEach(track => tracks.Add(track));
        }

        public static void GetAllTracksbyPlayList(ObservableCollection<Track> tracks, PlaylistCategory category)
        {
            var allTracks = getTracks();
            tracks.Clear();
            var filteredTracks = allTracks.Where(track => track.Category == category).ToList();
            filteredTracks.ForEach(track => tracks.Add(track));
        }

        private static List<Track> getTracks()
        {
            List<Track> tracks = new List<Track>
            {
                new Track("SomeoneLikeYou", PlaylistCategory.Chill),
                new Track("NoTearsLeftToCry", PlaylistCategory.Chill),
                new Track("SaySo", PlaylistCategory.Classics),
                new Track("ThinkingOutLoud", PlaylistCategory.Classics),
                new Track("Baby", PlaylistCategory.Dance),
                new Track("PartyRockAnthem", PlaylistCategory.Dance),
                new Track("UptownFunk", PlaylistCategory.Upbeat),
                new Track("Umbrella", PlaylistCategory.Upbeat)
            };
            return tracks;
                    }
    }
}
