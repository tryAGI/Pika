/*
order: 10
title: Check Balance
slug: balance

Checks the developer account credit balance.
*/

namespace Pika.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task Example_GetBalance()
    {
        using var client = GetAuthenticatedClient();

        //// Check the developer account balance
        var balance = await client.Developer.GetDeveloperBalanceAsync();

        balance.Should().NotBeNull();
        balance.Currency.Should().NotBeNullOrEmpty();
        Console.WriteLine($"Balance: {balance.Balance} {balance.Currency}");
    }
}
