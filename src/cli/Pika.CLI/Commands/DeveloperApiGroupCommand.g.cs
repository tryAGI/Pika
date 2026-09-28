#nullable enable

using System.CommandLine;

namespace Pika.CLI.Commands;

internal static partial class DeveloperApiGroupCommand
{
    static partial void CustomizeCommand(ref Command command);

    public static Command Create()
    {
        var command = new Command(@"developer", @"Developer endpoint commands.");
                         command.Subcommands.Add(DeveloperCreateTopupCommandApiCommand.Create());
                         command.Subcommands.Add(DeveloperGetDeveloperBalanceCommandApiCommand.Create());
                         command.Subcommands.Add(DeveloperGetTopupProductsCommandApiCommand.Create());
        CustomizeCommand(ref command);
        return command;
    }
}