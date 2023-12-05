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
using BTL_LWNC_WebAmNhac.Models.ViewModels;

namespace BTL_LWNC_WebAmNhac.Controllers
{
    public class SongsController : Controller
    {
        private readonly BTL_LWNC_WebAmNhacContext _context;
        public int pageSize = 5;

        public SongsController(BTL_LWNC_WebAmNhacContext context)
        {
            _context = context;
        }

        // GET: Songs
        
        public IActionResult Index(int productPage=1)
        {
            return View(
                new SongListViewModel
                {
                    Songs = _context.Song.Include(s => s.Artist).Include(s => s.Genre)
                    .Skip((productPage - 1) * pageSize)
                    .Take(pageSize),
                    PagingInfo = new PagingInfo
                    {
                        ItemsPerPage = pageSize,
                        CurrentPage = productPage,
                        TotalItems = _context.Song.Count()
                    }
                }
                );
        }

        [HttpPost]
        public IActionResult Search(string keywords)
        {
            return View(_context.Song.Include(s => s.Artist).Include(s => s.Genre)
                    .Where(s=>s.Name.Contains(keywords)));
        }
        [HttpPost]
        public IActionResult SearchByGenre(string keywords)
        {
            return View(_context.Song.Include(s => s.Artist).Include(s => s.Genre)
                    .Where(s => s.Genre.Name.Contains(keywords)));
        }
        public IActionResult ShowSongByGenreId(int id)
        {
            var SongByGenre =_context.Song
                .Include(s => s.Artist).Include(s => s.Genre)
                .AsNoTracking()
                .Where(x => x.GenreID == id)
                .OrderBy(x => x.Name).ToList();
            return View("Search",SongByGenre);
        }
        // GET: Songs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Song == null)
            {
                return NotFound();
            }

            var song = await _context.Song
                .Include(s => s.Artist)
                .Include(s => s.Genre)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (song == null)
            {
                return NotFound();
            }
                // Increment the view count
                if(song.ViewCount == null)
            {
                song.ViewCount=0;
            }
                song.ViewCount++;
                // Update the database
                _context.SaveChanges();
            return View(song);
        }

        // GET: Songs/Create
        [Authorize(Roles ="Admin")]
        public IActionResult Create()
        {
            ViewData["ArtistID"] = new SelectList(_context.Set<Artist>(), "ID", "Name");
            ViewData["GenreID"] = new SelectList(_context.Set<Genre>(), "ID", "Name");
            return View();
        }
        [Authorize(Roles = "Admin")]
        // POST: Songs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,ArtistID,Lyric,Thumbnail,Url,GenreID")] Song song)
        {
            if (ModelState.IsValid)
            {
                _context.Add(song);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtistID"] = new SelectList(_context.Set<Artist>(), "ID", "Name", song.ArtistID);
            ViewData["GenreID"] = new SelectList(_context.Set<Genre>(), "ID", "Name", song.GenreID);
            return View(song);
        }
        [Authorize(Roles = "Admin")]
        // GET: Songs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Song == null)
            {
                return NotFound();
            }

            var song = await _context.Song.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }
            ViewData["ArtistID"] = new SelectList(_context.Set<Artist>(), "ID", "Name", song.ArtistID);
            ViewData["GenreID"] = new SelectList(_context.Set<Genre>(), "ID", "Name", song.GenreID);
            return View(song);
        }
        [Authorize(Roles = "Admin")]
        // POST: Songs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,ArtistID,Lyric,Thumbnail,Url,GenreID")] Song song)
        {
            if (id != song.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(song);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongExists(song.ID))
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
            ViewData["ArtistID"] = new SelectList(_context.Set<Artist>(), "ID", "Name", song.ArtistID);
            ViewData["GenreID"] = new SelectList(_context.Set<Genre>(), "ID", "Name", song.GenreID);
            return View(song);
        }
        [Authorize(Roles = "Admin")]
        // GET: Songs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Song == null)
            {
                return NotFound();
            }

            var song = await _context.Song
                .Include(s => s.Artist)
                .Include(s => s.Genre)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }
        [Authorize(Roles = "Admin")]
        // POST: Songs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Song == null)
            {
                return Problem("Entity set 'BTL_LWNC_WebAmNhacContext.Song'  is null.");
            }
            var song = await _context.Song.FindAsync(id);
            if (song != null)
            {
                _context.Song.Remove(song);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin")]
        private bool SongExists(int id)
        {
          return (_context.Song?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
