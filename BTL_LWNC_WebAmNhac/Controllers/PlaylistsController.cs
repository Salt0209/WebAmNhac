using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTL_LWNC_WebAmNhac.Data;
using BTL_LWNC_WebAmNhac.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace BTL_LWNC_WebAmNhac.Controllers
{
    public class PlaylistsController : Controller
    {
        private readonly BTL_LWNC_WebAmNhacContext _context;

        public PlaylistsController(BTL_LWNC_WebAmNhacContext context)
        {
            _context = context;
        }

        // GET: Playlists
        public async Task<IActionResult> Index()
        {
            var bTL_LWNC_WebAmNhacContext = _context.Playlist?.Include(p => p.User);
            return View(await bTL_LWNC_WebAmNhacContext.ToListAsync());
        }
        public async Task<IActionResult> UserPlaylist()
        {
            var userClaims = User.Identity as ClaimsIdentity;
            if (userClaims.IsAuthenticated)
            {
                var usernameClaim = int.Parse(userClaims.FindFirst(ClaimTypes.NameIdentifier).Value);
                var userPlaylists = _context.Playlist.Include(p => p.User).Where(p => p.UserID == usernameClaim).ToListAsync();
                return View(await userPlaylists);
            }
            else
            {
                return RedirectToAction("Login","Users");
            }

        }

        // GET: Playlists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Playlist == null)
            {
                return NotFound();
            }

            var playlist = await _context.Playlist
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (playlist == null)
            {
                return NotFound();
            }

            return View(playlist);
        }

        // GET: Playlists/Create
        [Authorize(Roles ="Admin,User")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Playlists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin,User")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, [Bind("Name,Detail,Thumbnail")] Playlist playlist)
        {
            if (ModelState.IsValid)
            {
                var newPlaylist = new Playlist()
                {
                    Name = playlist.Name,
                    Detail = playlist.Detail,
                    Thumbnail = playlist.Thumbnail,
                    UserID = id,
                    ViewCount = 0
                };
                _context.Add(newPlaylist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(UserPlaylist));
            }
            return View(playlist);
        }

        // GET: Playlists/Edit/5
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Playlist == null)
            {
                return NotFound();
            }

            var playlist = await _context.Playlist.FindAsync(id);
            if (playlist == null)
            {
                return NotFound();
            }
            return View(playlist);
        }

        // POST: Playlists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin,User")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Detail,Thumbnail,UserID,ViewCount")] Playlist playlist)
        {
            if (id != playlist.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playlist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlaylistExists(playlist.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(UserPlaylist));
            }
            return View(playlist);
        }

        // GET: Playlists/Delete/5
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Playlist == null)
            {
                return NotFound();
            }

            var playlist = await _context.Playlist
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (playlist == null)
            {
                return NotFound();
            }

            return View(playlist);
        }

        // POST: Playlists/Delete/5
        [Authorize(Roles = "Admin,User")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Playlist == null)
            {
                return Problem("Entity set 'BTL_LWNC_WebAmNhacContext.Playlist'  is null.");
            }
            var playlist = await _context.Playlist.FindAsync(id);
            if (playlist != null)
            {
                _context.Playlist.Remove(playlist);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(UserPlaylist));
        }
        [Authorize(Roles = "Admin,User")]
        private bool PlaylistExists(int id)
        {
          return (_context.Playlist?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
