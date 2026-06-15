#nullable enable
#pragma warning disable CS0618

using System.CommandLine;

namespace Pika.CLI.Commands;

internal static partial class VoiceCloneVoiceCommandApiCommand
{
    private static Argument<string> NameOption { get; } = new(
        name: @"name")
    {
        Description = @"Name for the cloned voice",
    };

    private static Option<byte[]> Audio { get; } = new(
        name: @"--audio")
    {
        Description = @"Audio sample for voice cloning (binary upload)",
        Required = true,
    };

    private static Option<string> Audioname { get; } = new(
        name: @"--audioname")
    {
        Description = @"Audio sample for voice cloning (binary upload)",
        Required = true,
    };

    private static Option<bool?> NoiseReduction { get; } = CliRuntime.CreateNullableBoolOption(
        name: @"--noise-reduction",
        description: @"Whether to apply noise reduction to the audio sample");
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

                    private static string FormatResponse(ParseResult parseResult, global::Pika.CloneVoiceResponse value, global::System.Text.Json.Serialization.JsonSerializerContext context, bool truncateLongStrings)
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

                    static partial void CustomizeResponseText(ParseResult parseResult, global::Pika.CloneVoiceResponse value, ref string? text);
                    static partial void CustomizeResponseFormatHints(Dictionary<string, CliFormatHint> hints);


    public static Command Create()
    {
        var command = new Command(@"clone-voice", @"Clone a voice from audio
Creates a cloned voice from an audio sample. The cloned voice can be used
for avatar speech synthesis in meeting sessions.
");
                        command.Arguments.Add(NameOption);
                        command.Options.Add(Audio);
                        command.Options.Add(Audioname);
                        command.Options.Add(NoiseReduction);
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
                        var __requestBase = await CliRuntime.ReadRequestOrDefaultAsync<global::Pika.CloneVoiceRequest>(
                            parseResult,
                            Input,
                            RequestJson,
                            RequestFile,
                            global::Pika.SourceGenerationContext.Default,
                            cancellationToken).ConfigureAwait(false);
                        var name = parseResult.GetRequiredValue(NameOption);
                        var audio = parseResult.GetRequiredValue(Audio);
                        var audioname = parseResult.GetRequiredValue(Audioname);
                        var noiseReduction = CliRuntime.WasSpecified(parseResult, NoiseReduction) ? parseResult.GetValue(NoiseReduction) : __requestBase is not null ? __requestBase.NoiseReduction : default;
                using var client = await CliRuntime.CreateClientAsync(parseResult, cancellationToken).ConfigureAwait(false);


                                var response = await client.Voice.CloneVoiceAsync(
                                    name: name,
                                    audio: audio,
                                    audioname: audioname,
                                    noiseReduction: noiseReduction,
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