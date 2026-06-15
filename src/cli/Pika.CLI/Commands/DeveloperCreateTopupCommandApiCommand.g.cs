#nullable enable
#pragma warning disable CS0618

using System.CommandLine;

namespace Pika.CLI.Commands;

internal static partial class DeveloperCreateTopupCommandApiCommand
{
    private static Option<string> ProductId { get; } = new(
        name: @"--product-id")
    {
        Description = @"The ID of the top-up product to purchase",
        Required = true,
    };

                    private static string FormatResponse(ParseResult parseResult, global::Pika.TopupResponse value, global::System.Text.Json.Serialization.JsonSerializerContext context, bool truncateLongStrings)
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

                    static partial void CustomizeResponseText(ParseResult parseResult, global::Pika.TopupResponse value, ref string? text);
                    static partial void CustomizeResponseFormatHints(Dictionary<string, CliFormatHint> hints);


    public static Command Create()
    {
        var command = new Command(@"create-topup", @"Create a top-up checkout session
Initiates a credit purchase by creating a checkout session for the specified product.");
                        command.Options.Add(ProductId);


        command.SetAction(async (ParseResult parseResult, CancellationToken cancellationToken) =>
            await CliRuntime.RunAsync(async () =>
            {
                        var productId = parseResult.GetRequiredValue(ProductId);
                using var client = await CliRuntime.CreateClientAsync(parseResult, cancellationToken).ConfigureAwait(false);


                                var response = await client.Developer.CreateTopupAsync(
                                    productId: productId,
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