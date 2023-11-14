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

        public IActionResult Index()
        {
            var modelSong = _context.Song?.AsNoTracking().OrderByDescending(p=>p.ViewCount).Include(p => p.Artist).Take(5).ToList();
            var modelPlaylist = _context.Playlist?.AsNoTracking().OrderByDescending(p => p.ViewCount).Take(5).ToList();
            var modelArtist = _context.Artist?.Take(5).ToList();

            var viewModel = new Home
            {
                Songs = modelSong,
                Playlists = modelPlaylist,
                Artists = modelArtist
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