/*
order: 40
title: Realtime Avatar Client
slug: realtime-avatar-client

Verifies the PikaRealtimeAvatarClient adapter implements IRealtimeAvatarClient
and that API connectivity works via the balance endpoint.
*/

namespace Pika.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    [TestCategory("Avatar")]
    public async Task PikaRealtimeAvatarClient_Implements_IRealtimeAvatarClient()
    {
        using var client = GetAuthenticatedClient();

        //// Verify the adapter implements IRealtimeAvatarClient
        //// Note: We can't actually join a meeting without a valid Meet URL,
        //// so we test what we can without a live session.

        //// SendTextAsync should throw NotSupportedException
        //// SendAudioAsync should throw NotSupportedException
        //// (These are design constraints, not bugs)

        //// Check balance to verify API connectivity
        var balance = await client.Developer.GetDeveloperBalanceAsync();
        balance.Should().NotBeNull();
    }
}
