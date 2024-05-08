/// <summary>
/// Manages the access token used for authentication.
/// </summary>
public class AccessTokenManager
{
    private static AccessTokenManager? _instance;
    private string? _accessToken;
    private DateTime _expiration;

    private AccessTokenManager() { }

    /// <summary>
    /// Gets the singleton instance of AccessTokenManager.
    /// </summary>
    public static AccessTokenManager Instance => _instance ??= new AccessTokenManager();

    /// <summary>
    /// Sets the access token and its expiration time.
    /// </summary>
    /// <param name="accessToken">The access token.</param>
    /// <param name="expiration">The expiration time of the access token.</param>
    public void SetAccessToken(string accessToken, DateTime expiration)
    {
        _accessToken = accessToken;
        _expiration = expiration;
    }

    /// <summary>
    /// Gets the access token if it's valid; otherwise, clears it and returns null.
    /// </summary>
    /// <returns>The access token if it's valid; otherwise, null.</returns>
    public string? GetAccessToken()
    {
        if (DateTime.UtcNow > _expiration)
        {
            ClearAccessToken();
            return null;
        }

        return _accessToken;
    }

    /// <summary>
    /// Gets the expiration time of the access token.
    /// </summary>
    /// <returns>The expiration time of the access token.</returns>
    public DateTime GetExpiration()
    {
        return _expiration;
    }

    /// <summary>
    /// Clears the access token.
    /// </summary>
    public void ClearAccessToken()
    {
        _accessToken = null;
        _expiration = DateTime.MinValue;
    }
}
