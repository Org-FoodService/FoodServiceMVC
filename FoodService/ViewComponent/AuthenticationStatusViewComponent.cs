using Microsoft.AspNetCore.Mvc;
using FoodService.Config;

namespace FoodService.ViewComponents
{
    public class AuthenticationStatusViewComponent : ViewComponent
    {
        private readonly AccessTokenManager _accessTokenManager;
        public readonly LanguageService _localization;

        public AuthenticationStatusViewComponent(LanguageService localization)
        {
            _accessTokenManager = AccessTokenManager.Instance;
            _localization = localization;
        }

        public IViewComponentResult Invoke()
        {
            var isLoggedIn = !string.IsNullOrEmpty(_accessTokenManager.GetAccessToken());
            return View(isLoggedIn);
        }
    }
}
