using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BTL_LWNC_WebAmNhac.Models
{
    public class Song
    {
        [Key]
        public int ID { get; set; }
        public string? Name { get; set; }
        [ForeignKey("Artist")]
        public int ArtistID { get; set; }
        public string? Lyric { get; set; }

        public string? Thumbnail { get; set; }
        public string? Url { get; set; }

        [ForeignKey("Genre")]
        public int GenreID { get; set; }
        public int ViewCount { get; set; }

        public virtual Artist? Artist { get; set; }

        public virtual Genre? Genre { get; set; }
    }
}
