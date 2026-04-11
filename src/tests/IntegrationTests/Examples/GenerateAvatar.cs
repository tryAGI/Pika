/*
order: 30
title: Generate Avatar
slug: generate-avatar

Generates an AI avatar image from a text prompt.
*/

namespace Pika.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task Example_GenerateAvatar()
    {
        using var client = GetAuthenticatedClient();

        //// Generate an avatar image from a text prompt
        var response = await client.Avatar.GenerateAvatarAsync(
            prompt: "A professional-looking person in business attire");

        response.Should().NotBeNull();
        response.Url.Should().NotBeNullOrEmpty();
        Console.WriteLine($"Avatar URL: {response.Url}");
        if (response.RevisedPrompt is { Length: > 0 } revisedPrompt)
        {
            Console.WriteLine($"Revised prompt: {revisedPrompt}");
        }
    }
}
