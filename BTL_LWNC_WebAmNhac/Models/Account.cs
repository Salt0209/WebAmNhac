using BTL_LWNC_WebAmNhac.Data;
using Microsoft.AspNetCore.Mvc;

namespace BTL_LWNC_WebAmNhac.Models
{
    public class Account:ViewComponent
    {
        private readonly BTL_LWNC_WebAmNhacContext _context;

        public Account(BTL_LWNC_WebAmNhacContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
