using BTL_LWNC_WebAmNhac.Data;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BTL_LWNC_WebAmNhac.Models
{
    public class UserPlaylist:ViewComponent
    {
        private readonly BTL_LWNC_WebAmNhacContext _context;

        public UserPlaylist(BTL_LWNC_WebAmNhacContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            int userID =1 ;
            if (_context.Playlist != null)
            {
                return View(_context.Playlist.Where(p=>p.UserID== userID).ToList());
            }
            else { return View(); }
        }
    }
}
