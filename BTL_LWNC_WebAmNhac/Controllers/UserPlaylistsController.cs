using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTL_LWNC_WebAmNhac.Data;
using BTL_LWNC_WebAmNhac.Models;

namespace BTL_LWNC_WebAmNhac.Controllers
{
    public class UserPlaylistsController : Controller
    {
        private readonly BTL_LWNC_WebAmNhacContext _context;

        public UserPlaylistsController(BTL_LWNC_WebAmNhacContext context)
        {
            _context = context;
        }

        // GET: UserPlaylists
        public async Task<IActionResult> Index()
        {
            var bTL_LWNC_WebAmNhacContext = _context.Playlist.Include(p => p.User);
            return View(await bTL_LWNC_WebAmNhacContext.ToListAsync());
        }

        // GET: UserPlaylists/Details/5
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


        // GET: UserPlaylists/Create
        public IActionResult Create()
        {
            ViewData["UserID"] = new SelectList(_context.User, "ID", "ID");
            return View();
        }

        // POST: UserPlaylists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Detail,Thumbnail,UserID,ViewCount")] Playlist playlist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playlist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserID"] = new SelectList(_context.User, "ID", "ID", playlist.UserID);
            return View(playlist);
        }

        // GET: UserPlaylists/Edit/5
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
            ViewData["UserID"] = new SelectList(_context.User, "ID", "ID", playlist.UserID);
            return View(playlist);
        }

        // POST: UserPlaylists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserID"] = new SelectList(_context.User, "ID", "ID", playlist.UserID);
            return View(playlist);
        }

        // GET: UserPlaylists/Delete/5
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

        // POST: UserPlaylists/Delete/5
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
            return RedirectToAction(nameof(Index));
        }

        private bool PlaylistExists(int id)
        {
          return (_context.Playlist?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
