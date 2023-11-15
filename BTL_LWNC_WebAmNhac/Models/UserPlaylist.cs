using BTL_LWNC_WebAmNhac.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
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
            
            if (User.Identity.IsAuthenticated)
            {
                var userClaims = User.Identity as ClaimsIdentity;
                var userID = int.Parse(userClaims.FindFirst(ClaimTypes.NameIdentifier).Value); ;
                var username = User.Identity.Name;
                return View(_context.Playlist.Where(p => p.UserID == userID).ToList());
            }
            
            else
            {
                var defaultModel = new List<Playlist>();
                return View(defaultModel);
            }
        }
    }
}
