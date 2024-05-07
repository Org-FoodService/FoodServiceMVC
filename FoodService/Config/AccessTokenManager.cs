public class AccessTokenManager
{
    private static AccessTokenManager? _instance;
    private string? _accessToken;
    private DateTime _expiration;

    private AccessTokenManager() { }

    public static AccessTokenManager Instance => _instance ??= new AccessTokenManager();

    public void SetAccessToken(string accessToken, DateTime expiration)
    {
        _accessToken = accessToken;
        _expiration = expiration;
    }

    public string? GetAccessToken()
    {
        if (DateTime.UtcNow > _expiration)
        {
            ClearAccessToken();
            return null;
        }

        return _accessToken;
    }

    public DateTime GetExpiration()
    {
        return _expiration;
    }

    public void ClearAccessToken()
    {
        _accessToken = null;
        _expiration = DateTime.MinValue;
    }
}
