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

        public int Age { get; set; }

        public string? Role { get; set; }
    }
}
