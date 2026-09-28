#nullable enable

using System.CommandLine;

namespace Pika.CLI.Commands;

internal static partial class AvatarApiGroupCommand
{
    static partial void CustomizeCommand(ref Command command);

    public static Command Create()
    {
        var command = new Command(@"avatar", @"Avatar endpoint commands.");
                         command.Subcommands.Add(AvatarGenerateAvatarCommandApiCommand.Create());
        CustomizeCommand(ref command);
        return command;
    }
}