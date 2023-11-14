using System.ComponentModel.DataAnnotations;

namespace BTL_LWNC_WebAmNhac.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? Role { get; set; }

        public virtual ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();
    }
}
