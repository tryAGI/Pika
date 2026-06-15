#nullable enable

using System.CommandLine;

namespace Pika.CLI.Commands;

internal static class AvatarApiGroupCommand
{
    public static Command Create()
    {
        var command = new Command(@"avatar", @"Avatar endpoint commands.");
                         command.Subcommands.Add(AvatarGenerateAvatarCommandApiCommand.Create());
        return command;
    }
}