using FoodService.Models.Entities;
using FoodService.Models.Responses;

namespace FoodService.HttpRequest.Interface
{
    public interface ISiteSettingsHttpRequest
    {
        Task<ResponseCommon<SiteSettings>> GetSiteSettings();
        Task<ResponseCommon<SiteSettings>> UpdateSiteSettings(SiteSettings siteSettings, int id = 1);
    }
}