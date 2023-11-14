using Microsoft.AspNetCore.Mvc;

namespace BTL_LWNC_WebAmNhac.Models
{
    public class Option:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
