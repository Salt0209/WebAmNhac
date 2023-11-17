using BTL_LWNC_WebAmNhac.Data;
using BTL_LWNC_WebAmNhac.Models;
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
            var modelSong = _context.Song?.AsNoTracking().OrderByDescending(p => p.ViewCount).Include(p => p.Artist).Take(5).ToList();
            var randomOrderedSongs = modelSong.OrderBy(x => Guid.NewGuid()).ToList();
            var modelPlaylist = _context.Playlist?.AsNoTracking().OrderByDescending(p => p.ViewCount).Take(5).ToList();
            var randomOrderedPlaylists = modelPlaylist.OrderBy(x => Guid.NewGuid()).ToList();
            var modelArtist = _context.Artist?.Take(5).ToList();
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
            var modelSong = _context.Song?.AsNoTracking().OrderByDescending(p => p.ViewCount).Include(p => p.Artist).Take(5).ToList();
            var modelPlaylist = _context.Playlist?.AsNoTracking().OrderByDescending(p => p.ViewCount).Take(5).ToList();

            var viewModel = new Home
            {
                Songs = modelSong,
                Playlists = modelPlaylist
            };
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}