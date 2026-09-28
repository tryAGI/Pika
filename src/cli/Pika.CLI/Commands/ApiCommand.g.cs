#nullable enable

using System.CommandLine;

namespace Pika.CLI.Commands;

internal static partial class ApiCommand
{
    static partial void CustomizeCommand(ref Command command);

    public static Command Create()
    {
        var command = new Command("api", "Generated endpoint commands.");

                         command.Subcommands.Add(AvatarApiGroupCommand.Create());
                         command.Subcommands.Add(DeveloperApiGroupCommand.Create());
                         command.Subcommands.Add(SessionsApiGroupCommand.Create());
                         command.Subcommands.Add(VoiceApiGroupCommand.Create());
        CustomizeCommand(ref command);
        return command;
    }
}