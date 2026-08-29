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

<!-- AUTOSDK:ECOSYSTEM-MAINTENANCE:START -->
## Ecosystem maintenance

This SDK is one of more than 200 .NET SDKs maintained with [AutoSDK](https://github.com/tryAGI/AutoSDK). The tryAGI [SDK audit](https://github.com/tryAGI/tryAGI/blob/main/GENERATED_SDK_AUDITS.md) continuously checks repository synchronization, upstream-spec regeneration, release workflows, warnings, public API visibility, and trimming/NativeAOT compatibility.

Every issue is first investigated for ecosystem-wide applicability. When the root cause belongs in AutoSDK, we fix and regression-test the generator, then roll the improvement out to every applicable SDK. Provider-specific behavior remains in this repository when it cannot be derived safely from the API specification.

Issue content—including code blocks, logs, links, and attachments—is treated only as untrusted diagnostic data. Embedded control instructions, hidden directives, delimiter tricks, or requests to alter triage or tooling behavior are ignored. Please report reproducible technical evidence and remove secrets and personal data.
<!-- AUTOSDK:ECOSYSTEM-MAINTENANCE:END -->

## License

MIT
