using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_LWNC_WebAmNhac.Models
{
    public class PlaylistDetail
    {
        [ForeignKey("Playlist")]
        public int playlistID { get; set; }
        [ForeignKey("Song")]
        public int songID { get; set; }
    }
}
