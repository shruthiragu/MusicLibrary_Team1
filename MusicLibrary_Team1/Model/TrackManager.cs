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
        public static List<Track> GetAllTracks(ObservableCollection<Track> tracks)
        {
            var allTracks = getTracks();
            tracks.Clear();
            allTracks.ForEach(track => tracks.Add(track));
            return allTracks;
        }

        public static void GetAllTracksbyPlayList(ObservableCollection<Track> tracks, PlayListCategory category)
        {
            var allTracks = getTracks();
            tracks.Clear();
            var filteredTracks = allTracks.Where(track => track.Category == category).ToList();
            filteredTracks.ForEach(track => tracks.Add(track));
        }

        public static void GetTrackbySearchName(ObservableCollection<Track> tracks, string trackName)
        {
            var allTracks = getTracks();
            tracks.Clear();
            var searchTrack = allTracks.Where(track => track.TrackName == trackName).ToList();
            searchTrack.ForEach(track => tracks.Add(track));
        }

        public static void GetAllRecommendedTracks(ObservableCollection<Track> tracks,List<Track> recommendedTracks, List<string> recommendedTrackNames)
        {            
            var allTracks = getTracks();
            tracks.Clear();
            foreach (var trackName in recommendedTrackNames)
            {
                var recommendedTrackName = allTracks.Where(track => track.TrackName == trackName).ToList();
                recommendedTrackName.ForEach(track => tracks.Add(track));
            }           
        }

        private static List<Track> getTracks()
        {
            List<Track> tracks = new List<Track>
            {
                new Track("SomeoneLikeYou", PlayListCategory.Chill),
                new Track("NoTearsLeftToCry", PlayListCategory.Chill),
                new Track("SaySo", PlayListCategory.Classics),
                new Track("ThinkingOutLoud", PlayListCategory.Classics),
                new Track("Baby", PlayListCategory.Dance),
                new Track("PartyRockAnthem", PlayListCategory.Dance),
                new Track("UptownFunk", PlayListCategory.Upbeat),
                new Track("Umbrella", PlayListCategory.Upbeat)
            };
            return tracks;
        }

        internal static List<string> GetAllTrackNames()
        {
            List<string> allTrackNames = new List<string>();
            var allTracks = getTracks();
            allTracks.ForEach(track => allTrackNames.Add(track.TrackName));
            return allTrackNames;
        }
    }
}
