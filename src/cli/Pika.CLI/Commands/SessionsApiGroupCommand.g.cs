#nullable enable

using System.CommandLine;

namespace Pika.CLI.Commands;

internal static partial class SessionsApiGroupCommand
{
    static partial void CustomizeCommand(ref Command command);

    public static Command Create()
    {
        var command = new Command(@"sessions", @"Sessions endpoint commands.");
                         command.Subcommands.Add(SessionsCreateMeetingSessionCommandApiCommand.Create());
                         command.Subcommands.Add(SessionsDeleteSessionCommandApiCommand.Create());
                         command.Subcommands.Add(SessionsGetSessionCommandApiCommand.Create());
        CustomizeCommand(ref command);
        return command;
    }
}