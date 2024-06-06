/// <summary>
/// Manages the access token used for authentication.
/// </summary>
public class AccessTokenManager
{
    private static AccessTokenManager? _instance;
    private string? _accessToken;
    private DateTime _expiration;
    private List<string>? _roles;

    private AccessTokenManager() { }

    /// <summary>
    /// Gets the singleton instance of AccessTokenManager.
    /// </summary>
    public static AccessTokenManager Instance => _instance ??= new AccessTokenManager();

    /// <summary>
    /// Sets the access token, its expiration time, and the user roles.
    /// </summary>
    /// <param name="accessToken">The access token.</param>
    /// <param name="expiration">The expiration time of the access token.</param>
    /// <param name="roles">The roles of the user.</param>
    public void SetAccessToken(string accessToken, DateTime expiration, List<string>? roles = null)
    {
        _accessToken = accessToken;
        _expiration = expiration;
        _roles = roles;
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
    /// Gets the roles of the user if the token is valid; otherwise, clears them and returns null.
    /// </summary>
    /// <returns>The roles of the user if the token is valid; otherwise, null.</returns>
    public List<string>? GetRoles()
    {
        if (DateTime.UtcNow > _expiration)
        {
            ClearAccessToken();
            return null;
        }

        return _roles;
    }

    /// <summary>
    /// Clears the access token and user roles.
    /// </summary>
    public void ClearAccessToken()
    {
        _accessToken = null;
        _expiration = DateTime.MinValue;
        _roles = null;
    }
}
