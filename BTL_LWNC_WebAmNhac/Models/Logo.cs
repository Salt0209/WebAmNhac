using Microsoft.AspNetCore.Mvc;

namespace BTL_LWNC_WebAmNhac.Models
{
    public class Logo:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
