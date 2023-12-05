using BTL_LWNC_WebAmNhac.Data;
using BTL_LWNC_WebAmNhac.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BTL_LWNC_WebAmNhac.Controllers
{
    public class HomeController : Controller
    {
        private readonly BTL_LWNC_WebAmNhacContext _context;

        public HomeController(BTL_LWNC_WebAmNhacContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var modelSong = await _context.Song
                .AsNoTracking()
                .OrderByDescending(p => p.ViewCount)
                .Include(p => p.Artist)
                .Take(5)
                .ToListAsync();

            var randomOrderedSongs = modelSong.OrderBy(x => Guid.NewGuid()).ToList();

            var modelPlaylist = await _context.Playlist
                .AsNoTracking()
                .OrderByDescending(p => p.ViewCount)
                .Where(p=>p.User.Role.Equals("Admin"))
                .Take(5)
                .ToListAsync();

            var randomOrderedPlaylists = modelPlaylist.OrderBy(x => Guid.NewGuid()).ToList();

            var modelArtist = await _context.Artist
                .Take(5)
                .ToListAsync();

            var randomOrderedArtists = modelArtist.OrderBy(x => Guid.NewGuid()).ToList();

            var viewModel = new Home
            {
                Songs = randomOrderedSongs,
                Playlists = randomOrderedPlaylists,
                Artists = randomOrderedArtists
            };

            return View(viewModel);
        }
        public async Task<IActionResult> BangXepHang()
        {
            var modelSong = await _context.Song
                .AsNoTracking()
                .OrderByDescending(p => p.ViewCount)
                .Include(p => p.Artist)
                .Include(p => p.Genre)
                .Take(5)
                .ToListAsync();

            var modelPlaylist = await _context.Playlist
                .AsNoTracking()
                .OrderByDescending(p => p.ViewCount)
                .Take(5)
                .ToListAsync();

            var viewModel = new Home
            {
                Songs = modelSong,
                Playlists = modelPlaylist
            };

            return View(viewModel);
        }
        public async Task<IActionResult> ShowSongByGenreId(int id)
        {
            return RedirectToAction("ShowSongByGenreId", "Songs",new {id=id});
        }
        [Authorize(Roles ="Admin")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Authorize(Roles ="Admin")]
        public IActionResult Admin()
        {
            return View();
        }
    }
}