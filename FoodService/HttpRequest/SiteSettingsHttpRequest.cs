using FoodService.HttpRequest.Interface;
using FoodService.Models.Entities;
using FoodService.Models.Responses;

namespace FoodService.HttpRequest
{
    public class SiteSettingsHttpRequest : BaseHttpRequest<SiteSettingsHttpRequest>, ISiteSettingsHttpRequest
    {
        public SiteSettingsHttpRequest(string baseUrl, ILogger<SiteSettingsHttpRequest> logger) : base(baseUrl, logger)
        {
        }
        public async Task<ResponseCommon<SiteSettings>> GetSiteSettings()
        {
            try
            {
                _logger.LogInformation($"Fetching siteSettings.");
                return await GetAsync<ResponseCommon<SiteSettings>>($"/api/sitesettings");
            }
            catch (Exception ex)
            {
                var errorMessage = $"Error occurred while fetching siteSettings.";
                _logger.LogError(ex, errorMessage);
                return FailedRequest<SiteSettings>(errorMessage, 500);
            }
        }

        /// <summary>
        /// Updates an existing siteSettings.
        /// </summary>
        /// <param name="id">The ID of the siteSettings to update.</param>
        /// <param name="siteSettings">The updated siteSettings data.</param>
        /// <returns>A response containing the updated siteSettings.</returns>
        public async Task<ResponseCommon<SiteSettings>> UpdateSiteSettings(SiteSettings siteSettings, int id = 1)
        {
            try
            {
                _logger.LogInformation($"Updating siteSettings with ID: {id}");
                return await PutAsync<ResponseCommon<SiteSettings>>($"/api/sitesettings/{id}", siteSettings, useCryptoToken: true);
            }
            catch (Exception ex)
            {
                var errorMessage = $"Error occurred while updating siteSettings with ID: {id}.";
                _logger.LogError(ex, errorMessage);
                return FailedRequest<SiteSettings>(errorMessage, 500);
            }
        }
    }
}
