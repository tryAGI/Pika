# Pika

C# SDK for the [Pika Labs](https://pika.art) PikaStream API -- real-time AI avatars for video meetings, voice cloning, and avatar generation.

## Installation

```bash
dotnet add package TryAGI.Pika
```

### CLI

```bash
dotnet tool install --global Pika.CLI --prerelease
pika api --help
```

## Usage

```csharp
using Pika;

var client = new PikaClient(apiKey);

// Check balance
var balance = await client.GetDeveloperBalanceAsync();
Console.WriteLine($"Balance: {balance.Balance} {balance.Currency}");

// Get session status
var status = await client.GetSessionAsync("session-id");
Console.WriteLine($"Status: {status.Status}");
```

## Auth

Uses `DevKey` authorization scheme:

```
Authorization: DevKey {your-api-key}
```

## License

MIT
