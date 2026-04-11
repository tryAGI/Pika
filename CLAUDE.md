# CLAUDE.md -- Pika SDK

## Overview

Auto-generated C# SDK for [Pika Labs](https://pika.art) PikaStream API -- real-time AI avatars for video meetings, voice cloning, and avatar generation.
Manual OpenAPI spec reverse-engineered from the [Pika-Skills](https://github.com/Pika-Labs/Pika-Skills) Python client.

## Build & Test

```bash
dotnet build Pika.slnx
dotnet test src/tests/IntegrationTests/
```

## Auth

DevKey authorization. Constructor uses Bearer internally, converted via `Authorized` hook:

```
Authorization: DevKey {api_key}
```

```csharp
var client = new PikaClient(apiKey); // PIKA_API_KEY env var
```

## Key Files

- `src/libs/Pika/openapi.yaml` -- Manual OpenAPI 3.0.3 spec (8 endpoints)
- `src/libs/Pika/generate.sh` -- Runs autosdk with Bearer scheme
- `src/libs/Pika/Generated/` -- **Never edit** -- auto-generated code
- `src/libs/Pika/Extensions/PikaClient.Authorized.cs` -- Auth hook (Bearer -> DevKey)
- `src/libs/Pika/Extensions/PikaClient.Tools.cs` -- MEAI `AIFunction` tools
- `src/tests/IntegrationTests/Tests.cs` -- Test helper with API key auth
- `src/tests/IntegrationTests/Examples/` -- Example tests (also generate docs)

## Sub-client Pattern

```csharp
var client = new PikaClient(apiKey);

// Developer -- billing and credits
client.Developer.GetDeveloperBalanceAsync()     // Check credit balance
client.Developer.GetTopupProductsAsync()        // List top-up products
client.Developer.CreateTopupAsync(request)      // Create checkout session

// Sessions -- meeting avatar management
client.Sessions.CreateMeetingSessionAsync(...)  // Join meeting with avatar
client.Sessions.GetSessionAsync(sessionId)      // Get session status
client.Sessions.DeleteSessionAsync(sessionId)   // Leave meeting

// Voice -- voice cloning
client.Voice.CloneVoiceAsync(request)           // Clone voice from audio

// Avatar -- image generation
client.Avatar.GenerateAvatarAsync(prompt, model) // Generate avatar image
```

## MEAI AIFunction Tools

| Tool | Method | Description |
|------|--------|-------------|
| `AsGetBalanceTool()` | Developer | Check account credit balance |
| `AsJoinMeetingTool()` | Sessions | Join Google Meet/Zoom with avatar |
| `AsGetSessionStatusTool()` | Sessions | Get meeting session status |
| `AsLeaveMeetingTool()` | Sessions | Leave a meeting session |
| `AsGenerateAvatarTool()` | Avatar | Generate avatar image from prompt |

## Spec Notes

- Base URL: `https://api.pika.art` (primary), `https://srkibaanghvsriahb.pika.art/proxy/realtime` (proxy)
- Manual spec: Reverse-engineered from Pika-Skills Python client
- Auth: `DevKey` prefix -- `--security-scheme Http:Header:Bearer` for constructor, `Authorized` hook rewrites to DevKey
- Meeting sessions use multipart/form-data with binary image upload
- Voice cloning uses multipart/form-data with binary audio upload
- Platforms: `google_meet`, `zoom`
- Session statuses: `created`, `pending`, `ready`, `error`, `closed`

## Endpoints

| Endpoint | Method | Tag | Description |
|----------|--------|-----|-------------|
| `/developer/balance` | GET | Developer | Get credit balance |
| `/developer/topup/products` | GET | Developer | List top-up products |
| `/developer/topup` | POST | Developer | Create checkout session |
| `/meeting-session` | POST | Sessions | Join meeting with avatar |
| `/session/{session_id}` | GET | Sessions | Get session status |
| `/session/{session_id}` | DELETE | Sessions | Leave meeting |
| `/voice/clone` | POST | Voice | Clone voice from audio |
| `/avatar/generate` | POST | Avatar | Generate avatar image |
