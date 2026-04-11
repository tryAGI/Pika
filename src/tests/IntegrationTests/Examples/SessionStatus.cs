/*
order: 20
title: Get Session Status
slug: session-status

Gets the status of an active meeting session.
*/

namespace Pika.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task Example_GetSessionStatus()
    {
        using var client = GetAuthenticatedClient();

        //// Get the status of a meeting session
        var sessionId =
            Environment.GetEnvironmentVariable("PIKA_SESSION_ID") is { Length: > 0 } sessionValue
                ? sessionValue
                : throw new AssertInconclusiveException("PIKA_SESSION_ID environment variable is not found.");

        var status = await client.Sessions.GetSessionAsync(sessionId);

        status.Should().NotBeNull();
        status.SessionId.Should().NotBeNullOrEmpty();
        Console.WriteLine($"Session: {status.SessionId}, Status: {status.Status}");
        Console.WriteLine($"Video Worker: {status.VideoWorkerConnected}");
        Console.WriteLine($"Video: {status.VideoConnected}");
        Console.WriteLine($"Meeting Bot: {status.MeetingBotConnected}");
    }
}
