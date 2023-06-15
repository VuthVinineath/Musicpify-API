using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musipify_API.Models
{
    public class Playlist
    {
        // MARK : ARTIST
        public int ARTIST_ID { get; set; }
        public string NAME { get; set; }
        public string COUNTRY { get; set; }
        public string ARTIST_PHOTO { get; set; }

        // MARK: ALBUM
        public int ALBUM_ID { get; set; }
        public string ALBUM_PHOTO { get; set; }
        public string TITLE { get; set; }
        public string DESCRIPTION { get; set; }

        // MARK : SONG 
        public string SONG_ID { get; set; }
        public string DURATION { get; set; }

        // MARK : ALBUM_TRACK
        public int TRACK_ID { get; set; }
    }
}