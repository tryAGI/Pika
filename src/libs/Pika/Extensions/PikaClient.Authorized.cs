#nullable enable

namespace Pika;

public sealed partial class PikaClient
{
    /// <summary>
    /// Converts Bearer auth to DevKey auth.
    /// Pika uses "Authorization: DevKey {api_key}" instead of standard Bearer.
    /// </summary>
    partial void Authorized(global::System.Net.Http.HttpClient client)
    {
        var apiKey = Authorizations.FirstOrDefault()?.Value;
        if (apiKey is { Length: > 0 })
        {
            client.DefaultRequestHeaders.Authorization =
                new global::System.Net.Http.Headers.AuthenticationHeaderValue("DevKey", apiKey);
        }
    }
}
