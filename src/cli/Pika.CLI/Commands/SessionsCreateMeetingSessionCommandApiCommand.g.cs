#nullable enable
#pragma warning disable CS0618

using System.CommandLine;

namespace Pika.CLI.Commands;

internal static partial class SessionsCreateMeetingSessionCommandApiCommand
{
    private static Option<byte[]> Image { get; } = new(
        name: @"--image")
    {
        Description = @"Avatar reference image (binary upload)",
        Required = true,
    };

    private static Option<string> Imagename { get; } = new(
        name: @"--imagename")
    {
        Description = @"Avatar reference image (binary upload)",
        Required = true,
    };

    private static Option<string> VoiceId { get; } = new(
        name: @"--voice-id")
    {
        Description = @"Voice ID for avatar speech synthesis",
        Required = true,
    };

    private static Option<string> MeetUrl { get; } = new(
        name: @"--meet-url")
    {
        Description = @"Meeting URL to join",
        Required = true,
    };

    private static Option<string> BotName { get; } = new(
        name: @"--bot-name")
    {
        Description = @"Display name for the avatar bot in the meeting",
        Required = true,
    };

    private static Option<global::Pika.MeetingPlatform> Platform { get; } = new(
        name: @"--platform")
    {
        Description = @"The video meeting platform",
        Required = true,
    };

    private static Option<string?> MeetingPassword { get; } = new(
        name: @"--meeting-password")
    {
        Description = @"Optional meeting password",
    };

    private static Option<string?> SystemPrompt { get; } = new(
        name: @"--system-prompt")
    {
        Description = @"Optional system prompt to guide avatar behavior",
    };
      private static Option<string?> Input { get; } = new(@"--input")
      {
          Description = "Load request JSON from a file path, '-' for stdin, or an inline JSON object/array string.",
      };

      private static Option<string?> RequestJson { get; } = new(@"--request-json")
      {
          Description = "Request body as JSON.",
          Hidden = true,
      };

      private static Option<string?> RequestFile { get; } = new(@"--request-file")
      {
          Description = "Path to a JSON request file, or '-' for stdin.",
          Hidden = true,
      };

                    private static string FormatResponse(ParseResult parseResult, global::Pika.MeetingSessionResponse value, global::System.Text.Json.Serialization.JsonSerializerContext context, bool truncateLongStrings)
                    {
                        string? text = null;
                        CustomizeResponseText(parseResult, value, ref text);
                        if (!string.IsNullOrWhiteSpace(text))
                        {
                            return text;
                        }

                        var hints = new Dictionary<string, CliFormatHint>(StringComparer.OrdinalIgnoreCase)
                        {
                        };
                        CustomizeResponseFormatHints(hints);
                        return CliRuntime.FormatHumanReadable(value, context, truncateLongStrings, hints);
                    }

                    static partial void CustomizeResponseText(ParseResult parseResult, global::Pika.MeetingSessionResponse value, ref string? text);
                    static partial void CustomizeResponseFormatHints(Dictionary<string, CliFormatHint> hints);


    public static Command Create()
    {
        var command = new Command(@"create-meeting-session", @"Create a meeting session with avatar
Joins a Google Meet or Zoom call with an AI-powered avatar.
Requires a reference image for the avatar appearance, a voice ID for speech synthesis,
and the meeting URL to join.
");
                        command.Options.Add(Image);
                        command.Options.Add(Imagename);
                        command.Options.Add(VoiceId);
                        command.Options.Add(MeetUrl);
                        command.Options.Add(BotName);
                        command.Options.Add(Platform);
                        command.Options.Add(MeetingPassword);
                        command.Options.Add(SystemPrompt);
          command.Options.Add(Input);
          command.Options.Add(RequestJson);
          command.Options.Add(RequestFile);
          command.Validators.Add(result =>
          {
              var hasInput = result.GetResult(Input) is not null;
              var hasRequestJson = result.GetResult(RequestJson) is not null;
              var hasRequestFile = result.GetResult(RequestFile) is not null;
              var specifiedCount = (hasInput ? 1 : 0) + (hasRequestJson ? 1 : 0) + (hasRequestFile ? 1 : 0);
              if (specifiedCount > 1)
              {
                  result.AddError(@"Specify at most one of --input, --request-json, or --request-file.");
              }
          });

        command.SetAction(async (ParseResult parseResult, CancellationToken cancellationToken) =>
            await CliRuntime.RunAsync(async () =>
            {
                        var __requestBase = await CliRuntime.ReadRequestOrDefaultAsync<global::Pika.CreateMeetingSessionRequest>(
                            parseResult,
                            Input,
                            RequestJson,
                            RequestFile,
                            global::Pika.SourceGenerationContext.Default,
                            cancellationToken).ConfigureAwait(false);
                        var image = parseResult.GetRequiredValue(Image);
                        var imagename = parseResult.GetRequiredValue(Imagename);
                        var voiceId = parseResult.GetRequiredValue(VoiceId);
                        var meetUrl = parseResult.GetRequiredValue(MeetUrl);
                        var botName = parseResult.GetRequiredValue(BotName);
                        var platform = parseResult.GetRequiredValue(Platform);
                        var meetingPassword = CliRuntime.WasSpecified(parseResult, MeetingPassword) ? parseResult.GetValue(MeetingPassword) : __requestBase is not null ? __requestBase.MeetingPassword : default;
                        var systemPrompt = CliRuntime.WasSpecified(parseResult, SystemPrompt) ? parseResult.GetValue(SystemPrompt) : __requestBase is not null ? __requestBase.SystemPrompt : default;
                using var client = await CliRuntime.CreateClientAsync(parseResult, cancellationToken).ConfigureAwait(false);


                                var response = await client.Sessions.CreateMeetingSessionAsync(
                                    image: image,
                                    imagename: imagename,
                                    voiceId: voiceId,
                                    meetUrl: meetUrl,
                                    botName: botName,
                                    platform: platform,
                                    meetingPassword: meetingPassword,
                                    systemPrompt: systemPrompt,
                                    cancellationToken: cancellationToken).ConfigureAwait(false);


                                await CliRuntime.WriteResponseAsync(
                                    parseResult,
                                    response,
                                    global::Pika.SourceGenerationContext.Default,
                                    FormatResponse,
                                    cancellationToken).ConfigureAwait(false);
            }, cancellationToken).ConfigureAwait(false));
        return command;
    }
}