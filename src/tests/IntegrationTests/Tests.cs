namespace Pika.IntegrationTests;

[TestClass]
public partial class Tests
{
    private static PikaClient GetAuthenticatedClient()
    {
        var apiKey =
            Environment.GetEnvironmentVariable("PIKA_API_KEY") is { Length: > 0 } apiKeyValue
                ? apiKeyValue
                : throw new AssertInconclusiveException("PIKA_API_KEY environment variable is not found.");

        var client = new PikaClient(apiKey);

        return client;
    }
}
