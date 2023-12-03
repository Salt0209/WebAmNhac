using Microsoft.AspNetCore.Mvc;

namespace BTL_LWNC_WebAmNhac.Models
{
    public class SearchBar:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
