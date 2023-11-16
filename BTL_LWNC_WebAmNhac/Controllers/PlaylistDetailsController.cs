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
    public class PlaylistDetailsController : Controller
    {
        private readonly BTL_LWNC_WebAmNhacContext _context;

        public PlaylistDetailsController(BTL_LWNC_WebAmNhacContext context)
        {
            _context = context;
        }

        // GET: PlaylistDetails
        public async Task<IActionResult> Index()
        {
            var bTL_LWNC_WebAmNhacContext = _context.PlaylistDetail?.Include(p => p.Playlist).Include(p=>p.Song);
            return bTL_LWNC_WebAmNhacContext != null ?
                        View(await bTL_LWNC_WebAmNhacContext.ToListAsync()) :
                        Problem("Entity set 'BTL_LWNC_WebAmNhacContext.PlaylistDetail'  is null.");
        }

        // GET: PlaylistDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PlaylistDetail == null)
            {
                return NotFound();
            }

            var playlistDetail = await _context.PlaylistDetail
                .Include(p => p.Playlist)
                .Include(p => p.Song)
                .Where(m => m.PlaylistID == id)
                .ToListAsync();
            if (playlistDetail == null)
            {
                return NotFound();
            }

            return View(playlistDetail);
        }
        [HttpPost]
        public JsonResult addToPlaylistDetail(int playlistID, int songID)
        {
            var playlistDetail = new PlaylistDetail()
            {
                PlaylistID = playlistID,
                SongID = songID
            };

            _context.PlaylistDetail.Add(playlistDetail);

            // Check the number of entries written to the database
            var saveChangesResult = _context.SaveChanges();

            if (saveChangesResult > 0)
            {
                // If at least one entry was written, the operation was successful
                return Json(new { success = true });
            }
            else
            {
                // If no entries were written, the operation failed
                return Json(new { success = false, errorMessage = "Failed to add to the database." });
            }
        }

        // GET: PlaylistDetails/Create
        public IActionResult Create()
        {
            ViewData["PlaylistID"] = new SelectList(_context.Set<Playlist>(), "ID", "Name");
            ViewData["SongID"] = new SelectList(_context.Set<Song>(), "ID", "Name");
            return View();
        }

        // POST: PlaylistDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlaylistID,SongID")] PlaylistDetail playlistDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playlistDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(playlistDetail);
        }
        [HttpPost]
        public JsonResult XoaBaiHat(int playlistID,int songID)
        {
            TempData["Message"] = "";
            var playlistDetail = _context.PlaylistDetail.Find(playlistID, songID);
            if (playlistDetail != null)
            {
                _context.PlaylistDetail.Remove(playlistDetail);
            }
            else
            {
                return Json(new { success = false });
            }
            _context.SaveChanges();
            return Json(new { success = true });
        }
        // GET: PlaylistDetails/Delete/5
        public async Task<IActionResult> Delete(int? playlistID, int? songID)
        {
            if (playlistID == null || songID==null || _context.PlaylistDetail == null)
            {
                return NotFound();
            }

            var playlistDetail = await _context.PlaylistDetail
                .Include(x => x.Playlist).Include(x => x.Song)
                .FirstOrDefaultAsync(m => m.PlaylistID == playlistID && m.SongID==songID );
            if (playlistDetail == null)
            {
                return NotFound();
            }

            return View(playlistDetail);
        }

        // POST: PlaylistDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int playlistID, int songID)
        {
            if (_context.PlaylistDetail == null)
            {
                return Problem("Entity set 'BTL_LWNC_WebAmNhacContext.PlaylistDetail'  is null.");
            }
            var playlistDetail = await _context.PlaylistDetail.FindAsync(playlistID,songID);
            if (playlistDetail != null)
            {
                _context.PlaylistDetail.Remove(playlistDetail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlaylistDetailExists(int playlistID,int songID)
        {
          return (_context.PlaylistDetail?.Any(e => e.PlaylistID == playlistID && e.SongID==songID)).GetValueOrDefault();
        }
    }
}
