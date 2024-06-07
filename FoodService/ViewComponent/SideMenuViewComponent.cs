using Microsoft.AspNetCore.Mvc;

namespace FoodService.ViewComponents
{
    public class SideMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
