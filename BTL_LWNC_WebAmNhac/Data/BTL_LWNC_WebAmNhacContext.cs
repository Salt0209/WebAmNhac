using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BTL_LWNC_WebAmNhac.Models;

namespace BTL_LWNC_WebAmNhac.Data
{
    public class BTL_LWNC_WebAmNhacContext : DbContext
    {
        public BTL_LWNC_WebAmNhacContext (DbContextOptions<BTL_LWNC_WebAmNhacContext> options)
            : base(options)
        {
        }

        public DbSet<BTL_LWNC_WebAmNhac.Models.Song> Song { get; set; } = default!;

        public DbSet<BTL_LWNC_WebAmNhac.Models.Playlist>? Playlist { get; set; }

        public DbSet<BTL_LWNC_WebAmNhac.Models.Artist>? Artist { get; set; }

        public DbSet<BTL_LWNC_WebAmNhac.Models.Genre>? Genre { get; set; }

        public DbSet<BTL_LWNC_WebAmNhac.Models.User>? User { get; set; }
    }
}
