using System.ComponentModel.DataAnnotations;

namespace BTL_LWNC_WebAmNhac.Models
{
    public class Genre
    {
        [Key]
        public int ID { get; set; }

        public string? Name { get; set; }

        public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
    }
}
