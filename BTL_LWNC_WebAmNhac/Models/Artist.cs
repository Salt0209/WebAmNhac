using System.ComponentModel.DataAnnotations;

namespace BTL_LWNC_WebAmNhac.Models
{
    public class Artist
    {
        [Key]
        public int ID { get; set; }

        public string? Name { get; set; }

        public string? Birthday { get; set; }

        public string? Country { get; set; }

        public string? Image { get; set; }

        public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
    }
}
