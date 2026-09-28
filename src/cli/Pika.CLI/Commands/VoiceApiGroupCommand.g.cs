#nullable enable

using System.CommandLine;

namespace Pika.CLI.Commands;

internal static partial class VoiceApiGroupCommand
{
    static partial void CustomizeCommand(ref Command command);

    public static Command Create()
    {
        var command = new Command(@"voice", @"Voice endpoint commands.");
                         command.Subcommands.Add(VoiceCloneVoiceCommandApiCommand.Create());
        CustomizeCommand(ref command);
        return command;
    }
}