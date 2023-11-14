using BTL_LWNC_WebAmNhac.Data;
using Microsoft.AspNetCore.Mvc;

namespace BTL_LWNC_WebAmNhac.Models
{
    public class Sidebar:ViewComponent
    {
        private readonly BTL_LWNC_WebAmNhacContext _context;

        public Sidebar(BTL_LWNC_WebAmNhacContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            if (_context.Genre != null)
            {
                return View(_context.Genre.ToList());
            }
            else { return View(); }
        }
    }
}
