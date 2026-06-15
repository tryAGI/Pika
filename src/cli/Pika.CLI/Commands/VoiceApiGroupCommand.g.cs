#nullable enable

using System.CommandLine;

namespace Pika.CLI.Commands;

internal static class VoiceApiGroupCommand
{
    public static Command Create()
    {
        var command = new Command(@"voice", @"Voice endpoint commands.");
                         command.Subcommands.Add(VoiceCloneVoiceCommandApiCommand.Create());
        return command;
    }
}